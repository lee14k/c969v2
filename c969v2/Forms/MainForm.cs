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
        private TimeZoneInfo userTimeZone;

        public MainForm()
        {
            SetUserTimeZone();
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            LoadAppointmentData();
            LoadCustomerData();
        }
        private void SetUserTimeZone()
        {
            try
            {
                // Attempt to get the local system timezone
                userTimeZone = TimeZoneInfo.Local;

                // Log successful timezone retrieval
                string tzInfo = $"Timezone set: {userTimeZone.Id}, Display Name: {userTimeZone.DisplayName}";
                MessageBox.Show(tzInfo, "Timezone Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Additional checks
                if (userTimeZone.Id.Contains("Mountain"))
                {
                    MessageBox.Show("Mountain Time detected as expected.", "Timezone Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Expected Mountain Time, but got: {userTimeZone.Id}", "Timezone Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Detailed error logging
                string errorMessage = $"Error setting timezone: {ex.GetType().Name}\n" +
                                      $"Message: {ex.Message}\n" +
                                      $"Stack Trace: {ex.StackTrace}";
                MessageBox.Show(errorMessage, "Timezone Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Attempt to get timezone information through alternative means
                try
                {
                    string timeZoneId = TimeZone.CurrentTimeZone.StandardName;
                    MessageBox.Show($"Alternative timezone method: {timeZoneId}", "Timezone Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception altEx)
                {
                    MessageBox.Show($"Alternative method also failed: {altEx.Message}", "Timezone Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // If unable to get the local timezone, default to UTC
                userTimeZone = TimeZoneInfo.Utc;
                MessageBox.Show("Defaulting to UTC due to error.", "Timezone Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                        foreach (DataRow row in appointmentTable.Rows)
                        {
                            DateTime utcStart = (DateTime)row["start"];
                            DateTime utcEnd = (DateTime)row["end"];

                            DateTime localStart = TimeZoneInfo.ConvertTimeFromUtc(utcStart, userTimeZone);
                            DateTime localEnd = TimeZoneInfo.ConvertTimeFromUtc(utcEnd, userTimeZone);

                            row["start"] = localStart;
                            row["end"] = localEnd;


                        }
                        AppointmentData.DataSource = appointmentTable;
                        AppointmentData.Columns["start"].DefaultCellStyle.Format = "g";
                        AppointmentData.Columns["end"].DefaultCellStyle.Format = "g";

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
            var addAppointmentForm = new AppointmentForm();
            addAppointmentForm.ShowDialog();
            RefreshAppointmentData();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var addCustomerForm = new CustomerForm();
            addCustomerForm.ShowDialog();
            RefreshCustomerData();
        }
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

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (CustomerData.SelectedRows.Count>0)
            {
                int selectedCustomerId = Convert.ToInt32(CustomerData.SelectedRows[0].Cells[0].Value);
                var editCustomerForm = new CustomerForm(selectedCustomerId);
                editCustomerForm.ShowDialog();
                RefreshCustomerData();
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.", "No Customer Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (CustomerData.SelectedRows.Count > 0)
            {
                int selectedCustomerId = Convert.ToInt32(CustomerData.SelectedRows[0].Cells[0].Value);

                var result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeleteCustomer(selectedCustomerId);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "No Customer Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void DeleteCustomer(int customerId)
        {
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM customer WHERE customerId = @customerId";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshAppointmentData();
                        }
                        else
                        {
                            MessageBox.Show("No customer found with the given ID.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error deleting customer: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void OpenReports_Click(object sender, EventArgs e)
        {
            var addReportsForm = new ReportsForm();
            addReportsForm.ShowDialog();
        }

        private void OpenCalendar_Click(object sender, EventArgs e)
        {
            var addCalendarViewForm = new CalendarForm();
            addCalendarViewForm.ShowDialog();
        }

    }
}
 


