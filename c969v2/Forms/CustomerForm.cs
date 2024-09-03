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
            string postalCode = postalCodeTextBox.Text.Trim(); 

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

            if (string.IsNullOrEmpty(postalCode))
            {
                MessageBox.Show("Please enter the postal code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Please enter a valid phone number using only digits and dashes.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cityName = cityComboBox.Text.Trim();
            string countryName = countryComboBox.Text.Trim();

            int countryId;
            int cityId;
            int addressId;

            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();

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

                query = "SELECT addressId FROM address WHERE LOWER(address) = LOWER(@address) AND cityId = @cityId AND postalCode = @postalCode AND phone = @phone";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@cityId", cityId);
                    cmd.Parameters.AddWithValue("@postalCode", postalCode);
                    cmd.Parameters.AddWithValue("@phone", phoneNumber);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        addressId = Convert.ToInt32(result);
                    }
                    else
                    {
                        query = @"INSERT INTO address (address, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) 
                          VALUES (@address, @cityId, @postalCode, @phone, NOW(), 'current user', NOW(), 'current user')";
                        using (var insertCmd = new MySqlCommand(query, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@address", address);
                            insertCmd.Parameters.AddWithValue("@cityId", cityId);
                            insertCmd.Parameters.AddWithValue("@postalCode", postalCode);
                            insertCmd.Parameters.AddWithValue("@phone", phoneNumber);
                            insertCmd.ExecuteNonQuery();
                            addressId = (int)insertCmd.LastInsertedId;
                        }
                    }
                }
                if (isEditMode)
                {
                    query = @"UPDATE customer 
                      SET name = @customerName, addressId = @addressId, lastUpdate = NOW(), lastUpdateBy = 'current user' 
                      WHERE customerId = @customerId";
                }
                else
                {
                    query = @"INSERT INTO customer (customerId, name, addressId, createDate, createdBy, lastUpdate, lastUpdateBy) 
                      VALUES (@customerId, @customerName, @addressId, NOW(), 'current user', NOW(), 'current user')";
                }

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    cmd.Parameters.AddWithValue("@customerName", customerName);
                    cmd.Parameters.AddWithValue("@addressId", addressId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Customer and Address have been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^[\d-]{10,20}$");
        }
        private void ValidateTextBox(TextBox textBox, string fieldName, bool isInteger = false, bool isDecimal = false, bool isCustomerId = false) 
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                throw new Exception($"Please fill out the {fieldName}.");
            }

            if (isInteger && !int.TryParse(textBox.Text, out _))
            {
                throw new Exception($"Please enter a valid number for {fieldName}.");
            }

            if (isDecimal && !decimal.TryParse(textBox.Text, out _))
            {
                throw new Exception($"Please enter a valid decimal number for {fieldName}.");
            }

            if (isCustomerId)
            {
                int customerId;
                if (!int.TryParse(textBox.Text, out customerId))
                {
                    throw new Exception($"Please enter a valid number for {fieldName}.");
                }
            }

        }
        private void ValidateNumericUpDown() { }
        private void LoadCustomerData()
        {
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();
                string query = @"SELECT c.customerId, c.customerName, a.address, a.cityId, ci.city, co.country, a.postalCode, a.phone 
                         FROM customer c
                         JOIN address a ON c.addressId = a.addressId
                         JOIN city ci ON a.cityId = ci.cityId
                         JOIN country co ON ci.countryId = co.countryId
                         WHERE c.customerId = @customerId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customerNameTextBox.Text = reader["customerName"].ToString();
                            addressTextBox.Text = reader["address"].ToString();
                            postalCodeTextBox.Text = reader["postalCode"].ToString();
                            phoneNumberTextBox.Text = reader["phone"].ToString();

                            // Select the correct country and city in the ComboBoxes
                            countryComboBox.Text = reader["country"].ToString();
                            cityComboBox.Text = reader["city"].ToString();

                            // Load the cities based on the country
                            int countryId = Convert.ToInt32(reader["cityId"]);
                            LoadCityDropdown(countryId);
                        }
                    }
                }
            }
        }
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


