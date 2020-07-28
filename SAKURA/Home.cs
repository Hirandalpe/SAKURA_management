using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAKURA
{

    public partial class Home : Form
    {

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            label1.Text = Front.user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Front fr = new Front();
            fr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Manager mg = new Manager();
            mg.Show();

        }

        private void Prodbut_Click(object sender, EventArgs e)
        {
            Product pr = new Product();
            pr.Show();
         
        }
    }
}
