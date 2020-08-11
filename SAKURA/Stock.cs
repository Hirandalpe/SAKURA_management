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
   
    
    public partial class Stock : Form
    {
        public static string name;
        public static string type;
        public static string catagory;

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\SAKURA.mdf;Integrated Security=True;Connect Timeout=30");
        public Stock()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This ccode provides the code to load the datagridview on load of form
        /// it loads all the data available in the table to the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stock_Load(object sender, EventArgs e)
        {
            string qry = "SELECT * FROM Stock"; //selecting the Stock details from the database table
            SqlDataAdapter ad = new SqlDataAdapter(qry, con);
            DataTable Dttb = new DataTable();
            ad.Fill(Dttb);
            dgvstock.DataSource = Dttb.DefaultView;          
        
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
        {
            if (chktyp.Checked)
            {
                try
                {
                    string qry = "SELECT * FROM Stock WHERE Type = '" + cattxt.Text + "'"; //selecting the Category details from the database table
                    SqlDataAdapter ad = new SqlDataAdapter(qry, con);//this retirives the data from the database to the datatable below
                    DataTable DTb = new DataTable();//datatable represents the data recieved by the dataadaptor in datarows and datacolumns
                    ad.Fill(DTb);//fills the datatable
                    if (DTb.Rows.Count > 0)//To check whether the value entered through the textbox is there in the table
                    {
                        dgvstock.DataSource = DTb.DefaultView;
                        chktyp.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("Type not available");
                    }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            if (chkcat.Checked)
            {
                try
                {
                    string qry = "SELECT * FROM Stock WHERE Category = '" + cattxt.Text + "'"; //selecting the Category details from the database table
                    SqlDataAdapter ad = new SqlDataAdapter(qry, con);//this retirives the data from the database to the datatable below
                    DataTable DTb = new DataTable();//datatable represents the data recieved by the dataadaptor in datarows and datacolumns
                    ad.Fill(DTb);//fills the datatable
                    if (DTb.Rows.Count > 0)//To check whether the value entered through the textbox is there in the table
                    {
                        dgvstock.DataSource = DTb.DefaultView;
                        chkcat.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("Category not available");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (categorychk.Checked)
            {
                try
                {
                    string qry = "SELECT * FROM Stock WHERE Category = '" + txtSearch.Text + "'"; //selecting the Category details from the database table
                    SqlDataAdapter ad = new SqlDataAdapter(qry, con);//this retirives the data from the database to the datatable below
                    DataTable DTb = new DataTable();//datatable represents the data recieved by the dataadaptor in datarows and datacolumns
                    ad.Fill(DTb);//fills the datatable
                    if (DTb.Rows.Count > 0)//To check whether the value entered through the textbox is there in the table
                    {
                        loadcodecat();
                        categorychk.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("Enter a valid Category");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }


                if (typechk.Checked)
                {
                    try
                    {
                        string qry = "SELECT * FROM Stock WHERE Type = '" + txtSearch.Text + "'"; //selecting the Category details from the database table
                        SqlDataAdapter ad = new SqlDataAdapter(qry, con);//this retirives the data from the database to the datatable below
                        DataTable DTb = new DataTable();//datatable represents the data recieved by the dataadaptor in datarows and datacolumns
                        ad.Fill(DTb);//fills the datatable
                        if (DTb.Rows.Count > 0)//To check whether the value entered through the textbox is there in the table
                        {
                            loadcode();
                            typechk.Checked = false;
                        }
                        else
                        {
                            MessageBox.Show("Enter a valid Type");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }

        /// <summary>
        /// the following code provides the code for bring up the required set of codes according to the type mentioned by the user
        /// datareader reads the values taken from the daatavase table and while it reads the table in the loop it is assigned to a button
        /// </summary>
        private void loadcode()
        {
            flowLayoutPanel1.Controls.Clear();
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                string query = "SELECT Code FROM Stock WHERE Type = '" + txtSearch.Text + "'";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dr = com.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    Button but = new Button();
                    but.Text = dr.GetValue(0).ToString();                    
                    but.BackColor = Color.DarkCyan;
                    but.Width = 157;
                    but.Height = 47;
                    but.TextAlign = ContentAlignment.MiddleCenter;
                    but.ForeColor = Color.White;
                    but.FlatStyle = FlatStyle.Popup;
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
            txtcode.Text = (sender as Button).Text;
        }

        private void loadcodecat()
        {
            flowLayoutPanel1.Controls.Clear();
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                string query = "SELECT Code FROM Stock WHERE Category = '" + txtSearch.Text + "'";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dr = com.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    Button but1 = new Button();
                    but1.Text = dr.GetValue(0).ToString();
                    but1.BackColor = Color.DarkCyan;
                    but1.Width = 157;
                    but1.Height = 47;
                    but1.TextAlign = ContentAlignment.MiddleCenter;
                    but1.ForeColor = Color.White;
                    but1.FlatStyle = FlatStyle.Popup;
                    but1.Click += But1_Click;
                    
                    flowLayoutPanel1.Controls.Add(but1);
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
        private void But1_Click(object sender, EventArgs e)
        {
            txtcode.Text = (sender as Button).Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Today;
            string date = dt.ToString();
            

            if (txtcode.Text == "" || txtname.Text == "" || txttype.Text == "" || txtcat.Text == "" || txtstock.Text == "")
            {
                MessageBox.Show("Enter the required fields");
            }
            else
            {
                string insert = "INSERT INTO Stock VALUES('" + txtcode.Text + "','" + txtname.Text + "','" + txttype.Text + "', '" + txtcat.Text + "','" + txtstock.Text + "', '"+dt+"' )";
                SqlCommand cmd = new SqlCommand(insert, con);

                string dateinput = "Update UpdateDate SET date = '" + date + "' WHERE id = '" + 1 + "'";
                SqlCommand intab = new SqlCommand(dateinput, con);
                try
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    cmd.ExecuteNonQuery();
                    intab.ExecuteNonQuery();
                    MessageBox.Show("Data added successfully!");
                    showdata();
                    clear();
                }
                catch (Exception rx)
                {
                    MessageBox.Show(rx.ToString());
                }
                finally
                {
                    con.Close();

                }
            }
        }

        private void txtcode_TextChanged(object sender, EventArgs e)
        {
            //getting the required information when the cde is input
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                string show = "Select Name, Type, Category, Stock FROM Stock WHERE Code = '" + txtcode.Text + "'";
                SqlCommand com = new SqlCommand(show, con);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    txtname.Text = dr.GetValue(0).ToString();
                    txttype.Text = dr.GetValue(1).ToString();
                    txtcat.Text = dr.GetValue(2).ToString();
                    txtstock.Text = dr.GetValue(3).ToString();
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
        private void clear()
        {
            txtcat.Text = "";
            txtcode.Text = "";
            txtname.Text = "";
            txtSearch.Text = "";
            txtstock.Text = "";
            txttype.Text = "";

        }                                  

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Today;
            string date = dt.ToString();
            string qry = "SELECT * FROM Stock WHERE Code = '" + txtcode.Text + "'"; //selecting the item code details from the database table if there is any
            SqlDataAdapter ad = new SqlDataAdapter(qry, con);
            DataTable Dttb = new DataTable();
            ad.Fill(Dttb);
            if (Dttb.Rows.Count == 0)//checking whether the item is available
            {
                MessageBox.Show("Item not Available");
            }
            else
            {
                //update query
                string upd = "UPDATE Stock SET Name='" + txtname.Text + "', Type='" + txttype.Text + "', Category='" + txtcat.Text + "', Stock='" + int.Parse(txtstock.Text) + "', LastUpdate = '"+dt+"' WHERE Code='" + txtcode.Text + "'";
                SqlCommand up = new SqlCommand(upd, con);

                string insert = "Update UpdateDate SET date = '"+date+"' WHERE id = '"+1+"'";
                SqlCommand intab = new SqlCommand(insert, con);
                try
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    up.ExecuteNonQuery();
                    intab.ExecuteNonQuery();
                    MessageBox.Show("Stock Information Updated!");
                    showdata();
                    clear();
                }
                catch (Exception e2)
                {
                    MessageBox.Show(e2.ToString());
                }
                finally
                {
                    con.Close();
                }
            }


        }

        private void button9_Click(object sender, EventArgs e)
        {

            string qry = "SELECT * FROM Product_info WHERE Code = '" + txtcode.Text + "'"; //selecting the item code details from the database table if there is any
            SqlDataAdapter ad = new SqlDataAdapter(qry, con);
            DataTable Dttb = new DataTable();
            ad.Fill(Dttb);
            if (Dttb.Rows.Count == 0)//checking if the item is still available
            {
                MessageBox.Show("Item not Available \n Enter to the product or recheck the code");
            }
            else
            {
                try
                {
                    //opening the connection if closed
                    if (con.State == ConnectionState.Closed) con.Open();
                    string show = "Select Name, Type, Category FROM Product_info WHERE Code = '" + txtcode.Text + "'";
                    SqlCommand com = new SqlCommand(show, con);
                    SqlDataReader dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        txtname.Text = dr.GetValue(0).ToString();
                        txttype.Text = dr.GetValue(1).ToString();
                        txtcat.Text = dr.GetValue(2).ToString();
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
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            showdata();
        }

        private void showdata()//showing data in a gridview
        {
            try
            {
                string qry = "SELECT * FROM Stock"; //selecting the Stock details from the database table
                SqlDataAdapter ad = new SqlDataAdapter(qry, con);
                DataTable Dttb = new DataTable();
                ad.Fill(Dttb);
                dgvstock.DataSource = Dttb.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Today;
            string date = dt.ToString();
            string qry = "SELECT * FROM Stock WHERE Code = '" + txtcode.Text + "'"; //selecting the item code details from the database table if there is any
            SqlDataAdapter ad = new SqlDataAdapter(qry, con);
            DataTable Dttb = new DataTable();
            ad.Fill(Dttb);
            if (Dttb.Rows.Count == 0)//checking if the item is still available
            {
                MessageBox.Show("Item not Available");
            }
            else
            {
                string message = "Are you sure you want to Delete this Item?";//giving  warning to ask if need to be actualy deleted
                string title = "Delete";
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result = MessageBox.Show(message, title, buttons, icon);
                if (result == DialogResult.Yes)
                {
                    string qry1 = "SELECT * FROM Stock WHERE Code = '" + txtcode.Text + "'"; //selecting the item code details from the database table if there is any
                    SqlDataAdapter ad1 = new SqlDataAdapter(qry1, con);
                    DataTable Dttb1 = new DataTable();
                    ad1.Fill(Dttb1);
                    if (Dttb1.Rows.Count == 0)
                    {
                        MessageBox.Show("Item not Available");
                    }
                    else
                    {
                        string del = "DELETE  FROM Stock WHERE Code='" + txtcode.Text + "'";
                        SqlCommand dq = new SqlCommand(del, con);

                        string insert = "Update UpdateDate SET date = '" + date + "' WHERE id = '" + 1 + "'";
                        SqlCommand intab = new SqlCommand(insert, con);

                        try
                        {
                            if (con.State == ConnectionState.Closed) con.Open();
                            dq.ExecuteNonQuery();
                            intab.ExecuteNonQuery();
                            MessageBox.Show("Item Deleted Successfully!");
                            showdata();
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
                else
                {
                    MessageBox.Show("Your Data Was not Delete!");
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string rep_name = "Stock Report";
            int T_width = 100;
            int T_height = 255;
            int width = 100;
            int height = 295;
            string col1 = "Code";
            string col2 = "Name";
            string col3 = "Type";
            string col4 = "Category";
            string col5 = "Stock";

            if (con.State == ConnectionState.Closed) con.Open();

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.Graphics.DrawImage(Properties.Resources.sakubit, 350, 10, 150, 120);
            e.Graphics.DrawLine(new Pen(Color.MidnightBlue), new PointF(0, 140), new PointF(900, 140));
            e.Graphics.DrawString(rep_name, new Font("Times New Roman", 18, FontStyle.Bold), Brushes.MidnightBlue, new PointF(350, 150));


            e.Graphics.DrawString(col1, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(T_width, T_height));
            e.Graphics.DrawString(col2, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(T_width + 100, T_height));
            e.Graphics.DrawString(col3, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(T_width + 250, T_height));
            e.Graphics.DrawString(col4, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(T_width + 400, T_height));
            e.Graphics.DrawString(col5, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(T_width + 600, T_height));
            StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
           
            string last = "Last Update:- ";
            string today = "Date:- ";
            DateTime tdy = DateTime.Today;
            string now = tdy.ToString();
            string nowdt = now.Substring(0, now.Length - 11);

            
            e.Graphics.DrawString(today, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 185));
            e.Graphics.DrawString(nowdt, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(260, 175));
            e.Graphics.DrawString(last, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 215));
            string update = "SELECT date FROM UpdateDate WHERE id='"+1+"'";
            SqlCommand com1 = new SqlCommand(update, con);
            SqlDataReader dr1 = com1.ExecuteReader();
            while (dr1.Read())
            {
                try
                {
                    string lastdate = dr1.GetValue(0).ToString();
                    
                    e.Graphics.DrawString(lastdate.Substring(0,lastdate.Length-11), new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(260, 215));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            dr1.Close();







            string query = "SELECT * FROM Stock";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                try
                {
                    e.Graphics.DrawString(dr.GetValue(0).ToString(), new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(width, height));
                    e.Graphics.DrawString(dr.GetValue(1).ToString(), new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(width + 100, height));
                    e.Graphics.DrawString(dr.GetValue(2).ToString(), new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(width + 250, height));
                    e.Graphics.DrawString(dr.GetValue(3).ToString(), new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(width + 400, height));
                    e.Graphics.DrawString(dr.GetValue(4).ToString(), new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(width + 650, height),format);
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

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
