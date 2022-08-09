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
    public partial class FlashScreen : Form
    {
        public FlashScreen()
        {
            InitializeComponent();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
           

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard2 login = new Dashboard2();
            this.Hide();
            login.Show();
        }
    }
}
