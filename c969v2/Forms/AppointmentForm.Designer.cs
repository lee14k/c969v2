namespace c969v2.Forms
{
    partial class AppointmentForm
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
            this.IDLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.CustomerIDLabel = new System.Windows.Forms.Label();
            this.UserIDLabel = new System.Windows.Forms.Label();
            this.ContactLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.AppointmentCancelButton = new System.Windows.Forms.Button();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.TypeTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.LocationTextBox = new System.Windows.Forms.TextBox();
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CustomerIDTextBox = new System.Windows.Forms.TextBox();
            this.UserIDTextBox = new System.Windows.Forms.TextBox();
            this.ContactTextBox = new System.Windows.Forms.TextBox();
            this.MainAppointmentHeadline = new System.Windows.Forms.Label();
            this.URLLabel = new System.Windows.Forms.Label();
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(32, 89);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(18, 13);
            this.IDLabel.TabIndex = 0;
            this.IDLabel.Text = "ID";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(32, 127);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(27, 13);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Title";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(32, 162);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TypeLabel.Size = new System.Drawing.Size(31, 13);
            this.TypeLabel.TabIndex = 2;
            this.TypeLabel.Text = "Type";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(29, 197);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionLabel.TabIndex = 3;
            this.DescriptionLabel.Text = "Description";
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(29, 229);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(48, 13);
            this.LocationLabel.TabIndex = 4;
            this.LocationLabel.Text = "Location";
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(29, 286);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(102, 13);
            this.StartDateLabel.TabIndex = 5;
            this.StartDateLabel.Text = "Start Date and Time";
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(29, 325);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(99, 13);
            this.EndDateLabel.TabIndex = 7;
            this.EndDateLabel.Text = "End Date and Time";
            this.EndDateLabel.Click += new System.EventHandler(this.EndDateLabel_Click);
            // 
            // CustomerIDLabel
            // 
            this.CustomerIDLabel.AutoSize = true;
            this.CustomerIDLabel.Location = new System.Drawing.Point(29, 390);
            this.CustomerIDLabel.Name = "CustomerIDLabel";
            this.CustomerIDLabel.Size = new System.Drawing.Size(65, 13);
            this.CustomerIDLabel.TabIndex = 9;
            this.CustomerIDLabel.Text = "Customer ID";
            // 
            // UserIDLabel
            // 
            this.UserIDLabel.AutoSize = true;
            this.UserIDLabel.Location = new System.Drawing.Point(29, 423);
            this.UserIDLabel.Name = "UserIDLabel";
            this.UserIDLabel.Size = new System.Drawing.Size(43, 13);
            this.UserIDLabel.TabIndex = 10;
            this.UserIDLabel.Text = "User ID";
            // 
            // ContactLabel
            // 
            this.ContactLabel.AutoSize = true;
            this.ContactLabel.Location = new System.Drawing.Point(29, 456);
            this.ContactLabel.Name = "ContactLabel";
            this.ContactLabel.Size = new System.Drawing.Size(44, 13);
            this.ContactLabel.TabIndex = 11;
            this.ContactLabel.Text = "Contact";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(266, 413);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 12;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(68, 517);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 13;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            // 
            // AppointmentCancelButton
            // 
            this.AppointmentCancelButton.Location = new System.Drawing.Point(191, 517);
            this.AppointmentCancelButton.Name = "AppointmentCancelButton";
            this.AppointmentCancelButton.Size = new System.Drawing.Size(75, 23);
            this.AppointmentCancelButton.TabIndex = 14;
            this.AppointmentCancelButton.Text = "Cancel";
            this.AppointmentCancelButton.UseVisualStyleBackColor = true;
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(107, 84);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(100, 20);
            this.IDTextBox.TabIndex = 15;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(107, 124);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(100, 20);
            this.TitleTextBox.TabIndex = 16;
            // 
            // TypeTextBox
            // 
            this.TypeTextBox.Location = new System.Drawing.Point(107, 162);
            this.TypeTextBox.Name = "TypeTextBox";
            this.TypeTextBox.Size = new System.Drawing.Size(100, 20);
            this.TypeTextBox.TabIndex = 17;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(107, 197);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(100, 20);
            this.DescriptionTextBox.TabIndex = 18;
            // 
            // LocationTextBox
            // 
            this.LocationTextBox.Location = new System.Drawing.Point(107, 229);
            this.LocationTextBox.Name = "LocationTextBox";
            this.LocationTextBox.Size = new System.Drawing.Size(100, 20);
            this.LocationTextBox.TabIndex = 19;
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.StartDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDateTimePicker.Location = new System.Drawing.Point(32, 302);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.StartDateTimePicker.ShowUpDown = true;
            this.StartDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.StartDateTimePicker.TabIndex = 20;
            // 
            // EndDateTimePicker
            // 
            this.EndDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.EndDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDateTimePicker.Location = new System.Drawing.Point(32, 341);
            this.EndDateTimePicker.Name = "EndDateTimePicker";
            this.EndDateTimePicker.ShowUpDown = true;
            this.EndDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.EndDateTimePicker.TabIndex = 21;
            // 
            // CustomerIDTextBox
            // 
            this.CustomerIDTextBox.Location = new System.Drawing.Point(111, 390);
            this.CustomerIDTextBox.Name = "CustomerIDTextBox";
            this.CustomerIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.CustomerIDTextBox.TabIndex = 24;
            // 
            // UserIDTextBox
            // 
            this.UserIDTextBox.Location = new System.Drawing.Point(107, 423);
            this.UserIDTextBox.Name = "UserIDTextBox";
            this.UserIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.UserIDTextBox.TabIndex = 25;
            // 
            // ContactTextBox
            // 
            this.ContactTextBox.Location = new System.Drawing.Point(107, 456);
            this.ContactTextBox.Name = "ContactTextBox";
            this.ContactTextBox.Size = new System.Drawing.Size(100, 20);
            this.ContactTextBox.TabIndex = 26;
            // 
            // MainAppointmentHeadline
            // 
            this.MainAppointmentHeadline.AutoSize = true;
            this.MainAppointmentHeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.6F);
            this.MainAppointmentHeadline.Location = new System.Drawing.Point(-4, 9);
            this.MainAppointmentHeadline.Name = "MainAppointmentHeadline";
            this.MainAppointmentHeadline.Size = new System.Drawing.Size(313, 40);
            this.MainAppointmentHeadline.TabIndex = 27;
            this.MainAppointmentHeadline.Text = "Appointment Form";
            this.MainAppointmentHeadline.Click += new System.EventHandler(this.label1_Click);
            // 
            // URLLabel
            // 
            this.URLLabel.AutoSize = true;
            this.URLLabel.Location = new System.Drawing.Point(29, 258);
            this.URLLabel.Name = "URLLabel";
            this.URLLabel.Size = new System.Drawing.Size(29, 13);
            this.URLLabel.TabIndex = 28;
            this.URLLabel.Text = "URL";
            // 
            // URLTextBox
            // 
            this.URLTextBox.Location = new System.Drawing.Point(107, 258);
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.Size = new System.Drawing.Size(100, 20);
            this.URLTextBox.TabIndex = 29;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 575);
            this.Controls.Add(this.URLTextBox);
            this.Controls.Add(this.URLLabel);
            this.Controls.Add(this.MainAppointmentHeadline);
            this.Controls.Add(this.ContactTextBox);
            this.Controls.Add(this.UserIDTextBox);
            this.Controls.Add(this.CustomerIDTextBox);
            this.Controls.Add(this.EndDateTimePicker);
            this.Controls.Add(this.StartDateTimePicker);
            this.Controls.Add(this.LocationTextBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.TypeTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.AppointmentCancelButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ContactLabel);
            this.Controls.Add(this.UserIDLabel);
            this.Controls.Add(this.CustomerIDLabel);
            this.Controls.Add(this.EndDateLabel);
            this.Controls.Add(this.StartDateLabel);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.IDLabel);
            this.Name = "AppointmentForm";
            this.Text = "AppointmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.Label CustomerIDLabel;
        private System.Windows.Forms.Label UserIDLabel;
        private System.Windows.Forms.Label ContactLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button AppointmentCancelButton;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.TextBox TypeTextBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.TextBox LocationTextBox;
        private System.Windows.Forms.DateTimePicker StartDateTimePicker;
        private System.Windows.Forms.DateTimePicker EndDateTimePicker;
        private System.Windows.Forms.TextBox CustomerIDTextBox;
        private System.Windows.Forms.TextBox UserIDTextBox;
        private System.Windows.Forms.TextBox ContactTextBox;
        private System.Windows.Forms.Label MainAppointmentHeadline;
        private System.Windows.Forms.Label URLLabel;
        private System.Windows.Forms.TextBox URLTextBox;
    }
}