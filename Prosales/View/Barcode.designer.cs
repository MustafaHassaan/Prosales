namespace Prosales.View
{
    partial class Barcode
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.PQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btnex = new System.Windows.Forms.Button();
            this.Pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic)).BeginInit();
            this.SuspendLayout();
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
            this.PQ});
            this.DGV.Location = new System.Drawing.Point(23, 180);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(291, 233);
            this.DGV.TabIndex = 29;
            // 
            // PQ
            // 
            this.PQ.HeaderText = "Barcode";
            this.PQ.Name = "PQ";
            // 
            // TCN
            // 
            this.TCN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TCN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.TCN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TCN.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCN.ForeColor = System.Drawing.Color.White;
            this.TCN.Location = new System.Drawing.Point(114, 154);
            this.TCN.Name = "TCN";
            this.TCN.Size = new System.Drawing.Size(200, 20);
            this.TCN.TabIndex = 31;
            this.TCN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TCN_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label1.Location = new System.Drawing.Point(22, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label2.Location = new System.Drawing.Point(22, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 18);
            this.label2.TabIndex = 33;
            this.label2.Text = "How many barcode you want generat ?";
            // 
            // Btnex
            // 
            this.Btnex.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btnex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.Btnex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btnex.FlatAppearance.BorderSize = 0;
            this.Btnex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnex.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnex.ForeColor = System.Drawing.Color.White;
            this.Btnex.Location = new System.Drawing.Point(117, 424);
            this.Btnex.Name = "Btnex";
            this.Btnex.Size = new System.Drawing.Size(85, 41);
            this.Btnex.TabIndex = 34;
            this.Btnex.Text = "Export";
            this.Btnex.UseVisualStyleBackColor = false;
            this.Btnex.Click += new System.EventHandler(this.Btnex_Click);
            // 
            // Pic
            // 
            this.Pic.Location = new System.Drawing.Point(25, 93);
            this.Pic.Name = "Pic";
            this.Pic.Size = new System.Drawing.Size(289, 55);
            this.Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pic.TabIndex = 35;
            this.Pic.TabStop = false;
            // 
            // Barcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 488);
            this.Controls.Add(this.Pic);
            this.Controls.Add(this.Btnex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TCN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGV);
            this.MaximizeBox = false;
            this.Name = "Barcode";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Barcode";
            this.Load += new System.EventHandler(this.Barcode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.TextBox TCN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btnex;
        private System.Windows.Forms.DataGridViewTextBoxColumn PQ;
        private System.Windows.Forms.PictureBox Pic;
    }
}