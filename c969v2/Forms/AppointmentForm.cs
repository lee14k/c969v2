using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c969v2.Forms
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.AppointmentForm_Load);
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            // Define the start and end times
            TimeSpan startTime = new TimeSpan(9, 0, 0); // 9:00 AM
            TimeSpan endTime = new TimeSpan(17, 0, 0); // 5:00 PM
            TimeSpan interval = new TimeSpan(0, 30, 0); // 30 minutes interval

            // Populate both ComboBoxes
            PopulateTimeComboBox(StartTimeComboBox, startTime, endTime, interval);
            PopulateTimeComboBox(EndTimeComboBox, startTime, endTime, interval);
        }

        private void PopulateTimeComboBox(ComboBox comboBox, TimeSpan startTime, TimeSpan endTime, TimeSpan interval)
        {
            // Loop through the time range and add the time options to the ComboBox
            for (TimeSpan time = startTime; time <= endTime; time += interval)
            {
                comboBox.Items.Add(time.ToString(@"hh\:mm"));
            }

            // Optionally, set the default selected item
            comboBox.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}