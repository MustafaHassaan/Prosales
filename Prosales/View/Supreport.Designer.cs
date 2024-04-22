namespace Prosales.View
{
    partial class Supreport
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
            this.DTT = new System.Windows.Forms.DateTimePicker();
            this.DTF = new System.Windows.Forms.DateTimePicker();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.TPN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Btnr = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DTT
            // 
            this.DTT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTT.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.DTT.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTT.Location = new System.Drawing.Point(122, 90);
            this.DTT.Name = "DTT";
            this.DTT.Size = new System.Drawing.Size(904, 27);
            this.DTT.TabIndex = 32;
            this.DTT.ValueChanged += new System.EventHandler(this.DTT_ValueChanged);
            // 
            // DTF
            // 
            this.DTF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTF.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.DTF.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTF.Location = new System.Drawing.Point(122, 57);
            this.DTF.Name = "DTF";
            this.DTF.Size = new System.Drawing.Size(904, 27);
            this.DTF.TabIndex = 33;
            this.DTF.ValueChanged += new System.EventHandler(this.DTF_ValueChanged);
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
            this.DGV.Location = new System.Drawing.Point(122, 149);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(906, 364);
            this.DGV.TabIndex = 29;
            // 
            // TPN
            // 
            this.TPN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.TPN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TPN.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TPN.ForeColor = System.Drawing.Color.White;
            this.TPN.Location = new System.Drawing.Point(122, 123);
            this.TPN.Name = "TPN";
            this.TPN.Size = new System.Drawing.Size(906, 20);
            this.TPN.TabIndex = 28;
            this.TPN.TextChanged += new System.EventHandler(this.TPN_TextChanged);
            this.TPN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TPN_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label3.Location = new System.Drawing.Point(23, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 23);
            this.label3.TabIndex = 25;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label2.Location = new System.Drawing.Point(23, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 23);
            this.label2.TabIndex = 26;
            this.label2.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label1.Location = new System.Drawing.Point(23, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "Supplier";
            // 
            // Btnr
            // 
            this.Btnr.ActiveControl = null;
            this.Btnr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btnr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btnr.Location = new System.Drawing.Point(14, 407);
            this.Btnr.Name = "Btnr";
            this.Btnr.Size = new System.Drawing.Size(89, 106);
            this.Btnr.TabIndex = 34;
            this.Btnr.Text = "Report";
            this.Btnr.TileImage = global::Prosales.Properties.Resources.bill_64px;
            this.Btnr.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btnr.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.Btnr.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.Btnr.UseSelectable = true;
            this.Btnr.UseTileImage = true;
            this.Btnr.Click += new System.EventHandler(this.Btnr_Click);
            // 
            // Supreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 536);
            this.Controls.Add(this.Btnr);
            this.Controls.Add(this.DTT);
            this.Controls.Add(this.DTF);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.TPN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Supreport";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Supreport";
            this.Load += new System.EventHandler(this.Supreport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker DTT;
        private System.Windows.Forms.DateTimePicker DTF;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.TextBox TPN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTile Btnr;
    }
}