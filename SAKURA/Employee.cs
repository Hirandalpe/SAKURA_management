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
using System.Drawing.Drawing2D;

namespace SAKURA
{
    public partial class Employee : Form
    {
        //sql connection
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\XAMPP\mysql\SAKURA.mdf;Integrated Security=True;Connect Timeout=30");

        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            showdata();
        }

        public void showdata()//showing data in a gridview
        {
            try
            {
                string qry = "SELECT * FROM Employee_info"; //selecting the employee_info details from the database table
                SqlDataAdapter ad = new SqlDataAdapter(qry, con);
                DataTable Dttb = new DataTable();
                ad.Fill(Dttb);
                dgvemp.DataSource = Dttb.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Front fr = new Front();
            fr.Show();
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "Front")
                    Application.OpenForms[i].Close();
            }

            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Addemployee add = new Addemployee();
            add.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //opening the connection if closed
                if (con.State == ConnectionState.Closed) con.Open();
                string show = "Select Name, Salary_Per_Hour FROM Employee_info WHERE Id = '" + txtempcode.Text + "'";
                SqlCommand com = new SqlCommand(show, con);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    txtempname.Text = dr.GetValue(0).ToString();
                    txtperh.Text = dr.GetValue(1).ToString();
                }
                txtbonus.Text = "0";
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

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateEmployee up = new UpdateEmployee();
            up.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DeleteEmployee del = new DeleteEmployee();
            del.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            showdata();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int salary;
            int basic_sal;

            basic_sal = int.Parse(txtperh.Text) * int.Parse(txtworkho.Text);

            salary = basic_sal + int.Parse(txtbonus.Text);

            txtsalary.Text = salary.ToString();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
                clear();
            }
        }

        private void clear()
        {
            txtbonus.Text = "";
            txtempcode.Text = "";
            txtempname.Text = "";
            txtperh.Text = "";
            txtsalary.Text = "";
            txtworkho.Text = "";
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string name = "D W G M P Kumarasiri\nDirector\nSakura Fashions";
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.DrawImage(Properties.Resources.sakubit, 350,20,150,130);
            g.DrawLine(new Pen(Color.MidnightBlue), new PointF(0, 150),new PointF(this.Width,150));
            g.DrawString(label2.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(150, 200));
            g.DrawString(txtempcode.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(500, 200));

            g.DrawString(label1.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(150, 230));
            g.DrawString(txtempname.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(500, 230));

            g.DrawString(label6.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(150, 290));
            g.DrawString(txtsalary.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(500, 290));

            g.DrawString(label5.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(150, 260));
            g.DrawString(txtbonus.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(500, 260));

            g.DrawLine(new Pen(Color.Black), new PointF(100, this.Height - 100), new PointF(300, this.Height - 100));
            g.DrawString(name, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(100, this.Height-90));


        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog2.ShowDialog() == DialogResult.OK)
            {
                printDocument2.Print();
            }
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string rep_name = "Employee Report";
            int T_width = 80;
            int T_height = 230;
            string col1 = "Id";
            string col2 = "Name";
            string col3 = "Phone Number";
            string col4 = "Date of intake";
          

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.Graphics.DrawImage(Properties.Resources.sakubit, 350, 20, 150, 130);
            e.Graphics.DrawLine(new Pen(Color.MidnightBlue), new PointF(0, 150), new PointF(900, 150));
            e.Graphics.DrawString(rep_name, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.MidnightBlue, new PointF(350, 160));

            e.Graphics.DrawString(col1, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(T_width, T_height));
            e.Graphics.DrawString(col2, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(T_width + 100, T_height));
            e.Graphics.DrawString(col3, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(T_width + 250, T_height));
            e.Graphics.DrawString(col4, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(T_width + 400, T_height));

            
            if (con.State == ConnectionState.Closed) con.Open();
            string query = "SELECT Id, Name, PhoneNumber, Date_of_intake FROM Employee_info";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            int width = 80;
            int height = 270;
            while (dr.Read())
            {
                try
                {
                    string date = dr.GetValue(3).ToString();
                    date = date.Substring(0, date.Length-11);
                    e.Graphics.DrawString(dr.GetValue(0).ToString(), new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(width, height));
                    e.Graphics.DrawString(dr.GetValue(1).ToString(), new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(width + 100, height));
                    e.Graphics.DrawString(dr.GetValue(2).ToString(), new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(width + 250, height));
                    e.Graphics.DrawString(date, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(width + 400, height));
                    e.Graphics.DrawLine(new Pen(Color.Black), width, height, 800, height);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                height += 35;
            }
            dr.Close();
        }
    }
    
}
