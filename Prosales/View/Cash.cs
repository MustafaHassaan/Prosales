using Prosales.Controler;
using Prosales.Report;
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
    public partial class Cash : MetroFramework.Forms.MetroForm
    {
        public static string BIDPass;
        Prosalescontext PDb;
        Model.Cash CH;
        public Cash()
        {
            InitializeComponent();
        }
        public async void GetCash()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from SL in PDb.Solds
                          where SL.Date == DateTime.Today
                          join Ch in PDb.Cashes
                          on SL.CashId equals Ch.Id
                          select new
                          {
                              Ch.Countitem,
                              Ch.Tottalprice,
                              Ch.Date,
                              Ch.Time,
                              SL.Billnumber
                          };
                DGV.DataSource = Qua.Distinct().ToList();

            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }
        public async void GetCashByDate()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from SL in PDb.Solds
                          where SL.Date >= DTF.Value && SL.Date <= DTT.Value
                          join Ch in PDb.Cashes
                          on SL.CashId equals Ch.Id
                          select new
                          {
                              Ch.Countitem,
                              Ch.Tottalprice,
                              Ch.Date,
                              Ch.Time,
                              SL.Billnumber
                          };
                DGV.DataSource = Qua.Distinct().ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }
        public async void GetCashBysearsh()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from SL in PDb.Solds
                          join Ch in PDb.Cashes
                          on SL.CashId equals Ch.Id
                          where SL.Billnumber.Contains(TSS.Text)
                          select new
                          {
                              Ch.Countitem,
                              Ch.Tottalprice,
                              Ch.Date,
                              Ch.Time,
                              SL.Billnumber
                          };
                DGV.DataSource = Qua.Distinct().ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }
        public void GetTottal()
        {
            decimal sum = 0;
            for (int i = 0; i < DGV.Rows.Count; ++i)
            {
                sum += Convert.ToDecimal(DGV.Rows[i].Cells[1].Value);
            }
            Tottal.Text = sum.ToString();
        }
        public void GBill(string Num)
        {
            PDb = new Prosalescontext();
            CrlRpt cr = new CrlRpt();
            var Qua = from B in PDb.Solds
                      where B.Billnumber == Num

                      join U in PDb.Users
                      on B.UserId equals U.Id

                      select new
                      {
                          Billnumber = B.Billnumber,
                          Productname = B.Productname,
                          Tottal = B.Endprice,
                          Quantity = B.Quantity,
                          Date = B.Date,
                          Time = B.Time,
                          Salesname = U.Fullname,
                          Productnumber = B.Productnumber,
                      };
            //DGV.DataSource = Qua.ToList();
            cr.SetDataSource(Qua.ToList());
            View.Bill BF = new View.Bill();
            BF.CRV.ReportSource = cr;
            BF.ShowDialog();
        }
        public void Reall()
        {
            DTF.Value = DateTime.Today;
            DTT.Value = DateTime.Today;
            GetCash();
            GetTottal();
        }
        private void Cash_Load(object sender, EventArgs e)
        {
            LblId.Text = Home.IDPassing;
            Reall();
        }
        private void TPN_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Key Pres Number Only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void TPN_TextChanged(object sender, EventArgs e)
        {
        }
        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var BN = DGV.CurrentRow.Cells[4].Value.ToString();
            var Msg = MessageBox.Show("Are you want Bill ? Y/N" +
                            "\n" +
                            "If yes : Bill Open" +
                            "\n" +
                            "Else : Item Open", "Quation ?", MessageBoxButtons.YesNoCancel);
            if (Msg == DialogResult.Yes)
            {
                BIDPass = BN;
                string Num = BIDPass;
                GBill(Num);
            }
            else if (Msg == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                Retitem RI = new Retitem(this);
                BIDPass = BN;
                RI.ShowDialog();
            }
        }
        private void DTF_ValueChanged(object sender, EventArgs e)
        {
            GetCashByDate();
            GetTottal();
        }
        private void DTT_ValueChanged(object sender, EventArgs e)
        {
            GetCashByDate();
            GetTottal();
        }
        private void TSS_TextChanged(object sender, EventArgs e)
        {
            GetCashBysearsh();
            GetTottal();
        }
    }
}
