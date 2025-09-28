using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MimeKit;
using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace StudentLoginSystem
{
    public static class DatabaseHelper
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // ---- Gmail API Credentials ----
        private static string clientId = "307718353281-mh02aah88co1thhl7pqguebs1e5drhdq.apps.googleusercontent.com";
        // No client secret needed for desktop apps

        // --- Error logging (optional) ---
        private static void LogError(string msg)
        {
            try { File.AppendAllText("error.log", $"{DateTime.Now}: {msg}{Environment.NewLine}"); } catch { }
        }

        // --------- Email Validation ----------
        public static bool IsValidEmail(string email)
        {
            try { var addr = new MailAddress(email); return true; }
            catch { return false; }
        }

        // --------- Username/Email Checks ----------
        public static bool IsEmailRegistered(string email)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Students WHERE LOWER(Email)=LOWER(@Email)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email.ToLower());
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public static bool IsUsernameRegistered(string username)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Students WHERE LOWER(Username)=LOWER(@Username)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username.ToLower());
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        // --------- Password Logic ----------
        public static bool IsPasswordValid(string pass)
        {
            bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;
            foreach (char c in pass)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else hasSpecial = true;
            }
            return pass.Length >= 8 && hasUpper && hasLower && hasDigit && hasSpecial;
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        // --------- Registration ----------
        public static bool RegisterUser(string email, string username, string password)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string hash = HashPassword(password);
                string sql = "INSERT INTO Students (Email, Username, PasswordHash, IsActive, IsLocked, LoginAttempts, CreatedAt) VALUES (@Email, @Username, @PasswordHash, 1, 0, 0, GETDATE())";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", hash);
                    try { return cmd.ExecuteNonQuery() > 0; }
                    catch (Exception ex) { LogError("RegisterUser: " + ex.Message); return false; }
                }
            }
        }

        // --------- Authentication ----------
        public static bool AuthenticateUser(string username, string password)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT PasswordHash, IsActive, IsLocked FROM Students WHERE LOWER(Username)=LOWER(@Username)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username.ToLower());
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hash = reader.GetString(0);
                            bool isActive = reader.GetBoolean(1);
                            bool isLocked = reader.GetBoolean(2);
                            if (!isActive || isLocked) return false;
                            if (HashPassword(password) == hash)
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        // --------- Account Lockout ----------
        public static bool IsAccountLocked(string username)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT IsLocked FROM Students WHERE LOWER(Username)=LOWER(@Username)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username.ToLower());
                    return (bool?)cmd.ExecuteScalar() ?? false;
                }
            }
        }

        public static int GetLoginAttempts(string username)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT LoginAttempts FROM Students WHERE LOWER(Username)=LOWER(@Username)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username.ToLower());
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public static void IncrementLoginAttempt(string username)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "UPDATE Students SET LoginAttempts = LoginAttempts + 1 WHERE LOWER(Username)=LOWER(@Username)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username.ToLower());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ResetLoginAttempts(string username)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "UPDATE Students SET LoginAttempts = 0 WHERE LOWER(Username)=LOWER(@Username)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username.ToLower());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void LockAccount(string username)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "UPDATE Students SET IsLocked = 1 WHERE LOWER(Username)=LOWER(@Username)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username.ToLower());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // --------- Password Change ----------
        public static bool ChangePassword(string username, string newPassword)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string hash = HashPassword(newPassword);
                string sql = "UPDATE Students SET LastPassword=PasswordHash, PasswordHash=@Hash WHERE LOWER(Username)=LOWER(@Username)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Hash", hash);
                    cmd.Parameters.AddWithValue("@Username", username.ToLower());
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // --------- OTP Logic ----------
        public static string GenerateSecureOtp()
        {
            var bytes = new byte[4];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
                int value = Math.Abs(BitConverter.ToInt32(bytes, 0) % 900000) + 100000;
                return value.ToString();
            }
        }

        public static int GetStudentIdByEmail(string email)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT StudentID FROM Students WHERE LOWER(Email)=LOWER(@Email)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email.ToLower());
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        public static bool CreateAndSendOtp(string email, string otp)
        {
            int studentId = GetStudentIdByEmail(email);
            if (studentId == -1) return false;
            DateTime expiresAt = DateTime.Now.AddMinutes(10);

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO OTP (StudentID, Code, ExpiresAt, IsUsed) VALUES (@StudentID, @Code, @ExpiresAt, 0)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@Code", otp);
                    cmd.Parameters.AddWithValue("@ExpiresAt", expiresAt);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        // Send OTP via Gmail API
                        SendOtpToEmail(email, otp).Wait();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        LogError("CreateAndSendOtp: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public static bool VerifyOtp(string email, string enteredOtp)
        {
            int studentId = GetStudentIdByEmail(email);
            if (studentId == -1) return false;

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT OTPID, ExpiresAt, IsUsed FROM OTP WHERE StudentID=@StudentID AND Code=@Code ORDER BY ExpiresAt DESC";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@Code", enteredOtp);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int otpId = reader.GetInt32(0);
                            DateTime expiresAt = reader.GetDateTime(1);
                            bool isUsed = reader.GetBoolean(2);

                            if (isUsed || DateTime.Now > expiresAt) return false;

                            reader.Close();
                            using (var cmd2 = new SqlCommand("UPDATE OTP SET IsUsed=1 WHERE OTPID=@OTPID", conn))
                            {
                                cmd2.Parameters.AddWithValue("@OTPID", otpId);
                                cmd2.ExecuteNonQuery();
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // --------- Gmail API OTP ---------
        public static async Task SendOtpToEmail(string email, string otp)
        {
            var secrets = new ClientSecrets
            {
                ClientId = clientId
                // No client secret for desktop apps
            };

            UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                secrets,
                new[] { GmailService.Scope.GmailSend },
                "user",
                CancellationToken.None,
                new FileDataStore("Gmail.Api.Auth.Store")
            );

            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "StudentLoginSystem"
            });

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Student Portal", "your_gmail@gmail.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Your OTP Code";
            message.Body = new TextPart("plain") { Text = $"Your OTP code is: {otp}" };

            using (var ms = new MemoryStream())
            {
                message.WriteTo(ms);
                var rawMessage = Convert.ToBase64String(ms.ToArray())
                    .Replace('+', '-').Replace('/', '_').Replace("=", "");

                var gmailMessage = new Message { Raw = rawMessage };
                await service.Users.Messages.Send(gmailMessage, "me").ExecuteAsync();
            }
        }
    }
}