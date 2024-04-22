using Prosales.Controler;
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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Prosales.View
{
    public partial class POS : MetroFramework.Forms.MetroForm
    {
        public static string UNPassing;
        public static string IDPassing;
        public static int SaLeId;
        public static int BillNum;
        Prosalescontext PDb;
        Model.Sold SL;
        Model.Product Pro;
        Model.Serialnumber SN;
        Model.Barcode Bc;
        Model.Cash Ch;
        public POS()
        {
            InitializeComponent();
        }
        public void GBNC()
        {
            var Bn = BN.Text;
            CrlRpt cr = new CrlRpt();
            var Qua = from B in PDb.Solds
                      where B.Billnumber == Bn

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
            cr.SetDataSource(Qua.ToList());
            View.Bill BF = new View.Bill();
            BF.CRV.ReportSource = cr;
            BF.ShowDialog();
        }
        //Get Type Of Sales
        public void GTS()
        {
            try
            {
                //string constr = @"Data Source=192.168.3.180;Initial Catalog=Prosales;Persist Security Info=True;User ID=PCServicesAdministrator;Password=PCS2020";
                string constr = Prosalescontext.Con();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, Salesname FROM TOSales", con))
                    {
                        //Fill the DataTable with records from Table.
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        //Insert the Default Item to DataTable.
                        DataRow row = dt.NewRow();

                        //Assign DataTable as DataSource.
                        CBS.DataSource = dt;
                        CBS.DisplayMember = "Salesname";
                        CBS.ValueMember = "Id";
                        CBS.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ths Server Is Dowen ...", "Error");
                return;
            }
        }
        public void GetTottal()
        {
            decimal sum = 0;
            for (int i = 0; i < DGV.Rows.Count; ++i)
            {
                sum += Convert.ToDecimal(DGV.Rows[i].Cells[8].Value);
            }
            TR.Text = Convert.ToString(sum);
        }
        public void GetCust()
        {
            try
            {
                string constr = Prosalescontext.Con();
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, Customername FROM Customers", constr))
                {
                    //Fill the DataTable with records from Table.
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    //Insert the Default Item to DataTable.
                    DataRow row = dt.NewRow();
                    row[0] = 0;
                    row[1] = "Client";
                    dt.Rows.InsertAt(row, 0);

                    //Assign DataTable as DataSource.
                    CBC.DataSource = dt;
                    CBC.DisplayMember = "Customername";
                    CBC.ValueMember = "Id";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ths Server Is Dowen ...", "Error");
                return;
            }
        }
        private void POS_Load(object sender, EventArgs e)
        {
            LblId.Text = Home.IDPassing;
            LblFN.Text = Home.UNPassing;
            Random rnd = new Random();
            int RN = rnd.Next();
            BN.Text = RN.ToString();
            GTS();
            GetTottal();
            GetCust();
        }
        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                if (DGV.Rows.Count > 1)
                {
                    var Qty = int.Parse(DGV.CurrentRow.Cells[7].Value.ToString());
                    if (Qty > 1)
                    {
                        int x = 1;
                        var y = int.Parse(DGV.CurrentRow.Cells[7].Value.ToString());
                        var res = y - x ;
                        DGV.CurrentRow.Cells[7].Value = res;
                        DGV.BeginEdit(true);
                    }
                    else
                    {
                        int row = DGV.CurrentCell.RowIndex;
                        DGV.Rows.RemoveAt(row);
                        GetTottal();
                        TSS.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Cant delete this row ...", "Warning");
                }
            }
        }
        private async void BtnSale_Click(object sender, EventArgs e)
        {
            PDb = new Prosalescontext();
            SL = new Model.Sold();
            Pro = new Model.Product();
            Ch = new Model.Cash();
            if (DGV.Rows == null || TR.Text == "0")
            {
                MessageBox.Show("Please Insert List Of Products ...", "warning");
                return;
            }
            else
            {
                var D = DateTime.Now.ToShortDateString();
                var T = DateTime.Now.ToLongTimeString();
                Ch.Countitem = DGV.Rows.Count - 1;
                Ch.Tottalprice = Convert.ToDecimal(TR.Text);
                Ch.Date = Convert.ToDateTime(D);
                Ch.Time = T;
                Ch.UserId = int.Parse(LblId.Text);
                PDb.Cashes.Add(Ch);
                await PDb.SaveChangesAsync();
                foreach (DataGridViewRow Row in DGV.Rows)
                {
                    if (Row.Cells[0].Value == null)
                    {
                        break;
                    }
                    else
                    {
                        SL.Productname = Row.Cells[2].Value.ToString();
                        SL.Billnumber = Row.Cells[0].Value.ToString();
                        SL.Productnumber = Row.Cells[3].Value.ToString();
                        SL.Flages = Row.Cells[11].Value.ToString();
                        SL.Quantity = int.Parse(Row.Cells[7].Value.ToString());
                        SL.Endprice = decimal.Parse(Row.Cells[8].Value.ToString());
                        var Totprice = SL.Quantity * SL.Endprice;
                        SL.Tottal = Totprice;
                        SL.Date = Convert.ToDateTime(D);
                        SL.Time = T;
                        Pro = await PDb.Products.Where(p => p.Productname == SL.Productname).FirstOrDefaultAsync();
                        SL.CategoryId = Pro.CategoryId;
                        SL.SupplierId = Pro.SupplierId;
                        SL.UserId = int.Parse(LblId.Text);
                        SL.UnitId = Pro.UnitId;
                        SL.StorId = Pro.StorId;
                        SL.CashId = Ch.Id;
                        PDb.Solds.Add(SL);
                        await PDb.SaveChangesAsync();

                        if (Row.Cells[11].Value.ToString() == "Barcode")
                        {
                            //لو الكمية اكبر من 1
                            var Qty = int.Parse(Row.Cells[7].Value.ToString());
                            if (Qty >= 1)
                            {
                                for (int i = 0; i < Qty; i++)
                                {
                                    Bc = await PDb.Barcodes.Where(b => b.Pronumber == SL.Productnumber).FirstOrDefaultAsync();
                                    Pro = await PDb.Products.Where(p => p.Id == Bc.ProId).FirstOrDefaultAsync();
                                    var count = Pro.Quantity;
                                    Pro.Quantity = count - 1;
                                    PDb.Barcodes.Remove(Bc);
                                    PDb.Entry(Pro).State = EntityState.Modified;
                                    await PDb.SaveChangesAsync();
                                }
                            }
                        }
                        else
                        {
                            SN = await PDb.Serialnumbers.Where(b => b.Pronumber == SL.Productnumber).FirstOrDefaultAsync();
                            Pro = await PDb.Products.Where(p => p.Id == SN.ProId).FirstOrDefaultAsync();
                            var count = Pro.Quantity;
                            Pro.Quantity = count - 1;

                            PDb.Serialnumbers.Remove(SN);
                            PDb.Entry(Pro).State = EntityState.Modified;

                        }
                    }
                    await PDb.SaveChangesAsync();
                }
                GBNC();
                DGV.Rows.Clear();
                TR.Text = "0";
            }
        }
        private void CBC_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }
        private void TD_TextChanged(object sender, EventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void CBS_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void TP_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void TD_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void TP_TextChanged(object sender, EventArgs e)
        {
        }
        private async void TSS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    var Qty = 1;
                    var id = int.Parse(LblId.Text);
                    PDb = new Prosalescontext();
                    Pro = new Model.Product();
                    Bc = new Model.Barcode();
                    SN = new Model.Serialnumber();
                    var Flag = false;
                    Bc = await PDb.Barcodes.Where(b => b.Pronumber == TSS.Text).FirstOrDefaultAsync();
                    SN = await PDb.Serialnumbers.Where(b => b.Pronumber == TSS.Text).FirstOrDefaultAsync();
                    DataGridViewRow row = (DataGridViewRow)DGV.Rows[0].Clone();
                    if (SN != null)
                    {
                        Flag = true;
                    }
                    else
                    {
                        Flag = false;
                    }
                    if (Flag)
                    {
                        Pro = await PDb.Products.Where(S => S.Id == SN.ProId).FirstOrDefaultAsync();
                        var Cat = await PDb.Categories.Where(C => C.Id == Pro.CategoryId).FirstOrDefaultAsync();
                        var Unit = await PDb.Units.Where(U => U.Id == Pro.UnitId).FirstOrDefaultAsync();
                        var Store = await PDb.Stores.Where(S => S.Id == Pro.StorId).FirstOrDefaultAsync();
                        var Users = await PDb.Users.Where(US => US.Id == id).FirstOrDefaultAsync();
                        for (int i = 0; i < DGV.Rows.Count - 1; i++)
                        {
                            var QPar = DGV.Rows[i].Cells[3].Value;
                            var QP = Convert.ToString(QPar);
                            if (QP == TSS.Text)
                            {
                                MessageBox.Show("This product is added befor ...", "Warning");
                                TSS.Clear();
                                TSS.Focus();
                                GetTottal();
                                return;
                            }
                        }
                        row.Cells[0].Value = BN.Text;
                        row.Cells[1].Value = Pro.Id;
                        row.Cells[2].Value = Pro.Productname;
                        row.Cells[3].Value = SN.Pronumber;
                        row.Cells[4].Value = Cat.Categoryname;
                        row.Cells[5].Value = Unit.Unitname;
                        row.Cells[6].Value = Store.Storename;
                        row.Cells[7].Value = Qty;
                        row.Cells[8].Value = Pro.Endprice;
                        row.Cells[9].Value = Users.Fullname;
                        row.Cells[11].Value = Pro.Flages;
                        DGV.Rows.Add(row);
                        TSS.Clear();
                        GetTottal();
                        return;
                    }
                    else
                    {
                        Pro = await PDb.Products.Where(S => S.Id == Bc.ProId).FirstOrDefaultAsync();
                        var Catp = await PDb.Categories.Where(C => C.Id == Pro.CategoryId).FirstOrDefaultAsync();
                        var Unitp = await PDb.Units.Where(U => U.Id == Pro.UnitId).FirstOrDefaultAsync();
                        var Storep = await PDb.Stores.Where(S => S.Id == Pro.StorId).FirstOrDefaultAsync();
                        var Usersp = await PDb.Users.Where(US => US.Id == id).FirstOrDefaultAsync();
                        if (Pro != null && Pro.Quantity != 0)
                        {
                            for (int i = 0; i < DGV.Rows.Count - 1; i++)
                            {
                                var QPar = DGV.Rows[i].Cells[3].Value;
                                var QP = Convert.ToString(QPar);
                                var Qt = DGV.Rows[i].Cells[7].Value.ToString();
                                var x = int.Parse(Qt);
                                if (QP == TSS.Text && Bc.Pronumber == QP && Pro.Quantity > x)
                                {
                                    x++;
                                    DGV.Rows[i].Cells[7].Value = x;
                                    var Pr = Pro.Endprice;
                                    var end = x * Pr;
                                    DGV.Rows[i].Cells[8].Value = end;
                                    DGV.BeginEdit(true);
                                    TSS.Clear();
                                    TSS.Focus();
                                    GetTottal();
                                    return;
                                }
                                if (QP == TSS.Text && Bc.Pronumber == QP && Pro.Quantity == x)
                                {
                                    MessageBox.Show("The product cannot be added because it is not sufficient", "Warning");
                                    return;
                                }
                            }
                            row.Cells[0].Value = BN.Text;
                            row.Cells[1].Value = Pro.Id;
                            row.Cells[2].Value = Pro.Productname;
                            row.Cells[3].Value = Bc.Pronumber;
                            row.Cells[4].Value = Catp.Categoryname;
                            row.Cells[5].Value = Unitp.Unitname;
                            row.Cells[6].Value = Storep.Storename;
                            row.Cells[7].Value = Qty;
                            row.Cells[8].Value = Pro.Endprice;
                            row.Cells[9].Value = Usersp.Fullname;
                            row.Cells[11].Value = Pro.Flages;
                            DGV.Rows.Add(row);
                            TSS.Clear();
                            GetTottal();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("This product not found ...", "Warning");
                            TSS.Clear();
                            return;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("This product not found ...", "Warning");
                    TSS.Clear();
                    return;
                }
            }
        }
    }
}
