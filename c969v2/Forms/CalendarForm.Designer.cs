﻿namespace c969v2.Forms
{
    partial class CalendarForm
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
            this.appointmentsDataGridView = new System.Windows.Forms.DataGridView();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // appointmentsDataGridView
            // 
            this.appointmentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentsDataGridView.Location = new System.Drawing.Point(57, 122);
            this.appointmentsDataGridView.Name = "appointmentsDataGridView";
            this.appointmentsDataGridView.Size = new System.Drawing.Size(351, 184);
            this.appointmentsDataGridView.TabIndex = 0;
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(490, 129);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select a date and appointments on that date will show";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(490, 94);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Go Back";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.backButton_click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
            this.label2.Location = new System.Drawing.Point(49, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 44);
            this.label2.TabIndex = 8;
            this.label2.Text = "Calendar View";
            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.appointmentsDataGridView);
            this.Name = "CalendarForm";
            this.Text = "CalendarForm";
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView appointmentsDataGridView;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
    }
}