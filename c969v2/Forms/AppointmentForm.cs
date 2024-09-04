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
        private DatabaseConnection dbConnection;
        private TimeZoneInfo easternTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
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

                DateTime startLocal = StartDateTimePicker.Value;
                DateTime endLocal = EndDateTimePicker.Value;

                if (startLocal < DateTime.Now)
                {
                    MessageBox.Show("Appointments cannot be scheduled for dates in the past.", "Invalid Appointment Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;                
                }

                if (!IsWithinBusinessHours(startLocal, endLocal))
                {
                    MessageBox.Show("Appointments can only be scheduled during business hours (Monday through Friday, 9:00 AM to 5:00 PM Eastern Time).",
                                    "Invalid Appointment Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int userId = (int)UserComboBox.SelectedItem;
                if (IsOverlappingAppointment(startLocal, endLocal, userId))
                {
                    MessageBox.Show("The appointment times overlap with an existing appointment for this user.",
                                    "Appointment Overlap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            Appointment appointment = new Appointment
                {
                    AppointmentId = isEditMode ? this.appointmentId : GenerateNewAppointmentId(),
                    CustomerId = (int)CustomerComboBox.SelectedItem,
                    UserId = (int)UserComboBox.SelectedItem,
                    Title = TitleTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Location = LocationTextBox.Text,
                    Contact = ContactTextBox.Text,
                    Type = TypeTextBox.Text,
                    Url = URLTextBox.Text,
                    Start = startLocal.ToUniversalTime(),
                    End = endLocal.ToUniversalTime(),
                    CreateDate = DateTime.UtcNow,
                    CreatedBy = LoginForm.CurrentUserName,
                    LastUpdate = DateTime.UtcNow,
                    LastUpdateBy = LoginForm.CurrentUserName
                };

                appointment.ValidateFields();

                if (!IsWithinBusinessHours(appointment.Start, appointment.End))
                {
                    MessageBox.Show("Appointments can only be scheduled during business hours (Monday through Friday, 9:00 AM to 5:00 PM Eastern Time).",
                                    "Invalid Appointment Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (IsOverlappingAppointment(appointment.Start, appointment.End, appointment.UserId))
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
                            lastUpdate = @lastUpdate,
                            lastUpdateBy = @lastUpdateBy
                          WHERE appointmentId = @appointmentId";
                    }
                    else
                    {
                        query = @"INSERT INTO appointment 
                            (appointmentId, customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) 
                          VALUES 
                            (@appointmentId, @customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                    }

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@appointmentId", appointment.AppointmentId);
                        cmd.Parameters.AddWithValue("@customerId", appointment.CustomerId);
                        cmd.Parameters.AddWithValue("@userId", appointment.UserId);
                        cmd.Parameters.AddWithValue("@title", appointment.Title);
                        cmd.Parameters.AddWithValue("@description", appointment.Description);
                        cmd.Parameters.AddWithValue("@location", appointment.Location);
                        cmd.Parameters.AddWithValue("@contact", appointment.Contact);
                        cmd.Parameters.AddWithValue("@type", appointment.Type);
                        cmd.Parameters.AddWithValue("@url", appointment.Url);
                        cmd.Parameters.AddWithValue("@start", appointment.Start);
                        cmd.Parameters.AddWithValue("@end", appointment.End);
                        cmd.Parameters.AddWithValue("@createDate", appointment.CreateDate);
                        cmd.Parameters.AddWithValue("@createdBy", appointment.CreatedBy);
                        cmd.Parameters.AddWithValue("@lastUpdate", appointment.LastUpdate);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", appointment.LastUpdateBy);

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
                        StartDateTimePicker.Value = TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(reader["start"]), TimeZoneInfo.Local);
                        EndDateTimePicker.Value = TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(reader["end"]), TimeZoneInfo.Local);
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
        private bool IsOverlappingAppointment(DateTime startLocal, DateTime endLocal, int userId)
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
                    cmd.Parameters.AddWithValue("@start", startLocal.ToUniversalTime());
                    cmd.Parameters.AddWithValue("@end", endLocal.ToUniversalTime());
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
        private bool IsWithinBusinessHours(DateTime startLocal, DateTime endLocal)
        {
            DateTime startEastern = TimeZoneInfo.ConvertTime(startLocal, easternTimeZone);
            DateTime endEastern = TimeZoneInfo.ConvertTime(endLocal, easternTimeZone);


            if (startEastern.DayOfWeek < DayOfWeek.Monday || startEastern.DayOfWeek > DayOfWeek.Friday ||
                endEastern.DayOfWeek < DayOfWeek.Monday || endEastern.DayOfWeek > DayOfWeek.Friday)
            {
                return false;
            }

            TimeSpan businessStart = new TimeSpan(9, 0, 0);
            TimeSpan businessEnd = new TimeSpan(17, 0, 0);

            if (startEastern.TimeOfDay < businessStart || endEastern.TimeOfDay > businessEnd)
            {
                return false;
            }

            return true;
        }
    }
}



