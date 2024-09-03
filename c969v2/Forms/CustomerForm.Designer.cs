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
            this.MainCustFormHeadline = new System.Windows.Forms.Label();
            this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.customerNameTextBox = new System.Windows.Forms.TextBox();
            this.AppointmentCancelButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.StartTimeLabel = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.IDLabel = new System.Windows.Forms.Label();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.City = new System.Windows.Forms.Label();
            this.IDNum = new System.Windows.Forms.NumericUpDown();
            this.countryComboBox = new System.Windows.Forms.ComboBox();
            this.postalCodeTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.IDNum)).BeginInit();
            this.SuspendLayout();
            // 
            // MainCustFormHeadline
            // 
            this.MainCustFormHeadline.AutoSize = true;
            this.MainCustFormHeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.6F);
            this.MainCustFormHeadline.Location = new System.Drawing.Point(35, 35);
            this.MainCustFormHeadline.Name = "MainCustFormHeadline";
            this.MainCustFormHeadline.Size = new System.Drawing.Size(267, 40);
            this.MainCustFormHeadline.TabIndex = 55;
            this.MainCustFormHeadline.Text = "Customer Form";
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.Location = new System.Drawing.Point(126, 170);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(119, 20);
            this.phoneNumberTextBox.TabIndex = 46;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(124, 198);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(121, 20);
            this.addressTextBox.TabIndex = 45;
            // 
            // customerNameTextBox
            // 
            this.customerNameTextBox.Location = new System.Drawing.Point(124, 140);
            this.customerNameTextBox.Name = "customerNameTextBox";
            this.customerNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.customerNameTextBox.TabIndex = 44;
            // 
            // AppointmentCancelButton
            // 
            this.AppointmentCancelButton.Location = new System.Drawing.Point(170, 334);
            this.AppointmentCancelButton.Name = "AppointmentCancelButton";
            this.AppointmentCancelButton.Size = new System.Drawing.Size(75, 23);
            this.AppointmentCancelButton.TabIndex = 42;
            this.AppointmentCancelButton.Text = "Cancel";
            this.AppointmentCancelButton.UseVisualStyleBackColor = true;
            this.AppointmentCancelButton.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(45, 334);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 41;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.customerBtnSave_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(368, 386);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 40;
            // 
            // StartTimeLabel
            // 
            this.StartTimeLabel.AutoSize = true;
            this.StartTimeLabel.Location = new System.Drawing.Point(42, 288);
            this.StartTimeLabel.Name = "StartTimeLabel";
            this.StartTimeLabel.Size = new System.Drawing.Size(64, 13);
            this.StartTimeLabel.TabIndex = 34;
            this.StartTimeLabel.Text = "Postal Code";
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(42, 258);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(43, 13);
            this.LocationLabel.TabIndex = 32;
            this.LocationLabel.Text = "Country";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(42, 173);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(78, 13);
            this.DescriptionLabel.TabIndex = 31;
            this.DescriptionLabel.Text = "Phone Number";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(42, 201);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TypeLabel.Size = new System.Drawing.Size(45, 13);
            this.TypeLabel.TabIndex = 30;
            this.TypeLabel.Text = "Address";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(42, 147);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(35, 13);
            this.TitleLabel.TabIndex = 29;
            this.TitleLabel.Text = "Name";
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(42, 116);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(18, 13);
            this.IDLabel.TabIndex = 28;
            this.IDLabel.Text = "ID";
            this.IDLabel.Click += new System.EventHandler(this.IDLabel_Click);
            // 
            // cityComboBox
            // 
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(124, 227);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(121, 21);
            this.cityComboBox.TabIndex = 56;
            // 
            // City
            // 
            this.City.AutoSize = true;
            this.City.Location = new System.Drawing.Point(45, 230);
            this.City.Name = "City";
            this.City.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.City.Size = new System.Drawing.Size(24, 13);
            this.City.TabIndex = 57;
            this.City.Text = "City";
            // 
            // IDNum
            // 
            this.IDNum.Location = new System.Drawing.Point(124, 114);
            this.IDNum.Name = "IDNum";
            this.IDNum.ReadOnly = true;
            this.IDNum.Size = new System.Drawing.Size(120, 20);
            this.IDNum.TabIndex = 58;
            // 
            // countryComboBox
            // 
            this.countryComboBox.FormattingEnabled = true;
            this.countryComboBox.Location = new System.Drawing.Point(124, 258);
            this.countryComboBox.Name = "countryComboBox";
            this.countryComboBox.Size = new System.Drawing.Size(121, 21);
            this.countryComboBox.TabIndex = 59;
            this.countryComboBox.SelectedIndexChanged += new System.EventHandler(this.countryComboBox_SelectedIndexChanged);
            // 
            // postalCodeTextBox
            // 
            this.postalCodeTextBox.Location = new System.Drawing.Point(124, 285);
            this.postalCodeTextBox.Name = "postalCodeTextBox";
            this.postalCodeTextBox.Size = new System.Drawing.Size(121, 20);
            this.postalCodeTextBox.TabIndex = 60;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 369);
            this.Controls.Add(this.postalCodeTextBox);
            this.Controls.Add(this.countryComboBox);
            this.Controls.Add(this.IDNum);
            this.Controls.Add(this.City);
            this.Controls.Add(this.cityComboBox);
            this.Controls.Add(this.MainCustFormHeadline);
            this.Controls.Add(this.phoneNumberTextBox);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.customerNameTextBox);
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
            ((System.ComponentModel.ISupportInitialize)(this.IDNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainCustFormHeadline;
        private System.Windows.Forms.TextBox phoneNumberTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox customerNameTextBox;
        private System.Windows.Forms.Button AppointmentCancelButton;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label StartTimeLabel;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.ComboBox cityComboBox;
        private System.Windows.Forms.Label City;
        private System.Windows.Forms.NumericUpDown IDNum;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.TextBox postalCodeTextBox;
    }
}