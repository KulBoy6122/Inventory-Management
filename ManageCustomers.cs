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
    public partial class ManageCustomers : Form
    {
        public ManageCustomers()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Inventory2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        void populate()
        {
            try
            {
                Con.Open();
                string Myquery = "select * from CustomerTbl";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                CustomerGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }
        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into CustomerTbl values('" + CustIdTb.Text + "','" + CustNameTb.Text + "','" + CustPhTb.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Successfully Added");
                Con.Close();
                populate();
            }
            catch
            {

            }
        }

        private void ManageCustomers_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CustIdTb.Text == "")
            {
                MessageBox.Show("Enter the Customer Id");
            }
            else
            {
                Con.Open();
                string myquery = "delete from CustomerTbl where Custid= '" + CustIdTb.Text + "';";
                SqlCommand cmd = new SqlCommand(myquery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Succesfully Deleted");
                Con.Close();
                populate();
            }
        }
        
        private void CustomerGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustIdTb.Text = CustomerGV.SelectedRows[0].Cells[0].Value.ToString();
            CustNameTb.Text = CustomerGV.SelectedRows[0].Cells[1].Value.ToString();
            CustPhTb.Text = CustomerGV.SelectedRows[0].Cells[2].Value.ToString();
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from OrderTbl where CustId = " + CustIdTb.Text + "",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            OrderLabel.Text = dt.Rows[0][0].ToString();            
            SqlDataAdapter sda1 = new SqlDataAdapter("select Sum(TotalAmt) from OrderTbl where CustId = " + CustIdTb.Text + "", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            AmountLabel.Text = dt1.Rows[0][0].ToString();
            SqlDataAdapter sda2 = new SqlDataAdapter("select Max(OrderDate) from OrderTbl where CustId = " + CustIdTb.Text + "", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            DateLabel.Text = dt2.Rows[0][0].ToString();
            Con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("update CustomerTbl set CustName = '" + CustNameTb.Text + "', CustPhone = '" + CustPhTb.Text + "' where Custid ='" + CustIdTb.Text + "'", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Successfully Updated");
                Con.Close();
                populate();
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HomeScreen home = new HomeScreen();
            home.Show();
            this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
