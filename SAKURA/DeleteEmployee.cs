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
    public partial class DeleteEmployee : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\sakuraDB\Sakuradb.mdf;Integrated Security=True;Connect Timeout=30");

        public DeleteEmployee()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string qry = "SELECT * FROM Employee_info WHERE Id = '" + idtxt.Text + "'"; //selecting the id details from the database table if there is any
            SqlDataAdapter ad = new SqlDataAdapter(qry, con);
            DataTable Dttb = new DataTable();
            ad.Fill(Dttb);
            if (Dttb.Rows.Count == 0)//checking if the id is still available
            {
                MessageBox.Show("Id not Available");
            }
            else
            {
                string message = "Are you sure you want to Delete?";//giving  warning to ask if need to be actualy deleted
                string title = "Delete";
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result = MessageBox.Show(message, title, buttons, icon);
                if (result == DialogResult.Yes)
                {
                   
                   string del = "DELETE  FROM Employee_info WHERE Id='" + idtxt.Text + "'";
                        SqlCommand dq = new SqlCommand(del, con);

                   try
                   {
                       con.Open();
                       dq.ExecuteNonQuery();
                       MessageBox.Show("Deleted Successfully!");
                       Employee emp = new Employee();
                       emp.showdata();
                        con.Close();
                        
                   }
                   catch (Exception ex)
                   {
                      MessageBox.Show(ex.ToString());
                   }
                        
                    
                }
                else
                {
                    MessageBox.Show("Data was not Deleted!");
                }

            }
        }

        private void idtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string show = "SELECT Name, PhoneNumber,  Date_of_intake FROM Employee_info WHERE Id = '"+idtxt.Text+"'";
                SqlCommand del = new SqlCommand(show, con);
                SqlDataReader dr = del.ExecuteReader();
                while (dr.Read())
                {
                    nametxt.Text = dr.GetValue(0).ToString();
                    phonetxt.Text = dr.GetValue(1).ToString();
                    datetxt.Text = dr.GetValue(2).ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally 
            {
                   con.Close();
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
