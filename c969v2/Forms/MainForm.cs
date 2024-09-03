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

        public void RefreshAppointmentData()
        {
            LoadAppointmentData();
        }

        private void DeleteAppointment (int appointmentId)
        {
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM appointment WHERE appointmentId = @appointmentId";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshAppointmentData();
                        }
                        else
                        {
                            MessageBox.Show("No appointment found with the given ID.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error deleting appointment: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void RefreshCustomerData()
        {
            LoadCustomerData();
        }
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

                var editAppointmentForm = new AppointmentForm(selectedAppointmentId); // Pass appointmentId for "Edit" mode
                editAppointmentForm.ShowDialog();
                RefreshAppointmentData(); // Refresh data after form is closed
            }
            else
            {
                MessageBox.Show("Please select an appointment to edit.", "No Appointment Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDeleteAppointment_Click (object sender, EventArgs e)
        {
            if (AppointmentData.SelectedRows.Count > 0)
            {
                int selectedAppointmentId = Convert.ToInt32(AppointmentData.SelectedRows[0].Cells[0].Value);

                var result = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeleteAppointment(selectedAppointmentId);
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to delete.", "No Appointment Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SignOutButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?", "Confirm Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

    }
}
 


