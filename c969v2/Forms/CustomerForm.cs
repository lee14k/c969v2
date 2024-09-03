using c969v2.Data;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace c969v2.Forms
{
    public partial class CustomerForm : Form
    {
        private bool isEditMode;
        private int customerId;
        private int userId;
        private DatabaseConnection dbConnection;

        public CustomerForm(int? customerId = null)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            isEditMode = customerId.HasValue;
            this.customerId = customerId ?? 0;
            SetFormTitle();

            // Load the country dropdown when the form initializes
            LoadCountryDropdown();

            if (isEditMode)
            {
                LoadCustomerData();
            }
            else
            {
                this.customerId = GenerateNewCustomerId();
                IDNum.Value = this.customerId;
            }

            // Attach event handler for country selection change
            countryComboBox.SelectedIndexChanged += countryComboBox_SelectedIndexChanged;
        }

        private int GenerateNewCustomerId()
        {
            int newCustomerId = 10;
            string query = "SELECT MAX(customerId) FROM customer";
            ExecuteQuery(query, cmd =>
            {
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    newCustomerId = Convert.ToInt32(result) + 1;
                }
            });

            return newCustomerId;
        }

        private void customerBtnSave_Click(object sender, EventArgs e)
        {
            string customerName = customerNameTextBox.Text.Trim();
            string address = addressTextBox.Text.Trim();
            string phoneNumber = phoneNumberTextBox.Text.Trim();

            // Validate that fields are not empty
            if (string.IsNullOrEmpty(customerName))
            {
                MessageBox.Show("Please enter the customer's name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Please enter the customer's address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Please enter the customer's phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate the phone number format
            if (!IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Please enter a valid phone number using only digits and dashes.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cityName = cityComboBox.Text.Trim();
            string countryName = countryComboBox.Text.Trim();

            int countryId;
            int cityId;

            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();

                // Check if country exists and insert if not
                string query = "SELECT countryId FROM country WHERE LOWER(country) = LOWER(@country)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@country", countryName);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        countryId = Convert.ToInt32(result);
                    }
                    else
                    {
                        query = @"INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) 
                          VALUES (@country, NOW(), 'current user', NOW(), 'current user')";
                        using (var insertCmd = new MySqlCommand(query, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@country", countryName);
                            insertCmd.ExecuteNonQuery();
                            countryId = (int)insertCmd.LastInsertedId;
                        }
                    }
                }

                // Check if city exists and insert if not
                query = "SELECT cityId FROM city WHERE LOWER(city) = LOWER(@city) AND countryId = @countryId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@city", cityName);
                    cmd.Parameters.AddWithValue("@countryId", countryId);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        cityId = Convert.ToInt32(result);
                    }
                    else
                    {
                        query = @"INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) 
                          VALUES (@city, @countryId, NOW(), 'current user', NOW(), 'current user')";
                        using (var insertCmd = new MySqlCommand(query, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@city", cityName);
                            insertCmd.Parameters.AddWithValue("@countryId", countryId);
                            insertCmd.ExecuteNonQuery();
                            cityId = (int)insertCmd.LastInsertedId;
                        }
                    }
                }
            }

            MessageBox.Show("City and Country have been validated and/or created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // This regex allows only digits and dashes, with a total length between 10 and 14 characters
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^[\d-]{10,14}$");
        }

        private void ValidateTextBox() { }
        private void ValidateNumericUpDown() { }
        private void LoadCustomerData() { }
        private void SetFormTitle()
        {
            MainCustFormHeadline.Text = isEditMode ? "Edit Customer" : "Add Customer";
        }

        private void LoadCountryDropdown()
        {
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT countryId, country FROM country";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            countryComboBox.Items.Add(new { Text = reader["country"].ToString(), Value = reader["countryId"].ToString() });
                        }
                    }
                }
            }

            countryComboBox.DisplayMember = "Text";
            countryComboBox.ValueMember = "Value";
        }

        private void LoadCityDropdown(int countryId)
        {
            cityComboBox.Items.Clear();

            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT cityId, city FROM city WHERE countryId = @countryId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@countryId", countryId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cityComboBox.Items.Add(new { Text = reader["city"].ToString(), Value = reader["cityId"].ToString() });
                        }
                    }
                }
            }

            cityComboBox.DisplayMember = "Text";
            cityComboBox.ValueMember = "Value";
        }

        private void ExecuteQuery(string query, Action<MySqlCommand> configureCommmand)
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        configureCommmand(cmd);
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void countryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (countryComboBox.SelectedItem != null)
            {
                int selectedCountryId = int.Parse((countryComboBox.SelectedItem as dynamic).Value);
                LoadCityDropdown(selectedCountryId);
            }
        }
    }
}


