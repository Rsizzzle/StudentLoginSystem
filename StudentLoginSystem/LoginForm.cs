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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            showPasswordCheckBox.CheckedChanged += (s, e) =>
            {
                passwordTextBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
            };
            passwordTextBox.ShortcutsEnabled = false; // Prevent paste

            signupLabel.Click += signupLabel_Click;
            loginButton.Click += loginButton_Click;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            if (DatabaseHelper.IsAccountLocked(username))
            {
                MessageBox.Show("Account is locked due to too many failed attempts. Please reset your password.");
                return;
            }

            if (DatabaseHelper.AuthenticateUser(username, password))
            {
                // TODO: Handle Remember Me logic here if checked
                new StudentDashboardForm(username).Show();
                this.Hide();
            }

            else
            {
                DatabaseHelper.IncrementLoginAttempt(username);
                int attempts = DatabaseHelper.GetLoginAttempts(username);
                if (attempts >= 3)
                {
                    DatabaseHelper.LockAccount(username);
                    MessageBox.Show("Account locked after 3 failed attempts. Reset via email.");
                }
                else
                {
                    MessageBox.Show($"Invalid credentials. {3 - attempts} attempts left.");
                }
            }
        }

        private void signupLabel_Click(object sender, EventArgs e)
        {
            new SignupForm().Show();
            this.Hide();
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
