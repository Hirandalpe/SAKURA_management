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
    public partial class Front : Form
    {
        //taking a public variable which can be used anywhere in the program
        public static string user;
        
        //connecting to the database
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\XAMPP\mysql\SAKURA.mdf;Integrated Security=True;Connect Timeout=30");
        public Front()
        {
            InitializeComponent();
        }
        /*
        private void logsub_Click(object sender, EventArgs e)
        {
            


        }
        */
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();//exit button closes the application
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        

        private void passtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && unametxt.Text != "")//to make the user login by pressing enter key
            {
                logsub_Click(this, new EventArgs());
            }
        }

        private void logsub_Click(object sender, EventArgs e)
        {
            user = unametxt.Text;//asigning  the values entered to the textbox to the variable


            if (unametxt.Text == "" || passtxt.Text == "")
            {
                MessageBox.Show("Enter the required Fields"); //checking if all the fields are filled
            }
            else
            {
                try
                {

                    string qry = "SELECT * FROM Manager where Username = '" + unametxt.Text + "' and Password='"+passtxt.Text+"'"; //selecting the manager details from the database table
                    SqlDataAdapter ad = new SqlDataAdapter(qry, con);
                    DataTable Dttb = new DataTable();
                    ad.Fill(Dttb);//asigning the data collected to a virtual table temporelly

                    if (Dttb.Rows.Count == 1)// checking if the enterd values are contained in the same row of table
                    {
                        Home hm = new Home(); //if the enetred credentials are true redirecting to the home page
                        hm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username or Password Incorrect!");//if the eneterd values are wrong show an error message
                    }
                }
                catch (Exception ex)//handling exceptions
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }
    }
}
