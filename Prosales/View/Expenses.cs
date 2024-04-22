using Prosales.Controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prosales.View
{
    public partial class Expenses : MetroFramework.Forms.MetroForm
    {
        Prosalescontext PDb;
        Model.Cash CH;
        Model.Expense Ex;
        public Expenses()
        {
            InitializeComponent();
        }
        public void GetTottalSum()
        {            
            try
            {
                //PDb = new Prosalescontext();
                //var Qua = from ch in PDb.Cashes
                //          where ch.Date == DateTime.Today
                //          group ch by 1 into G
                //          select new
                //          {
                //              Sum = G.Sum(x => x.Quantity)
                //          };
                //var R = Qua.AsEnumerable().Sum(o => o.Sum);
                //Tottal.Text = Convert.ToString(R);
            }
            catch (Exception)
            {
                MessageBox.Show("Ths Server Is Dowen ...", "Error");
                return;
            }
        }
        public void GetTottalId()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from ch in PDb.Cashes
                          where ch.Date == DateTime.Today
                          select new
                          {
                              ch.Id
                          };
                var R = Qua.FirstOrDefault();
                if (R == null)
                {
                    var msg = MessageBox.Show("Not have any Cash for this time ...","Warning");
                }
                else
                {
                    LblEid.Text = Convert.ToString(R.Id);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ths Server Is Dowen ...", "Error");
                return;
            }
        }
        public async void GetExpense()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from ch in PDb.Expenses
                          where ch.Date == DateTime.Today
                          select new
                          {
                              ch.Id,
                              ch.Quantity,
                              ch.Note,
                              ch.Date,
                              ch.Time
                          };
                DGV.DataSource = Qua.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }
        public async void GetExpenseByDate()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from ch in PDb.Expenses
                          where ch.Date >= DTF.Value && ch.Date <= DTT.Value
                          select new
                          {
                              ch.Id,
                              ch.Quantity,
                              ch.Date,
                              ch.Time
                          };
                DGV.DataSource = Qua.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }
        public void Reall()
        {
            DTF.Value = DateTime.Today;
            DTT.Value = DateTime.Today;
            BtnAdd.Enabled = true;
            BtnEdit.Enabled = false;
            GetExpense();
            GetTottalSum();
            GetTottalId();
            TPN.Clear();
            TN.Clear();
        }
        private void Expenses_Load(object sender, EventArgs e)
        {
            LblId.Text = Home.IDPassing;
            Reall();
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            Reall();
        }
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TPN.Text) || string.IsNullOrEmpty(TN.Text))
            {
                MessageBox.Show("Please Insert Quantity & Note ...", "warning");
                return;
            }
            else
            {
                try
                {
                    var D = DateTime.Now.ToShortDateString();
                    var T = DateTime.Now.ToLongTimeString();
                    PDb = new Prosalescontext();
                    Ex = new Model.Expense();
                    Ex.Quantity = Convert.ToDecimal(TPN.Text);
                    var ExQty = Ex.Quantity;
                    Ex.Note = TN.Text;
                    Ex.Date = Convert.ToDateTime(D);
                    Ex.Time = T;
                    Ex.UserId = Convert.ToInt32(LblId.Text);
                    PDb.Expenses.Add(Ex);
                    await PDb.SaveChangesAsync();

                    var id = int.Parse(LblEid.Text);
                    PDb = new Prosalescontext();
                    CH = new Model.Cash(); 
                    CH = await PDb.Cashes.Where(X => X.Id == id).FirstOrDefaultAsync();
                    //var ChQty = CH.Quantity;
                    //var Res = ChQty - ExQty;
                    //CH.Quantity = Res;
                    PDb.Entry(CH).State = EntityState.Modified;
                    await PDb.SaveChangesAsync();
                    Reall();
                    MessageBox.Show("Expense Is Saved Successfully ...", "Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Server Is Dowen ...", "warning");
                }
            }
        }
        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.Rows.Count > 0)
            {
                Lblsid.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                TPN.Text = DGV.CurrentRow.Cells[1].Value.ToString();
                TN.Text = DGV.CurrentRow.Cells[2].Value.ToString();
                BtnAdd.Enabled = false;
                BtnEdit.Enabled = true;
            }
        }
        private void DTF_ValueChanged(object sender, EventArgs e)
        {
            GetExpenseByDate();
        }
        private void DTT_ValueChanged(object sender, EventArgs e)
        {
            GetExpenseByDate();
        }
        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var D = DateTime.Now.ToShortDateString();
                var T = DateTime.Now.ToLongTimeString();
                var id = int.Parse(Lblsid.Text);
                PDb = new Prosalescontext();
                Ex= new Model.Expense();
                Ex = await PDb.Expenses.Where(X => X.Id == id).FirstOrDefaultAsync();
                Ex.Quantity = Convert.ToDecimal(TPN.Text);
                Ex.Note = TN.Text;
                Ex.Date = Convert.ToDateTime(D);
                Ex.Time = T;
                Ex.UserId = Convert.ToInt32(LblId.Text);
                PDb.Entry(Ex).State = EntityState.Modified;
                await PDb.SaveChangesAsync();
                Reall();
                MessageBox.Show("Expense Is Editing Successfully ...", "Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }
    }
}
