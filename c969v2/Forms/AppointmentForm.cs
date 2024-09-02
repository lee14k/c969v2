using System;
using System.Windows.Forms;

namespace c969v2.Forms
{
    public partial class AppointmentForm : Form
    {
        private bool isEditMode;

        // Constructor for adding a new appointment (default constructor)
        public AppointmentForm()
        {
            InitializeComponent();
            isEditMode = false;
            SetFormTitle();
        }

        // Constructor for editing an existing appointment
        public AppointmentForm(bool editMode)
        {
            InitializeComponent();
            isEditMode = editMode;
            SetFormTitle();
        }

        private void SetFormTitle()
        {
            if (isEditMode)
            {
                MainAppointmentHeadline.Text = "Edit Appointment";
            }
            else
            {
                MainAppointmentHeadline.Text = "Add Appointment";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Event handler logic
        }

        private void EndDateLabel_Click(object sender, EventArgs e)
        {
            // Event handler logic
        }
    }
}


