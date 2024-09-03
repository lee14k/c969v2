﻿using c969v2.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c969v2.Forms
{
    public partial class CalendarForm : Form
    {
        private List<Appointment> upcomingAppointments;
        private DatabaseConnection dbConnection;

        public CalendarForm()
        {
            InitializeComponent();
            LoadUpcomingAppointments();
            dbConnection = new DatabaseConnection();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadUpcomingAppointments()
        {
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();
                string query = @"SELECT Start, End, Title, Type 
                             FROM appointments 
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

        // Handle the button click to view appointments for the selected date
        private void viewAppointmentsButton_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar.SelectionStart;
            DisplayAppointmentsForDate(selectedDate);
        }

        // Display appointments for the selected date in the DataGridView
        private void DisplayAppointmentsForDate(DateTime date)
        {
            var appointmentsForDate = upcomingAppointments
                .Where(a => a.Start.Date == date.Date)
                .OrderBy(a => a.Start)
                .ToList();

            appointmentsDataGridView.DataSource = appointmentsForDate;
        }
    }



}
}
