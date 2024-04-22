using Prosales.Controler;
using Prosales.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prosales.View
{
    public partial class Serialnumber : MetroFramework.Forms.MetroForm
    {
        Products FPro;
        PSRSeriale PSR;
        PSR Psrs;
        public Serialnumber(Products _FPro)
        {
            InitializeComponent();
            FPro = _FPro;
        }
        Prosalescontext PDb;
        Model.Product Pro;
        Model.Serialnumber Sn;
        Model.PSRSeriale Psr;
        
        //Get Products Id
        public void GPro()
        {
            PDb = new Prosalescontext();
            int s = int.Parse(LblSid.Text);
            var Qua = from i in PDb.Serialnumbers
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
        private void Serialnumber_Load(object sender, EventArgs e)
        {
            LblSid.Text = Convert.ToString(View.Products.Pidpass);
            Lblu.Text = Home.IDPassing;
            GPro();
        }
        private void Btndone_Click(object sender, EventArgs e)
        {
            FPro.Reall();
            this.Close();
        }
        private async void BtnDel_Click(object sender, EventArgs e)
        {
            PDb = new Prosalescontext();
            Sn = new Model.Serialnumber();
            Pro = new Model.Product();
            Psr = new PSRSeriale();
            var Qty = 1;

            var id = int.Parse(LblSid.Text);
            Pro = await PDb.Products.Where(i => i.Id == id).FirstOrDefaultAsync();
            var Count = Pro.Quantity;
            Pro.Quantity = Count - Qty;
            var bid = Convert.ToInt32(LblId.Text);
            Sn = await PDb.Serialnumbers.Where(b => b.Id == bid).FirstOrDefaultAsync();
            Psr = await PDb.PSRSeriales.Where(p => p.Pronumber == Sn.Pronumber).FirstOrDefaultAsync();
            PDb.Entry(Pro).State = EntityState.Modified;
            PDb.Serialnumbers.Remove(Sn);
            PDb.PSRSeriales.Remove(Psr);
            await PDb.SaveChangesAsync();
            GPro();
            MessageBox.Show("Serial number Is Deleted Successfully", "Success");
        }
        private async void PS_KeyDown(object sender, KeyEventArgs e)
        {
            PDb = new Prosalescontext();
            Pro = new Model.Product();
            Sn = new Model.Serialnumber();
            PSR = new Model.PSRSeriale();
            Psrs = new Model.PSR();
            if (e.KeyCode == Keys.Enter)
            {
                int s = int.Parse(LblSid.Text);
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
                    PSR.ProId = Psrs.Id;
                    Sn.ProId = Pro.Id;
                    Sn.Pronumber = PS.Text;
                    PSR.Pronumber = Sn.Pronumber;
                    if (DGV.Rows.Count > 0)
                    {
                        for (int i = 0; i < DGV.Rows.Count; i++)
                        {
                            if (DGV.Rows[i].Cells[1].Value.ToString() == PS.Text)
                            {
                                MessageBox.Show("Cant add same Serial for this product ...", "Warning");
                                return;
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
                                PDb.Serialnumbers.Add(Sn);
                                PDb.PSRSeriales.Add(PSR);
                                await PDb.SaveChangesAsync();
                                GPro();
                                PS.Clear();
                                return;
                            }
                        }
                    }
                    else
                    {
                        //Model.SoldSerial SS = new Model.SoldSerial();
                        //SS = await PDb.SoldSerials.Where(sn => sn.Soldnumber == PS.Text).FirstOrDefaultAsync();
                        foreach (var item in PDb.Solds)
                        {
                            if (item.Productnumber == PS.Text)
                            {
                                MessageBox.Show("Cant add Product sold befor ...", "Warning");
                                return;
                            }
                        }
                        PDb.Entry(Pro).State = EntityState.Modified;
                        PDb.Serialnumbers.Add(Sn);
                        PDb.Entry(Psrs).State = EntityState.Modified;
                        PDb.PSRSeriales.Add(PSR);
                        await PDb.SaveChangesAsync();
                        GPro();
                        PS.Clear();
                        return;
                    }
                }
            }
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
                    var Sn = await PDb.Serialnumbers.Where(b => b.Pronumber == PS.Text).FirstOrDefaultAsync();
                    LblId.Text = Convert.ToString(Sn.Id);
                }
            }
            else
            {
                MessageBox.Show("Cannot make delete Please ask admin ...", "Warning");
            }
        }
    }
}
