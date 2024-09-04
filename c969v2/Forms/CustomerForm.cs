
using c969v2.Data;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using c969v2.Models;

namespace c969v2.Forms
{
    public partial class CustomerForm : Form
    {
        private bool isEditMode;
        private int customerId;
        private int addressId;
        private DatabaseConnection dbConnection;
        public CustomerForm(int? customerId = null)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            isEditMode = customerId.HasValue;
            this.customerId = customerId ?? 0;
            SetFormTitle();
            LoadCountryDropdown();

            if (isEditMode)
            {
                LoadCustomerData();
            }
            else
            {
                this.customerId = GenerateNewCustomerId();
                this.addressId = GenerateNewAddressId();
                IDNum.Value = this.customerId;
            }

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
        private int GenerateNewAddressId()
        {
            int newAddressId = 10;
            string query = "SELECT MAX(addressId) FROM address";
            ExecuteQuery(query, cmd =>
            {
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    newAddressId = Convert.ToInt32(result) + 1;
                }
            });

            return newAddressId;
        }
        private void customerBtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string countryName = countryComboBox.Text.Trim();
                string cityName = cityComboBox.Text.Trim();

                int cityId = GetCityId(cityName, countryName);

                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            int addressId;

                            // Handle address first
                            if (isEditMode)
                            {
                                // Update existing address
                                string addressQuery = @"UPDATE address 
                                                SET address = @address, 
                                                    address2 = @address2, 
                                                    cityId = @cityId, 
                                                    postalCode = @postalCode, 
                                                    phone = @phone, 
                                                    lastUpdate = NOW(), 
                                                    lastUpdateBy = @lastUpdateBy
                                                WHERE addressId = @addressId";

                                using (var cmd = new MySqlCommand(addressQuery, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@addressId", this.addressId);
                                    cmd.Parameters.AddWithValue("@address", addressTextBox.Text.Trim());
                                    cmd.Parameters.AddWithValue("@address2", addressLineTwo.Text.Trim());
                                    cmd.Parameters.AddWithValue("@cityId", cityId);
                                    cmd.Parameters.AddWithValue("@postalCode", postalCodeTextBox.Text.Trim());
                                    cmd.Parameters.AddWithValue("@phone", phoneNumberTextBox.Text.Trim());
                                    cmd.Parameters.AddWithValue("@lastUpdateBy", LoginForm.CurrentUserName);

                                    int rowsAffected = cmd.ExecuteNonQuery();
                                    if (rowsAffected == 0)
                                    {
                                        throw new Exception("No address record found to update. Please check the address ID.");
                                    }
                                }
                                addressId = this.addressId;
                            }
                            else
                            {
                                // Insert new address
                                string addressQuery = @"INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) 
                                                VALUES (@address, @address2, @cityId, @postalCode, @phone, NOW(), @createdBy, NOW(), @lastUpdateBy);
                                                SELECT LAST_INSERT_ID();";

                                using (var cmd = new MySqlCommand(addressQuery, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@address", addressTextBox.Text.Trim());
                                    cmd.Parameters.AddWithValue("@address2", addressLineTwo.Text.Trim());
                                    cmd.Parameters.AddWithValue("@cityId", cityId);
                                    cmd.Parameters.AddWithValue("@postalCode", postalCodeTextBox.Text.Trim());
                                    cmd.Parameters.AddWithValue("@phone", phoneNumberTextBox.Text.Trim());
                                    cmd.Parameters.AddWithValue("@createdBy", LoginForm.CurrentUserName);
                                    cmd.Parameters.AddWithValue("@lastUpdateBy", LoginForm.CurrentUserName);
                                    addressId = Convert.ToInt32(cmd.ExecuteScalar());
                                }
                            }

                            // Now handle customer
                            if (isEditMode)
                            {
                                string customerQuery = @"UPDATE customer 
                                                 SET customerName = @customerName, 
                                                     addressId = @addressId,
                                                     active = @active, 
                                                     lastUpdate = NOW(), 
                                                     lastUpdateBy = @lastUpdateBy
                                                 WHERE customerId = @customerId";

                                using (var cmd = new MySqlCommand(customerQuery, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@customerId", this.customerId);
                                    cmd.Parameters.AddWithValue("@customerName", customerNameTextBox.Text.Trim());
                                    cmd.Parameters.AddWithValue("@addressId", addressId);
                                    cmd.Parameters.AddWithValue("@active", activeCheckBox.Checked);
                                    cmd.Parameters.AddWithValue("@lastUpdateBy", LoginForm.CurrentUserName);

                                    int rowsAffected = cmd.ExecuteNonQuery();
                                    if (rowsAffected == 0)
                                    {
                                        throw new Exception("No customer record found to update. Please check the customer ID.");
                                    }
                                }
                            }
                            else
                            {
                                string customerQuery = @"INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) 
                                                 VALUES (@customerName, @addressId, @active, NOW(), @createdBy, NOW(), @lastUpdateBy)";

                                using (var cmd = new MySqlCommand(customerQuery, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@customerName", customerNameTextBox.Text.Trim());
                                    cmd.Parameters.AddWithValue("@addressId", addressId);
                                    cmd.Parameters.AddWithValue("@active", activeCheckBox.Checked);
                                    cmd.Parameters.AddWithValue("@createdBy", LoginForm.CurrentUserName);
                                    cmd.Parameters.AddWithValue("@lastUpdateBy", LoginForm.CurrentUserName);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception($"Transaction failed: {ex.Message}", ex);
                        }
                    }
                }

                MessageBox.Show(isEditMode ? "Customer updated successfully." : "Customer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int GetCityId(string cityName, string countryName)
        {
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT countryId FROM country WHERE LOWER(country) = LOWER(@country)";
                int countryId;
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@country", countryName);
                    var result = cmd.ExecuteScalar();
                    countryId = result != null ? Convert.ToInt32(result) : CreateCountry(countryName, connection);
                }
                    query = "SELECT cityId FROM city WHERE LOWER(city) = LOWER(@city) AND countryId = @countryId";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@city", cityName);
                        cmd.Parameters.AddWithValue("@countryId", countryId);
                        var cityResult = cmd.ExecuteScalar();
                        return cityResult != null ? Convert.ToInt32(cityResult) : CreateCity(cityName, countryId, connection);
                    }
                }

            }    
        private int CreateCountry(string countryName, MySqlConnection connection)
        {
            string query = @"INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) 
                             VALUES (@country, NOW(), @createdBy, NOW(), @lastUpdateBy)";
            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@country", countryName);
                cmd.Parameters.AddWithValue("@createdBy", LoginForm.CurrentUserName);
                cmd.Parameters.AddWithValue("@lastUpdateBy", LoginForm.CurrentUserName);
                cmd.ExecuteNonQuery();
                return (int)cmd.LastInsertedId;
            }
        }
        private int CreateCity(string cityName, int countryId, MySqlConnection connection)
        {
            string query = @"INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) 
                             VALUES (@city, @countryId, NOW(),@createdBy, NOW(), @lastUpdateBy)";
            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@city", cityName);
                cmd.Parameters.AddWithValue("@countryId", countryId);
                cmd.Parameters.AddWithValue("@createdBy", LoginForm.CurrentUserName);
                cmd.Parameters.AddWithValue("@lastUpdateBy", LoginForm.CurrentUserName);

                cmd.ExecuteNonQuery();
                return (int)cmd.LastInsertedId;
            }
        }
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
                            countryComboBox.Text = reader["country"].ToString();
                            cityComboBox.Text = reader["city"].ToString();
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

