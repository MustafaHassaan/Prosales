using Microsoft.VisualBasic;
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
    public partial class ProBarcode : MetroFramework.Forms.MetroForm
    {
        Prosalescontext PDb;
        Model.Product Pro;
        Model.Barcode Bc;
        Products FPro;
        PSRBarcode PBR;
        PSR Psrs;
        public ProBarcode(Products _FPro)
        {
            InitializeComponent();
            FPro = _FPro;
        }
        //Get Products Id
        public void GPro()
        {
            PDb = new Prosalescontext();
            int s = int.Parse(LblSid.Text);
            var Qua = from i in PDb.Barcodes
                      where i.ProId == s

                      join p in PDb.Products
                      on i.ProId equals p.Id

                      select new
                      {
                          p.Productname,
                          i.Pronumber
                      };
            DGV.DataSource = Qua.ToList();
        }
        private async void ProBarcode_Load(object sender, EventArgs e)
        {
            LblSid.Text = Convert.ToString(View.Products.Pidpass);
            Lblu.Text = Home.IDPassing;
            Lbl.Text = Convert.ToString(Products.PRidpass);
            GPro();
        }
        private async void PS_KeyDown(object sender, KeyEventArgs e)
        {
            PDb = new Prosalescontext();
            Pro = new Model.Product();
            Bc = new Model.Barcode();
            Psrs = new Model.PSR();
            PBR = new Model.PSRBarcode();
            if (e.KeyCode == Keys.Enter)
            {
                int s = int.Parse(LblSid.Text);
                var Msg = MessageBox.Show("Are you want add biger than one ? Y/N", "Quastion", MessageBoxButtons.YesNoCancel);
                if (Msg == DialogResult.Cancel)
                {
                    return;
                }
                if (Msg == DialogResult.No)
                {
                    if (string.IsNullOrEmpty(PS.Text))
                    {
                        MessageBox.Show("Please Insert Barcode Number Of Products", "Warning");
                        return;
                    }
                    else
                    {
                        var Qty = 1;

                        var pr = s;
                        Pro = await PDb.Products.Where(i => i.Id == s).FirstOrDefaultAsync();
                        Psrs = await PDb.PSRS.Where(p => p.Productname == Pro.Productname).FirstOrDefaultAsync();
                        Pro.Quantity = DGV.RowCount + 1;
                        Psrs.Quantity = Pro.Quantity;
                        Bc.ProId = Pro.Id;
                        PBR.ProId = Psrs.Id;
                        Bc.Pronumber = PS.Text;
                        PBR.Pronumber = Bc.Pronumber;
                        if (DGV.Rows.Count > 0)
                        {
                            for (int i = 0; i < DGV.Rows.Count; i++)
                            {
                                if (DGV.Rows[i].Cells[1].Value.ToString() == PS.Text)
                                {
                                    PDb.Entry(Pro).State = EntityState.Modified;
                                    PDb.Entry(Psrs).State = EntityState.Modified;
                                    PDb.Barcodes.Add(Bc);
                                    PDb.PSRBarcodes.Add(PBR);
                                    await PDb.SaveChangesAsync();
                                    GPro();
                                    PS.Clear();
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("Cant add difrrent barcode for this product ...", "Warning");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            foreach (var item in PDb.Solds)
                            {
                                if (item.Productnumber == PS.Text)
                                {
                                    MessageBox.Show("Cant add Product sold befor ...", "Warning");
                                    return;
                                }
                            }
                            PDb.Entry(Pro).State = EntityState.Modified;
                            PDb.Entry(Psrs).State = EntityState.Modified;
                            PDb.Barcodes.Add(Bc);
                            PDb.PSRBarcodes.Add(PBR);
                            await PDb.SaveChangesAsync();
                            GPro();
                            PS.Clear();
                            return;
                        }
                    }
                }
                if (Msg == DialogResult.Yes)
                {
                    var msg = Interaction.InputBox("How many product you want add ?", "Question ?");
                    if (msg.Length == 0)
                    {
                        return;
                    }
                    else
                    {
                        var Count = int.Parse(msg);
                        for (int y = 0; y < Count; y++)
                        {
                            if (DGV.Rows.Count > 0 && DGV.CurrentRow.Cells[1].Value.ToString() == PS.Text)
                            {
                                if (string.IsNullOrEmpty(PS.Text))
                                {
                                    MessageBox.Show("Please Insert Barcode Number Of Products", "Warning");
                                    return;
                                }
                                else
                                {
                                    var pr = s;
                                    Pro = await PDb.Products.Where(i => i.Id == s).FirstOrDefaultAsync();
                                    Bc.ProId = Pro.Id;
                                    Bc.Pronumber = PS.Text;
                                    foreach (var item in PDb.Solds)
                                    {
                                        if (item.Productnumber == PS.Text)
                                        {
                                            MessageBox.Show("Cant add Product sold befor ...", "Warning");
                                            return;
                                        }
                                    }
                                    PDb.Barcodes.Add(Bc);
                                    await PDb.SaveChangesAsync();

                                    Psrs = await PDb.PSRS.Where(p => p.Productname == Pro.Productname).FirstOrDefaultAsync();
                                    PBR.ProId = Psrs.Id;
                                    PBR.Pronumber = PS.Text;
                                    PDb.PSRBarcodes.Add(PBR);
                                    await PDb.SaveChangesAsync();
                                    GPro();


                                    Psrs.Quantity = DGV.Rows.Count;
                                    PDb.Entry(Psrs).State = EntityState.Modified;
                                    await PDb.SaveChangesAsync();

                                    Pro.Quantity = DGV.Rows.Count;
                                    PDb.Entry(Pro).State = EntityState.Modified;
                                    await PDb.SaveChangesAsync();
                                }
                            }
                            else if (DGV.Rows.Count == 0 )
                            {
                                if (string.IsNullOrEmpty(PS.Text))
                                {
                                    MessageBox.Show("Please Insert Barcode Number Of Products", "Warning");
                                    return;
                                }
                                else
                                {
                                    var pr = s;
                                    Pro = await PDb.Products.Where(i => i.Id == s).FirstOrDefaultAsync();
                                    Bc.ProId = Pro.Id;
                                    Bc.Pronumber = PS.Text;
                                    foreach (var item in PDb.Solds)
                                    {
                                        if (item.Productnumber == PS.Text)
                                        {
                                            MessageBox.Show("Cant add Product sold befor ...", "Warning");
                                            return;
                                        }
                                    }
                                    PDb.Barcodes.Add(Bc);
                                    await PDb.SaveChangesAsync();

                                    Psrs = await PDb.PSRS.Where(p => p.Productname == Pro.Productname).FirstOrDefaultAsync();
                                    PBR.ProId = Psrs.Id;
                                    PBR.Pronumber = PS.Text;
                                    PDb.PSRBarcodes.Add(PBR);
                                    await PDb.SaveChangesAsync();
                                    GPro();


                                    Psrs.Quantity = DGV.Rows.Count;
                                    PDb.Entry(Psrs).State = EntityState.Modified;
                                    await PDb.SaveChangesAsync();

                                    Pro.Quantity = DGV.Rows.Count;
                                    PDb.Entry(Pro).State = EntityState.Modified;
                                    await PDb.SaveChangesAsync();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Cant add difrrent barcode for this product ...", "Warning");
                                return;
                            }
                        }
                    }
                }
            }
        }
        private async void BtnDel_Click(object sender, EventArgs e)
        {
            PDb = new Prosalescontext();
            Bc = new Model.Barcode();
            Pro = new Model.Product();
            PBR = new PSRBarcode();
            var Qty = 1;

            var id = int.Parse(LblSid.Text);
            Pro = await PDb.Products.Where(i => i.Id == id).FirstOrDefaultAsync();
            var Count = Pro.Quantity;
            Pro.Quantity = Count - Qty;
            var bid = Convert.ToInt32(LblId.Text);
            Bc = await PDb.Barcodes.Where(b => b.Id == bid).FirstOrDefaultAsync();
            PBR = await PDb.PSRBarcodes.Where(p => p.Pronumber == Bc.Pronumber).FirstOrDefaultAsync();
            PDb.Entry(Pro).State = EntityState.Modified;
            PDb.PSRBarcodes.Remove(PBR);
            PDb.Barcodes.Remove(Bc);
            await PDb.SaveChangesAsync();
            GPro();
            MessageBox.Show("Barcode Is Deleted Successfully","Success");
        }
        private async void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {     
            User user = new User();
            var use = int.Parse(Lblu.Text);
            user = await PDb.Users.Where(u => u.Id == use).FirstOrDefaultAsync();
            var Pos = await PDb.Positions.Where(p => p.Id == user.PositionId).FirstOrDefaultAsync();
            if (Pos.Positionname == "Admin")
            {
                BtnDel.Enabled = true;
                if (DGV.Rows.Count > 0)
                {
                    PS.Text = DGV.CurrentRow.Cells[1].Value.ToString();
                    var Bc = await PDb.Barcodes.Where(b => b.Pronumber == PS.Text).FirstOrDefaultAsync();
                    LblId.Text = Convert.ToString(Bc.Id);
                }
            }
            else
            {
                MessageBox.Show("Cannot make delete Please ask admin ...","Warning");
            }
        }
        private void Btndone_Click(object sender, EventArgs e)
        {
            FPro.Reall();
            this.Close();
        }
    }
}
