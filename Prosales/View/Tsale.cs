using Prosales.Controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prosales.View
{
    public partial class Tsale : MetroFramework.Forms.MetroForm
    {
        Prosalescontext PDb;
        Model.TOSale TOS;
        public Tsale()
        {
            InitializeComponent();
        }

        //Get Type Of Sales
        public async void GTS()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from TS in PDb.TOSales
                          select new
                          {
                              TS.Salesname
                          };
                DGV.DataSource = Qua.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }
        private void Tsale_Load(object sender, EventArgs e)
        {
            GTS();
        }
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TPN.Text))
            {
                MessageBox.Show("Please Insert Type Sales Name ...", "warning");
                return;
            }
            else
            {
                try
                {
                    PDb = new Prosalescontext();
                    TOS = new Model.TOSale();
                    TOS.Salesname = TPN.Text;
                    PDb.TOSales.Add(TOS);
                    await PDb.SaveChangesAsync();
                    GTS();
                    TPN.Clear();
                    MessageBox.Show("Type Of Sales Is Saved Successfully ...", "Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Server Is Dowen ...", "warning");
                }
            }
        }
        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(LblId.Text);
                PDb = new Prosalescontext();
                var tos = await PDb.TOSales.Where(X => X.Id == id).FirstOrDefaultAsync();
                tos.Salesname = TPN.Text;
                PDb.Entry(tos).State = EntityState.Modified;
                await PDb.SaveChangesAsync();
                GTS();
                TPN.Clear();
                BtnEdit.Enabled = false;
                BtnDel.Enabled = false;
                LblId.Text = "0";
                MessageBox.Show("Type Of Sales Is Editing Successfully ...", "Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }
        private async void BtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(LblId.Text);
                PDb = new Prosalescontext();
                var tos = await PDb.TOSales.Where(X => X.Id == id).FirstOrDefaultAsync();
                tos.Salesname = TPN.Text;
                PDb.TOSales.Remove(tos);
                await PDb.SaveChangesAsync();
                GTS();
                TPN.Clear();
                LblId.Text = "0";
                BtnEdit.Enabled = false;
                BtnDel.Enabled = false;
                MessageBox.Show("Type Of Sales Is Deleting Successfully ...", "Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Cant delete This type becouse his added to sales ...", "warning");
            }
        }
        private async void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PDb = new Prosalescontext();
            TOS = new Model.TOSale();
            if (DGV.Rows.Count > 0)
            {
                TPN.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                TOS = await PDb.TOSales.Where(s => s.Salesname == TPN.Text).FirstOrDefaultAsync();
                if (TOS != null)
                {
                    LblId.Text = Convert.ToString(TOS.Id);
                }
                else
                {
                    return;
                }
                BtnAdd.Enabled = false;
                BtnEdit.Enabled = true;
                BtnDel.Enabled = true;
            }
        }
        private void TPN_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TPN.Text))
            {
                BtnAdd.Enabled = true;
            }
            else
            {
                BtnAdd.Enabled = false;
            }
        }
    }
}
