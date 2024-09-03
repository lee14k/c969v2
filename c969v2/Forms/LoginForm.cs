using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using c969v2.Data;
using MySql.Data.MySqlClient;

namespace c969v2.Forms
{
    public partial class LoginForm : Form
    {
        private DatabaseConnection dbConnection;
        private TimeZoneInfo userTimeZone;
        public LoginForm()
        {
            InitializeComponent();
            SetLanguageBasedOnRegion();
            dbConnection = new DatabaseConnection();
            userTimeZone = TimeZoneInfo.Local;
        }

        private void SetLanguageBasedOnRegion()
        {
            // Get the current region information
            RegionInfo region = RegionInfo.CurrentRegion;

            // Check if the region is France
            if (region.TwoLetterISORegionName == "FR")
            {
                // Set text to French
                this.Text = "Formulaire de connexion";
                MainAppHeadline.Text = "Planificateur de rendez-vous";
                WelcomeMessage.Text = "Bienvenue, veuillez vous connecter.";
                UsernameLabel.Text = "Nom d'utilisateur";
                PasswordLabel.Text = "Mot de passe";
                loginButton.Text = "Connexion";
            }
            else
            {
                // Set text to English or your default language
                this.Text = "Login Form";
                loginButton.Text = "Login";
            }
        }

        private void ValidateLogin(string username, string password)
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT userId FROM user WHERE username = @username AND password = @password";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        var result = command.ExecuteScalar();
                        bool loginSuccess = result != null;

                        // Log the login attempt
                        LogLoginHistory(username, loginSuccess);

                        if (loginSuccess)
                        {
                            int userId = Convert.ToInt32(result);
                            CheckForUpcomingAppointments(userId);
                            MainForm mainForm = new MainForm();
                            mainForm.FormClosed += (s, args) => this.Close();
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            ShowErrorMessage();
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void LogLoginHistory(string username, bool success)
        {
            try
            {
                string solutionDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string filePath = Path.Combine(solutionDirectory, "login_history.txt");
                string status = success ? "successful" : "unsuccessful";
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Login attempt by '{username}' was {status}{Environment.NewLine}";
                File.AppendAllText(filePath, logEntry);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging login history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }











        private void ShowErrorMessage()
        {
            RegionInfo region = RegionInfo.CurrentRegion;
            string errorMessage = region.TwoLetterISORegionName == "FR"
                ? "Nom d'utilisateur ou mot de passe invalide."
                : "Invalid username or password.";
            MessageBox.Show(errorMessage);
        }

        private void CheckForUpcomingAppointments(int userId)
        {
            DateTime utcNow = DateTime.UtcNow; // Get current UTC time
            DateTime userLocalTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, userTimeZone); // Convert to user's local time
            DateTime userAlertTime = userLocalTime.AddMinutes(15); // Alert time in user's local time

            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT COUNT(*) FROM appointment 
                             WHERE userId = @userId 
                             AND start > @currentUtcTime 
                             AND start <= @alertUtcTime";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        // Convert user local times back to UTC for the database query
                        DateTime currentUtcTime = TimeZoneInfo.ConvertTimeToUtc(userLocalTime, userTimeZone);
                        DateTime alertUtcTime = TimeZoneInfo.ConvertTimeToUtc(userAlertTime, userTimeZone);

                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@currentUtcTime", currentUtcTime);
                        command.Parameters.AddWithValue("@alertUtcTime", alertUtcTime);

                        int appointmentCount = Convert.ToInt32(command.ExecuteScalar());

                        if (appointmentCount > 0)
                        {
                            string message = "You have an appointment within the next 15 minutes.";
                            MessageBox.Show(message, "Upcoming Appointment Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }







        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameEnter.Text;
            string password = passwordEnter.Text;
            ValidateLogin(username, password);
        }

        private void usernameEnter_TextChanged(object sender, EventArgs e)
        {
            // Implement if needed
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Implement if needed
        }

        private void passwordEnter_TextChanged(object sender, EventArgs e)
        {
            // Implement if needed
        }
    }
}