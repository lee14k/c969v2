namespace c969v2.Forms
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
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
            this.appointmentsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add Appointment";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(166, 322);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 42);
            this.button2.TabIndex = 5;
            this.button2.Text = "Edit Appointment";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(272, 322);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 42);
            this.button3.TabIndex = 6;
            this.button3.Text = "Delete Appointment";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(490, 94);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Go Back";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}