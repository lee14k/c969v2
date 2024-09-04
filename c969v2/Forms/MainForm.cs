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
            timezoneLabel.Text = userTimeZone.DisplayName;

        }
        private void SetUserTimeZone()
        {
             userTimeZone = TimeZoneInfo.Local;
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
                int selectedAppointmentId = Convert.ToInt32(AppointmentData.SelectedRows[0].Cells[0].Value);
                var editAppointmentForm = new AppointmentForm(selectedAppointmentId);
                editAppointmentForm.ShowDialog();
                RefreshAppointmentData();
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
        private bool CustomerHasAppointments(int customerId)
        {
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM appointment WHERE customerId = @customerId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    var count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        private void DeleteCustomerAndAppointments(int customerId)
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();

                    string deleteAppointmentsQuery = "DELETE FROM appointment WHERE customerId = @customerId";
                    using (var cmd = new MySqlCommand(deleteAppointmentsQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.ExecuteNonQuery();
                    }

                    string deleteCustomerQuery = "DELETE FROM customer WHERE customerId = @customerId";
                    using (var cmd = new MySqlCommand(deleteCustomerQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Customer and related appointments have been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshCustomerData();
                RefreshAppointmentData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (CustomerData.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(CustomerData.SelectedRows[0].Cells["customerId"].Value);

                if (CustomerHasAppointments(customerId))
                {
                    var result = MessageBox.Show(
                        "This customer has associated appointments. Deleting this customer will also delete all associated appointments. Do you wish to proceed?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        DeleteCustomerAndAppointments(customerId);
                    }
                }
                else
                {
                    var result = MessageBox.Show(
                        "Are you sure you want to delete this customer?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        DeleteCustomer(customerId);
                    }
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
                            RefreshCustomerData();
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
 


