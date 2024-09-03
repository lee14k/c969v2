using c969v2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public CustomerForm(int? customerId=null)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            isEditMode=customerId.HasValue;
            this.customerId = customerId ?? 0;
            SetFormTitle();
            if (isEditMode)
            {
                LoadCustomerData();
            }
            else
            {
                this.customerId = GenerateNewCustomerId();
                IDNum.Value = this.customerId;
            }
        }


        private int GenerateNewCustomerId() {
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



        })

    private void SetFormTitle()
        {
            MainCustFormHeadline.Text = isEditMode ? "Edit Appointment" : "Add Appointment";
        }







    }
}
