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
        private int userId; // Assuming you have a way to get the userId for the appointment
        private int customerId;
        private DatabaseConnection dbConnection;

        // Constructor for adding or editing an appointment
        public AppointmentForm(int? appointmentId = null)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            isEditMode = appointmentId.HasValue;
            this.appointmentId = appointmentId ?? 0;
            SetFormTitle();
            if (isEditMode)
            {
                LoadAppointmentData();
            }
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

                        customerId = Convert.ToInt32(reader["customerId"]);
                        userId = Convert.ToInt32(reader["userId"]);  // Assuming userId is retrieved and stored
                        CustomerNum.Value = customerId;
                    }
                    else
                    {
                        MessageBox.Show($"Appointment with ID {appointmentId} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = TitleTextBox.Text;
            string description = DescriptionTextBox.Text;
            string location = LocationTextBox.Text;
            string contact = ContactTextBox.Text;
            string type = TypeTextBox.Text;
            string url = URLTextBox.Text;
            DateTime start = StartDateTimePicker.Value;
            DateTime end = EndDateTimePicker.Value;

            // Validate business hours
            if (!IsWithinBusinessHours(start, end))
            {
                MessageBox.Show("Appointments can only be scheduled during business hours (Monday through Friday, 9:00 AM to 5:00 PM Eastern Time).",
                                "Invalid Appointment Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Do not proceed with saving
            }

            // Check for overlapping appointments
            if (IsOverlappingAppointment(start, end, userId))
            {
                MessageBox.Show("The appointment times overlap with an existing appointment.",
                                "Appointment Overlap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Do not proceed with saving
            }

            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();

                    string query;

                    if (isEditMode) // Update existing appointment
                    {
                        query = @"UPDATE appointment SET 
                            title = @title, 
                            description = @description, 
                            location = @location, 
                            contact = @contact, 
                            type = @type, 
                            url = @url, 
                            start = @start, 
                            end = @end 
                          WHERE appointmentId = @appointmentId";
                    }
                    else // Insert new appointment
                    {
                        query = @"INSERT INTO appointment 
                            (customerId, userId, title, description, location, contact, type, url, start, end) 
                          VALUES 
                            (@customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end)";
                    }

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        // Set parameters common to both insert and update
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@location", location);
                        cmd.Parameters.AddWithValue("@contact", contact);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@url", url);
                        cmd.Parameters.AddWithValue("@start", start);
                        cmd.Parameters.AddWithValue("@end", end);

                        if (isEditMode)
                        {
                            cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@customerId", customerId);
                            cmd.Parameters.AddWithValue("@userId", userId);
                        }

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show(isEditMode ? "Appointment updated successfully." : "Appointment added successfully.",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error saving appointment: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsWithinBusinessHours(DateTime start, DateTime end)
        {
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime startEastern = TimeZoneInfo.ConvertTimeFromUtc(start.ToUniversalTime(), easternZone);
            DateTime endEastern = TimeZoneInfo.ConvertTimeFromUtc(end.ToUniversalTime(), easternZone);

            // Check if the start and end times are on a weekday (Monday = 1, ..., Friday = 5)
            if (startEastern.DayOfWeek < DayOfWeek.Monday || startEastern.DayOfWeek > DayOfWeek.Friday ||
                endEastern.DayOfWeek < DayOfWeek.Monday || endEastern.DayOfWeek > DayOfWeek.Friday)
            {
                return false;
            }

            // Check if the times are within business hours (9:00 AM - 5:00 PM)
            DateTime businessStart = DateTime.Today.AddHours(9); // 9:00 AM
            DateTime businessEnd = DateTime.Today.AddHours(17);  // 5:00 PM

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
    }
}


