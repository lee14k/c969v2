﻿namespace c969v2.Forms
{
    partial class MainForm
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
            this.AppointmentData = new System.Windows.Forms.DataGridView();
            this.CustomerData = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SignOutButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ViewReports = new System.Windows.Forms.Button();
            this.timezoneLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerData)).BeginInit();
            this.SuspendLayout();
            // 
            // AppointmentData
            // 
            this.AppointmentData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppointmentData.Location = new System.Drawing.Point(12, 35);
            this.AppointmentData.Name = "AppointmentData";
            this.AppointmentData.RowHeadersWidth = 51;
            this.AppointmentData.Size = new System.Drawing.Size(838, 214);
            this.AppointmentData.TabIndex = 0;
            // 
            // CustomerData
            // 
            this.CustomerData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerData.Location = new System.Drawing.Point(12, 292);
            this.CustomerData.Name = "CustomerData";
            this.CustomerData.RowHeadersWidth = 51;
            this.CustomerData.Size = new System.Drawing.Size(838, 240);
            this.CustomerData.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(862, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add Appointment";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(862, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 42);
            this.button2.TabIndex = 3;
            this.button2.Text = "Edit Appointment";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnEditAppointment_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(862, 292);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 41);
            this.button4.TabIndex = 5;
            this.button4.Text = "Add Customer";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(862, 339);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 41);
            this.button5.TabIndex = 6;
            this.button5.Text = "Edit Customer";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnEditCustomer_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(862, 386);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(90, 41);
            this.button6.TabIndex = 7;
            this.button6.Text = "Delete Customer";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // SignOutButton
            // 
            this.SignOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.SignOutButton.Location = new System.Drawing.Point(1169, 477);
            this.SignOutButton.Name = "SignOutButton";
            this.SignOutButton.Size = new System.Drawing.Size(215, 40);
            this.SignOutButton.TabIndex = 9;
            this.SignOutButton.Text = "Sign Out";
            this.SignOutButton.UseVisualStyleBackColor = true;
            this.SignOutButton.Click += new System.EventHandler(this.SignOutButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Upcoming Appointments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Customers";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(862, 179);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(90, 42);
            this.button7.TabIndex = 12;
            this.button7.Text = "Calendar View";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.OpenCalendar_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(862, 131);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 42);
            this.button3.TabIndex = 4;
            this.button3.Text = "Delete Appointment";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnDeleteAppointment_Click);
            // 
            // ViewReports
            // 
            this.ViewReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.ViewReports.Location = new System.Drawing.Point(1169, 416);
            this.ViewReports.Name = "ViewReports";
            this.ViewReports.Size = new System.Drawing.Size(215, 40);
            this.ViewReports.TabIndex = 13;
            this.ViewReports.Text = "View Reports";
            this.ViewReports.UseVisualStyleBackColor = true;
            this.ViewReports.Click += new System.EventHandler(this.OpenReports_Click);
            // 
            // timezoneLabel
            // 
            this.timezoneLabel.AutoSize = true;
            this.timezoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.timezoneLabel.Location = new System.Drawing.Point(1029, 243);
            this.timezoneLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.timezoneLabel.Name = "timezoneLabel";
            this.timezoneLabel.Size = new System.Drawing.Size(82, 20);
            this.timezoneLabel.TabIndex = 14;
            this.timezoneLabel.Text = "Timezone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(884, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Your timezone is:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 544);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timezoneLabel);
            this.Controls.Add(this.ViewReports);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SignOutButton);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CustomerData);
            this.Controls.Add(this.AppointmentData);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AppointmentData;
        private System.Windows.Forms.DataGridView CustomerData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button SignOutButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button ViewReports;
        private System.Windows.Forms.Label timezoneLabel;
        private System.Windows.Forms.Label label3;
    }
}