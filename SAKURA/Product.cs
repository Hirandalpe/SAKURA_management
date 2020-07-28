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
    public partial class Product : Form
    {
        //connecting the database with the form
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\XAMPP\mysql\SAKURA.mdf;Integrated Security=True;Connect Timeout=30");

        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            
            try
            {
                
                string qry = "SELECT * FROM Product_info";//selecting all the information to show in the datagridview from the table "Product"
                SqlDataAdapter da = new SqlDataAdapter(qry, con);//to get the data from the source(table) to the DateSet used next
                DataSet dt = new  DataSet();
                da.Fill(dt, "Product_info");//filling up a virtual table 
                dgvproduct.DataSource = dt.Tables["Product_info"].DefaultView;//showing the data taken in a datagridview
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Home hm = new Home();
            hm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void catshow_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                try
                {
                    string qry1 = "SELECT * FROM Product_info WHERE Name = '" + txtcat.Text + "'";//taking a specific data set to the data grid view (Here showing data from the same Name)
                    SqlDataAdapter da1 = new SqlDataAdapter(qry1, con);
                    DataSet dt1 = new DataSet();
                    da1.Fill(dt1, "Product_info");
                    dgvproduct.DataSource = dt1.Tables["Product_info"].DefaultView;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            if (checkBox3.Checked)
            {
                try
                {                 
                    string qry2 = "SELECT * FROM Product_info WHERE Category = '" + txtcat.Text + "'";//taking a specific data set to the data grid view (Here showing data from the same Category)
                    SqlDataAdapter da = new SqlDataAdapter(qry2, con);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "Product_info");
                    dgvproduct.DataSource = dt.Tables["Product_info"].DefaultView;
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.ToString());
                }

            }

            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3.Checked = false;//unchecking a checkbox if this is checked          
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }
    }
}
