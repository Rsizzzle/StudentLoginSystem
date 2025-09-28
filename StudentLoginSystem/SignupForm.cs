using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentLoginSystem
{
    public partial class SignupForm : Form
    {
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
            string enteredOtp = otpTextBox.Text.Trim();
            if (enteredOtp == generatedOtp)
            {
                MessageBox.Show("OTP verified! Please set your password.");
                passwordTextBox.Enabled = true;
                confirmPasswordTextBox.Enabled = true;
                signupButton.Enabled = true;
                // Optionally disable email, username, OTP fields now
                emailTextBox.Enabled = false;
                usernameTextBox.Enabled = false;
                verifyEmailButton.Enabled = false;
                otpTextBox.Enabled = false;
                verifyOtpButton.Enabled = false;
            }
            else
            {
                MessageBox.Show("Invalid OTP.");
            }
        }

        private string GenerateSecureOtp()
        {
            var bytes = new byte[4];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
                int value = BitConverter.ToInt32(bytes, 0);
                value = Math.Abs(value % 900000) + 100000; // ensure 6 digits
                return value.ToString();
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
            generatedOtp = new Random().Next(100000, 999999).ToString();

            try
            {
                DatabaseHelper.SendOtpToEmail(email, generatedOtp);
                otpTextBox.Enabled = true;
                verifyOtpButton.Enabled = true;
                MessageBox.Show("OTP sent to your email. Please check your inbox.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send OTP: " + ex.Message);
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
    }
}
