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
    public partial class Product : Form
    {
        //connecting the database with the form
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\sakuraDB\Sakuradb.mdf;Integrated Security=True;Connect Timeout=30");

        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            showdata();//line 160
        }
        
        /// <summary>
        /// front(login) opens and closes what ever left in the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            this.WindowState = FormWindowState.Minimized;//minimising the form minimise the form
        }

        private void catshow_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                string qry = "SELECT * FROM Product_info WHERE Type = '" + txtcat.Text + "'"; //selecting the Type details from the database table
                SqlDataAdapter ad = new SqlDataAdapter(qry, con);//this retirives the data from the database to the datatable below
                DataTable DTb = new DataTable();//datatable represents the data recieved by the dataadaptor in datarows and datacolumns
                ad.Fill(DTb);//fills the datatable
                if (DTb.Rows.Count > 0)//To check whether the entered through the textbox is there in the table
                {
                    try
                    {
                        dgvproduct.DataSource = DTb.DefaultView;//fills the datagridview with the data taken into the datatable
                        txtcat.Text = "";//clear the textbox
                        checkBox1.Checked = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Type entered does not exist!");
                }


              
            }

            if (checkBox3.Checked)
            {

                string qry = "SELECT * FROM Product_info WHERE Category = '" + txtcat.Text + "'"; //selecting the Category details from the database table
                SqlDataAdapter ad = new SqlDataAdapter(qry, con);//this retirives the data from the database to the datatable below
                DataTable DTb = new DataTable();//datatable represents the data recieved by the dataadaptor in datarows and datacolumns
                ad.Fill(DTb);//fills the datatable
                if (DTb.Rows.Count > 0)//To check whether the entered through the textbox is there in the table
                {
                    try
                    {
                        dgvproduct.DataSource = DTb.DefaultView;//fills the datagridview with the data taken into the datatable
                        txtcat.Text = "";
                        checkBox3.Checked = false;
                    }
                    catch (Exception ex)//exception handling
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Category entered does not exist!");
                }

            }

            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3.Checked = false;//unchecking a checkbox if this is checked          
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;//unchecking a checkbox if this is checked 
        }
        
        private void addpro_Click(object sender, EventArgs e)
        {
            if (Codetxt.Text == "" || Nametxt.Text == "" || Typetxt.Text == "" || Cattxt.Text == "" || Pricetxt.Text == "")
            {
                MessageBox.Show("Enter the required fields");
            }
            else
            {
                try
                {
                    string qry = "SELECT * FROM Product_info WHERE Code = '" + Codetxt.Text + "'"; //selecting the item code details from the database table if there is any
                    SqlDataAdapter ad = new SqlDataAdapter(qry, con);
                    DataTable Dttb = new DataTable();
                    ad.Fill(Dttb);//filling virtual data table
                    if (Dttb.Rows.Count == 1)//checking whether the code is already there
                    {
                        MessageBox.Show("Item Code already in System \n Update Product or \n Enter a new Item Code");//send error message if the code is already available
                    }
                    else
                    {
                        //insert query
                        string insert = "Insert INTO Product_info VALUES ('" + Codetxt.Text + "', '" + Nametxt.Text + "', '" + Typetxt.Text + "', '" + Cattxt.Text + "', '" + Pricetxt.Text + "')";

                        SqlCommand enter = new SqlCommand(insert, con);
                        try
                        {
                            con.Open();
                            enter.ExecuteNonQuery();
                            MessageBox.Show("Data Successfully Entered");
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showdata();

        }

        private void showdata()//showing data in a gridview
        {
            try
            {
                string qry = "SELECT * FROM Product_info"; //selecting the product_info details from the database table
                SqlDataAdapter ad = new SqlDataAdapter(qry, con);
                DataTable Dttb = new DataTable();
                ad.Fill(Dttb);
                dgvproduct.DataSource = Dttb.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void clear()//clearing out the text field
        {
            Codetxt.Text = "";
            Nametxt.Text = "";
            Typetxt.Text = "";
            Cattxt.Text = "";
            Pricetxt.Text = "";
        }

        private void updpro_Click(object sender, EventArgs e)
        {
            string qry = "SELECT * FROM Product_info WHERE Code = '" + Codetxt.Text + "'"; //selecting the item code details from the database table if there is any
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
                string upd = "UPDATE Product_info SET Name='" + Nametxt.Text + "', Type='" + Typetxt.Text + "', Category='" + Cattxt.Text + "', Price='" + int.Parse(Pricetxt.Text) + "' WHERE Code='" + Codetxt.Text + "'";
                SqlCommand up = new SqlCommand(upd, con);
                try
                {
                    con.Open();
                    up.ExecuteNonQuery();
                    MessageBox.Show("Product Information Updated!");
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

        private void Codetxt_TextChanged(object sender, EventArgs e)//filing the rest of the text boxes when the code is added 
        {
            try
            {
                //opening the connection if closed
                if (con.State == ConnectionState.Closed) con.Open();
                string show = "Select Name, Type, Category, Price FROM Product_info WHERE Code = '" + Codetxt.Text + "'";
                SqlCommand com = new SqlCommand(show, con);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    Nametxt.Text = dr.GetValue(0).ToString();
                    Typetxt.Text = dr.GetValue(1).ToString();
                    Cattxt.Text = dr.GetValue(2).ToString();
                    Pricetxt.Text = dr.GetValue(3).ToString();
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

        private void delpro_Click(object sender, EventArgs e)
        {
            string qry = "SELECT * FROM Product_info WHERE Code = '" + Codetxt.Text + "'"; //selecting the item code details from the database table if there is any
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
                    string qry1 = "SELECT * FROM Product_info WHERE Code = '" + Codetxt.Text + "'"; //selecting the item code details from the database table if there is any
                    SqlDataAdapter ad1 = new SqlDataAdapter(qry1, con);
                    DataTable Dttb1 = new DataTable();
                    ad1.Fill(Dttb1);
                    if (Dttb1.Rows.Count == 0)
                    {
                        MessageBox.Show("Item not Available");
                    }
                    else
                    {
                        string del = "DELETE  FROM Product_info WHERE Code='" + Codetxt.Text + "'";
                        SqlCommand dq = new SqlCommand(del, con);

                        string delst = "DELETE  FROM Stock WHERE Code='" + Codetxt.Text + "'";
                        SqlCommand dqst = new SqlCommand(delst, con);

                        try
                        {
                            con.Open();
                            dq.ExecuteNonQuery();
                            dqst.ExecuteNonQuery();
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

        private void button8_Click(object sender, EventArgs e)
        {
            if (categorychk.Checked)
            {
                loadcode2();
                categorychk.Checked = false;
            }
            if (Typechk.Checked)
            {
                loadcode1();
                Typechk.Checked = false;
            }
        }

        /// <summary>
        /// the following code provides the code for bring up the required set of codes according to the type mentioned by the user
        /// datareader reads the values taken from the daatavase table and while it reads the table in the loop it is assigned to a button
        /// line:341 shows the butttons in the flowlayout panel
        /// </summary>
        private void loadcode1()
        {

            flowLayoutPanel1.Controls.Clear();
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                string query = "SELECT Code FROM Product_info WHERE Type = '" + txtSearch.Text + "'";
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
            Codetxt.Text = (sender as Button).Text;
        }

        private void loadcode2()
        {

            flowLayoutPanel1.Controls.Clear();
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                string query = "SELECT Code FROM Product_info WHERE Category = '" + txtSearch.Text + "'";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dr = com.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    Button but2 = new Button();
                    but2.Text = dr.GetValue(0).ToString();
                    but2.FlatStyle = FlatStyle.Flat;
                    but2.BackColor = Color.DarkCyan;
                    but2.Width = 157;
                    but2.Height = 47;
                    but2.ForeColor = Color.White;
                    but2.Click += But2_Click;

                    flowLayoutPanel1.Controls.Add(but2);
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
        private void But2_Click(object sender, EventArgs e)
        {
            Codetxt.Text = (sender as Button).Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string rep_name = "Product Report";
            int T_width = 100;
            int T_height = 230;
            string col1 = "Code";
            string col2 = "Name";
            string col3 = "Type";
            string col4 = "Category";
            string col5 = "Price(Rs)";

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;


            e.Graphics.DrawImage(Properties.Resources.sakubit, 350, 20, 150, 130);
            e.Graphics.DrawLine(new Pen(Color.MidnightBlue), new PointF(0, 150), new PointF(900, 140));
            e.Graphics.DrawString(rep_name, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.MidnightBlue, new PointF(350, 150));

            string today = "Date:- ";
            DateTime tdy = DateTime.Today;
            string now = tdy.ToString();
            string nowdt = now.Substring(0, now.Length - 11);


            e.Graphics.DrawString(today, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(100, 185));
            e.Graphics.DrawString(nowdt, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(260, 185));

            e.Graphics.DrawString(col1, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(T_width, T_height));
            e.Graphics.DrawString(col2, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(T_width + 100, T_height));
            e.Graphics.DrawString(col3, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(T_width + 250, T_height));
            e.Graphics.DrawString(col4, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(T_width + 400, T_height));
            e.Graphics.DrawString(col5, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new PointF(T_width + 600, T_height));

            StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);

            if (con.State == ConnectionState.Closed) con.Open();
            string query = "SELECT * FROM Product_info";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            int width = 100;
            int height = 270;
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

        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            
            
            printPreviewDialog1.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Typechk_CheckedChanged(object sender, EventArgs e)
        {
            if (categorychk.Checked == true)
            {
                categorychk.Checked = false;
            }
        }

        private void categorychk_CheckedChanged(object sender, EventArgs e)
        {
            if (Typechk.Checked == true)
            {
                Typechk.Checked = false;
            }
        }
    }
}
