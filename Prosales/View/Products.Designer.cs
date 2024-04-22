namespace Prosales.View
{
    partial class Products
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
            this.LblId = new System.Windows.Forms.Label();
            this.TSS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnNew = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.Qty = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TDisc = new System.Windows.Forms.TextBox();
            this.TEP = new System.Windows.Forms.TextBox();
            this.TSN = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CBCat = new System.Windows.Forms.ComboBox();
            this.CBS = new System.Windows.Forms.ComboBox();
            this.CBU = new System.Windows.Forms.ComboBox();
            this.TSP = new System.Windows.Forms.TextBox();
            this.CBSup = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblSid = new System.Windows.Forms.Label();
            this.Mt = new MetroFramework.Controls.MetroTile();
            this.Btnr = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // LblId
            // 
            this.LblId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblId.AutoSize = true;
            this.LblId.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.LblId.Location = new System.Drawing.Point(1225, 34);
            this.LblId.Name = "LblId";
            this.LblId.Size = new System.Drawing.Size(22, 23);
            this.LblId.TabIndex = 9;
            this.LblId.Text = "0";
            this.LblId.Visible = false;
            // 
            // TSS
            // 
            this.TSS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TSS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.TSS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TSS.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSS.ForeColor = System.Drawing.Color.White;
            this.TSS.Location = new System.Drawing.Point(184, 63);
            this.TSS.Name = "TSS";
            this.TSS.Size = new System.Drawing.Size(1051, 20);
            this.TSS.TabIndex = 205;
            this.TSS.TextChanged += new System.EventHandler(this.TSS_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label4.Location = new System.Drawing.Point(24, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 23);
            this.label4.TabIndex = 206;
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
            this.DGV.Location = new System.Drawing.Point(404, 89);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(831, 358);
            this.DGV.TabIndex = 258;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.BtnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEdit.Enabled = false;
            this.BtnEdit.FlatAppearance.BorderSize = 0;
            this.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEdit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.ForeColor = System.Drawing.Color.White;
            this.BtnEdit.Location = new System.Drawing.Point(529, 475);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(85, 41);
            this.BtnEdit.TabIndex = 260;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(620, 475);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(85, 41);
            this.BtnAdd.TabIndex = 259;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.BtnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNew.FlatAppearance.BorderSize = 0;
            this.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNew.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew.ForeColor = System.Drawing.Color.White;
            this.BtnNew.Location = new System.Drawing.Point(802, 475);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(85, 41);
            this.BtnNew.TabIndex = 262;
            this.BtnNew.Text = "New";
            this.BtnNew.UseVisualStyleBackColor = false;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnDel
            // 
            this.BtnDel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.BtnDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDel.Enabled = false;
            this.BtnDel.FlatAppearance.BorderSize = 0;
            this.BtnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDel.ForeColor = System.Drawing.Color.White;
            this.BtnDel.Location = new System.Drawing.Point(711, 475);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(85, 41);
            this.BtnDel.TabIndex = 261;
            this.BtnDel.Text = "Delete";
            this.BtnDel.UseVisualStyleBackColor = false;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label13.Location = new System.Drawing.Point(24, 319);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 23);
            this.label13.TabIndex = 285;
            this.label13.Text = "Quantity";
            // 
            // Qty
            // 
            this.Qty.AutoSize = true;
            this.Qty.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Qty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.Qty.Location = new System.Drawing.Point(180, 319);
            this.Qty.Name = "Qty";
            this.Qty.Size = new System.Drawing.Size(22, 23);
            this.Qty.TabIndex = 284;
            this.Qty.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label11.Location = new System.Drawing.Point(24, 293);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 23);
            this.label11.TabIndex = 267;
            this.label11.Text = "Discounts";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label1.Location = new System.Drawing.Point(24, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 23);
            this.label1.TabIndex = 277;
            this.label1.Text = "Product Name";
            // 
            // TDisc
            // 
            this.TDisc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.TDisc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TDisc.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TDisc.ForeColor = System.Drawing.Color.White;
            this.TDisc.Location = new System.Drawing.Point(184, 296);
            this.TDisc.MaxLength = 11;
            this.TDisc.Name = "TDisc";
            this.TDisc.Size = new System.Drawing.Size(193, 20);
            this.TDisc.TabIndex = 265;
            // 
            // TEP
            // 
            this.TEP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.TEP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TEP.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEP.ForeColor = System.Drawing.Color.White;
            this.TEP.Location = new System.Drawing.Point(184, 270);
            this.TEP.MaxLength = 11;
            this.TEP.Name = "TEP";
            this.TEP.Size = new System.Drawing.Size(193, 20);
            this.TEP.TabIndex = 264;
            this.TEP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEP_KeyPress);
            // 
            // TSN
            // 
            this.TSN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.TSN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TSN.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSN.ForeColor = System.Drawing.Color.White;
            this.TSN.Location = new System.Drawing.Point(184, 90);
            this.TSN.Name = "TSN";
            this.TSN.Size = new System.Drawing.Size(193, 20);
            this.TSN.TabIndex = 270;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label10.Location = new System.Drawing.Point(24, 267);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 23);
            this.label10.TabIndex = 266;
            this.label10.Text = "End price";
            // 
            // CBCat
            // 
            this.CBCat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.CBCat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBCat.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBCat.ForeColor = System.Drawing.Color.White;
            this.CBCat.FormattingEnabled = true;
            this.CBCat.Location = new System.Drawing.Point(184, 148);
            this.CBCat.Name = "CBCat";
            this.CBCat.Size = new System.Drawing.Size(193, 26);
            this.CBCat.TabIndex = 272;
            // 
            // CBS
            // 
            this.CBS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.CBS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBS.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBS.ForeColor = System.Drawing.Color.White;
            this.CBS.FormattingEnabled = true;
            this.CBS.Location = new System.Drawing.Point(184, 180);
            this.CBS.Name = "CBS";
            this.CBS.Size = new System.Drawing.Size(193, 26);
            this.CBS.TabIndex = 275;
            // 
            // CBU
            // 
            this.CBU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.CBU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBU.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBU.ForeColor = System.Drawing.Color.White;
            this.CBU.FormattingEnabled = true;
            this.CBU.Location = new System.Drawing.Point(184, 116);
            this.CBU.Name = "CBU";
            this.CBU.Size = new System.Drawing.Size(193, 26);
            this.CBU.TabIndex = 271;
            // 
            // TSP
            // 
            this.TSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.TSP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TSP.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSP.ForeColor = System.Drawing.Color.White;
            this.TSP.Location = new System.Drawing.Point(184, 244);
            this.TSP.MaxLength = 11;
            this.TSP.Name = "TSP";
            this.TSP.Size = new System.Drawing.Size(193, 20);
            this.TSP.TabIndex = 274;
            this.TSP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TSP_KeyPress);
            // 
            // CBSup
            // 
            this.CBSup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.CBSup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBSup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBSup.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBSup.ForeColor = System.Drawing.Color.White;
            this.CBSup.FormattingEnabled = true;
            this.CBSup.Location = new System.Drawing.Point(184, 212);
            this.CBSup.Name = "CBSup";
            this.CBSup.Size = new System.Drawing.Size(193, 26);
            this.CBSup.TabIndex = 273;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label7.Location = new System.Drawing.Point(24, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 23);
            this.label7.TabIndex = 281;
            this.label7.Text = "Category";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label8.Location = new System.Drawing.Point(24, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 23);
            this.label8.TabIndex = 282;
            this.label8.Text = "Supplier";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label3.Location = new System.Drawing.Point(24, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 23);
            this.label3.TabIndex = 279;
            this.label3.Text = "Start price";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label9.Location = new System.Drawing.Point(24, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 23);
            this.label9.TabIndex = 283;
            this.label9.Text = "Store";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label6.Location = new System.Drawing.Point(24, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 23);
            this.label6.TabIndex = 280;
            this.label6.Text = "Unit";
            // 
            // LblSid
            // 
            this.LblSid.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSid.AutoSize = true;
            this.LblSid.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.LblSid.Location = new System.Drawing.Point(1197, 34);
            this.LblSid.Name = "LblSid";
            this.LblSid.Size = new System.Drawing.Size(22, 23);
            this.LblSid.TabIndex = 9;
            this.LblSid.Text = "0";
            this.LblSid.Visible = false;
            // 
            // Mt
            // 
            this.Mt.ActiveControl = null;
            this.Mt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Mt.Location = new System.Drawing.Point(28, 356);
            this.Mt.Name = "Mt";
            this.Mt.Size = new System.Drawing.Size(169, 91);
            this.Mt.TabIndex = 286;
            this.Mt.Text = "metroTile1";
            this.Mt.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.Mt.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.Mt.UseSelectable = true;
            this.Mt.Click += new System.EventHandler(this.Mt_Click);
            // 
            // Btnr
            // 
            this.Btnr.ActiveControl = null;
            this.Btnr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btnr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btnr.Location = new System.Drawing.Point(208, 356);
            this.Btnr.Name = "Btnr";
            this.Btnr.Size = new System.Drawing.Size(169, 91);
            this.Btnr.TabIndex = 287;
            this.Btnr.Text = "Report";
            this.Btnr.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btnr.TileImage = global::Prosales.Properties.Resources.bill_64px;
            this.Btnr.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btnr.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.Btnr.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.Btnr.UseSelectable = true;
            this.Btnr.UseTileImage = true;
            this.Btnr.Click += new System.EventHandler(this.Btnr_Click);
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 546);
            this.Controls.Add(this.Btnr);
            this.Controls.Add(this.Mt);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.Qty);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TDisc);
            this.Controls.Add(this.TEP);
            this.Controls.Add(this.TSN);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CBCat);
            this.Controls.Add(this.CBS);
            this.Controls.Add(this.CBU);
            this.Controls.Add(this.TSP);
            this.Controls.Add(this.CBSup);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnNew);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.TSS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LblSid);
            this.Controls.Add(this.LblId);
            this.Name = "Products";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Products";
            this.Load += new System.EventHandler(this.Pi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblId;
        private System.Windows.Forms.TextBox TSS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label Qty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TDisc;
        private System.Windows.Forms.TextBox TEP;
        private System.Windows.Forms.TextBox TSN;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox CBCat;
        public System.Windows.Forms.ComboBox CBS;
        public System.Windows.Forms.ComboBox CBU;
        private System.Windows.Forms.TextBox TSP;
        public System.Windows.Forms.ComboBox CBSup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblSid;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.DataGridView DGV;
        private MetroFramework.Controls.MetroTile Mt;
        private MetroFramework.Controls.MetroTile Btnr;
    }
}