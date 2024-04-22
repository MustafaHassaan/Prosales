namespace Prosales.View
{
    partial class POS
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POS));
            this.TSS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.LblId = new System.Windows.Forms.Label();
            this.LblFN = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Payment = new System.Windows.Forms.Panel();
            this.BtnSale = new MetroFramework.Controls.MetroTile();
            this.label3 = new System.Windows.Forms.Label();
            this.TR = new System.Windows.Forms.Label();
            this.CBS = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CBC = new System.Windows.Forms.ComboBox();
            this.BN = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Billnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Caregory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Store = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Flages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.Payment.SuspendLayout();
            this.SuspendLayout();
            // 
            // TSS
            // 
            this.TSS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TSS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.TSS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TSS.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSS.ForeColor = System.Drawing.Color.White;
            this.TSS.Location = new System.Drawing.Point(174, 95);
            this.TSS.Name = "TSS";
            this.TSS.Size = new System.Drawing.Size(956, 20);
            this.TSS.TabIndex = 202;
            this.TSS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TSS_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label4.Location = new System.Drawing.Point(14, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 23);
            this.label4.TabIndex = 204;
            this.label4.Text = "Product Search";
            // 
            // DGV
            // 
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.DGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Billnumber,
            this.ProId,
            this.ProductName,
            this.Parcode,
            this.Caregory,
            this.Unit,
            this.Store,
            this.Qty,
            this.Price,
            this.Sales,
            this.Result,
            this.Flages});
            this.DGV.Location = new System.Drawing.Point(23, 168);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(1112, 364);
            this.DGV.TabIndex = 203;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // LblId
            // 
            this.LblId.AutoSize = true;
            this.LblId.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.LblId.Location = new System.Drawing.Point(230, 60);
            this.LblId.Name = "LblId";
            this.LblId.Size = new System.Drawing.Size(22, 23);
            this.LblId.TabIndex = 207;
            this.LblId.Text = "0";
            this.LblId.Visible = false;
            // 
            // LblFN
            // 
            this.LblFN.AutoSize = true;
            this.LblFN.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.LblFN.Location = new System.Drawing.Point(124, 60);
            this.LblFN.Name = "LblFN";
            this.LblFN.Size = new System.Drawing.Size(100, 23);
            this.LblFN.TabIndex = 206;
            this.LblFN.Text = "FullName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label1.Location = new System.Drawing.Point(23, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 23);
            this.label1.TabIndex = 205;
            this.label1.Text = "Welcom : ";
            // 
            // Payment
            // 
            this.Payment.BackColor = System.Drawing.Color.Transparent;
            this.Payment.Controls.Add(this.BtnSale);
            this.Payment.Controls.Add(this.label3);
            this.Payment.Controls.Add(this.TR);
            this.Payment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Payment.Location = new System.Drawing.Point(20, 538);
            this.Payment.Name = "Payment";
            this.Payment.Size = new System.Drawing.Size(1118, 121);
            this.Payment.TabIndex = 208;
            this.Payment.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BtnSale
            // 
            this.BtnSale.ActiveControl = null;
            this.BtnSale.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnSale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSale.Location = new System.Drawing.Point(3, 3);
            this.BtnSale.Name = "BtnSale";
            this.BtnSale.Size = new System.Drawing.Size(102, 115);
            this.BtnSale.TabIndex = 2;
            this.BtnSale.Text = "Sale";
            this.BtnSale.TileImage = global::Prosales.Properties.Resources.land_sales_32px;
            this.BtnSale.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnSale.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.BtnSale.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.BtnSale.UseSelectable = true;
            this.BtnSale.UseTileImage = true;
            this.BtnSale.Click += new System.EventHandler(this.BtnSale_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label3.Location = new System.Drawing.Point(879, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 23);
            this.label3.TabIndex = 205;
            this.label3.Text = "Tottal : ";
            // 
            // TR
            // 
            this.TR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TR.AutoSize = true;
            this.TR.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.TR.Location = new System.Drawing.Point(997, 76);
            this.TR.Name = "TR";
            this.TR.Size = new System.Drawing.Size(22, 23);
            this.TR.TabIndex = 206;
            this.TR.Text = "0";
            // 
            // CBS
            // 
            this.CBS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.CBS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBS.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBS.ForeColor = System.Drawing.Color.White;
            this.CBS.FormattingEnabled = true;
            this.CBS.Location = new System.Drawing.Point(174, 123);
            this.CBS.Name = "CBS";
            this.CBS.Size = new System.Drawing.Size(210, 26);
            this.CBS.TabIndex = 212;
            this.CBS.SelectedIndexChanged += new System.EventHandler(this.CBS_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label6.Location = new System.Drawing.Point(14, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 23);
            this.label6.TabIndex = 211;
            this.label6.Text = "Type Of Sale";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label5.Location = new System.Drawing.Point(775, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 23);
            this.label5.TabIndex = 211;
            this.label5.Text = "Customers";
            // 
            // CBC
            // 
            this.CBC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CBC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.CBC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBC.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBC.ForeColor = System.Drawing.Color.White;
            this.CBC.FormattingEnabled = true;
            this.CBC.Location = new System.Drawing.Point(893, 121);
            this.CBC.Name = "CBC";
            this.CBC.Size = new System.Drawing.Size(237, 26);
            this.CBC.TabIndex = 212;
            this.CBC.SelectionChangeCommitted += new System.EventHandler(this.CBC_SelectionChangeCommitted);
            // 
            // BN
            // 
            this.BN.AutoSize = true;
            this.BN.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.BN.Location = new System.Drawing.Point(230, 27);
            this.BN.Name = "BN";
            this.BN.Size = new System.Drawing.Size(22, 23);
            this.BN.TabIndex = 214;
            this.BN.Text = "0";
            this.BN.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label7.Location = new System.Drawing.Point(82, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 23);
            this.label7.TabIndex = 213;
            this.label7.Text = "Bill Number : ";
            this.label7.Visible = false;
            // 
            // Billnumber
            // 
            this.Billnumber.HeaderText = "Billnumber";
            this.Billnumber.Name = "Billnumber";
            this.Billnumber.Visible = false;
            // 
            // ProId
            // 
            this.ProId.HeaderText = "ProId";
            this.ProId.Name = "ProId";
            this.ProId.Visible = false;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Productname";
            this.ProductName.Name = "ProductName";
            // 
            // Parcode
            // 
            this.Parcode.HeaderText = "Parcode";
            this.Parcode.Name = "Parcode";
            // 
            // Caregory
            // 
            this.Caregory.HeaderText = "Caregory";
            this.Caregory.Name = "Caregory";
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            // 
            // Store
            // 
            this.Store.HeaderText = "Store";
            this.Store.Name = "Store";
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Quantity";
            this.Qty.Name = "Qty";
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // Sales
            // 
            this.Sales.HeaderText = "Sales";
            this.Sales.Name = "Sales";
            // 
            // Result
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.Result.DefaultCellStyle = dataGridViewCellStyle1;
            this.Result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Result.HeaderText = "Delete";
            this.Result.Name = "Result";
            this.Result.Text = "Delete";
            this.Result.UseColumnTextForButtonValue = true;
            // 
            // Flages
            // 
            this.Flages.HeaderText = "Flages";
            this.Flages.Name = "Flages";
            this.Flages.Visible = false;
            // 
            // POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 679);
            this.Controls.Add(this.BN);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CBC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CBS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Payment);
            this.Controls.Add(this.LblId);
            this.Controls.Add(this.LblFN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TSS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DGV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "POS";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "P.O.S";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.POS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.Payment.ResumeLayout(false);
            this.Payment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TSS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label LblId;
        private System.Windows.Forms.Label LblFN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Payment;
        private MetroFramework.Controls.MetroTile BtnSale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TR;
        public System.Windows.Forms.ComboBox CBS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox CBC;
        private System.Windows.Forms.Label BN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Billnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caregory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Store;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sales;
        private System.Windows.Forms.DataGridViewButtonColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flages;
    }
}