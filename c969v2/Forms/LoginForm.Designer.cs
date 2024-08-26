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
            this.label1 = new System.Windows.Forms.Label();
            this.passwordEnter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labeler = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(246, 205);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // usernameEnter
            // 
            this.usernameEnter.Location = new System.Drawing.Point(253, 114);
            this.usernameEnter.Name = "usernameEnter";
            this.usernameEnter.Size = new System.Drawing.Size(68, 20);
            this.usernameEnter.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome, please login";
            // 
            // passwordEnter
            // 
            this.passwordEnter.Location = new System.Drawing.Point(253, 158);
            this.passwordEnter.Name = "passwordEnter";
            this.passwordEnter.Size = new System.Drawing.Size(68, 20);
            this.passwordEnter.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username:";
            // 
            // labeler
            // 
            this.labeler.AutoSize = true;
            this.labeler.Location = new System.Drawing.Point(178, 161);
            this.labeler.Name = "labeler";
            this.labeler.Size = new System.Drawing.Size(56, 13);
            this.labeler.TabIndex = 5;
            this.labeler.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label4.Location = new System.Drawing.Point(140, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(277, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Appointment Scheduler";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labeler);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordEnter);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordEnter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labeler;
        private System.Windows.Forms.Label label4;
    }
}