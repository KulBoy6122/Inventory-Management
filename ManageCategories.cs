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
    public partial class ManageCategories : Form
    {
        public ManageCategories()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Inventory2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        void populate()
        {
            try
            {
                Con.Open();
                string Myquery = "select * from CategoryTbl";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                CategoryGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into CategoryTbl values('" + CatIdTb.Text + "','" + CatNameTb.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Successfully Added");
                Con.Close();
                populate();
            }
            catch
            {

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ManageCategories_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CatIdTb.Text == "")
            {
                MessageBox.Show("Enter the Category Id");
            }
            else
            {
                Con.Open();
                string myquery = "delete from CategoryTbl where CatId= '" + CatIdTb.Text + "';";
                SqlCommand cmd = new SqlCommand(myquery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Succesfully Deleted");
                Con.Close();
                populate();
            }
        }

        private void CategoryGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CatIdTb.Text = CategoryGV.SelectedRows[0].Cells[0].Value.ToString();
            CatNameTb.Text = CategoryGV.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("update CategoryTbl set CatName = '" + CatNameTb.Text + "' where CatId ='" + CatIdTb.Text + "'", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Successfully Updated");
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
    }
    
}
