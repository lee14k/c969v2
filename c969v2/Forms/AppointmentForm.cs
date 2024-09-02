using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using c969v2.Data;
using System.Management;

namespace c969v2.Forms
{
    public partial class AppointmentForm : Form
    {
        private bool isEditMode;
        private int appointmentId;
        private DatabaseConnection dbConnection;

        // Constructor for adding a new appointment
        public AppointmentForm()
        {
            InitializeComponent();
            isEditMode = false;
            dbConnection = new DatabaseConnection();
            SetFormTitle();
        }

        // Constructor for editing an existing appointment
        public AppointmentForm(int appointmentId)
        {
            InitializeComponent();
            isEditMode = true;
            this.appointmentId = appointmentId;
            dbConnection = new DatabaseConnection();
            SetFormTitle();
            LoadAppointmentData();  // Load data when in edit mode
        }

        private void SetFormTitle()
        {
            MainAppointmentHeadline.Text = isEditMode ? "Edit Appointment" : "Add Appointment";
        }

        private void LoadAppointmentData()
        {
            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT customerId, userId, title, description, location, 
                                     contact, type, url, start, end 
                                     FROM appointment 
                                     WHERE appointmentId = @appointmentId";

                    using (var cmd = new MySqlCommand(query, connection))
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
                                CustomerNum.Value = customerId;  // Assuming CustomerNum is a NumericUpDown control
                            }
                            else
                            {
                                MessageBox.Show($"Appointment with ID {appointmentId} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error loading appointment data: {ex.Message}\nAppointment ID: {appointmentId}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unexpected error: {ex.Message}\nAppointment ID: {appointmentId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Gather the input values from the form controls
            string title = TitleTextBox.Text;
            string description = DescriptionTextBox.Text;
            string location = LocationTextBox.Text;
            string contact = ContactTextBox.Text;
            string type = TypeTextBox.Text;
            string url = URLTextBox.Text;
            DateTime start = StartDateTimePicker.Value;
            DateTime end = EndDateTimePicker.Value;
            int customerId = Convert.ToInt32(CustomerNum.Value);

            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();

                    string query = isEditMode
                        ? @"UPDATE appointment SET 
                            title = @title, 
                            description = @description, 
                            location = @location, 
                            contact = @contact, 
                            type = @type, 
                            url = @url, 
                            start = @start, 
                            end = @end 
                          WHERE appointmentId = @appointmentId"
                        : @"INSERT INTO appointment 
                            (customerId, userId, title, description, location, contact, type, url, start, end) 
                          VALUES 
                            (@customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end)";

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
                            // You need to set the userId here as well
                            // cmd.Parameters.AddWithValue("@userId", userId);
                        }

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(isEditMode ? "Appointment updated successfully." : "Appointment added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No changes were made to the database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    this.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error saving appointment: {ex.Message}\nAppointment ID: {appointmentId}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}\nAppointment ID: {appointmentId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


