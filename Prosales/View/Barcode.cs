using Prosales.Controler;
using Prosales.Model;
using Prosales.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace Prosales.View
{
    public partial class Barcode : MetroFramework.Forms.MetroForm
    {
        Prosalescontext PDb;
        PQR pqr;
        public Barcode()
        {
            InitializeComponent();
        }

        private void Barcode_Load(object sender, EventArgs e)
        {

        }
        private static Random random = new Random((int)DateTime.Now.Ticks);
        private static string RandomString(int length)
        {
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }
        private async void Btnex_Click(object sender, EventArgs e)
        {
            GFT();
            PDb = new Prosalescontext();
            pqr = new PQR();
            foreach (DataGridViewRow row in DGV.Rows)
            {
                var mes = Convert.ToString(row.Cells[0].Value);
                if (mes == null || mes == "")
                {
                    DGV.Rows.Clear();
                    TCN.Clear();
                    Pic.Image = null;
                    break;
                }
                else
                {
                    pqr = await PDb.PQRS.Where(p => p.Barcode == mes).SingleOrDefaultAsync();
                    PDb.PQRS.Remove(pqr);
                    await PDb.SaveChangesAsync();
                }            
            }
        }
        public void GFT()
        {
            CRB cr = new CRB();
            var Qua = from PQ in PDb.PQRS
                      select new
                      {
                          PQ.Data
                      };
            cr.SetDataSource(Qua.ToList());
            Bill FRB = new Bill();
            FRB.CRV.ReportSource = cr;
            FRB.Show();

        }
        private async void TCN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PDb = new Prosalescontext();
                pqr = new PQR();
                if (string.IsNullOrEmpty(TCN.Text))
                {
                    MessageBox.Show("Please enter Quantity ...", "Warning");
                }
                else
                {
                    var Count = Convert.ToInt32(TCN.Text);
                    for (int i = 0; i < Count; i++)
                    {
                        var mes = RandomString(13);
                        DataGridViewRow row = (DataGridViewRow)DGV.Rows[0].Clone();
                        BarcodeWriter Bw = new BarcodeWriter()
                        {
                            Format = BarcodeFormat.CODE_128
                        };
                        Pic.Image = Bw.Write(mes);
                        BarcodeReader Br = new BarcodeReader();
                        var Res = Br.Decode((Bitmap)Pic.Image);
                        if (Res != null)
                        {
                            var mesd = Res;



                            byte[] CITB(Image img)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    return ms.ToArray();
                                }
                            }







                            row.Cells[0].Value = mesd;
                            DGV.Rows.Add(row);
                            pqr = new PQR();
                            pqr = await PDb.PQRS.Where(p => p.Barcode == mes).SingleOrDefaultAsync();
                            if (pqr == null)
                            {
                                pqr = new PQR();
                                pqr.Barcode = mes;
                                pqr.Data = CITB(Pic.Image);
                                PDb.PQRS.Add(pqr);
                                await PDb.SaveChangesAsync();
                            }
                            else
                            {
                                MessageBox.Show("Can not insert this barcode again ...", "Warning");
                            }
                        }
                    }
                }
            }
        }
    }
}
