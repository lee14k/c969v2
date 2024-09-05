using c969v2.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Data;
using System.Linq;

namespace c969v2.Forms
{
    public partial class CalendarForm : Form
    {
        private MainForm _mainForm;
        private List<Appointment> upcomingAppointments;
        private DatabaseConnection dbConnection;

        public CalendarForm(MainForm mainForm)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            LoadUpcomingAppointments();
            PopulateMonthComboBox(); 
            monthCalendar.DateChanged += new DateRangeEventHandler(monthCalendar_DateChanged);
            monthComboBox.SelectedIndexChanged += new EventHandler(monthComboBox_SelectedIndexChanged);
            _mainForm = mainForm;
        }

        private void backButton_click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }

        private void LoadUpcomingAppointments()
        {
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();
                string query = @"SELECT Start, End, Title, Type, appointmentId, customerId, userId  
                                 FROM appointment 
                                 WHERE Start >= @today
                                 ORDER BY Start";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@today", DateTime.Today);

                    using (var reader = command.ExecuteReader())
                    {
                        upcomingAppointments = new List<Appointment>();

                        while (reader.Read())
                        {
                            upcomingAppointments.Add(new Appointment
                            {
                                Start = Convert.ToDateTime(reader["Start"]),
                                End = Convert.ToDateTime(reader["End"]),
                                Title = reader["Title"].ToString(),
                                Type = reader["Type"].ToString(),
                                AppointmentId = Convert.ToInt32(reader["appointmentId"]),
                                CustomerId = Convert.ToInt32(reader["customerId"]),
                                UserId = Convert.ToInt32(reader["userId"])
                            });
                        }
                    }
                }
            }
        }

        private void DisplayAppointmentsForDate(DateTime date)
        {
            var appointmentsForDate = upcomingAppointments
                .Where(a => a.Start.Date == date.Date)
                .OrderBy(a => a.Start)
                .ToList();

            appointmentsDataGridView.DataSource = appointmentsForDate;
        }

        private void DisplayAppointmentsForMonth(int month)
        {
            var appointmentsForMonth = upcomingAppointments
                .Where(a => a.Start.Month == month)
                .OrderBy(a => a.Start)
                .ToList();

            appointmentsDataGridView.DataSource = appointmentsForMonth;
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar.SelectionRange.Start;
            DisplayAppointmentsForDate(selectedDate);
        }

        private void monthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedMonth = monthComboBox.SelectedIndex + 1;
            DisplayAppointmentsForMonth(selectedMonth);
        }

        private void PopulateMonthComboBox()
        {
            var months = System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames
                         .Where(m => !string.IsNullOrEmpty(m)).ToArray();

            monthComboBox.Items.AddRange(months);
        }
    }
}

