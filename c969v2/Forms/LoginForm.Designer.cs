namespace c969v2.Forms
{
    partial class LoginForm
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
            this.loginButton = new System.Windows.Forms.Button();
            this.usernameEnter = new System.Windows.Forms.TextBox();
            this.WelcomeMessage = new System.Windows.Forms.Label();
            this.passwordEnter = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.MainAppHeadline = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(119, 196);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // usernameEnter
            // 
            this.usernameEnter.Location = new System.Drawing.Point(161, 108);
            this.usernameEnter.Name = "usernameEnter";
            this.usernameEnter.Size = new System.Drawing.Size(68, 20);
            this.usernameEnter.TabIndex = 1;
            // 
            // WelcomeMessage
            // 
            this.WelcomeMessage.AutoSize = true;
            this.WelcomeMessage.Location = new System.Drawing.Point(80, 67);
            this.WelcomeMessage.Name = "WelcomeMessage";
            this.WelcomeMessage.Size = new System.Drawing.Size(114, 13);
            this.WelcomeMessage.TabIndex = 2;
            this.WelcomeMessage.Text = "Welcome, please login";
            // 
            // passwordEnter
            // 
            this.passwordEnter.Location = new System.Drawing.Point(161, 152);
            this.passwordEnter.Name = "passwordEnter";
            this.passwordEnter.Size = new System.Drawing.Size(68, 20);
            this.passwordEnter.TabIndex = 3;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(49, 108);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(58, 13);
            this.UsernameLabel.TabIndex = 4;
            this.UsernameLabel.Text = "Username:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(51, 152);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.PasswordLabel.TabIndex = 5;
            this.PasswordLabel.Text = "Password:";
            // 
            // MainAppHeadline
            // 
            this.MainAppHeadline.AutoSize = true;
            this.MainAppHeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.MainAppHeadline.Location = new System.Drawing.Point(13, 21);
            this.MainAppHeadline.Name = "MainAppHeadline";
            this.MainAppHeadline.Size = new System.Drawing.Size(277, 29);
            this.MainAppHeadline.TabIndex = 6;
            this.MainAppHeadline.Text = "Appointment Scheduler";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 278);
            this.Controls.Add(this.MainAppHeadline);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.passwordEnter);
            this.Controls.Add(this.WelcomeMessage);
            this.Controls.Add(this.usernameEnter);
            this.Controls.Add(this.loginButton);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox usernameEnter;
        private System.Windows.Forms.Label WelcomeMessage;
        private System.Windows.Forms.TextBox passwordEnter;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label MainAppHeadline;
    }
}