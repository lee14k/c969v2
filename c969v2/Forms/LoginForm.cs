using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c969v2.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            SetLanguageBasedOnRegion();

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
            // Assuming you have already validated the username and password
            User user = User.GetAllUsers().FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user != null)
            {
                // Call the method to check for upcoming appointments
                CheckForUpcomingAppointments(user.UserId);

                // Proceed to open the main form or dashboard
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                RegionInfo region = RegionInfo.CurrentRegion;
                string errorMessage;

                if (region.TwoLetterISORegionName == "FR")
                {
                    errorMessage = "Nom d'utilisateur ou mot de passe invalide.";
                }
                else
                {
                    errorMessage = "Invalid username or password.";
                }

                MessageBox.Show(errorMessage);
            }
        }

        private void CheckForUpcomingAppointments(int userId)
        {
            DateTime currentTime = DateTime.Now;
            DateTime alertTime = currentTime.AddMinutes(15);

            var upcomingAppointments = Appointment.GetAllAppointments()
                .Where(a => a.UserId == userId && a.Start > currentTime && a.Start <= alertTime)
                .ToList();

            if (upcomingAppointments.Any())
            {
                string message = "You have an appointment within the next 15 minutes.";
                MessageBox.Show(message, "Upcoming Appointment Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void usernameEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void passwordEnter_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
