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
            this.addressLineTwo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.phoneNumberTextBox.Location = new System.Drawing.Point(125, 152);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(119, 20);
            this.phoneNumberTextBox.TabIndex = 31;
            this.phoneNumberTextBox.TextChanged += new System.EventHandler(this.phoneNumberTextBox_TextChanged);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(123, 180);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(121, 20);
            this.addressTextBox.TabIndex = 32;
            this.addressTextBox.TextChanged += new System.EventHandler(this.addressTextBox_TextChanged);
            // 
            // customerNameTextBox
            // 
            this.customerNameTextBox.Location = new System.Drawing.Point(123, 122);
            this.customerNameTextBox.Name = "customerNameTextBox";
            this.customerNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.customerNameTextBox.TabIndex = 30;
            this.customerNameTextBox.TextChanged += new System.EventHandler(this.customerNameTextBox_TextChanged);
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
            this.SubmitButton.TabIndex = 36;
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
            this.StartTimeLabel.TabIndex = 94;
            this.StartTimeLabel.Text = "Postal Code";
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(41, 235);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(43, 13);
            this.LocationLabel.TabIndex = 93;
            this.LocationLabel.Text = "Country";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(41, 155);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(78, 13);
            this.DescriptionLabel.TabIndex = 31;
            this.DescriptionLabel.Text = "Phone Number";
            this.DescriptionLabel.Click += new System.EventHandler(this.DescriptionLabel_Click);
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(41, 183);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TypeLabel.Size = new System.Drawing.Size(45, 13);
            this.TypeLabel.TabIndex = 91;
            this.TypeLabel.Text = "Address";
            this.TypeLabel.Click += new System.EventHandler(this.TypeLabel_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(41, 129);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(35, 13);
            this.TitleLabel.TabIndex = 29;
            this.TitleLabel.Text = "Name";
            this.TitleLabel.Click += new System.EventHandler(this.TitleLabel_Click);
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(41, 98);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(18, 13);
            this.IDLabel.TabIndex = 28;
            this.IDLabel.Text = "ID";
            this.IDLabel.Click += new System.EventHandler(this.IDLabel_Click);
            // 
            // cityComboBox
            // 
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(126, 258);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(121, 21);
            this.cityComboBox.TabIndex = 34;
            // 
            // City
            // 
            this.City.AutoSize = true;
            this.City.Location = new System.Drawing.Point(44, 261);
            this.City.Name = "City";
            this.City.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.City.Size = new System.Drawing.Size(24, 13);
            this.City.TabIndex = 57;
            this.City.Text = "City";
            // 
            // IDNum
            // 
            this.IDNum.Location = new System.Drawing.Point(123, 96);
            this.IDNum.Name = "IDNum";
            this.IDNum.ReadOnly = true;
            this.IDNum.Size = new System.Drawing.Size(120, 20);
            this.IDNum.TabIndex = 58;
            this.IDNum.ValueChanged += new System.EventHandler(this.IDNum_ValueChanged);
            // 
            // countryComboBox
            // 
            this.countryComboBox.FormattingEnabled = true;
            this.countryComboBox.Location = new System.Drawing.Point(123, 231);
            this.countryComboBox.Name = "countryComboBox";
            this.countryComboBox.Size = new System.Drawing.Size(121, 21);
            this.countryComboBox.TabIndex = 33;
            this.countryComboBox.SelectedIndexChanged += new System.EventHandler(this.countryComboBox_SelectedIndexChanged);
            // 
            // postalCodeTextBox
            // 
            this.postalCodeTextBox.Location = new System.Drawing.Point(124, 285);
            this.postalCodeTextBox.Name = "postalCodeTextBox";
            this.postalCodeTextBox.Size = new System.Drawing.Size(121, 20);
            this.postalCodeTextBox.TabIndex = 35;
            // 
            // addressLineTwo
            // 
            this.addressLineTwo.Location = new System.Drawing.Point(122, 206);
            this.addressLineTwo.Name = "addressLineTwo";
            this.addressLineTwo.Size = new System.Drawing.Size(121, 20);
            this.addressLineTwo.TabIndex = 95;
            this.addressLineTwo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 209);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 96;
            this.label1.Text = "Address Line 2";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 369);
            this.Controls.Add(this.addressLineTwo);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.TextBox addressLineTwo;
        private System.Windows.Forms.Label label1;
    }
}