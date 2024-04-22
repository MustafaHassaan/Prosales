using Prosales.Controler;
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
    public partial class GC : MetroFramework.Forms.MetroForm
    {
        public static string IDPassing;
        Prosalescontext PDb;
        public GC()
        {
            InitializeComponent();
        }
        public void GetCust()
        {
            PDb = new Prosalescontext();
            var Qua = from Cust in PDb.Customers
                      select new { 
                      Cust.Id,
                      Cust.Customername
                      };
            DGV.DataSource = Qua.ToList();
        }
        private void GC_Load(object sender, EventArgs e)
        {
            GetCust();
        }
        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.Rows.Count > 0)
            {
                IDPassing = DGV.CurrentRow.Cells[0].Value.ToString();
                this.Hide();
            }
        }
    }
}
