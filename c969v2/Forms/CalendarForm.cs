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
        private List<Appointment> upcomingAppointments;
        private DatabaseConnection dbConnection;

        public CalendarForm()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            LoadUpcomingAppointments();
            monthCalendar.DateChanged += new DateRangeEventHandler(monthCalendar_DateChanged);
        }

        private void backButton_click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }

        private void LoadUpcomingAppointments()
        {
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();
                string query = @"SELECT Start, End, Title, Type 
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
                                Type = reader["Type"].ToString()
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
        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar.SelectionRange.Start;
            DisplayAppointmentsForDate(selectedDate);
        }
    }
}

