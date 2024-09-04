using c969v2.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace c969v2.Forms
{
    public partial class ReportsForm : Form
    {
        private DatabaseConnection dbConnection;
        public ReportsForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            dbConnection = new DatabaseConnection();    
        }
        private void backButton_click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }
        private void ReportsForm_Load(object sender, EventArgs e)
        {
            PopulateCustomerComboBox();
            PopulateUserComboBox();
            PopulateMonthComboBox();
        }
        private void PopulateCustomerComboBox()
        {
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT customerId, customerName FROM customer";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var dataTable = new DataTable();
                        dataTable.Load(reader);

                        customerComboBox.DisplayMember = "CustomerName";
                        customerComboBox.ValueMember = "CustomerId";
                        customerComboBox.DataSource = dataTable;
                    }
                }
            }
        }
        private void PopulateUserComboBox()
        {
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT userId, userName FROM user";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var dataTable = new DataTable();
                        dataTable.Load(reader);

                        userComboBox.DisplayMember = "UserName";
                        userComboBox.ValueMember = "UserId";
                        userComboBox.DataSource = dataTable;
                    }
                }
            }
        }
        private void PopulateMonthComboBox()
        {
            var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames.Take(12).ToList();
            monthComboBox.DataSource = months;
        }
        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customerComboBox.SelectedValue != null)
            {
                int selectedCustomerId = Convert.ToInt32(customerComboBox.SelectedValue);
                GetAppointmentsByCustomer(selectedCustomerId);
            }
        }
        private void userComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userComboBox.SelectedValue != null)
            {
                int selectedUserId = Convert.ToInt32(userComboBox.SelectedValue);
                GetUserSchedule(selectedUserId);
            }
        }
        private void monthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (monthComboBox.SelectedValue != null)
            {
                int selectedMonth = monthComboBox.SelectedIndex + 1; // Assuming months are 0-indexed in the ComboBox
                GetAppointmentTypesByMonth(selectedMonth);
            }
        }
        private void GetAppointmentsByCustomer(int customerId)
        {
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();
                string query = @"SELECT Start, End, Title, Type 
                                 FROM appointment 
                                 WHERE customerId = @customerId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customerId", customerId);

                    using (var reader = command.ExecuteReader())
                    {
                        var appointments = new List<Appointment>();

                        while (reader.Read())
                        {
                            appointments.Add(new Appointment
                            {
                                Start = Convert.ToDateTime(reader["Start"]),
                                End = Convert.ToDateTime(reader["End"]),
                                Title = reader["Title"].ToString(),
                                Type = reader["Type"].ToString()
                            });
                        }

                        var customerAppointments = appointments
                            .OrderBy(a => a.Start)
                            .Select(a => new
                            {
                                Date = a.Start.ToShortDateString(),
                                Time = $"{a.Start.ToShortTimeString()} - {a.End.ToShortTimeString()}",
                                Title = a.Title,
                                Type = a.Type,
                            })
                            .ToList();

                        customerAppointmentsDataGridView.DataSource = customerAppointments;
                        customerAppointmentsDataGridView.AutoResizeColumns();

                        int totalAppointments = customerAppointments.Count;
                    }
                }
            }
        }
        private void GetUserSchedule(int userId)
        {
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();
                string query = @"SELECT Start, End, Title, Type 
                         FROM appointment 
                         WHERE userId = @userId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        var userSchedule = new List<Appointment>();

                        while (reader.Read())
                        {
                            userSchedule.Add(new Appointment
                            {
                                Start = Convert.ToDateTime(reader["Start"]),
                                End = Convert.ToDateTime(reader["End"]),
                                Title = reader["Title"].ToString(),
                                Type = reader["Type"].ToString()
                            });
                        }

                        // Order the appointments by start time
                        var orderedSchedule = userSchedule
                            .OrderBy(a => a.Start)
                            .ToList();

                        userScheduleDataGridView.AutoGenerateColumns = false;
                        userScheduleDataGridView.DataSource = orderedSchedule;

                        userScheduleDataGridView.Columns.Clear();
                        userScheduleDataGridView.Columns.Add("Start", "Start Time");
                        userScheduleDataGridView.Columns.Add("End", "End Time");
                        userScheduleDataGridView.Columns.Add("Title", "Title");
                        userScheduleDataGridView.Columns.Add("Type", "Type");

                        userScheduleDataGridView.Columns["Start"].DataPropertyName = "Start";
                        userScheduleDataGridView.Columns["End"].DataPropertyName = "End";
                        userScheduleDataGridView.Columns["Title"].DataPropertyName = "Title";
                        userScheduleDataGridView.Columns["Type"].DataPropertyName = "Type";
                    }
                }
            }
        }
        private void GetAppointmentTypesByMonth(int month)
        {
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();
                string query = @"SELECT Type 
                         FROM appointment
                         WHERE MONTH(start) = @month";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@month", month);

                    using (var reader = command.ExecuteReader())
                    {
                        var appointmentTypes = new List<string>();

                        while (reader.Read())
                        {
                            appointmentTypes.Add(reader["Type"].ToString());
                        }

                        // Use a lambda expression to group by type and count each type
                        var typeCounts = appointmentTypes
                            .GroupBy(type => type)
                            .Select(group => new { Type = group.Key, Count = group.Count() })
                            .ToList();

                        // Display the results in a DataGridView or other UI component
                        appointmentTypesDataGridView.DataSource = typeCounts;
                    }
                }
            }
        }
    }
}

