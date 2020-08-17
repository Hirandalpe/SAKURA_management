namespace SAKURA
{
    partial class panel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(panel));
            System.Drawing.StringFormat stringFormat1 = new System.Drawing.StringFormat();
            System.Drawing.StringFormat stringFormat2 = new System.Drawing.StringFormat();
            System.Drawing.StringFormat stringFormat3 = new System.Drawing.StringFormat();
            System.Drawing.StringFormat stringFormat4 = new System.Drawing.StringFormat();
            System.Drawing.StringFormat stringFormat5 = new System.Drawing.StringFormat();
            this.CHbut = new System.Windows.Forms.Button();
            this.totprc = new SAKURA.column();
            this.Dis = new SAKURA.column();
            this.Pri = new SAKURA.column();
            this.Quant = new SAKURA.column();
            this.item = new SAKURA.column();
            this.SuspendLayout();
            // 
            // CHbut
            // 
            this.CHbut.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CHbut.BackgroundImage")));
            this.CHbut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CHbut.Dock = System.Windows.Forms.DockStyle.Right;
            this.CHbut.FlatAppearance.BorderSize = 0;
            this.CHbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHbut.Location = new System.Drawing.Point(968, 0);
            this.CHbut.Name = "CHbut";
            this.CHbut.Size = new System.Drawing.Size(64, 49);
            this.CHbut.TabIndex = 5;
            this.CHbut.UseVisualStyleBackColor = true;
            this.CHbut.Click += new System.EventHandler(this.CHbut_Click);
            // 
            // totprc
            // 
            this.totprc.CellName = "TotalPrice";
            this.totprc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totprc.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totprc.Location = new System.Drawing.Point(717, 0);
            this.totprc.Margin = new System.Windows.Forms.Padding(4);
            this.totprc.Name = "totprc";
            this.totprc.Size = new System.Drawing.Size(315, 49);
            stringFormat1.Alignment = System.Drawing.StringAlignment.Center;
            stringFormat1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            stringFormat1.LineAlignment = System.Drawing.StringAlignment.Center;
            stringFormat1.Trimming = System.Drawing.StringTrimming.Character;
            this.totprc.StringFormat = stringFormat1;
            this.totprc.TabIndex = 4;
            // 
            // Dis
            // 
            this.Dis.CellName = "Discount";
            this.Dis.Dock = System.Windows.Forms.DockStyle.Left;
            this.Dis.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dis.Location = new System.Drawing.Point(558, 0);
            this.Dis.Margin = new System.Windows.Forms.Padding(4);
            this.Dis.Name = "Dis";
            this.Dis.Size = new System.Drawing.Size(159, 49);
            stringFormat2.Alignment = System.Drawing.StringAlignment.Center;
            stringFormat2.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            stringFormat2.LineAlignment = System.Drawing.StringAlignment.Center;
            stringFormat2.Trimming = System.Drawing.StringTrimming.Character;
            this.Dis.StringFormat = stringFormat2;
            this.Dis.TabIndex = 3;
            // 
            // Pri
            // 
            this.Pri.CellName = "Price";
            this.Pri.Dock = System.Windows.Forms.DockStyle.Left;
            this.Pri.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pri.Location = new System.Drawing.Point(403, 0);
            this.Pri.Margin = new System.Windows.Forms.Padding(4);
            this.Pri.Name = "Pri";
            this.Pri.Size = new System.Drawing.Size(155, 49);
            stringFormat3.Alignment = System.Drawing.StringAlignment.Center;
            stringFormat3.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            stringFormat3.LineAlignment = System.Drawing.StringAlignment.Center;
            stringFormat3.Trimming = System.Drawing.StringTrimming.Character;
            this.Pri.StringFormat = stringFormat3;
            this.Pri.TabIndex = 2;
            // 
            // Quant
            // 
            this.Quant.CellName = "Quantity";
            this.Quant.Dock = System.Windows.Forms.DockStyle.Left;
            this.Quant.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quant.Location = new System.Drawing.Point(256, 0);
            this.Quant.Margin = new System.Windows.Forms.Padding(4);
            this.Quant.Name = "Quant";
            this.Quant.Size = new System.Drawing.Size(147, 49);
            stringFormat4.Alignment = System.Drawing.StringAlignment.Center;
            stringFormat4.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            stringFormat4.LineAlignment = System.Drawing.StringAlignment.Center;
            stringFormat4.Trimming = System.Drawing.StringTrimming.Character;
            this.Quant.StringFormat = stringFormat4;
            this.Quant.TabIndex = 1;
            // 
            // item
            // 
            this.item.CellName = "ItemName";
            this.item.Dock = System.Windows.Forms.DockStyle.Left;
            this.item.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item.Location = new System.Drawing.Point(0, 0);
            this.item.Margin = new System.Windows.Forms.Padding(4);
            this.item.Name = "item";
            this.item.Size = new System.Drawing.Size(256, 49);
            stringFormat5.Alignment = System.Drawing.StringAlignment.Center;
            stringFormat5.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            stringFormat5.LineAlignment = System.Drawing.StringAlignment.Center;
            stringFormat5.Trimming = System.Drawing.StringTrimming.Character;
            this.item.StringFormat = stringFormat5;
            this.item.TabIndex = 0;
            // 
            // panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.CHbut);
            this.Controls.Add(this.totprc);
            this.Controls.Add(this.Dis);
            this.Controls.Add(this.Pri);
            this.Controls.Add(this.Quant);
            this.Controls.Add(this.item);
            this.Name = "panel";
            this.Size = new System.Drawing.Size(1032, 49);
            this.Load += new System.EventHandler(this.panel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private column item;
        private column Quant;
        private column Pri;
        private column Dis;
        private column totprc;
        public System.Windows.Forms.Button CHbut;
    }
}
