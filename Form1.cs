using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Inventory2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            UnameTb.Text = "";
            PasswordTb.Text = ""; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from UserTbl where Uname = '" + UnameTb.Text + "' and Upassword = '" + PasswordTb.Text + "'",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                ManageCustomers cust = new ManageCustomers();
                cust.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong UserName or Password");
            }
            Con.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard2 login = new Dashboard2();
            this.Hide();
            login.Show();
        }
    }
}
