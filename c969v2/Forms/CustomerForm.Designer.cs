namespace c969v2.Forms
{
    partial class CustomerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.StartTimeComboBox = new System.Windows.Forms.ComboBox();
            this.LocationTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.TypeTextBox = new System.Windows.Forms.TextBox();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.AppointmentCancelButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.StartTimeLabel = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.IDLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.6F);
            this.label1.Location = new System.Drawing.Point(36, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 52);
            this.label1.TabIndex = 55;
            this.label1.Text = "Customer Form";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // StartTimeComboBox
            // 
            this.StartTimeComboBox.FormattingEnabled = true;
            this.StartTimeComboBox.Location = new System.Drawing.Point(124, 261);
            this.StartTimeComboBox.Name = "StartTimeComboBox";
            this.StartTimeComboBox.Size = new System.Drawing.Size(121, 21);
            this.StartTimeComboBox.TabIndex = 50;
            // 
            // LocationTextBox
            // 
            this.LocationTextBox.Location = new System.Drawing.Point(120, 224);
            this.LocationTextBox.Name = "LocationTextBox";
            this.LocationTextBox.Size = new System.Drawing.Size(100, 20);
            this.LocationTextBox.TabIndex = 47;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(139, 192);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(100, 20);
            this.DescriptionTextBox.TabIndex = 46;
            // 
            // TypeTextBox
            // 
            this.TypeTextBox.Location = new System.Drawing.Point(120, 157);
            this.TypeTextBox.Name = "TypeTextBox";
            this.TypeTextBox.Size = new System.Drawing.Size(100, 20);
            this.TypeTextBox.TabIndex = 45;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(120, 119);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(100, 20);
            this.TitleTextBox.TabIndex = 44;
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(120, 79);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(100, 20);
            this.IDTextBox.TabIndex = 43;
            // 
            // AppointmentCancelButton
            // 
            this.AppointmentCancelButton.Location = new System.Drawing.Point(170, 315);
            this.AppointmentCancelButton.Name = "AppointmentCancelButton";
            this.AppointmentCancelButton.Size = new System.Drawing.Size(75, 23);
            this.AppointmentCancelButton.TabIndex = 42;
            this.AppointmentCancelButton.Text = "Cancel";
            this.AppointmentCancelButton.UseVisualStyleBackColor = true;
            this.AppointmentCancelButton.Click += new System.EventHandler(this.AppointmentCancelButton_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(47, 315);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 41;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(368, 386);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 15);
            this.label13.TabIndex = 40;
            // 
            // StartTimeLabel
            // 
            this.StartTimeLabel.AutoSize = true;
            this.StartTimeLabel.Location = new System.Drawing.Point(42, 261);
            this.StartTimeLabel.Name = "StartTimeLabel";
            this.StartTimeLabel.Size = new System.Drawing.Size(73, 15);
            this.StartTimeLabel.TabIndex = 34;
            this.StartTimeLabel.Text = "Postal Code";
            this.StartTimeLabel.Click += new System.EventHandler(this.StartTimeLabel_Click);
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(42, 224);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(48, 15);
            this.LocationLabel.TabIndex = 32;
            this.LocationLabel.Text = "Country";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(42, 192);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(91, 15);
            this.DescriptionLabel.TabIndex = 31;
            this.DescriptionLabel.Text = "Phone Number";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(42, 157);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TypeLabel.Size = new System.Drawing.Size(51, 15);
            this.TypeLabel.TabIndex = 30;
            this.TypeLabel.Text = "Address";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(45, 122);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(41, 15);
            this.TitleLabel.TabIndex = 29;
            this.TitleLabel.Text = "Name";
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(45, 84);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(19, 15);
            this.IDLabel.TabIndex = 28;
            this.IDLabel.Text = "ID";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 369);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartTimeComboBox);
            this.Controls.Add(this.LocationTextBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.TypeTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.AppointmentCancelButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.StartTimeLabel);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.IDLabel);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox StartTimeComboBox;
        private System.Windows.Forms.TextBox LocationTextBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.TextBox TypeTextBox;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Button AppointmentCancelButton;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label StartTimeLabel;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label IDLabel;
    }
}