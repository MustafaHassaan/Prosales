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
    public partial class Unit : MetroFramework.Forms.MetroForm
    {
        Prosalescontext PDb;
        Model.Unit UN;
        public Unit()
        {
            InitializeComponent();
        }
        public async void GetUnits()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from Un in PDb.Units
                          select new
                          {
                              Un.Unitname
                          };
                DGV.DataSource = Qua.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }
        private void Unit_Load(object sender, EventArgs e)
        {
            GetUnits();
        }
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TUN.Text))
            {
                MessageBox.Show("Please Insert Unit Name ...", "warning");
                return;
            }
            else
            {
                try
                {
                    PDb = new Prosalescontext();
                    UN = new Model.Unit();
                    UN.Unitname = TUN.Text;
                    PDb.Units.Add(UN);
                    await PDb.SaveChangesAsync();
                    GetUnits();
                    TUN.Clear();
                    MessageBox.Show("Unit Is Saved Successfully ...", "Successfully");
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
                UN = new Model.Unit();
                UN = await PDb.Units.Where(X => X.Id == id).FirstOrDefaultAsync();
                UN.Unitname = TUN.Text;
                PDb.Entry(UN).State = EntityState.Modified;
                await PDb.SaveChangesAsync();
                GetUnits();
                TUN.Clear();
                LblId.Text = "0";
                BtnEdit.Enabled = false;
                BtnDel.Enabled = false;
                MessageBox.Show("Unit Is Editing Successfully ...", "Successfully");
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
                UN = new Model.Unit();
                UN = await PDb.Units.Where(X => X.Id == id).FirstOrDefaultAsync();
                PDb.Units.Remove(UN);
                await PDb.SaveChangesAsync();
                GetUnits();
                TUN.Clear();
                BtnEdit.Enabled = false;
                BtnDel.Enabled = false;
                MessageBox.Show("Unit Is Deleting Successfully ...", "Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Cand delete this unit becouse his added to products ...", "warning");
            }
        }
        private async void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PDb = new Prosalescontext();
            UN = new Model.Unit();
            if (DGV.Rows.Count > 0)
            {
                TUN.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                UN = await PDb.Units.Where(u => u.Unitname == TUN.Text).FirstOrDefaultAsync();
                if (UN != null)
                {
                    LblId.Text = Convert.ToString(UN.Id);
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
        private void TUN_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TUN.Text))
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
