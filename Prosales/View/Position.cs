using Prosales.Controler;
using Prosales.Model;
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
    public partial class Position : MetroFramework.Forms.MetroForm
    {
        Prosalescontext PDb;
        Model.Position POS;
        public Position()
        {
            InitializeComponent();
        }
        public async void GetPositions()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from Pos in PDb.Positions
                          select new
                          {
                              Pos.Positionname
                          };
                DGV.DataSource = Qua.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...","warning");
            }
        }
        private async void Position_Load(object sender, EventArgs e)
        {
            GetPositions();
        }
        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private async void BtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(LblId.Text);
                PDb = new Prosalescontext();
                var Pos = await PDb.Positions.Where(X => X.Id == id).FirstOrDefaultAsync();
                Pos.Positionname = TPN.Text;
                PDb.Positions.Remove(Pos);
                await PDb.SaveChangesAsync();
                GetPositions();
                TPN.Clear();
                MessageBox.Show("Position Is Deleting Successfully ...", "Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Cant delete this position becouse his added to user ...", "warning");
            }
        }
        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(LblId.Text);
                PDb = new Prosalescontext();
                var Pos = await PDb.Positions.Where(X => X.Id == id).FirstOrDefaultAsync();
                Pos.Positionname = TPN.Text;
                PDb.Entry(Pos).State = EntityState.Modified;
                await PDb.SaveChangesAsync();
                GetPositions();
                TPN.Clear();
                LblId.Text = "0";
                MessageBox.Show("Position Is Editing Successfully ...", "Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TPN.Text))
            {
                MessageBox.Show("Please Insert Position Name ...", "warning");
                return;
            }
            else
            {
                try
                {
                    PDb = new Prosalescontext();
                    Model.Position Po;
                    Po = new Model.Position();
                    Po.Positionname = TPN.Text;
                    PDb.Positions.Add(Po);
                    await PDb.SaveChangesAsync();
                    var Qua = from Pos in PDb.Positions
                              select new
                              {
                                  Pos.Id,
                                  Pos.Positionname
                              };
                    DGV.DataSource = Qua.ToList();
                    TPN.Clear();
                    MessageBox.Show("Position Is Saved Successfully ...", "Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Server Is Dowen ...", "warning");
                }
            }   
        }
        private async void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PDb = new Prosalescontext();
            POS = new Model.Position();
            if (DGV.Rows.Count > 0)
            {
                TPN.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                POS = await PDb.Positions.Where(p => p.Positionname == TPN.Text).FirstOrDefaultAsync();
                if (POS != null)
                {
                    LblId.Text = Convert.ToString(POS.Id);
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
    }
}
