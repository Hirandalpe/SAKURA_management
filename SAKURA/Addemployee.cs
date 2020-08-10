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
    public partial class Addemployee : Form
    {
        
        //connecting the database with the form
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\XAMPP\mysql\SAKURA.mdf;Integrated Security=True;Connect Timeout=30");

        public Addemployee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtmp1.Format = DateTimePickerFormat.Custom;
            dtmp1.CustomFormat = " dd MM yyyy ";
            DateTime dtmp;
            dtmp = dtmp1.Value;
            if (idtxt.Text == "" || nametxt.Text == "" || phonetxt.Text == "" || saltxt.Text == "")
            {
                MessageBox.Show("Enter the required fields");
            }
            else
            {
                string insert = "INSERT INTO Employee_info VALUES('" + idtxt.Text + "', '" + nametxt.Text + "', '" + phonetxt.Text + "', '" + dtmp + "','" + saltxt.Text + "', '" + Sptxt.Text + "')";
                SqlCommand cmd = new SqlCommand(insert, con);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data successfully inserted");
                    Employee em = new Employee();
                    em.Refresh();
                    idtxt.Text = "";
                    nametxt.Text = "";
                    phonetxt.Text = "";
                    saltxt.Text = "";
                    Sptxt.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
