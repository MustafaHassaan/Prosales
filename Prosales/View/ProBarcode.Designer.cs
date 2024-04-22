namespace Prosales.View
{
    partial class ProBarcode
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
            this.BtnDel = new System.Windows.Forms.Button();
            this.LblId = new System.Windows.Forms.Label();
            this.LblSid = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PS = new System.Windows.Forms.TextBox();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.Btndone = new System.Windows.Forms.Button();
            this.Lblu = new System.Windows.Forms.Label();
            this.Lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
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
            this.BtnDel.Location = new System.Drawing.Point(155, 490);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(85, 41);
            this.BtnDel.TabIndex = 292;
            this.BtnDel.Text = "Delete";
            this.BtnDel.UseVisualStyleBackColor = false;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // LblId
            // 
            this.LblId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblId.AutoSize = true;
            this.LblId.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.LblId.Location = new System.Drawing.Point(424, 32);
            this.LblId.Name = "LblId";
            this.LblId.Size = new System.Drawing.Size(22, 23);
            this.LblId.TabIndex = 290;
            this.LblId.Text = "0";
            this.LblId.Visible = false;
            // 
            // LblSid
            // 
            this.LblSid.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSid.AutoSize = true;
            this.LblSid.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.LblSid.Location = new System.Drawing.Point(452, 32);
            this.LblSid.Name = "LblSid";
            this.LblSid.Size = new System.Drawing.Size(22, 23);
            this.LblSid.TabIndex = 291;
            this.LblSid.Text = "0";
            this.LblSid.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label2.Location = new System.Drawing.Point(23, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 23);
            this.label2.TabIndex = 289;
            this.label2.Text = "Product Barcode";
            // 
            // PS
            // 
            this.PS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.PS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PS.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PS.ForeColor = System.Drawing.Color.White;
            this.PS.Location = new System.Drawing.Point(196, 93);
            this.PS.Name = "PS";
            this.PS.Size = new System.Drawing.Size(278, 20);
            this.PS.TabIndex = 288;
            this.PS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PS_KeyDown);
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
            this.DGV.Location = new System.Drawing.Point(23, 119);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(451, 365);
            this.DGV.TabIndex = 287;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // Btndone
            // 
            this.Btndone.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btndone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.Btndone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btndone.FlatAppearance.BorderSize = 0;
            this.Btndone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btndone.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btndone.ForeColor = System.Drawing.Color.White;
            this.Btndone.Location = new System.Drawing.Point(246, 490);
            this.Btndone.Name = "Btndone";
            this.Btndone.Size = new System.Drawing.Size(85, 41);
            this.Btndone.TabIndex = 292;
            this.Btndone.Text = "Done";
            this.Btndone.UseVisualStyleBackColor = false;
            this.Btndone.Click += new System.EventHandler(this.Btndone_Click);
            // 
            // Lblu
            // 
            this.Lblu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Lblu.AutoSize = true;
            this.Lblu.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lblu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.Lblu.Location = new System.Drawing.Point(396, 32);
            this.Lblu.Name = "Lblu";
            this.Lblu.Size = new System.Drawing.Size(22, 23);
            this.Lblu.TabIndex = 290;
            this.Lblu.Text = "0";
            this.Lblu.Visible = false;
            // 
            // Lbl
            // 
            this.Lbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Lbl.AutoSize = true;
            this.Lbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.Lbl.Location = new System.Drawing.Point(368, 32);
            this.Lbl.Name = "Lbl";
            this.Lbl.Size = new System.Drawing.Size(22, 23);
            this.Lbl.TabIndex = 290;
            this.Lbl.Text = "0";
            this.Lbl.Visible = false;
            // 
            // ProBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 544);
            this.ControlBox = false;
            this.Controls.Add(this.Btndone);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.Lbl);
            this.Controls.Add(this.Lblu);
            this.Controls.Add(this.LblId);
            this.Controls.Add(this.LblSid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PS);
            this.Controls.Add(this.DGV);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProBarcode";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "ProBarcode";
            this.Load += new System.EventHandler(this.ProBarcode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.Label LblId;
        private System.Windows.Forms.Label LblSid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PS;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button Btndone;
        private System.Windows.Forms.Label Lblu;
        private System.Windows.Forms.Label Lbl;
    }
}