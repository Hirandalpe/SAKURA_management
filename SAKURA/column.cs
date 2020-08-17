using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAKURA
{
    public partial class column : UserControl
    {
        private string _Cellname = "Name";

        private StringFormat _stringFormat = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };


        public string CellName
        {
            get
            {
                return _Cellname;
            }


            set
            {
                _Cellname = value;
                this.Invalidate();
            }
        }

        public StringFormat StringFormat
        {
            get
            {
                return _stringFormat;
            }
            set
            {
                _stringFormat = value;
                this.Invalidate();
            }
        }


        public column()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rectangle = new Rectangle(0, 0, this.Width - 2, this.Height);

            g.DrawString(_Cellname, DefaultFont, new SolidBrush(ForeColor), rectangle, _stringFormat);
            g.DrawLine(new Pen(Color.Silver), this.Width - 2, 10, this.Width - 2, this.Height - 5);

        }




        private void column_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
