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
    public partial class dailysalesupdate : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\sakuraDB\Sakuradb.mdf;Integrated Security=True;Connect Timeout=30");
        String ItemID;
        long BillID = 0;
        int Billno = 0;
        int total = 0;

        private readonly Random ranum = new Random();

        public int randnum()
        {
            return ranum.Next(9999);
        }



        public dailysalesupdate()
        {
            InitializeComponent();
        }      

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addbill();        
        }

        public void refreshbill()
        {
            Billno++;  
            String newBillId = DateTime.Now.ToString("mmdd") + randnum().ToString() + Billno.ToString(); 
            BillID = Convert.ToInt64(newBillId);    
            
        }

        
        
      
        public void addbill()
        {
            if (FLP_bill.Controls.Count < 1)
            {
                refreshbill();
            }

            total = (int.Parse(pricecounttxt.Text) - int.Parse(discountCounttxt.Text)) * int.Parse(quantitycounttxt.Text);


            try
            {
                string date = datelbl.Text;   
                string inst = "INSERT INTO Billing VALUES ('"+BillID+"', '"+ItemID+"', '"+Codecounttxt.Text+"', '"+pricecounttxt.Text+"', '"+quantitycounttxt.Text+"', '"+discountCounttxt.Text+"', '"+total+"', '"+date+"')";
                SqlCommand cmd = new SqlCommand(inst, con);
                if(con.State==ConnectionState.Closed)con.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
                                 
            panel row = new panel();
            row.ItemName = Codecounttxt.Text;
            row.Quantity = quantitycounttxt.Text;
            row.price = pricecounttxt.Text;
            row.discount = discountCounttxt.Text;
            row.total = total.ToString();
            row.Width = FLP_bill.Width-10;
            row.ItemID = ItemID;
            row.CHbut.Click += CHbut_Click;
                                 
            FLP_bill.Controls.Add(row);
            Claculatetotal();
        }

        private void CHbut_Click(object sender, EventArgs e)
        {
            int total = int.Parse((sender as panel).total);
            /*
             (sender as panel).itemid;
             */
            try
            {
                
                string qry = "DELETE FROM Billing WHERE BillId = '"+BillID+"' AND ItemCode = '"+ItemID+"' AND Total = '"+total+"'";
                SqlCommand cmd = new SqlCommand(qry, con);
                if (con.State == ConnectionState.Closed) con.Open();
                cmd.ExecuteNonQuery();
                Claculatetotal();
                FLP_bill.Controls.Remove(sender as panel);


            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        double finaltotal = 0;
        private void Claculatetotal()
        {
            try
            {
                string qry = "SELECT SUM(Total) FROM Billing WHERE BillId = '" + BillID + "'";
                SqlDataAdapter ad = new SqlDataAdapter(qry, con);
                DataTable dtb = new DataTable();
                ad.Fill(dtb);
                try
                {
                    finaltotal = Convert.ToDouble(dtb.Rows[0][0]);
                }
                catch
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                subtxt.Text = "Rs." + finaltotal.ToString("F2");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {
            Codecounttxt.Text = "";
            quantitycounttxt.Text = "";
            pricecounttxt.Text = "";
            discountCounttxt.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "SELECT * FROM Product_info WHERE Type = '" + navtypetxt.Text + "'";
                SqlDataAdapter ad = new SqlDataAdapter(qry, con);
                DataTable Dttb = new DataTable();
                ad.Fill(Dttb);
                if (Dttb.Rows.Count == 0)//checking whether the item is available
                {
                    MessageBox.Show("Item not Available");
                }
                else
                {
                    loadcode1();
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

        private void loadcode1()
        {

            flowLayoutPanel1.Controls.Clear();
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                string query = "SELECT Name FROM Product_info WHERE Type = '" + navtypetxt.Text + "'";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dr = com.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    Button but = new Button();
                    but.Text = dr.GetValue(0).ToString();
                    but.FlatStyle = FlatStyle.Flat;
                    but.BackColor = Color.DarkCyan;
                    but.Width = 157;
                    but.Height = 47;
                    but.ForeColor = Color.White;
                    but.Click += But_Click;
                    

                    flowLayoutPanel1.Controls.Add(but);
                    i++;
                }
                i = 0;
            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.ToString());
            }
            finally
            {
                con.Close();
            }

        }
        //sends the code to the required textbox
        private void But_Click(object sender, EventArgs e)
        {
            Codecounttxt.Text = (sender as Button).Text;
            try
            {
                //opening the connection if closed
                if (con.State == ConnectionState.Closed) con.Open();
                string show = "SELECT Price,Code FROM Product_info WHERE Name = '" + Codecounttxt.Text + "'";
                SqlCommand com = new SqlCommand(show, con);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    pricecounttxt.Text = dr.GetValue(0).ToString();
                    ItemID = dr.GetValue(1).ToString();
                    
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

        private void dailysalesupdate_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Today;
            string dtnow = date.ToString();
            string dtlbl = dtnow.Substring(0, dtnow.Length - 11);
            datelbl.Text = dtlbl;
            
        }

        private void print_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            FLP_bill.Controls.Clear();
            subtxt.Text = "";
            totaldistxt.Text = "";
            grosstxt.Text = "";
        }
    }
}
