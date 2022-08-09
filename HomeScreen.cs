using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
        }
        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void label9_Click(object sender, EventArgs e)
        {
            ManageProducts prod = new ManageProducts();
            prod.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ManageUsers user = new ManageUsers();
            user.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ManageCategories cat = new ManageCategories();
            cat.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ManageCustomers cust = new ManageCustomers();
            cust.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ManageOrders order = new ManageOrders();
            order.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Dashboard2 Dash = new Dashboard2();
            Dash.Show();
            this.Hide();
        }
    }
}
