using Prosales.Controler;
using Prosales.Model;
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
    public partial class Suppliers : MetroFramework.Forms.MetroForm
    {
        Prosalescontext PDb;
        Supplier Sup;
        public Suppliers()
        {
            InitializeComponent();
        }
        //Get Type Of Supplier
        public void TOS()
        {
            try
            {
                //string constr = @"Data Source=192.168.3.180;Initial Catalog=Prosales;Persist Security Info=True;User ID=PCServicesAdministrator;Password=PCS2020";
                string constr = Prosalescontext.Con();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, TOSname FROM TOSuppliers", con))
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
                        CBT.DataSource = dt;
                        CBT.DisplayMember = "TOSname";
                        CBT.ValueMember = "Id";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ths Server Is Dowen ...", "Error");
                return;
            }
        }
        //Get Suppliers
        public async void GS()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from SP in PDb.Suppliers

                          join type in PDb.TOSuppliers
                          on SP.TSId equals type.Id

                          join Use in PDb.Users
                          on SP.UserId equals Use.Id

                          select new
                          {
                              SP.SupplierName,
                              SP.Phone,
                              SP.AtherPhone,
                              SP.Email,
                              SP.Address,
                              type.TOSname,
                              Use.Fullname
                          };
                DGV.DataSource = Qua.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }
        //Get Suppliers By Search
        public async void GSS()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from SP in PDb.Suppliers
                          where SP.Email.Contains(TSS.Text) || SP.SupplierName.Contains(TSS.Text) || SP.Phone.Contains(TSS.Text)
                          join Use in PDb.Users
                          on SP.UserId equals Use.Id
                          join type in PDb.TOSuppliers
                          on SP.TSId equals type.Id
                          select new
                          {
                              SP.SupplierName,
                              SP.Phone,
                              SP.AtherPhone,
                              SP.Email,
                              SP.Address,
                              type.TOSname,
                              Use.Fullname
                          };
                DGV.DataSource = Qua.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }
        private void Suppliers_Load(object sender, EventArgs e)
        {
            LblId.Text = Home.IDPassing;
            GS();
            TOS();
        }
        private void TPN_KeyPress(object sender, KeyPressEventArgs e)
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
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TSN.Text) ||
                string.IsNullOrEmpty(TPN.Text) ||
                string.IsNullOrEmpty(TSE.Text) ||
                string.IsNullOrEmpty(TSA.Text) ||
                CBT.Text == "-- All --")
            {
                MessageBox.Show("Please Insert Name Of Supplier , " + "\n" + "Phone , Email ," + "\n" + "Type & Address ...", "warning");
                return;
            }
            else if (!string.IsNullOrEmpty(TPN.Text) && TPN.TextLength < 11)
            {
                MessageBox.Show("The Phone Less Than 11 Charcter ... " + "\n" + "Must Be Eual 11 ...", "warning");
                return;
            }
            else
            {
                try
                {
                    PDb = new Prosalescontext();
                    Supplier SP;
                    SP = new Supplier();
                    SP.SupplierName = TSN.Text;
                    SP.Phone = TPN.Text;
                    SP.AtherPhone = TAP.Text;
                    SP.Email = TSE.Text;
                    SP.Address = TSA.Text;
                    SP.TSId = int.Parse(CBT.SelectedValue.ToString());
                    SP.UserId = int.Parse(LblId.Text);
                    PDb.Suppliers.Add(SP);
                    await PDb.SaveChangesAsync();

                    TSN.Clear();
                    TPN.Clear();
                    TAP.Clear();
                    TSE.Clear();
                    TSA.Clear();
                    TOS();
                    GS();
                    MessageBox.Show("Supplier Is Saved Successfully ...", "Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Server Is Dowen ...", "warning");
                }
            }
        }
        private void TSS_TextChanged(object sender, EventArgs e)
        {
            GSS();
        }
        private void TAP_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TSA_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TSA.Text))
            {
                BtnAdd.Enabled = true;
            }
            else
            {
                BtnAdd.Enabled = false;
            }
        }
        private async void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PDb = new Prosalescontext();
            Sup = new Supplier();
            if (DGV.Rows.Count > 0)
            {
                TSN.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                TPN.Text = DGV.CurrentRow.Cells[1].Value.ToString();
                TAP.Text = DGV.CurrentRow.Cells[2].Value.ToString();
                TSE.Text = DGV.CurrentRow.Cells[3].Value.ToString();
                CBT.Text = DGV.CurrentRow.Cells[5].Value.ToString();
                TSA.Text = DGV.CurrentRow.Cells[4].Value.ToString();
                Sup = await PDb.Suppliers.Where(s => s.SupplierName == TSN.Text).FirstOrDefaultAsync();
                if (Sup != null)
                {
                    LblSid.Text = Convert.ToString(Sup.Id);
                }
                else
                {
                    return;
                }

                BtnAdd.Enabled = false;
                BtnEdit.Enabled = true;
                BtnDel.Enabled = true;
            }
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            TOS();
            GS();
            TSS.Clear();
            TSN.Clear();
            TPN.Clear();
            TAP.Clear();
            TSE.Clear();
            TSA.Clear();
            BtnAdd.Enabled = false;
            BtnDel.Enabled = false;
            BtnEdit.Enabled = false;
        }
        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(LblSid.Text);
                PDb = new Prosalescontext();
                var SP = await PDb.Suppliers.Where(X => X.Id == id).FirstOrDefaultAsync();
                SP.SupplierName = TSN.Text;
                SP.Phone = TPN.Text;
                SP.AtherPhone = TAP.Text;
                SP.Email = TSE.Text;
                SP.Address = TSA.Text;
                SP.TSId = int.Parse(CBT.SelectedValue.ToString());
                SP.UserId = int.Parse(LblId.Text);
                PDb.Entry(SP).State = EntityState.Modified;
                await PDb.SaveChangesAsync();
                TOS();
                GS();
                LblSid.Text = "0";
                TSS.Clear();
                TSN.Clear();
                TPN.Clear();
                TAP.Clear();
                TSE.Clear();
                TSA.Clear();
                BtnAdd.Enabled = false;
                BtnDel.Enabled = false;
                BtnEdit.Enabled = false;
                MessageBox.Show("Supplier Is Editing Successfully ...", "Successfully");
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
                var id = int.Parse(LblSid.Text);
                PDb = new Prosalescontext();
                var SP = await PDb.Suppliers.Where(X => X.Id == id).FirstOrDefaultAsync();
                SP.SupplierName = TSN.Text;
                SP.Phone = TPN.Text;
                SP.AtherPhone = TAP.Text;
                SP.Email = TSE.Text;
                SP.Address = TSA.Text;
                SP.TSId = int.Parse(CBT.SelectedValue.ToString());
                SP.UserId = int.Parse(LblId.Text);
                PDb.Suppliers.Remove(SP);
                await PDb.SaveChangesAsync();
                TOS();
                GS();
                TSS.Clear();
                TSN.Clear();
                TPN.Clear();
                TAP.Clear();
                TSE.Clear();
                TSA.Clear();
                BtnAdd.Enabled = false;
                BtnDel.Enabled = false;
                BtnEdit.Enabled = false;
                MessageBox.Show("Supplier Is Deleting Successfully ...", "Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Cant delete this supplier becouse his in products ...", "warning");
            }
        }
    }
}
