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
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void GetAppointmentsByCustomer(int customerId)
        {
            var customerAppointments = appointmentsList
                .Where(a => a.CustomerId == customerId)
                .OrderBy(a => a.Start)
                .Select(a => new { a.Start, a.End, a.Title })
                .ToList();

            // Bind the filtered list to the DataGridView
            customerAppointmentsDataGridView.DataSource = customerAppointments;
        }


        private void GetUserSchedule(int userId)
        {
            var userSchedule = appointmentsList
                .Where(a => a.UserId == userId)
                .OrderBy(a => a.Start)
                .Select(a => new { a.Start, a.End, a.Title })
                .ToList();

            // Bind the filtered list to the DataGridView
            userScheduleDataGridView.DataSource = userSchedule;
        }



        private void GetAppointmentCountByUserAndMonth(int userId, int month)
        {
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();
                string query = @"SELECT Start 
                         FROM appointments 
                         WHERE UserId = @userId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        var appointments = new List<DateTime>();

                        while (reader.Read())
                        {
                            appointments.Add(Convert.ToDateTime(reader["Start"]));
                        }

                        // Use a lambda expression to count the appointments in the selected month
                        int appointmentCount = appointments
                            .Where(a => a.Month == month)
                            .Count();

                        // Display the count in a message box
                        MessageBox.Show($"Total appointments for user {userId} in month {month}: {appointmentCount}",
                                        "Appointment Count",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }




    }
}
