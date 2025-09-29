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
    public partial class PasswordManagementForm : Form
    {
        private string username;
        public PasswordManagementForm(string username)
        {
            InitializeComponent();
            this.username = username;
            changePasswordButton.Click += changePasswordButton_Click;
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            string oldPass = oldPasswordTextBox.Text;
            string newPass = newPasswordTextBox.Text;
            string confirmNew = confirmPasswordTextBox.Text;

            if (!DatabaseHelper.AuthenticateUser(username, oldPass))
            {
                MessageBox.Show("Old password is incorrect.");
                return;
            }
            if (!DatabaseHelper.IsPasswordValid(newPass))
            {
                MessageBox.Show("Password requirements not met.");
                return;
            }
            if (oldPass == newPass)
            {
                MessageBox.Show("New password cannot be the same as the old password.");
                return;
            }
            if (newPass != confirmNew)
            {
                MessageBox.Show("New passwords do not match.");
                return;
            }
            if (DatabaseHelper.ChangePassword(username, newPass))
            {
                MessageBox.Show("Password changed successfully. You will be logged out for security. Please log in again.");
                // Close all open forms except LoginForm and show LoginForm
                foreach (Form frm in Application.OpenForms)
                {
                    if (!(frm is LoginForm))
                        frm.Hide();
                }
                new LoginForm().Show();
                // Close this form (PasswordManagementForm)
                this.Close();
                // Optionally, close SettingsForm if open
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm is SettingsForm)
                        frm.Close();
                    else if (frm is StudentDashboardForm)
                        frm.Close();
                }
            }

            else
            {
                MessageBox.Show("Error changing password.");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
