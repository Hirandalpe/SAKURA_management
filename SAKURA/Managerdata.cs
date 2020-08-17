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

namespace SAKURA
{
    public partial class Managerdata : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\sakuraDB\Sakuradb.mdf;Integrated Security=True;Connect Timeout=30");

        public Managerdata()
        {
            InitializeComponent();
        }

        private void Managerdata_Load(object sender, EventArgs e)
        {
            try
            {
                string qry = "SELECT * FROM Manager";//selecting all the information to show in the datagridview from the table "Manager"
                SqlDataAdapter da = new SqlDataAdapter(qry, con);//to get the data from the source(table) to the DateSet used next
                DataSet dt = new DataSet();
                da.Fill(dt, "Manager");//filling up a virtual table 
                Dgvmanager.DataSource = dt.Tables["Manager"].DefaultView;//showing the data taken in a datagridview
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Hide();
            this.Hide();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "SELECT * FROM Manager";//selecting all the information to show in the datagridview from the table "Manager"
                SqlDataAdapter da = new SqlDataAdapter(qry, con);//to get the data from the source(table) to the DateSet used next
                DataSet dt = new DataSet();
                da.Fill(dt, "Manager");//filling up a virtual table 
                Dgvmanager.DataSource = dt.Tables["Manager"].DefaultView;//showing the data taken in a datagridview
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
