using Microsoft.VisualBasic;
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
    public partial class Retitem : MetroFramework.Forms.MetroForm
    {
        Cash Ch;
        public Retitem(Cash _Ch)
        {
            InitializeComponent();
            Ch = _Ch;
        }

        Prosalescontext PDb;

        Model.Product Pro;
        Model.Barcode Bc;
        Model.Serialnumber Sn;

        Model.Sold SL;
        Model.Cash CH;

        Model.Damegd Dam;

        //Get Bill number Data grid
        public void GBNC()
        {
            string Salesname;
            var billnum = Cash.BIDPass;
            PDb = new Prosalescontext();
            string num = billnum;
            var Qua = from B in PDb.Solds
                      where B.Billnumber == num

                      join U in PDb.Users
                      on B.UserId equals U.Id

                      select new
                      {
                          B.Billnumber,
                          B.Productname,
                          B.Productnumber,
                          B.Endprice,
                          B.Quantity,
                          B.Date,
                          B.Time,
                          U.Fullname,
                          B.Flages
                      };
            DGV.DataSource = Qua.ToList();
        }
        private void Retitem_Load(object sender, EventArgs e)
        {
            GBNC();
        }
        private async void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.Rows.Count > 0)
            {
                //رقم الفاتورة
                var Bn = DGV.CurrentRow.Cells[0].Value.ToString();
                //اسم المنتج
                var Proname = DGV.CurrentRow.Cells[1].Value.ToString();
                //رقم المنتج
                var Pronum = DGV.CurrentRow.Cells[2].Value.ToString();
                
                //سعر المنتج
                var Price = DGV.CurrentRow.Cells[3].Value.ToString();
                //الكمية
                var Qty = int.Parse(DGV.CurrentRow.Cells[4].Value.ToString());
                //نوع المنتج
                var Type = DGV.CurrentRow.Cells[8].Value.ToString();
                //Get Product
                var pro = await PDb.Products.Where(p => p.Productname == Proname).FirstOrDefaultAsync();

                //لو المنتج جيد
                if (RBG.Checked)
                {
                    SL = new Model.Sold();
                    Pro = new Model.Product();
                    Sn = new Model.Serialnumber();
                    Bc = new Model.Barcode();
                    CH = new Model.Cash();
                    if (Type == "Barcode")
                    {
                        if (Qty > 1)
                        {
                            var msg = Interaction.InputBox("How many product you want return ?", "Question ?");
                            var x = int.Parse(msg);
                            if (msg.Length == 0)
                            {
                                return;
                            }
                            else
                            {
                                Pro = await PDb.Products.Where(p => p.Productname == Proname).FirstOrDefaultAsync();
                                Bc = await PDb.Barcodes.Where(b => b.ProId == Pro.Id).FirstOrDefaultAsync();
                                if (Pro != null)
                                {
                                    for (int i = 0; i < x; i++)
                                    {
                                        if (Bc != null)
                                        {
                                            Bc = new Model.Barcode();
                                            Bc.Pronumber = Pronum;
                                            Bc.ProId = Pro.Id;
                                            PDb.Barcodes.Add(Bc);
                                        }
                                        else
                                        {
                                            Bc = new Model.Barcode();
                                            Bc.Pronumber = Pronum;
                                            Bc.ProId = Pro.Id;
                                            PDb.Barcodes.Add(Bc);
                                        }
                                        await PDb.SaveChangesAsync();
                                    }
                                    var NQty = Pro.Quantity;
                                    Pro.Quantity = NQty + x;
                                    PDb.Entry(Pro).State = EntityState.Modified;
                                    
                                    SL = new Model.Sold();
                                    SL = await PDb.Solds.Where(s => s.Billnumber == Bn).FirstAsync();

                                    var qtysd = SL.Quantity - x;
                                    SL.Quantity = qtysd;
                                    SL.Endprice = Pro.Endprice * x;
                                    if (SL.Quantity == 0)
                                    {

                                        PDb.Solds.Remove(SL);
                                        await PDb.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        PDb.Entry(SL).State = EntityState.Modified;
                                        await PDb.SaveChangesAsync();
                                    }
                                    GBNC();

                                    CH = new Model.Cash();
                                    CH = await PDb.Cashes.Where(c => c.Id == SL.CashId).FirstOrDefaultAsync();
                                    decimal sum = 0;
                                    for (int i = 0; i < DGV.Rows.Count; ++i)
                                    {
                                        sum += Convert.ToDecimal(DGV.Rows[i].Cells[3].Value);
                                    }
                                    var Tottal = sum.ToString();
                                    CH.Tottalprice = Convert.ToDecimal(Tottal);
                                    if (CH.Tottalprice == Convert.ToDecimal("0.00"))
                                    {
                                        PDb.Cashes.Remove(CH);
                                    }
                                    else
                                    {
                                        CH.Countitem = DGV.Rows.Count;
                                        PDb.Entry(CH).State = EntityState.Modified;
                                    }
                                    await PDb.SaveChangesAsync();
                                    GBNC();
                                }
                            }
                        }
                        else
                        {
                            Pro = await PDb.Products.Where(p => p.Productname == Proname).FirstOrDefaultAsync();
                            Bc = await PDb.Barcodes.Where(b => b.ProId == Pro.Id).FirstOrDefaultAsync();

                            if (Pro != null)
                            {
                                for (int i = 0; i < 1; i++)
                                {
                                    if (Bc != null)
                                    {
                                        Bc.Pronumber = Pronum;
                                        Bc.ProId = Pro.Id;
                                        PDb.Barcodes.Add(Bc);
                                    }
                                    else
                                    {
                                        Bc.Pronumber = Pronum;
                                        Bc.ProId = Pro.Id;
                                        PDb.Barcodes.Add(Bc);
                                    }
                                    await PDb.SaveChangesAsync();
                                }
                                var NQty = Pro.Quantity;
                                Pro.Quantity = NQty + 1;
                                PDb.Entry(Pro).State = EntityState.Modified;

                                SL = new Model.Sold();
                                SL = await PDb.Solds.Where(s => s.Billnumber == Bn).FirstAsync();

                                var qtysd = SL.Quantity - 1;
                                SL.Quantity = qtysd;
                                SL.Endprice = Pro.Endprice * 1;
                                if (SL.Quantity == 0)
                                {

                                    PDb.Solds.Remove(SL);
                                    await PDb.SaveChangesAsync();
                                }
                                else
                                {
                                    PDb.Entry(SL).State = EntityState.Modified;
                                    await PDb.SaveChangesAsync();
                                }
                                GBNC();

                                CH = new Model.Cash();
                                CH = await PDb.Cashes.Where(c => c.Id == SL.CashId).FirstOrDefaultAsync();
                                decimal sum = 0;
                                for (int i = 0; i < DGV.Rows.Count; ++i)
                                {
                                    sum += Convert.ToDecimal(DGV.Rows[i].Cells[3].Value);
                                }
                                var Tottal = sum.ToString();
                                CH.Tottalprice = Convert.ToDecimal(Tottal);
                                if (CH.Tottalprice == Convert.ToDecimal("0.00"))
                                {
                                    PDb.Cashes.Remove(CH);
                                }
                                else
                                {
                                    CH.Countitem = DGV.Rows.Count;
                                    PDb.Entry(CH).State = EntityState.Modified;
                                }
                                await PDb.SaveChangesAsync();
                                GBNC();
                            }
                        }
                    }
                    else
                    {
                        Pro = await PDb.Products.Where(p => p.Productname == Proname).FirstOrDefaultAsync();
                        Sn = await PDb.Serialnumbers.Where(b => b.ProId == Pro.Id).FirstOrDefaultAsync();
                        if (Pro != null)
                        {
                            Sn = new Model.Serialnumber();
                            Sn.Pronumber = Pronum;
                            Sn.ProId = Pro.Id;
                            PDb.Serialnumbers.Add(Sn);
                            await PDb.SaveChangesAsync();

                            var NQty = Pro.Quantity;
                            Pro.Quantity = NQty + 1;
                            PDb.Entry(Pro).State = EntityState.Modified;

                            SL = new Model.Sold();
                            SL = await PDb.Solds.Where(s => s.Billnumber == Bn).FirstAsync();

                            var qtysd = SL.Quantity - 1;
                            SL.Quantity = qtysd;
                            SL.Endprice = Pro.Endprice * 1;
                            if (SL.Quantity == 0)
                            {

                                PDb.Solds.Remove(SL);
                                await PDb.SaveChangesAsync();
                            }
                            else
                            {
                                PDb.Entry(SL).State = EntityState.Modified;
                                await PDb.SaveChangesAsync();
                            }
                            GBNC();

                            CH = new Model.Cash();
                            CH = await PDb.Cashes.Where(c => c.Id == SL.CashId).FirstOrDefaultAsync();
                            decimal sum = 0;
                            for (int i = 0; i < DGV.Rows.Count; ++i)
                            {
                                sum += Convert.ToDecimal(DGV.Rows[i].Cells[3].Value);
                            }
                            var Tottal = sum.ToString();
                            CH.Tottalprice = Convert.ToDecimal(Tottal);
                            if (CH.Tottalprice == Convert.ToDecimal("0.00"))
                            {
                                PDb.Cashes.Remove(CH);
                            }
                            else
                            {
                                CH.Countitem = DGV.Rows.Count;
                                PDb.Entry(CH).State = EntityState.Modified;
                            }
                            await PDb.SaveChangesAsync();
                            GBNC();
                        }
                    }
                    Ch.Reall();
                }
                //لو المنتج غير جيد
                else if (RBU.Checked)
                {
                    var Msg = MessageBox.Show("Are you want change this products ? Y/N","Quastion",MessageBoxButtons.YesNoCancel);
                    if (Msg == DialogResult.Cancel)
                    {
                        return;
                    }
                    else if (Msg == DialogResult.No)
                    {
                        Pro = new Model.Product();
                        SL = new Model.Sold();
                        Dam = new Model.Damegd();
                        CH = new Model.Cash();
                        if (Type == "Barcode")
                        {
                            if (Qty > 1)
                            {
                                var msg = Interaction.InputBox("How many product you want return ?", "Question ?");
                                var x = int.Parse(msg);
                                if (msg.Length == 0)
                                {
                                    return;
                                }
                                else
                                {
                                    Pro = await PDb.Products.Where(p => p.Productname == Proname).FirstOrDefaultAsync();
                                    Dam = await PDb.Damegds.Where(b => b.Id == Pro.Id).FirstOrDefaultAsync();
                                    if (Dam == null)
                                    {
                                        Dam = new Model.Damegd();
                                        Dam.Billnumber = Bn;
                                        Dam.Productname = Proname;
                                        Dam.Productnumber = Pronum;
                                        Dam.Flages = Type;
                                        Dam.Quantity = x;
                                        Dam.Endprice = Convert.ToDecimal(Price);
                                        Dam.Tottal = Dam.Quantity * Dam.Endprice;
                                        Dam.Date = DateTime.Today;
                                        Dam.Time = DateTime.Now.ToShortTimeString();
                                        Dam.CategoryId = Pro.CategoryId;
                                        Dam.SupplierId = Pro.SupplierId;
                                        Dam.UnitId = Pro.UnitId;
                                        Dam.StorId = Pro.StorId;
                                        Dam.UserId = Pro.UserId;
                                        PDb.Damegds.Add(Dam);
                                        await PDb.SaveChangesAsync();

                                        SL = new Model.Sold();
                                        SL = await PDb.Solds.Where(s => s.Billnumber == Bn).FirstAsync();

                                        var qtysd = SL.Quantity - x;
                                        SL.Quantity = qtysd;
                                        SL.Endprice = Pro.Endprice * x;
                                        if (SL.Quantity == 0)
                                        {

                                            PDb.Solds.Remove(SL);
                                            await PDb.SaveChangesAsync();
                                        }
                                        else
                                        {
                                            PDb.Entry(SL).State = EntityState.Modified;
                                            await PDb.SaveChangesAsync();
                                        }
                                        GBNC();

                                        CH = new Model.Cash();
                                        CH = await PDb.Cashes.Where(c => c.Id == SL.CashId).FirstOrDefaultAsync();
                                        decimal sum = 0;
                                        for (int i = 0; i < DGV.Rows.Count; ++i)
                                        {
                                            sum += Convert.ToDecimal(DGV.Rows[i].Cells[3].Value);
                                        }
                                        var Tottal = sum.ToString();
                                        CH.Tottalprice = Convert.ToDecimal(Tottal);
                                        if (CH.Tottalprice == Convert.ToDecimal("0.00"))
                                        {
                                            PDb.Cashes.Remove(CH);
                                        }
                                        else
                                        {
                                            CH.Countitem = DGV.Rows.Count;
                                            PDb.Entry(CH).State = EntityState.Modified;
                                        }
                                        await PDb.SaveChangesAsync();
                                        GBNC();
                                    }
                                    else
                                    {
                                        Dam = new Model.Damegd();
                                        var NQtyb = Dam.Quantity;
                                        Dam.Quantity = NQtyb + 1;
                                        PDb.Entry(Dam).State = EntityState.Modified;
                                        await PDb.SaveChangesAsync();

                                        SL = new Model.Sold();
                                        SL = await PDb.Solds.Where(s => s.Billnumber == Bn).FirstAsync();

                                        var qtysd = SL.Quantity - x;
                                        SL.Quantity = qtysd;
                                        SL.Endprice = Pro.Endprice * x;
                                        if (SL.Quantity == 0)
                                        {

                                            PDb.Solds.Remove(SL);
                                            await PDb.SaveChangesAsync();
                                        }
                                        else
                                        {
                                            PDb.Entry(SL).State = EntityState.Modified;
                                            await PDb.SaveChangesAsync();
                                        }
                                        GBNC();

                                        CH = new Model.Cash();
                                        CH = await PDb.Cashes.Where(c => c.Id == SL.CashId).FirstOrDefaultAsync();
                                        decimal sum = 0;
                                        for (int i = 0; i < DGV.Rows.Count; ++i)
                                        {
                                            sum += Convert.ToDecimal(DGV.Rows[i].Cells[3].Value);
                                        }
                                        var Tottal = sum.ToString();
                                        CH.Tottalprice = Convert.ToDecimal(Tottal);
                                        if (CH.Tottalprice == Convert.ToDecimal("0.00"))
                                        {
                                            PDb.Cashes.Remove(CH);
                                        }
                                        else
                                        {
                                            CH.Countitem = DGV.Rows.Count;
                                            PDb.Entry(CH).State = EntityState.Modified;
                                        }
                                        await PDb.SaveChangesAsync();
                                        GBNC();

                                    }
                                }
                            }
                            else
                            {
                                Pro = await PDb.Products.Where(p => p.Productname == Proname).FirstOrDefaultAsync();
                                Dam = await PDb.Damegds.Where(b => b.Id == Pro.Id).FirstOrDefaultAsync();
                                if (Dam == null)
                                {
                                    Dam = new Model.Damegd();
                                    Dam.Billnumber = Bn;
                                    Dam.Productname = Proname;
                                    Dam.Productnumber = Pronum;
                                    Dam.Flages = Type;
                                    Dam.Quantity = 1;
                                    Dam.Endprice = Convert.ToDecimal(Price);
                                    Dam.Tottal = Dam.Quantity * Dam.Endprice;
                                    Dam.Date = DateTime.Today;
                                    Dam.Time = DateTime.Now.ToShortTimeString();
                                    Dam.CategoryId = Pro.CategoryId;
                                    Dam.SupplierId = Pro.SupplierId;
                                    Dam.UnitId = Pro.UnitId;
                                    Dam.StorId = Pro.StorId;
                                    Dam.UserId = Pro.UserId;
                                    PDb.Damegds.Add(Dam);
                                    await PDb.SaveChangesAsync();

                                    SL = new Model.Sold();
                                    SL = await PDb.Solds.Where(s => s.Productname == Dam.Productname).FirstAsync();

                                    var qtysd = SL.Quantity - 1;
                                    SL.Quantity = qtysd;
                                    SL.Endprice = Pro.Endprice * 1;
                                    if (SL.Quantity == 0)
                                    {
                                        PDb.Solds.Remove(SL);
                                        await PDb.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        PDb.Entry(SL).State = EntityState.Modified;
                                        await PDb.SaveChangesAsync();
                                    }
                                    GBNC();

                                    CH = new Model.Cash();
                                    CH = await PDb.Cashes.Where(c => c.Id == SL.CashId).FirstOrDefaultAsync();
                                    decimal sum = 0;
                                    for (int i = 0; i < DGV.Rows.Count; ++i)
                                    {
                                        sum += Convert.ToDecimal(DGV.Rows[i].Cells[3].Value);
                                    }
                                    var Tottal = sum.ToString();
                                    CH.Tottalprice = Convert.ToDecimal(Tottal);
                                    if (CH.Tottalprice == Convert.ToDecimal("0.00"))
                                    {
                                        PDb.Cashes.Remove(CH);
                                    }
                                    else
                                    {
                                        CH.Countitem = DGV.Rows.Count;
                                        PDb.Entry(CH).State = EntityState.Modified;
                                    }
                                    await PDb.SaveChangesAsync();
                                    GBNC();
                                }
                                else
                                {
                                    Dam = new Model.Damegd();
                                    Dam = await PDb.Damegds.Where(b => b.Productname == Proname).FirstOrDefaultAsync();

                                    var NQtyb = Dam.Quantity;
                                    Dam.Quantity = NQtyb + 1;
                                    PDb.Entry(Dam).State = EntityState.Modified;
                                    await PDb.SaveChangesAsync();

                                    SL = new Model.Sold();
                                    SL = await PDb.Solds.Where(s => s.Billnumber == Bn).FirstAsync();

                                    var qtysd = SL.Quantity - 1;
                                    SL.Quantity = qtysd;
                                    SL.Endprice = Pro.Endprice * 1;
                                    if (SL.Quantity == 0)
                                    {

                                        PDb.Solds.Remove(SL);
                                        await PDb.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        PDb.Entry(SL).State = EntityState.Modified;
                                        await PDb.SaveChangesAsync();
                                    }
                                    GBNC();

                                    CH = new Model.Cash();
                                    CH = await PDb.Cashes.Where(c => c.Id == SL.CashId).FirstOrDefaultAsync();
                                    decimal sum = 0;
                                    for (int i = 0; i < DGV.Rows.Count; ++i)
                                    {
                                        sum += Convert.ToDecimal(DGV.Rows[i].Cells[3].Value);
                                    }
                                    var Tottal = sum.ToString();
                                    CH.Tottalprice = Convert.ToDecimal(Tottal);
                                    if (CH.Tottalprice == Convert.ToDecimal("0.00"))
                                    {
                                        PDb.Cashes.Remove(CH);
                                    }
                                    else
                                    {
                                        CH.Countitem = DGV.Rows.Count;
                                        PDb.Entry(CH).State = EntityState.Modified;
                                    }
                                    await PDb.SaveChangesAsync();
                                    GBNC();

                                }
                            }
                        }
                        else
                        {
                            Pro = await PDb.Products.Where(p => p.Productname == Proname).FirstOrDefaultAsync();
                            Dam = await PDb.Damegds.Where(b => b.Id == Pro.Id).FirstOrDefaultAsync();
                            if (Dam == null)
                            {
                                Dam = new Model.Damegd();
                                Dam.Billnumber = Bn;
                                Dam.Productname = Proname;
                                Dam.Productnumber = Pronum;
                                Dam.Flages = Type;
                                Dam.Quantity = 1;
                                Dam.Endprice = Convert.ToDecimal(Price);
                                Dam.Tottal = Dam.Quantity * Dam.Endprice;
                                Dam.Date = DateTime.Today;
                                Dam.Time = DateTime.Now.ToShortTimeString();
                                Dam.CategoryId = Pro.CategoryId;
                                Dam.SupplierId = Pro.SupplierId;
                                Dam.UnitId = Pro.UnitId;
                                Dam.StorId = Pro.StorId;
                                Dam.UserId = Pro.UserId;
                                PDb.Damegds.Add(Dam);
                                await PDb.SaveChangesAsync();

                                SL = new Model.Sold();
                                SL = await PDb.Solds.Where(s => s.Productname == Dam.Productname).FirstAsync();

                                var qtysd = SL.Quantity - 1;
                                SL.Quantity = qtysd;
                                SL.Endprice = Pro.Endprice * 1;
                                if (SL.Quantity == 0)
                                {

                                    PDb.Solds.Remove(SL);
                                    await PDb.SaveChangesAsync();
                                }
                                else
                                {
                                    PDb.Entry(SL).State = EntityState.Modified;
                                    await PDb.SaveChangesAsync();
                                }
                                GBNC();

                                CH = new Model.Cash();
                                CH = await PDb.Cashes.Where(c => c.Id == SL.CashId).FirstOrDefaultAsync();
                                decimal sum = 0;
                                for (int i = 0; i < DGV.Rows.Count; ++i)
                                {
                                    sum += Convert.ToDecimal(DGV.Rows[i].Cells[3].Value);
                                }
                                var Tottal = sum.ToString();
                                CH.Tottalprice = Convert.ToDecimal(Tottal);
                                if (CH.Tottalprice == Convert.ToDecimal("0.00"))
                                {
                                    PDb.Cashes.Remove(CH);
                                }
                                else
                                {
                                    CH.Countitem = DGV.Rows.Count;
                                    PDb.Entry(CH).State = EntityState.Modified;
                                }
                                await PDb.SaveChangesAsync();
                                GBNC();
                            }
                        }
                    }
                    else
                    {
                        Pro = new Model.Product();
                        Bc = new Model.Barcode();
                        Sn = new Model.Serialnumber();
                        Dam = new Model.Damegd();
                        SL = new Model.Sold();
                        if (Type == "Barcode")
                        {
                            if (Qty > 1)
                            {
                                var msg = Interaction.InputBox("How many product you want change ?", "Question ?");
                                var x = int.Parse(msg);
                                if (msg.Length == 0)
                                {
                                    return;
                                }
                                else
                                {
                                    Pro = await PDb.Products.Where(p => p.Productname == Proname).FirstOrDefaultAsync();
                                    Dam = await PDb.Damegds.Where(b => b.Id == Pro.Id).FirstOrDefaultAsync();
                                    if (Dam == null)
                                    {
                                        Dam = new Model.Damegd();
                                        Dam.Billnumber = Bn;
                                        Dam.Productname = Proname;
                                        Dam.Productnumber = Pronum;
                                        Dam.Flages = Type;
                                        Dam.Quantity = x;
                                        Dam.Endprice = Convert.ToDecimal(Price);
                                        Dam.Tottal = Dam.Quantity * Dam.Endprice;
                                        Dam.Date = DateTime.Today;
                                        Dam.Time = DateTime.Now.ToShortTimeString();
                                        Dam.CategoryId = Pro.CategoryId;
                                        Dam.SupplierId = Pro.SupplierId;
                                        Dam.UnitId = Pro.UnitId;
                                        Dam.StorId = Pro.StorId;
                                        Dam.UserId = Pro.UserId;
                                        PDb.Damegds.Add(Dam);
                                        await PDb.SaveChangesAsync();

                                        Pro = new Model.Product();
                                        Pro.Quantity = x;
                                        for (int i = 0; i < x; i++)
                                        {
                                            Bc = await PDb.Barcodes.Where(b => b.Pronumber == Pronum).FirstOrDefaultAsync();
                                            PDb.Barcodes.Remove(Bc);
                                            await PDb.SaveChangesAsync();
                                        }
                                    }
                                    else
                                    {
                                        Dam = new Model.Damegd();
                                        var NQtyb = Dam.Quantity;
                                        Dam.Quantity = NQtyb + 1;
                                        PDb.Entry(Dam).State = EntityState.Modified;
                                        await PDb.SaveChangesAsync();

                                        Pro = new Model.Product();
                                        Pro.Quantity = x;
                                        for (int i = 0; i < x; i++)
                                        {
                                            Bc = await PDb.Barcodes.Where(b => b.Pronumber == Pronum).FirstOrDefaultAsync();
                                            PDb.Barcodes.Remove(Bc);
                                            await PDb.SaveChangesAsync();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Pro = await PDb.Products.Where(p => p.Productname == Proname).FirstOrDefaultAsync();
                                Dam = await PDb.Damegds.Where(b => b.Id == Pro.Id).FirstOrDefaultAsync();
                                if (Dam == null)
                                {
                                    Dam = new Model.Damegd();
                                    Dam.Billnumber = Bn;
                                    Dam.Productname = Proname;
                                    Dam.Productnumber = Pronum;
                                    Dam.Flages = Type;
                                    Dam.Quantity = 1;
                                    Dam.Endprice = Convert.ToDecimal(Price);
                                    Dam.Tottal = Dam.Quantity * Dam.Endprice;
                                    Dam.Date = DateTime.Today;
                                    Dam.Time = DateTime.Now.ToShortTimeString();
                                    Dam.CategoryId = Pro.CategoryId;
                                    Dam.SupplierId = Pro.SupplierId;
                                    Dam.UnitId = Pro.UnitId;
                                    Dam.StorId = Pro.StorId;
                                    Dam.UserId = Pro.UserId;
                                    PDb.Damegds.Add(Dam);
                                    await PDb.SaveChangesAsync();

                                    Pro = new Model.Product();
                                    Pro.Quantity = 1;
                                    Bc = await PDb.Barcodes.Where(b => b.Pronumber == Pronum).FirstOrDefaultAsync();
                                    PDb.Barcodes.Remove(Bc);
                                    await PDb.SaveChangesAsync();
                                }
                                else
                                {
                                    Dam = new Model.Damegd();
                                    var NQtyb = Dam.Quantity;
                                    Dam.Quantity = NQtyb + 1;
                                    PDb.Entry(Dam).State = EntityState.Modified;
                                    await PDb.SaveChangesAsync();

                                    Pro = new Model.Product();
                                    Pro.Quantity = 1;
                                    Bc = await PDb.Barcodes.Where(b => b.Pronumber == Pronum).FirstOrDefaultAsync();
                                    PDb.Barcodes.Remove(Bc);
                                    await PDb.SaveChangesAsync();
                                }
                            }
                        }
                        else
                        {
                            var msg = Interaction.InputBox("Where the product you want change ?", "Question ?");
                            if (msg.Length == 0)
                            {
                                return;
                            }
                            else
                            {
                                Pro = await PDb.Products.Where(p => p.Productname == Proname).FirstOrDefaultAsync();
                                Dam = await PDb.Damegds.Where(b => b.Id == Pro.Id).FirstOrDefaultAsync();
                                SL = await PDb.Solds.Where(s => s.Productnumber == Pronum).FirstOrDefaultAsync();
                                if (Dam == null)
                                {
                                    Dam = new Model.Damegd();
                                    Dam.Billnumber = Bn;
                                    Dam.Productname = Proname;
                                    Dam.Productnumber = Pronum;
                                    Dam.Flages = Type;
                                    Dam.Quantity = 1;
                                    Dam.Endprice = Convert.ToDecimal(Price);
                                    Dam.Tottal = Dam.Quantity * Dam.Endprice;
                                    Dam.Date = DateTime.Today;
                                    Dam.Time = DateTime.Now.ToShortTimeString();
                                    Dam.CategoryId = Pro.CategoryId;
                                    Dam.SupplierId = Pro.SupplierId;
                                    Dam.UnitId = Pro.UnitId;
                                    Dam.StorId = Pro.StorId;
                                    Dam.UserId = Pro.UserId;
                                    PDb.Damegds.Add(Dam);
                                    await PDb.SaveChangesAsync();

                                    var LPro = Pro.Quantity;
                                    Pro.Quantity = LPro - Qty;
                                    PDb.Entry(Pro).State = EntityState.Modified;
                                    await PDb.SaveChangesAsync();

                                    Sn = await PDb.Serialnumbers.Where(b => b.Pronumber == msg).FirstOrDefaultAsync();
                                    PDb.Serialnumbers.Remove(Sn);
                                    await PDb.SaveChangesAsync();

                                    SL.Productnumber = msg;
                                    PDb.Entry(SL).State = EntityState.Modified;
                                    await PDb.SaveChangesAsync();
                                }
                                else
                                {
                                    Dam = new Model.Damegd();
                                    var NQtyb = Dam.Quantity;
                                    Dam.Quantity = NQtyb + 1;
                                    PDb.Entry(Dam).State = EntityState.Modified;
                                    await PDb.SaveChangesAsync();

                                    var LPro = Pro.Quantity;
                                    Pro.Quantity = LPro - Qty;
                                    PDb.Entry(Pro).State = EntityState.Modified;
                                    await PDb.SaveChangesAsync();

                                    Sn = await PDb.Serialnumbers.Where(b => b.Pronumber == msg).FirstOrDefaultAsync();
                                    PDb.Serialnumbers.Remove(Sn);
                                    await PDb.SaveChangesAsync();

                                    SL.Productnumber = msg;
                                    PDb.Entry(SL).State = EntityState.Modified;
                                    await PDb.SaveChangesAsync();
                                }
                            }
                        }
                        GBNC();
                    }
                    Ch.Reall();
                }
                //
                else
                {
                    MessageBox.Show("Please check any Quastion ...", "Warning");
                }
            }
        }
    }
}
