namespace Prosales.View
{
    partial class Retitem
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
            this.RBU = new System.Windows.Forms.RadioButton();
            this.RBG = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
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
            this.DGV.Location = new System.Drawing.Point(23, 63);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(670, 332);
            this.DGV.TabIndex = 32;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // RBU
            // 
            this.RBU.AutoSize = true;
            this.RBU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RBU.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.RBU.Location = new System.Drawing.Point(387, 451);
            this.RBU.Name = "RBU";
            this.RBU.Size = new System.Drawing.Size(99, 27);
            this.RBU.TabIndex = 33;
            this.RBU.TabStop = true;
            this.RBU.Text = "Un good";
            this.RBU.UseVisualStyleBackColor = true;
            // 
            // RBG
            // 
            this.RBG.AutoSize = true;
            this.RBG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RBG.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.RBG.Location = new System.Drawing.Point(206, 451);
            this.RBG.Name = "RBG";
            this.RBG.Size = new System.Drawing.Size(72, 27);
            this.RBG.TabIndex = 34;
            this.RBG.TabStop = true;
            this.RBG.Text = "Good";
            this.RBG.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(166)))), ((int)(((byte)(200)))));
            this.label1.Location = new System.Drawing.Point(167, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 23);
            this.label1.TabIndex = 35;
            this.label1.Text = "Why customer want eturn this item ?";
            // 
            // Retitem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 491);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RBG);
            this.Controls.Add(this.RBU);
            this.Controls.Add(this.DGV);
            this.MaximizeBox = false;
            this.Name = "Retitem";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Retitem";
            this.Load += new System.EventHandler(this.Retitem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.RadioButton RBU;
        private System.Windows.Forms.RadioButton RBG;
        private System.Windows.Forms.Label label1;
    }
}