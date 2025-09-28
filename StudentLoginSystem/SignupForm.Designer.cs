namespace StudentLoginSystem
{
    partial class SignupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignupForm));
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.showPasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.noAccountLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.verifyEmailButton = new System.Windows.Forms.Button();
            this.signupButton = new System.Windows.Forms.Button();
            this.verifyOtpButton = new System.Windows.Forms.Button();
            this.otpTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(29, 630);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(322, 22);
            this.passwordTextBox.TabIndex = 14;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(26, 608);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(71, 18);
            this.passwordLabel.TabIndex = 12;
            this.passwordLabel.Text = "Password:";
            this.passwordLabel.Click += new System.EventHandler(this.passwordLabel_Click);
            // 
            // showPasswordCheckBox
            // 
            this.showPasswordCheckBox.AutoSize = true;
            this.showPasswordCheckBox.Location = new System.Drawing.Point(29, 713);
            this.showPasswordCheckBox.Name = "showPasswordCheckBox";
            this.showPasswordCheckBox.Size = new System.Drawing.Size(101, 17);
            this.showPasswordCheckBox.TabIndex = 8;
            this.showPasswordCheckBox.Text = "Show password";
            this.showPasswordCheckBox.UseVisualStyleBackColor = true;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginLabel.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLabel.ForeColor = System.Drawing.Color.DimGray;
            this.loginLabel.Location = new System.Drawing.Point(233, 774);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(74, 18);
            this.loginLabel.TabIndex = 7;
            this.loginLabel.Text = "Login here";
            this.loginLabel.Click += new System.EventHandler(this.loginLabel_Click);
            // 
            // noAccountLabel
            // 
            this.noAccountLabel.AutoSize = true;
            this.noAccountLabel.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noAccountLabel.ForeColor = System.Drawing.Color.DimGray;
            this.noAccountLabel.Location = new System.Drawing.Point(72, 774);
            this.noAccountLabel.Name = "noAccountLabel";
            this.noAccountLabel.Size = new System.Drawing.Size(162, 18);
            this.noAccountLabel.TabIndex = 6;
            this.noAccountLabel.Text = "Already have an account?";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.Location = new System.Drawing.Point(29, 488);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(322, 22);
            this.usernameTextBox.TabIndex = 5;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(26, 466);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(72, 18);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Username:";
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(115, 439);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(148, 26);
            this.welcomeLabel.TabIndex = 1;
            this.welcomeLabel.Text = "Create Account";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 436);
            this.panel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Controls.Add(this.verifyEmailButton);
            this.panel1.Controls.Add(this.usernameLabel);
            this.panel1.Controls.Add(this.usernameTextBox);
            this.panel1.Controls.Add(this.signupButton);
            this.panel1.Controls.Add(this.verifyOtpButton);
            this.panel1.Controls.Add(this.otpTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.emailTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.confirmPasswordTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.passwordTextBox);
            this.panel1.Controls.Add(this.passwordLabel);
            this.panel1.Controls.Add(this.showPasswordCheckBox);
            this.panel1.Controls.Add(this.loginLabel);
            this.panel1.Controls.Add(this.noAccountLabel);
            this.panel1.Controls.Add(this.welcomeLabel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 815);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // verifyEmailButton
            // 
            this.verifyEmailButton.BackColor = System.Drawing.Color.Blue;
            this.verifyEmailButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verifyEmailButton.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifyEmailButton.ForeColor = System.Drawing.Color.White;
            this.verifyEmailButton.Location = new System.Drawing.Point(236, 533);
            this.verifyEmailButton.Name = "verifyEmailButton";
            this.verifyEmailButton.Size = new System.Drawing.Size(115, 29);
            this.verifyEmailButton.TabIndex = 23;
            this.verifyEmailButton.Text = "VERIFY EMAIL";
            this.verifyEmailButton.UseVisualStyleBackColor = false;
            this.verifyEmailButton.Click += new System.EventHandler(this.verifyEmailButton_Click);
            // 
            // signupButton
            // 
            this.signupButton.BackColor = System.Drawing.Color.Blue;
            this.signupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signupButton.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signupButton.ForeColor = System.Drawing.Color.White;
            this.signupButton.Location = new System.Drawing.Point(149, 742);
            this.signupButton.Name = "signupButton";
            this.signupButton.Size = new System.Drawing.Size(85, 29);
            this.signupButton.TabIndex = 22;
            this.signupButton.Text = "SIGNUP";
            this.signupButton.UseVisualStyleBackColor = false;
            this.signupButton.Click += new System.EventHandler(this.signupButton_Click);
            // 
            // verifyOtpButton
            // 
            this.verifyOtpButton.BackColor = System.Drawing.Color.Blue;
            this.verifyOtpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verifyOtpButton.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifyOtpButton.ForeColor = System.Drawing.Color.White;
            this.verifyOtpButton.Location = new System.Drawing.Point(236, 582);
            this.verifyOtpButton.Name = "verifyOtpButton";
            this.verifyOtpButton.Size = new System.Drawing.Size(115, 29);
            this.verifyOtpButton.TabIndex = 21;
            this.verifyOtpButton.Text = "VERIFY OTP";
            this.verifyOtpButton.UseVisualStyleBackColor = false;
            this.verifyOtpButton.Click += new System.EventHandler(this.verifyOtpButton_Click);
            // 
            // otpTextBox
            // 
            this.otpTextBox.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otpTextBox.Location = new System.Drawing.Point(29, 586);
            this.otpTextBox.Name = "otpTextBox";
            this.otpTextBox.Size = new System.Drawing.Size(201, 22);
            this.otpTextBox.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 564);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "Enter OTP";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextBox.Location = new System.Drawing.Point(29, 537);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(201, 22);
            this.emailTextBox.TabIndex = 18;
            this.emailTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 515);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Email Address:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(29, 678);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(322, 22);
            this.confirmPasswordTextBox.TabIndex = 16;
            this.confirmPasswordTextBox.UseSystemPasswordChar = true;
            this.confirmPasswordTextBox.TextChanged += new System.EventHandler(this.confirmPasswordTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 656);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Confirm password:";
            // 
            // SignupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 813);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SignupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignupForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.CheckBox showPasswordCheckBox;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label noAccountLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button verifyOtpButton;
        private System.Windows.Forms.TextBox otpTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button signupButton;
        private System.Windows.Forms.Button verifyEmailButton;
    }
}