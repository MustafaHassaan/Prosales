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
    public partial class Tcust : MetroFramework.Forms.MetroForm
    {
        Prosalescontext PDb;
        Model.TOCustomer TOC;
        public Tcust()
        {
            InitializeComponent();
        }
        //Get Type Of Customers
        public async void GTC()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from TC in PDb.TOCustomers
                          select new
                          {
                              TC.TOCname
                          };
                DGV.DataSource = Qua.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }
        private void Tcust_Load(object sender, EventArgs e)
        {
            GTC();
        }
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TPN.Text))
            {
                MessageBox.Show("Please Insert Type Customers Name ...", "warning");
                return;
            }
            else
            {
                try
                {
                    PDb = new Prosalescontext();
                    TOC = new Model.TOCustomer();
                    TOC.TOCname = TPN.Text;
                    PDb.TOCustomers.Add(TOC);
                    await PDb.SaveChangesAsync();
                    GTC();
                    TPN.Clear();
                    MessageBox.Show("Type Of Customer Is Saved Successfully ...", "Successfully");
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
                var toc = await PDb.TOCustomers.Where(X => X.Id == id).FirstOrDefaultAsync();
                toc.TOCname = TPN.Text;
                PDb.Entry(toc).State = EntityState.Modified;
                await PDb.SaveChangesAsync();
                GTC();
                TPN.Clear();
                LblId.Text = "0";
                BtnEdit.Enabled = false;
                BtnDel.Enabled = false;
                MessageBox.Show("Type Of Customer Is Editing Successfully ...", "Successfully");
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
                var toc = await PDb.TOCustomers.Where(X => X.Id == id).FirstOrDefaultAsync();
                toc.TOCname = TPN.Text;
                PDb.TOCustomers.Remove(toc);
                await PDb.SaveChangesAsync();
                GTC();
                TPN.Clear();
                LblId.Text = "0";
                BtnEdit.Enabled = false;
                BtnDel.Enabled = false;
                MessageBox.Show("Type Of Customer Is Deleting Successfully ...", "Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Cant delete this type becouse his added to customers ...", "warning");
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
        private async void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PDb = new Prosalescontext();
            TOC = new Model.TOCustomer();
            if (DGV.Rows.Count > 0)
            {
                //LblId.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                TPN.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                TOC = await PDb.TOCustomers.Where(c => c.TOCname == TPN.Text).FirstOrDefaultAsync();
                if (TOC != null)
                {
                    LblId.Text = Convert.ToString(TOC.Id);
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
