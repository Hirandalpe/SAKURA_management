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
    public partial class Manager : Form
    { 
        //connecting to the database
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\XAMPP\mysql\SAKURA.mdf;Integrated Security=True;Connect Timeout=30");
    
        public Manager()
        {
            InitializeComponent();
        }

        private void Addmg_Click(object sender, EventArgs e)
        {
            string add = "INSERT INTO Manager VALUES ('"+Usertxt.Text+"','"+Passwordtxt.Text+"','"+txtname.Text+"', '"+int.Parse(txtphone.Text)+"')";//adding data to the database
            SqlCommand cmd = new SqlCommand(add,con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();//executing the query
                MessageBox.Show("Manager Data Added Successfully!");
                clear();
            }
            catch(Exception ex)//finding if any exceptions
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();//closing the sql connection
            }


        }

        private void Upmg_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Manager SET Password=@Password Name=@Name PhoneNo=@PhoneNo WHERE Username=@Username", con);//accessing the data in the database
                con.Open();
                cmd.Parameters.AddWithValue("@Password", Passwordtxt.Text);//add with value gives provides the values entered to the textboxes to the assigned parameters
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@PhoneNo", int.Parse(txtphone.Text));
                cmd.Parameters.AddWithValue("@Username", Usertxt.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();
                clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Delmg_Click(object sender, EventArgs e)
        {
            string qry = "DELETE FROM Manager WHERE Username = '" + Usertxt.Text + "'"; //deleting data from the database

            SqlCommand cmd = new SqlCommand(qry, con);

            if (Usertxt.Text == "")//checking if the user has entered the username to be deleted
            {
                MessageBox.Show("Enter the Username to Delete!");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Data Was Deleted!");
                    clear();

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

        private void clear()
        {
            Usertxt.Text = "";
            Passwordtxt.Text = "";
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
