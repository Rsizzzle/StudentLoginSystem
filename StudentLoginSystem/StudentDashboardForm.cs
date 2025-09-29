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
    public partial class StudentDashboardForm : Form
    {
        private string username;
        private Timer inactivityTimer;
        public StudentDashboardForm(string username)
        {
            InitializeComponent();
            this.username = username;

            inactivityTimer = new Timer();
            inactivityTimer.Interval = 15 * 60 * 1000; // 15 minutes
            inactivityTimer.Tick += (s, e) => Logout();
            inactivityTimer.Start();

            settingsLabel.Click += settingsLabel_Click;
            logoutButton.Click += logoutButton_Click;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void Logout()
        {
            inactivityTimer.Stop();
            new LoginForm().Show();
            this.Hide();
        }

        private void settingsLabel_Click(object sender, EventArgs e)
        {
            new SettingsForm(username).ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
