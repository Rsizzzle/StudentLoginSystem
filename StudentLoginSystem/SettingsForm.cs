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
    public partial class SettingsForm : Form
    {
        private string username;
        public SettingsForm(string username)
        {
            InitializeComponent();

            this.username = username;
            ChangePasswordLabel.Click += ChangePasswordLabel_Click;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChangePasswordLabel_Click(object sender, EventArgs e)
        {
            PasswordManagementForm passwordForm = new PasswordManagementForm(username);
            passwordForm.ShowDialog();
        }
    }
}
