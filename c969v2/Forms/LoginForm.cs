﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public static int CurrentUserId { get; private set; }
        public static string CurrentUserName { get; private set; }
        public LoginForm()
        {
            InitializeComponent();
            SetLanguageBasedOnRegion();
            dbConnection = new DatabaseConnection();
            userTimeZone = TimeZoneInfo.Local;
            Debug.WriteLine(RegionInfo.CurrentRegion);
        }
        public static void SetCurrentUser (int userId, string userName)
        {
            CurrentUserId = userId;
            CurrentUserName = userName;
        }
        public static void ClearCurrentUser ()
        {
            CurrentUserId = 0;
            CurrentUserName = null;
        }
        private void SetLanguageBasedOnRegion()
        {
            RegionInfo currentRegion = RegionInfo.CurrentRegion;
            if (currentRegion.TwoLetterISORegionName == "FR")
            {
                this.Text = "Formulaire de connexion";
                MainAppHeadline.Text = "Planificateur de rendez-vous";
                WelcomeMessage.Text = "Bienvenue, veuillez vous connecter.";
                UsernameLabel.Text = "Nom d'utilisateur";
                PasswordLabel.Text = "Mot de passe";
                loginButton.Text = "Connexion";
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
                        LogLoginHistory(username, loginSuccess);

                        if (loginSuccess)
                        {
                            int userId = Convert.ToInt32(result);
                            SetCurrentUser(userId, username);
                            CheckForUpcomingAppointments(userId);
                            MainForm mainForm = new MainForm();
                            mainForm.FormClosed += (s, args) => 
                            {
                               ClearCurrentUser();
                                this.Close(); 
                            };
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
            DateTime utcNow = DateTime.UtcNow;
            DateTime userLocalTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, userTimeZone); 
            DateTime userAlertTime = userLocalTime.AddMinutes(15);

            using (var connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT c.customerName, a.start 
                             FROM appointment a
                             INNER JOIN customer c ON a.customerId = c.customerId
                             WHERE a.userId = @userId 
                             AND a.start > @currentUtcTime 
                             AND a.start <= @alertUtcTime
                             ORDER BY a.start ASC
                             LIMIT 1";  

                    using (var command = new MySqlCommand(query, connection))
                    {
                        DateTime currentUtcTime = TimeZoneInfo.ConvertTimeToUtc(userLocalTime, userTimeZone);
                        DateTime alertUtcTime = TimeZoneInfo.ConvertTimeToUtc(userAlertTime, userTimeZone);

                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@currentUtcTime", currentUtcTime);
                        command.Parameters.AddWithValue("@alertUtcTime", alertUtcTime);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string customerName = reader.GetString("customerName");
                                DateTime appointmentTime = reader.GetDateTime("start");

                                DateTime appointmentLocalTime = TimeZoneInfo.ConvertTimeFromUtc(appointmentTime, userTimeZone);

                                string message = $"You have a meeting with {customerName} at {appointmentLocalTime:HH:mm}.";
                                MessageBox.Show(message, "Upcoming Appointment Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
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
    }
}