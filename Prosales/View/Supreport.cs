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
    public partial class Supreport : MetroFramework.Forms.MetroForm
    {
        public Supreport()
        {
            InitializeComponent();
        }
        Prosalescontext PDb;
        public void GRep()
        {
            if (DGV.Rows.Count > 0)
            {
                if (TPN.Text == "" && DTT.Value == DateTime.Today && DTF.Value == DateTime.Today)
                {
                    Rep();
                }
                if (DTT.Value >= DateTime.Today && DTF.Value <= DateTime.Today)
                {
                    Repdate();
                }
                if (TPN.Text != "")
                {
                    Repsup();
                }
            }
            else
            {
                MessageBox.Show("Cant OPen Report ...","Warning");
            }
        }
        public void Rep()
        {
            PDb = new Prosalescontext();
            Supplierreports cr = new Supplierreports();
            var Qua = from Sup in PDb.PSRS
                      join Un in PDb.Units
                      on Sup.UnitId equals Un.Id
                      join Cat in PDb.Categories
                      on Sup.CategoryId equals Cat.Id
                      join St in PDb.Stores
                      on Sup.StorId equals St.Id
                      join Supl in PDb.Suppliers
                      on Sup.SupplierId equals Supl.Id
                      select new
                      {
                          Products = Sup.Productname,
                          Sup.Flages,
                          Qty = Sup.Quantity,
                          Price = Sup.Startprice,
                          Sup.Date,
                          Sup.Time,
                          Units = Un.Unitname,
                          Categories = Cat.Categoryname,
                          Store = St.Storename,
                          Suppliers = Supl.SupplierName
                      };
            cr.SetDataSource(Qua.ToList());
            View.Bill BF = new View.Bill();
            BF.CRV.ReportSource = cr;
            BF.ShowDialog();
        }
        public void Repdate()
        {
            PDb = new Prosalescontext();
            Supplierreports cr = new Supplierreports();
            var Qua = from Sup in PDb.PSRS
                      where Sup.Date >= DTF.Value && Sup.Date <= DTT.Value
                      join Un in PDb.Units
                      on Sup.UnitId equals Un.Id
                      join Cat in PDb.Categories
                      on Sup.CategoryId equals Cat.Id
                      join St in PDb.Stores
                      on Sup.StorId equals St.Id
                      join Supl in PDb.Suppliers
                      on Sup.SupplierId equals Supl.Id
                      select new
                      {
                          Products = Sup.Productname,
                          Sup.Flages,
                          Qty = Sup.Quantity,
                          Price = Sup.Startprice,
                          Sup.Date,
                          Sup.Time,
                          Units = Un.Unitname,
                          Categories = Cat.Categoryname,
                          Store = St.Storename,
                          Suppliers = Supl.SupplierName
                      };
            cr.SetDataSource(Qua.ToList());
            View.Bill BF = new View.Bill();
            BF.CRV.ReportSource = cr;
            BF.ShowDialog();
        }
        public void Repsup()
        {
            PDb = new Prosalescontext();
            Supplierreports cr = new Supplierreports();
            var Qua = from Sup in PDb.PSRS
                      join Un in PDb.Units
                      on Sup.UnitId equals Un.Id
                      join Cat in PDb.Categories
                      on Sup.CategoryId equals Cat.Id
                      join St in PDb.Stores
                      on Sup.StorId equals St.Id
                      join Supl in PDb.Suppliers
                      on Sup.SupplierId equals Supl.Id
                      where Supl.SupplierName.Contains(TPN.Text)
                      select new
                      {
                          Products = Sup.Productname,
                          Sup.Flages,
                          Qty = Sup.Quantity,
                          Price = Sup.Startprice,
                          Sup.Date,
                          Sup.Time,
                          Units = Un.Unitname,
                          Categories = Cat.Categoryname,
                          Store = St.Storename,
                          Suppliers = Supl.SupplierName
                      };
            cr.SetDataSource(Qua.ToList());
            View.Bill BF = new View.Bill();
            BF.CRV.ReportSource = cr;
            BF.ShowDialog();
        }
        public void GSR()
        {
            PDb = new Prosalescontext();
            var Qua = from Sup in PDb.PSRS
                      join Un in PDb.Units
                      on Sup.UnitId equals Un.Id
                      join Cat in PDb.Categories
                      on Sup.CategoryId equals Cat.Id
                      join St in PDb.Stores
                      on Sup.StorId equals St.Id
                      join Supl in PDb.Suppliers
                      on Sup.SupplierId equals Supl.Id
                      select new
                      {
                          Sup.Productname,
                          Sup.Flages,
                          Sup.Quantity,
                          Sup.Startprice,
                          Sup.Date,
                          Sup.Time,
                          Un.Unitname,
                          Cat.Categoryname,
                          St.Storename,
                          Supl.SupplierName
                      };
            DGV.DataSource = Qua.ToList();
        }
        public void Search()
        {
            if (DTF.Text == DateTime.Today.ToShortDateString() && DTT.Text == DateTime.Today.ToShortDateString() && TPN.Text != "")
            {
                var Qua = from Sup in PDb.PSRS
                          join Un in PDb.Units
                          on Sup.UnitId equals Un.Id
                          join Cat in PDb.Categories
                          on Sup.CategoryId equals Cat.Id
                          join St in PDb.Stores
                          on Sup.StorId equals St.Id
                          join Supl in PDb.Suppliers
                          on Sup.SupplierId equals Supl.Id
                          where Supl.SupplierName.Contains(TPN.Text)
                          select new
                          {
                              Sup.Productname,
                              Sup.Flages,
                              Sup.Quantity,
                              Sup.Startprice,
                              Sup.Date,
                              Sup.Time,
                              Un.Unitname,
                              Cat.Categoryname,
                              St.Storename,
                              Supl.SupplierName
                          };
                DGV.DataSource = Qua.ToList();
            }
            else
            {
                GSR();
            }
        }
        public void Searchbydate()
        {
            var Qua = from Sup in PDb.PSRS
                      where Sup.Date >= DTF.Value && Sup.Date <= DTT.Value
                      join Un in PDb.Units
                      on Sup.UnitId equals Un.Id
                      join Cat in PDb.Categories
                      on Sup.CategoryId equals Cat.Id
                      join St in PDb.Stores
                      on Sup.StorId equals St.Id
                      join Supl in PDb.Suppliers
                      on Sup.SupplierId equals Supl.Id
                      where Supl.SupplierName.Contains(TPN.Text)
                      select new
                      {
                          Sup.Productname,
                          Sup.Flages,
                          Sup.Quantity,
                          Sup.Startprice,
                          Sup.Date,
                          Sup.Time,
                          Un.Unitname,
                          Cat.Categoryname,
                          St.Storename,
                          Supl.SupplierName
                      };
            DGV.DataSource = Qua.ToList();
        }
        private void Supreport_Load(object sender, EventArgs e)
        {
            GSR();
        }
        private void TPN_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        private void TPN_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void DTF_ValueChanged(object sender, EventArgs e)
        {
            Searchbydate();
        }
        private void DTT_ValueChanged(object sender, EventArgs e)
        {
            Searchbydate();
        }
        private void Btnr_Click(object sender, EventArgs e)
        {
            GRep();
        }
    }
}
