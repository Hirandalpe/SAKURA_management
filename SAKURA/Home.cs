﻿using System;
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

    public partial class Home : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\sakuraDB\Sakuradb.mdf;Integrated Security=True;Connect Timeout=30");

        public Home()
        {
            InitializeComponent();
        }

        //loads the required datagridview according to the hovered buttoon
        private void Home_Load(object sender, EventArgs e)
        {
            label1.Text = Front.user;
            DGVshow.Hide();
        }

        //logout

        private void button1_Click(object sender, EventArgs e)
        {
            Front fr = new Front();
            fr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//minimize
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Manager mg = new Manager();//opens manager from
            mg.Show();

        }

        private void Prodbut_Click(object sender, EventArgs e)
        {
            Product pr = new Product();//opens products form
            pr.Show();
         
        }

        private void Stockbut_Click(object sender, EventArgs e)
        {
            Stock st = new Stock();//opens stock from
            st.Show();
           
        }

        private void Empbut_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();//opens employee information form
            emp.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Prodbut_MouseEnter(object sender, EventArgs e)
        {
            DGVshow.Show();
            Prodbut.BackColor = Color.DarkSlateGray;
            try
            {
                string qry = "SELECT * FROM Product_info"; //selecting the Stock details from the database table
                SqlDataAdapter ad = new SqlDataAdapter(qry, con);
                DataTable Dttb = new DataTable();
                ad.Fill(Dttb);
                DGVshow.DataSource = Dttb.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Prodbut_MouseLeave(object sender, EventArgs e)
        {
            Prodbut.BackColor = Color.DarkCyan;
            
        }

        private void Stockbut_MouseHover(object sender, EventArgs e)
        {
            DGVshow.Show();
            
            try
            {
                string qry = "SELECT * FROM Stock"; //selecting the Stock details from the database table
                SqlDataAdapter ad = new SqlDataAdapter(qry, con);
                DataTable Dttb = new DataTable();
                ad.Fill(Dttb);
                DGVshow.DataSource = Dttb.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Empbut_MouseHover(object sender, EventArgs e)
        {
           
            DGVshow.Show();
            
            try
            {
                string qry = "SELECT * FROM Employee_info"; //selecting the Stock details from the database table
                SqlDataAdapter ad = new SqlDataAdapter(qry, con);
                DataTable Dttb = new DataTable();
                ad.Fill(Dttb);
                DGVshow.DataSource = Dttb.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void panel6_MouseClick(object sender, MouseEventArgs e)
        {
            DGVshow.Hide();
        }

        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            DGVshow.Hide();
        }

        private void Stockbut_MouseEnter(object sender, EventArgs e)
        {
            Stockbut.BackColor = Color.DarkSlateGray;
        }

        private void Stockbut_MouseLeave(object sender, EventArgs e)
        {
            Stockbut.BackColor = Color.DarkCyan;
        }

        private void Empbut_MouseEnter(object sender, EventArgs e)
        {
            Empbut.BackColor = Color.DarkSlateGray;
        }

        private void Empbut_MouseLeave(object sender, EventArgs e)
        {
            Empbut.BackColor = Color.DarkCyan;
        }

        private void Repbut_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void Repbut_MouseLeave(object sender, EventArgs e)
        {
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.DarkSlateGray;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.DarkCyan;
        }

        private void Repbut_Click(object sender, EventArgs e)
        {
            
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dailysalesupdate ds = new dailysalesupdate();
            ds.Show();
        }
    }
}
