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
    public partial class UpdateEmployee : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\sakuraDB\Sakuradb.mdf;Integrated Security=True;Connect Timeout=30");

        public UpdateEmployee()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string update = "UPDATE Employee_info SET Name = '"+nametxt+"' ,PhoneNumber = '"+int.Parse(phonetxt.Text)+"' ,Salary_Per_Hour = '"+int.Parse(saltxt.Text)+"' WHERE Id = '"+idtxt.Text+"'";
            SqlCommand cmd = new SqlCommand(update, con);

            DateTime dt = DateTime.Today;

            

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Data Updated");
                nametxt.Text = "";
                phonetxt.Text = "";
                saltxt.Text = "";
                idtxt.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }

           


        }
           

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void idtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string show = "SELECT Name, PhoneNumber, Salary_Per_Hour  FROM Employee_info WHERE Id = '" + idtxt.Text + "'";
                SqlCommand del = new SqlCommand(show, con);
                SqlDataReader dr = del.ExecuteReader();
                while (dr.Read())
                {
                    nametxt.Text = dr.GetValue(0).ToString();
                    phonetxt.Text = dr.GetValue(1).ToString();
                    saltxt.Text = dr.GetValue(2).ToString();
                }
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

        private void UpdateEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
