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
    public partial class ManageProducts : Form
    {
        public ManageProducts()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Inventory2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        void fillcategory()
        {
            string query = "select * from CategoryTbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            try
            {
                Con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("CatName", typeof(string));
                rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                Catcombox.ValueMember = "CatName";
                Catcombox.DataSource = dt;
                SearchCombo.ValueMember = "CatName";
                SearchCombo.DataSource = dt;
                Con.Close();
            }
            catch
            {

            }
        }
        
        private void ManageProducts_Load(object sender, EventArgs e)
        {
            fillcategory();
            populate();
        }
        void populate()
        {
            try
            {
                Con.Open();
                string Myquery = "select * from ProductTbl";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                ProductGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }
        void filterbycategory()
        {
            try
            {
                Con.Open();
                string Myquery = "select * from ProductTbl where ProdCat='"+SearchCombo.SelectedValue.ToString()+"'";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                ProductGV.DataSource = ds.Tables[0];
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
                SqlCommand cmd = new SqlCommand("insert into ProductTbl values('" + ProductIdTb.Text + "','" + ProductNameTb.Text + "','" + ProductQtyTb.Text + "','" + ProductPriceTb.Text + "','" + DescriptionTb.Text + "','"+ Catcombox.SelectedValue.ToString() + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Successfully Added");
                Con.Close();
                populate();
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ProductIdTb.Text == "")
            {
                MessageBox.Show("Enter the Product Id");
            }
            else
            {
                Con.Open();
                string myquery = "delete from ProductTbl where ProdId= '" + ProductIdTb.Text + "';";
                SqlCommand cmd = new SqlCommand(myquery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Succesfully Deleted");
                Con.Close();
                populate();
            }
        }

        private void ProductGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductIdTb.Text = ProductGV.SelectedRows[0].Cells[0].Value.ToString();
            ProductNameTb.Text = ProductGV.SelectedRows[0].Cells[1].Value.ToString();
            ProductQtyTb.Text = ProductGV.SelectedRows[0].Cells[2].Value.ToString();
            ProductPriceTb.Text = ProductGV.SelectedRows[0].Cells[3].Value.ToString();
            DescriptionTb.Text = ProductGV.SelectedRows[0].Cells[4].Value.ToString();
            Catcombox.SelectedValue = ProductGV.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("update ProductTbl set ProdName = '" + ProductNameTb.Text + "', ProdQty = '" + ProductQtyTb.Text + "', ProdPrice = '" + ProductPriceTb.Text + "', ProdDesc = '" + DescriptionTb.Text + "', ProdCat='"+ Catcombox.SelectedValue + "'where ProdId ='" + ProductIdTb.Text + "'", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Successfully Updated");
                Con.Close();
                populate();
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            filterbycategory();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void SearchCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            HomeScreen home = new HomeScreen();
            home.Show();
            this.Hide();
        }
    }
}
