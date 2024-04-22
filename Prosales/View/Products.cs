using Microsoft.VisualBasic;
using Prosales.Controler;
using Prosales.Model;
using Prosales.Report;
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
    public partial class Products : MetroFramework.Forms.MetroForm
    {
        Prosalescontext PDb;
        Product Pro;
        PSR Psrs;
        //Productitem Pi;
        Model.Barcode Bc;
        public static int Pidpass;
        public static int PRidpass;
        public Products()
        {
            InitializeComponent();
        }
        public void GBNC()
        {
            PDb = new Prosalescontext();
            CrlRptPro cr = new CrlRptPro();
            var Qua = from Pro in PDb.Products

                      join C in PDb.Categories
                      on Pro.CategoryId equals C.Id

                      join U in PDb.Units
                      on Pro.UnitId equals U.Id

                      join Sup in PDb.Suppliers
                      on Pro.SupplierId equals Sup.Id

                      select new
                      {
                          Pro.Productname,
                          Category = C.Categoryname,
                          Unit = U.Unitname,
                          Flage = Pro.Flages,
                          Pro.Quantity,
                          Supplier = Sup.SupplierName,
                          Price = Pro.Startprice
                      };
            cr.SetDataSource(Qua.ToList());
            View.Bill BF = new View.Bill();
            BF.CRV.ReportSource = cr;
            BF.ShowDialog();
        }
        //Get Products
        public void GetPrd()
        {
            PDb = new Prosalescontext();
            var Qua = from Prd in PDb.Products

                      join Cat in PDb.Categories
                      on Prd.CategoryId equals Cat.Id

                      join Un in PDb.Units
                      on Prd.UnitId equals Un.Id

                      join Str in PDb.Stores
                      on Prd.StorId equals Str.Id

                      join Sup in PDb.Suppliers
                      on Prd.SupplierId equals Sup.Id

                      select new
                      {
                          Prd.Productname,
                          Prd.Startprice,
                          Prd.Endprice,
                          Prd.Quantity,
                          Prd.Discount,
                          Prd.Tottal,
                          Un.Unitname,
                          Cat.Categoryname,
                          Str.Storename,
                          Sup.SupplierName
                      };
            DGV.DataSource = Qua.ToList();
        }
        //Get Category
        public void GC()
        {
            try
            {
                //string constr = @"Data Source=192.168.3.180;Initial Catalog=Prosales;Persist Security Info=True;User ID=PCServicesAdministrator;Password=PCS2020";
                string constr = Prosalescontext.Con();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, Categoryname FROM Categories", con))
                    {
                        //Fill the DataTable with records from Table.
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        //Insert the Default Item to DataTable.
                        DataRow row = dt.NewRow();
                        row[0] = 0;
                        row[1] = "-- All --";
                        dt.Rows.InsertAt(row, 0);

                        //Assign DataTable as DataSource.
                        CBCat.DataSource = dt;
                        CBCat.DisplayMember = "Categoryname";
                        CBCat.ValueMember = "Id";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ths Server Is Dowen ...", "Error");
                return;
            }
        }
        //Get Units
        public void GU()
        {
            try
            {
                //string constr = @"Data Source=192.168.3.180;Initial Catalog=Prosales;Persist Security Info=True;User ID=PCServicesAdministrator;Password=PCS2020";
                string constr = Prosalescontext.Con();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, Unitname FROM Units", con))
                    {
                        //Fill the DataTable with records from Table.
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        //Insert the Default Item to DataTable.
                        DataRow row = dt.NewRow();
                        row[0] = 0;
                        row[1] = "-- All --";
                        dt.Rows.InsertAt(row, 0);

                        //Assign DataTable as DataSource.
                        CBU.DataSource = dt;
                        CBU.DisplayMember = "Unitname";
                        CBU.ValueMember = "Id";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ths Server Is Dowen ...", "Error");
                return;
            }
        }
        //Get Supplier
        public void GS()
        {
            try
            {
                //string constr = @"Data Source=192.168.3.180;Initial Catalog=Prosales;Persist Security Info=True;User ID=PCServicesAdministrator;Password=PCS2020";
                string constr = Prosalescontext.Con();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, Suppliername FROM Suppliers", con))
                    {
                        //Fill the DataTable with records from Table.
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        //Insert the Default Item to DataTable.
                        DataRow row = dt.NewRow();
                        row[0] = 0;
                        row[1] = "-- All --";
                        dt.Rows.InsertAt(row, 0);

                        //Assign DataTable as DataSource.
                        CBSup.DataSource = dt;
                        CBSup.DisplayMember = "Suppliername";
                        CBSup.ValueMember = "Id";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ths Server Is Dowen ...", "Error");
                return;
            }
        }
        //Get Stores
        public void GSt()
        {
            try
            {
                //string constr = @"Data Source=192.168.3.180;Initial Catalog=Prosales;Persist Security Info=True;User ID=PCServicesAdministrator;Password=PCS2020";
                string constr = Prosalescontext.Con();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, Storename FROM Stores", con))
                    {
                        //Fill the DataTable with records from Table.
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        //Insert the Default Item to DataTable.
                        DataRow row = dt.NewRow();
                        row[0] = 0;
                        row[1] = "-- All --";
                        dt.Rows.InsertAt(row, 0);

                        //Assign DataTable as DataSource.
                        CBS.DataSource = dt;
                        CBS.DisplayMember = "Storename";
                        CBS.ValueMember = "Id";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ths Server Is Dowen ...", "Error");
                return;
            }
        }
        //Get Products By Search
        public void GSP()
        {
            try
            {
                PDb = new Prosalescontext();
                var Qua = from Pro in PDb.Products
                          where Pro.Productname.Contains(TSS.Text)

                          join Cat in PDb.Categories
                          on Pro.CategoryId equals Cat.Id

                          join Un in PDb.Units
                          on Pro.UnitId equals Un.Id

                          join Str in PDb.Stores
                          on Pro.StorId equals Str.Id

                          join Sup in PDb.Suppliers
                          on Pro.SupplierId equals Sup.Id

                          select new
                          {
                              Pro.Id,
                              Pro.Productname,
                              Pro.Startprice,
                              Pro.Endprice,
                              Pro.Quantity,
                              Pro.Discount,
                              Pro.Tottal,
                              Un.Unitname,
                              Cat.Categoryname,
                              Str.Storename,
                              Sup.SupplierName
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
            GC();
            GS();
            GSt();
            GU();
            GetPrd();
            TSN.Clear();
            TSP.Clear();
            TEP.Clear();
            TDisc.Clear();
            Qty.Text = "0";
            LblSid.Text = "0";
            BtnAdd.Enabled = true;
            BtnEdit.Enabled = false;
            BtnDel.Enabled = false;
            Mt.Text = "";
            Mt.TileCount = 0;
            Mt.Enabled = false;
        }
        private void Pi_Load(object sender, EventArgs e)
        {
            LblId.Text = Home.IDPassing;
            Reall();
        }
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            PDb = new Prosalescontext();
            Pro = new Product();
            //Pi = new Productitem();
            if (string.IsNullOrEmpty(TSN.Text) ||
                string.IsNullOrEmpty(TSP.Text) ||
                string.IsNullOrEmpty(TEP.Text) ||
                CBU.Text == "-- All --" ||
                CBCat.Text == "-- All --" ||
                CBS.Text == "-- All --" ||
                CBSup.Text == "-- All --")
            {
                MessageBox.Show("Please Insert Productname,\n" +
                                "Unit, Category,\n" +
                                "Supplier, Start Price, End Price,\n" +
                                "& Store ...", "warning");
                return;
            }
            else
            {
                Pro = await PDb.Products.Where(i => i.Productname == TSN.Text).FirstOrDefaultAsync();
                if (Pro == null)
                {
                    Pro = new Product();
                    Psrs = new PSR();
                    var T = DateTime.Now.ToLongTimeString();
                    Psrs.Date = DateTime.Today;
                    Psrs.Time = T;
                    Pro.Productname = TSN.Text;
                    Psrs.Productname = Pro.Productname;
                    Pro.Startprice = Convert.ToDecimal(TSP.Text);
                    Psrs.Startprice = Pro.Startprice;
                    Pro.Endprice = Convert.ToDecimal(TEP.Text);
                    Pro.Quantity = int.Parse(Qty.Text);
                    Psrs.Quantity = Pro.Quantity;
                    Pro.StorId = Convert.ToInt32(CBS.SelectedValue.ToString());
                    Psrs.StorId = Pro.StorId;
                    Pro.UnitId = Convert.ToInt32(CBU.SelectedValue.ToString());
                    Psrs.UnitId = Pro.UnitId;
                    Pro.CategoryId = Convert.ToInt32(CBCat.SelectedValue.ToString());
                    Psrs.CategoryId = Pro.CategoryId;
                    Pro.SupplierId = Convert.ToInt32(CBSup.SelectedValue.ToString());
                    Psrs.SupplierId = Pro.SupplierId;
                    Pro.UserId = int.Parse(LblId.Text);
                    Psrs.UserId = Pro.UserId;
                    if (TDisc.Text == "")
                    {
                        Pro.Discount = Convert.ToDecimal("0.0");
                        Pro.Tottal = Pro.Endprice;
                    }
                    else
                    {
                        Pro.Discount = Convert.ToDecimal(TDisc.Text);
                        var Disc = TDisc.Text;
                        var EP = (Pro.Endprice * Convert.ToDecimal(Disc)) / 100;
                        var Result = Pro.Endprice - EP;
                        Pro.Tottal = Result;
                    }
                    var res = MessageBox.Show("Are this product have barcode ?","Quastions",MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        Pro.Flages = "Barcode";
                        Psrs.Flages = Pro.Flages;
                        PDb.Products.Add(Pro);
                        PDb.PSRS.Add(Psrs);
                        await PDb.SaveChangesAsync();
                        MessageBox.Show("Product Is Saved Successfully ...", "Success");
                        Reall();
                        ProBarcode FBP = new ProBarcode(this);
                        Pidpass = Pro.Id;
                        PRidpass = Psrs.Id;
                        FBP.ShowDialog();
                    }
                    else
                    {
                        Pro.Flages = "Serialnumber";
                        Psrs.Flages = Pro.Flages;
                        PDb.PSRS.Add(Psrs);
                        PDb.Products.Add(Pro);
                        await PDb.SaveChangesAsync();
                        MessageBox.Show("Product Is Saved Successfully ...", "Success");
                        Reall();
                        Serialnumber FSN = new Serialnumber(this);
                        Pidpass = Pro.Id;
                        PRidpass = Psrs.Id;
                        FSN.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Cant Add This Product because His Added befor ...", "Warning");
                    return;
                }
            }
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            Reall();
        }
        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(LblSid.Text);
                PDb = new Prosalescontext();
                var Pro = await PDb.Products.Where(X => X.Id == id).FirstOrDefaultAsync();
                Pro.Productname = TSN.Text;
                Pro.Startprice = Convert.ToDecimal(TSP.Text);
                Pro.Endprice = Convert.ToDecimal(TEP.Text);
                Pro.UnitId = int.Parse(CBU.SelectedValue.ToString());
                Pro.CategoryId = int.Parse(CBCat.SelectedValue.ToString());
                if (TDisc.Text == "")
                {
                    Pro.Discount = Convert.ToDecimal("0.0");
                    Pro.Tottal = Pro.Endprice;
                }
                else
                {
                    Pro.Discount = Convert.ToDecimal(TDisc.Text);
                    var Disc = TDisc.Text;
                    var EP = (Pro.Endprice * Convert.ToDecimal(Disc)) / 100;
                    var Result = Pro.Endprice - EP;
                    Pro.Tottal = Result;
                }
                Pro.SupplierId = int.Parse(CBSup.SelectedValue.ToString());
                Pro.StorId = int.Parse(CBS.SelectedValue.ToString());
                Pro.UserId = int.Parse(LblId.Text);
                PDb.Entry(Pro).State = EntityState.Modified;
                await PDb.SaveChangesAsync();
                Reall();
                MessageBox.Show("Product Is Editing Successfully ...", "Successfully");
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
                var id = LblSid.Text;
                PDb = new Prosalescontext();
                var Pro = await PDb.Products.Where(X => X.Productname == id).FirstOrDefaultAsync();
                var Psrs = await PDb.PSRS.Where(p => p.Productname == Pro.Productname).FirstOrDefaultAsync();
                if (Pro.Quantity == 0)
                {
                    PDb.PSRS.Remove(Psrs);
                    PDb.Products.Remove(Pro);
                    await PDb.SaveChangesAsync();
                    Reall();
                    MessageBox.Show("Product Is Deleting Successfully ...", "Successfully");
                }
                else
                {
                    MessageBox.Show("Cant delete this Product becuse his have items ...", "warning");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cant delete this product becouse his added to another table ...", "warning");
            }
        }
        private async void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PDb = new Prosalescontext();
            Pro = new Product();
            if (DGV.Rows.Count > 0)
            {
                Mt.Enabled = true;
                LblSid.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                TSN.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                TSP.Text = DGV.CurrentRow.Cells[1].Value.ToString();
                TEP.Text = DGV.CurrentRow.Cells[2].Value.ToString();
                Qty.Text = DGV.CurrentRow.Cells[3].Value.ToString();
                TDisc.Text = DGV.CurrentRow.Cells[4].Value.ToString();
                CBU.Text = DGV.CurrentRow.Cells[6].Value.ToString();
                CBCat.Text = DGV.CurrentRow.Cells[7].Value.ToString();
                CBS.Text = DGV.CurrentRow.Cells[8].Value.ToString();
                CBSup.Text = DGV.CurrentRow.Cells[9].Value.ToString();
                Pro = await PDb.Products.Where(p => p.Productname == TSN.Text).FirstOrDefaultAsync();
                Mt.Text = Pro.Flages;
                Mt.TileCount = Pro.Quantity;
                BtnAdd.Enabled = false;
                BtnEdit.Enabled = true;
                BtnDel.Enabled = true;
            }
        }
        private void TSP_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TEP_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TSS_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TSS.Text))
            {
                GSP();
            }
            else
            {
                Reall();
            }
        }
        private async void Btitem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TSN.Text) ||
                string.IsNullOrEmpty(TSP.Text) ||
                string.IsNullOrEmpty(TEP.Text) ||
                CBU.Text == "-- All --" ||
                CBCat.Text == "-- All --" ||
                CBS.Text == "-- All --" ||
                CBSup.Text == "-- All --" ||
                LblSid.Text == "0")
            {
                MessageBox.Show("Please Insert Productid,Productname,\n" +
                                "Unit, Category,\n" +
                                "Supplier, Start Price, End Price,\n" +
                                "& Store ...", "warning");
                return;
            }
            else
            {
                PDb = new Prosalescontext();
                Pro = new Product();
                Pro = await PDb.Products.Where(p => p.Productname == TSN.Text).FirstOrDefaultAsync();
                var bc = Bc.Pronumber;
                if (bc == null || bc == "")
                {
                    //Proitems Fp = new Proitems();
                    //Pidpass = int.Parse(LblSid.Text);
                    //Fp.ShowDialog();
                    return;
                }
                if (bc != null || bc != "")
                {
                    MessageBox.Show("This product have barcode mutched " + "\n" +
                                    "the barcode is" + bc + " ...", "Warning");
                    return;
                }
            }
        }
        private void PS_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    Proitems PIF = new Proitems();
            //    Pidpass = int.Parse(LblSid.Text);
            //    PIF.ShowDialog();
            //}
        }
        private async void Mt_Click(object sender, EventArgs e)
        {
            PDb = new Prosalescontext();
            Pro = new Product();
            Pro = await PDb.Products.Where(p => p.Productname == TSN.Text).FirstOrDefaultAsync();
            if (Pro.Flages == "Barcode")
            {
                LblSid.Text = Convert.ToString(Pro.Id);
                var id = int.Parse(LblSid.Text);
                ProBarcode FBC = new ProBarcode(this);
                Bc = new Model.Barcode();
                Pidpass = id;
                FBC.ShowDialog();
            }
            else
            {
                LblSid.Text = Convert.ToString(Pro.Id);
                var id = int.Parse(LblSid.Text);
                Serialnumber FSN = new Serialnumber(this);
                Bc = new Model.Barcode();
                Pidpass = id;
                FSN.ShowDialog();
            }
        }
        private void Btnr_Click(object sender, EventArgs e)
        {
            GBNC();
        }
    }
}
