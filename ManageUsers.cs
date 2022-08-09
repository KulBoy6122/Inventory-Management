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
    public partial class ManageUsers : Form
    {
        //Making Sql Connection 
        public ManageUsers()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Inventory2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        
        //making X for exit
        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        //Showing the user name,id etc on the ManageUsers Page
        void populate()
        {
            try
            {
                Con.Open();
                string Myquery = "select * from UserTbl";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                UserGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }

        //Making Add button work and adding values 
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into UserTbl values('" + uname.Text + "','" + Fname.Text + "','" + password.Text + "','" + Teleph.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Added");
                Con.Close();
                populate();
            }
            catch
            {

            }
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Teleph.Text == "")
            {
                MessageBox.Show("Enter the Users Phone Number");
            }
            else
            {
                Con.Open();
                string myquery = "delete from UserTbl where UPhone= '"+Teleph.Text+"';";
                SqlCommand cmd = new SqlCommand(myquery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Succesfully Deleted");
                Con.Close();
                populate();
            }
        }

        private void UserGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            uname.Text = UserGV.SelectedRows[0].Cells[0].Value.ToString();
            Fname.Text = UserGV.SelectedRows[0].Cells[1].Value.ToString();
            password.Text = UserGV.SelectedRows[0].Cells[2].Value.ToString();
            Teleph.Text = UserGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("update UserTbl set Uname='" + uname.Text + "', Ufullname= '" + Fname.Text + "' , Upassword= '" + password.Text + "' where UPhone='" + Teleph.Text + "'", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Updated");
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
