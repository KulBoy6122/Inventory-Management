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
    public partial class ViewOrders : Form
    {
        public ViewOrders()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Inventory2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        void populateorders()
        {
            try
            {
                Con.Open();
                string Myquery = "select * from OrderTbl";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                OrderGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }

        private void ViewOrders_Load(object sender, EventArgs e)
        {
            populateorders();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void OrderGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           // e.Graphics.DrawString("Order Summary", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(100,100));
            //e.Graphics.DrawString("Order Summary", new Font("Century", 25, FontStyle.Bold),Brushes.Red,new Point(230));
            //e.Graphics.DrawString("Order Id:"+OrderGV.SelectedRows[0].Cells[0].Value.ToString(), new Font("Order Id", 25, FontStyle.Bold), Brushes.Red, new Point(230,150));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument2.Print();
            }
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Order Summary", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
        }
    }
}
