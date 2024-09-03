using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using c969v2.Data;

namespace c969v2.Forms
{
    public partial class AppointmentForm : Form
    {
        private bool isEditMode;
        private int appointmentId;
        private int userId; 
        private int customerId;
        private DatabaseConnection dbConnection;


        public AppointmentForm(int? appointmentId = null)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            isEditMode = appointmentId.HasValue;
            this.appointmentId = appointmentId ?? 0;
            SetFormTitle();
            LoadCustomersIntoComboBox();
            LoadUsersIntoComboBox();

            if (isEditMode)
            {
                LoadAppointmentData();
            }
            else
            {
                this.appointmentId = GenerateNewAppointmentId();
                IDNum.Value = this.appointmentId;
            }
        }
        private int GenerateNewAppointmentId()
        {
            int newAppointmentId = 0;
            string query = "SELECT MAX(appointmentId) FROM appointment";

            ExecuteQuery(query, cmd =>
            {
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    newAppointmentId = Convert.ToInt32(result) + 1;
                }
            });

            return newAppointmentId;

        }
        private void LoadCustomersIntoComboBox()
        {
            CustomerComboBox.Items.Clear();
            string query = "SELECT customerId FROM customer";
            ExecuteQuery(query, cmd =>
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CustomerComboBox.Items.Add(reader.GetInt32("customerId"));

                    }
                }
            });
        }
        private void LoadUsersIntoComboBox()
        {
            UserComboBox.Items.Clear();
            string query = "SELECT userId FROM user";
            ExecuteQuery(query, cmd =>
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserComboBox.Items.Add(reader.GetInt32("userId"));



        }
                }
            });
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateComboBox(CustomerComboBox, "Customer");
                ValidateComboBox(UserComboBox, "User");
                ValidateTextBox(TitleTextBox, "Title");
                ValidateTextBox(LocationTextBox, "Location");
                ValidateTextBox(ContactTextBox, "Contact");
                ValidateTextBox(TypeTextBox, "Type");

                int customerId=(int)CustomerComboBox.SelectedItem;
                int userId=(int)UserComboBox.SelectedItem;
                string title = TitleTextBox.Text;
                string description = DescriptionTextBox.Text;
                string location = LocationTextBox.Text;
                string contact = ContactTextBox.Text;
                string type = TypeTextBox.Text;
                string url = URLTextBox.Text;
                DateTime start = StartDateTimePicker.Value.ToUniversalTime();
                DateTime end = EndDateTimePicker.Value.ToUniversalTime();

                if (!IsWithinBusinessHours(start, end))
                {
                    MessageBox.Show("Appointments can only be scheduled during business hours (Monday through Friday, 9:00 AM to 5:00 PM Eastern Time).",
                                    "Invalid Appointment Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                if (IsOverlappingAppointment(start, end, userId))
                {
                    MessageBox.Show("The appointment times overlap with an existing appointment.",
                                    "Appointment Overlap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();

                    string query;
                    DateTime currentTimestamp = DateTime.UtcNow;
                    if (isEditMode) 
                    {
                        query = @"UPDATE appointment SET 
                            title = @title, 
                            description = @description, 
                            location = @location, 
                            contact = @contact, 
                            type = @type, 
                            url = @url, 
                            start = @start, 
                            end = @end,
                            lastUpdate=@lastUpdate,
                            lastUpdateBy=@lastUpdateBy
                          WHERE appointmentId = @appointmentId";
                    }
                    else 
                    {
                        query = @"INSERT INTO appointment 
                            (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) 
                          VALUES 
                            (@customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                    }

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@location", location);
                        cmd.Parameters.AddWithValue("@contact", contact);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@url", url);
                        cmd.Parameters.AddWithValue("@start", start);
                        cmd.Parameters.AddWithValue("@end", end);
                        cmd.Parameters.AddWithValue("@lastUpdate", currentTimestamp);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", LoginForm.CurrentUserName);
                        if (isEditMode)
                        {
                            cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@customerId", customerId);
                            cmd.Parameters.AddWithValue("@userId", LoginForm.CurrentUserId);
                            cmd.Parameters.AddWithValue("@createDate", currentTimestamp);
                            cmd.Parameters.AddWithValue("@createdBy", LoginForm.CurrentUserName);

                        }

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show(isEditMode ? "Appointment updated successfully." : "Appointment added successfully.",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ValidateTextBox(TextBox textBox, string fieldName, bool isInteger = false, bool isDecimal = false, bool isCustomerId = false)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                throw new Exception($"Please fill out the {fieldName}.");
            }

            if (isInteger && !int.TryParse(textBox.Text, out _))
            {
                throw new Exception($"Please enter a valid number for {fieldName}.");
            }

            if (isDecimal && !decimal.TryParse(textBox.Text, out _))
            {
                throw new Exception($"Please enter a valid decimal number for {fieldName}.");
            }

            if (isCustomerId)
            {
                int customerId;
                if (!int.TryParse(textBox.Text, out customerId))
                {
                    throw new Exception($"Please enter a valid number for {fieldName}.");
                }

                if (!CustomerIdExists(customerId))
                {
                    throw new Exception($"Customer ID {customerId} does not exist. Please enter a valid customer ID.");
                }
            }
        }
        private void ValidateComboBox(ComboBox comboBox, string fieldName)
        {
            if (comboBox.SelectedItem ==null)
            {
                throw new Exception ($"Please select a {fieldName} ID.");
            }
        }
        private bool CustomerIdExists(int customerId)
        {
            bool exists = false;
            string query = "SELECT COUNT(*) FROM customer WHERE customerId = @customerId";

            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        exists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return exists;
        }
        private void SetFormTitle()
        {
            MainAppointmentHeadline.Text = isEditMode ? "Edit Appointment" : "Add Appointment";
        }
        private void LoadAppointmentData()
        {
            string query = @"SELECT customerId, userId, title, description, location, 
                             contact, type, url, start, end 
                             FROM appointment 
                             WHERE appointmentId = @appointmentId";

            ExecuteQuery(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        IDNum.Value = appointmentId;
                        TitleTextBox.Text = reader["title"].ToString();
                        DescriptionTextBox.Text = reader["description"].ToString();
                        LocationTextBox.Text = reader["location"].ToString();
                        ContactTextBox.Text = reader["contact"].ToString();
                        TypeTextBox.Text = reader["type"].ToString();
                        URLTextBox.Text = reader["url"].ToString();
                        StartDateTimePicker.Value = Convert.ToDateTime(reader["start"]);
                        EndDateTimePicker.Value = Convert.ToDateTime(reader["end"]);

                       int customerId = Convert.ToInt32(reader["customerId"]);
                       int userId = Convert.ToInt32(reader["userId"]);
                        CustomerComboBox.SelectedItem = customerId;
                        UserComboBox.SelectedItem = userId;
                    }
                    else
                    {
                        MessageBox.Show($"Appointment with ID {appointmentId} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            });
        }
        public class ComboBoxItem
        {
            public int Id { get; set; }
            public ComboBoxItem (int id)
            {
                Id = id;
            }
       
        }
        private bool IsWithinBusinessHours(DateTime start, DateTime end)
        {
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime startEastern = TimeZoneInfo.ConvertTimeFromUtc(start.ToUniversalTime(), easternZone);
            DateTime endEastern = TimeZoneInfo.ConvertTimeFromUtc(end.ToUniversalTime(), easternZone);

            if (startEastern.DayOfWeek < DayOfWeek.Monday || startEastern.DayOfWeek > DayOfWeek.Friday ||
                endEastern.DayOfWeek < DayOfWeek.Monday || endEastern.DayOfWeek > DayOfWeek.Friday)
            {
                return false;
            }

            DateTime businessStart = DateTime.Today.AddHours(9);
            DateTime businessEnd = DateTime.Today.AddHours(17); 

            if (startEastern.TimeOfDay < businessStart.TimeOfDay || endEastern.TimeOfDay > businessEnd.TimeOfDay)
            {
                return false;
            }

            return true;
        }
        private bool IsOverlappingAppointment(DateTime start, DateTime end, int userId)
        {
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();
                string query = @"SELECT COUNT(*) FROM appointment 
                                 WHERE userId = @userId 
                                 AND appointmentId != @appointmentId
                                 AND ((@start < end AND @end > start) OR (@start = start AND @end = end))";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);
                    cmd.Parameters.AddWithValue("@appointmentId", isEditMode ? appointmentId : 0);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        private void ExecuteQuery(string query, Action<MySqlCommand> configureCommand)
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        configureCommand(cmd);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}


