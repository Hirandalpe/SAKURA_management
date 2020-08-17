using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAKURA
{
    public partial class panel : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\sakuraDB\Sakuradb.mdf;Integrated Security=True;Connect Timeout=30");


        private string _name = "Item Name";
        private string _qty = "00";
        private string _dis = "0%";
        private string _price = "Rs. 0 ";
        private string _total = "Rs. 0 ";


        public string ItemID { get; set; }
        public string BillID { get; set; }

        public string ItemName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                this.Invalidate();
            }
        }

        public string Quantity
        {
            get
            {
                return _qty;
            }
            set
            {
                _qty = value;
                this.Invalidate();
            }
        }

        public string price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = "Rs. " + value;
                this.Invalidate();
            }
        }

        public string discount
        {
            get
            {
                return _dis;
            }
            set
            {
                _dis = value + "";
                this.Invalidate();
            }
        }

        public string total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = "Rs. " + value;
                this.Invalidate();
            }
        }
        public panel()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            item.CellName = _name;
            Quant.CellName = _qty;
            Pri.CellName = _price;
            Dis.CellName = _dis;
            totprc.CellName = _total;
        }

        private void panel_Load(object sender, EventArgs e)
        {

        }

        private void column2_Load(object sender, EventArgs e)
        {

        }

        private void CHbut_Click(object sender, EventArgs e)
        {
            
        } 
    }
}
