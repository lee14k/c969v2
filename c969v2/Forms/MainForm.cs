using System;
using System.Data;
using System.Windows.Forms;
using c969v2.Data;
using MySql.Data.MySqlClient;

namespace c969v2.Forms
{
    public partial class MainForm : Form
    {
        private DatabaseConnection dbConnection;

        public MainForm()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();

            // Load data when the form is initialized
            LoadAppointmentData();
            LoadCustomerData();
        }

        private void LoadAppointmentData()
        {
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT appointmentId, customerId, userId, title, description, 
                                     location, contact, type, url, start, end 
                                     FROM appointment";

                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable appointmentTable = new DataTable();
                        adapter.Fill(appointmentTable);

                        AppointmentData.DataSource = appointmentTable;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error loading appointment data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadCustomerData()
        {
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT customerId, customerName, addressId, active 
                                     FROM customer";

                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable customerTable = new DataTable();
                        adapter.Fill(customerTable);

                        CustomerData.DataSource = customerTable;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error loading customer data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Implement if needed
        }

        // Method to refresh appointment data
        public void RefreshAppointmentData()
        {
            LoadAppointmentData();
        }

        // Method to refresh customer data
        public void RefreshCustomerData()
        {
            LoadCustomerData();
        }



        // Event handler for adding a new appointment
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            var addAppointmentForm = new AppointmentForm(); // Opens form in "Add" mode
            addAppointmentForm.ShowDialog();
            RefreshAppointmentData(); // Refresh data after form is closed
        }

        // Event handler for editing an existing appointment
        private void btnEditAppointment_Click(object sender, EventArgs e)
        {
            if (AppointmentData.SelectedRows.Count > 0)
            {
                // Assuming the first column is the appointmentId
                int selectedAppointmentId = Convert.ToInt32(AppointmentData.SelectedRows[0].Cells[0].Value);

                var editAppointmentForm = new AppointmentForm(true); // Opens form in "Edit" mode
                editAppointmentForm.ShowDialog();
                RefreshAppointmentData(); // Refresh data after form is closed
            }
            else
            {
                MessageBox.Show("Please select an appointment to edit.", "No Appointment Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}


