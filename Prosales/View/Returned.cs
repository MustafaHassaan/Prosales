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
    public partial class Returned : MetroFramework.Forms.MetroForm
    {
        public Returned()
        {
            InitializeComponent();
        }
        public static int Dimpass;
        Prosalescontext PDb;
        Damegd D;
        //Get Damaged
        public void GD()
        {
            PDb = new Prosalescontext();
            var Qua = from d in PDb.Damegds
                      join S in PDb.Suppliers
                      on d.SupplierId equals S.Id
                      join C in PDb.Categories
                      on d.CategoryId equals C.Id
                      join St in PDb.Stores
                      on d.StorId equals St.Id
                      join U in PDb.Units
                      on d.UnitId equals U.Id
                      select new
                      {
                          d.Productname,
                          d.Productnumber,
                          d.Flages,
                          d.Quantity,
                          S.SupplierName,
                          C.Categoryname,
                          St.Storename,
                          U.Unitname,
                      };
            DGV.DataSource = Qua.ToList();
        }
        private void Returned_Load(object sender, EventArgs e)
        {
            GD();
        }
        private async void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblId.Text = DGV.CurrentRow.Cells[0].Value.ToString();
            PDb = new Prosalescontext();
            D = new Damegd();
            D = await PDb.Damegds.Where(d => d.Productname == LblId.Text).FirstOrDefaultAsync();
            if (D.Flages == "Barcode")
            {
                //Db = await PDb.Damegdbarcodes.Where(b => b.DamId == D.Id).FirstOrDefaultAsync();
                //var dim = Di.DamId;
                //DItems FDI = new DItems();
                ////Dimpass = dim;
                //FDI.ShowDialog();
            }
            else
            {
                //Ds = await PDb.Damegdserials.Where(b => b.DamId == D.Id).FirstOrDefaultAsync();
                //var dim = Di.DamId;
                //DItems FDI = new DItems();
                ////Dimpass = dim;
                //FDI.ShowDialog();
            }
        }
    }
}
