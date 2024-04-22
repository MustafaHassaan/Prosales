using Prosales.Controler;
using Prosales.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prosales.View
{
    public partial class Sales : MetroFramework.Forms.MetroForm
    {
        Prosalescontext PDb;
        public static string Billpass;
        public Sales()
        {
            InitializeComponent();
        }
        public void GBNS()
        {
            PDb = new Prosalescontext();
            var Qua = from S in PDb.Solds
                      select new
                      {
                          //S.Productname,
                          //S.Billnumber,
                          //S.Countitems,
                          //B.Date,
                          //B.Time,
                          //S.Result
                      };
            DGV.DataSource = Qua.ToList();
        }
        //public void GSTd()
        //{
        //    PDb = new Prosalescontext();
        //    var Qua = from S in PDb.Sales
        //              join B in PDb.Solds
        //              on S.SolId equals B.Id
        //              where B.Date >= DTF.Value && B.Date <= DTT.Value
        //              select new
        //              {
        //                  B.Billnumber,
        //                  S.Countitems,
        //                  B.Date,
        //                  B.Time,
        //                  S.Result
        //              };
        //    DGV.DataSource = Qua.Distinct().ToList();
        //}
        //public void GSTS()
        //{
        //    PDb = new Prosalescontext();
        //    var Qua = from S in PDb.Sales
        //              join B in PDb.Solds
        //              on S.SolId equals B.Id
        //              where B.Billnumber.Contains(TSS.Text)
        //              select new
        //              {
        //                  B.Billnumber,
        //                  S.Countitems,
        //                  B.Date,
        //                  B.Time,
        //                  S.Result
        //              };
        //    DGV.DataSource = Qua.Distinct().ToList();
        //}
        private void Sales_Load(object sender, EventArgs e)
        {
            GBNS();
        }
        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.Rows.Count > 0)
            {
                LblId.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                Billpass = LblId.Text;
                //GBN();
            }
        }
        private void TSS_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TSS.Text))
            {
                //GSTS();
            }
            else
            {
                GBNS();
            }
        }
        private void DTF_ValueChanged(object sender, EventArgs e)
        {
            //GSTd();
        }
        private void DTT_ValueChanged(object sender, EventArgs e)
        {
            //GSTd();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //GST();
        }
    }
}
