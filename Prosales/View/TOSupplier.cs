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
    public partial class TOSupplier : MetroFramework.Forms.MetroForm
    {
        Prosalescontext PDb;
        Model.TOSupplier TOS;
        public TOSupplier()
        {
            InitializeComponent();
        }
        public void Reall()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from tos in PDb.TOSuppliers
                          select new
                          {
                              tos.TOSname
                          };
                DGV.DataSource = Qua.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
            TPN.Clear();
            LblId.Text = "0";
            BtnAdd.Enabled = false;
            BtnDel.Enabled = false;
            BtnEdit.Enabled = false;
        }
        private void TOSupplier_Load(object sender, EventArgs e)
        {
            Reall();
        }
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TPN.Text))
            {
                MessageBox.Show("Please Insert Type Of Supplier Name ...", "warning");
                return;
            }
            else
            {
                try
                {
                    PDb = new Prosalescontext();
                    TOS = new Model.TOSupplier();
                    TOS.TOSname = TPN.Text;
                    PDb.TOSuppliers.Add(TOS);
                    await PDb.SaveChangesAsync();
                    Reall();
                    MessageBox.Show("Type of Supplier Is Saved Successfully ...", "Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Server Is Dowen ...", "warning");
                }
            }
        }
        private void TPN_TextChanged(object sender, EventArgs e)
        {
            if (TPN.Text != "")
            {
                BtnAdd.Enabled = true;
            }
            else
            {
                BtnAdd.Enabled = false;
                BtnEdit.Enabled = false;
                BtnDel.Enabled = false;
            }
        }
        private async void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PDb = new Prosalescontext();
            TOS = new Model.TOSupplier();
            if (DGV.Rows.Count > 0)
            {
                //LblId.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                TPN.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                TOS = await PDb.TOSuppliers.Where(t => t.TOSname == TPN.Text).FirstOrDefaultAsync();
                if (TOS != null)
                {
                    LblId.Text = Convert.ToString(TOS.Id);
                }
                BtnAdd.Enabled = false;
                BtnEdit.Enabled = true;
                BtnDel.Enabled = true;
            }
        }
        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(LblId.Text);
                PDb = new Prosalescontext();
                var tos = await PDb.TOSuppliers.Where(X => X.Id == id).FirstOrDefaultAsync();
                tos.TOSname = TPN.Text;
                PDb.Entry(tos).State = EntityState.Modified;
                await PDb.SaveChangesAsync();
                Reall();
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
                var tos = await PDb.TOSuppliers.Where(X => X.Id == id).FirstOrDefaultAsync();
                tos.TOSname = TPN.Text;
                PDb.TOSuppliers.Remove(tos);
                await PDb.SaveChangesAsync();
                Reall();
                MessageBox.Show("Type Of Supplier Is Deleting Successfully ...", "Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Cant delete this type becouse his added to suplier ...", "warning");
            }
        }
    }
}
