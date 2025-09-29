using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace StudentLoginSystem
{
    public partial class SignupForm : Form
    {
        private string pendingEmail = "";
        private string pendingOtp = "";
        private DateTime otpExpiry;
        private string generatedOtp = "";
        public SignupForm()
        {
            InitializeComponent();

            // Initial states
            otpTextBox.Enabled = false;
            passwordTextBox.Enabled = false;
            confirmPasswordTextBox.Enabled = false;
            signupButton.Enabled = false;

            verifyEmailButton.Click += verifyEmailButton_Click;
            verifyOtpButton.Click += verifyOtpButton_Click;
            signupButton.Click += signupButton_Click;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void passwordLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text.Trim();
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            if (!DatabaseHelper.IsPasswordValid(password))
            {
                MessageBox.Show("Password requirements not met.");
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }
            if (DatabaseHelper.RegisterUser(email, username, password))
            {
                MessageBox.Show("Account created successfully! Please log in.");
                new LoginForm().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error creating account. Email or username may already exist.");
            }
        }


        private void verifyOtpButton_Click(object sender, EventArgs e)
        {
            if (otpTextBox.Text.Trim() == pendingOtp && DateTime.Now <= otpExpiry)
            {
                MessageBox.Show("OTP verified! You can now complete registration.");
                signupButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("Invalid or expired OTP.");
                signupButton.Enabled = false;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

     

        private void verifyEmailButton_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text.Trim();
            string username = usernameTextBox.Text.Trim();

            if (!DatabaseHelper.IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }
            if (DatabaseHelper.IsEmailRegistered(email))
            {
                MessageBox.Show("Email already registered.");
                return;
            }
            if (DatabaseHelper.IsUsernameRegistered(username))
            {
                MessageBox.Show("Username already taken.");
                return;
            }

            // Generate 6-digit OTP
            Random rnd = new Random();
            pendingOtp = rnd.Next(100000, 999999).ToString();
            otpExpiry = DateTime.Now.AddMinutes(10);
            pendingEmail = email;

            try
            {
                SendEmailOtp(email, pendingOtp);
                MessageBox.Show("OTP sent. Please check your email.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send OTP: " + ex.Message);
            }
           
        }
        private void SendEmailOtp(string email, string otp)
        {
            string senderEmail = "unitracksti@gmail.com";
            string senderPassword = "mtwk vvzw mbde dzrz"; // Use app password for Gmail

            MailMessage mail = new MailMessage();
            mail.To.Add(emailTextBox.Text.Trim());
            mail.Subject = "Your OTP Code - UniTrack";
            mail.Body = $"Your OTP code is: {otp}. Expires in 10 minutes.";
            mail.From = new MailAddress(senderEmail);

            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }
        private void confirmPasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginLabel_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void otpTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
