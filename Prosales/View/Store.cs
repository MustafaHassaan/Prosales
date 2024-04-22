using Prosales.Controler;
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
    public partial class Store : MetroFramework.Forms.MetroForm
    {
        Prosalescontext PDb;
        Model.Store St;
        public Store()
        {
            InitializeComponent();
        }
        //Get Store
        public async void GS()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from ST in PDb.Stores
                          join Use in PDb.Users
                          on ST.UserId equals Use.Id
                          select new
                          {
                              ST.Storename,
                              Use.Fullname
                          };
                DGV.DataSource = Qua.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }

        //Get User
        public async void Gu()
        {
            PDb = new Prosalescontext();
            try
            {
                //string constr = @"Data Source=192.168.3.180;Initial Catalog=Prosales;Persist Security Info=True;User ID=PCServicesAdministrator;Password=PCS2020";
                string constr = Prosalescontext.Con();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, Fullname FROM Users", con))
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
                        CBU.DisplayMember = "Fullname";
                        CBU.ValueMember = "Id";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }
        private void Store_Load(object sender, EventArgs e)
        {
            GS();
            Gu();
        }
        private void SN_TextChanged(object sender, EventArgs e)
        { 
            if (string.IsNullOrEmpty(SN.Text))
            {
                BtnAdd.Enabled = false;
            }
            else
            {
                BtnAdd.Enabled = true;
            }
        }
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SN.Text) || CBU.Text == "-- All --")
            {
                MessageBox.Show("Please Insert Name Of Stok" + "\n" + "& Administrator Perosn", "warning");
                return;
            }
            else
            {
                try
                {
                    PDb = new Prosalescontext();
                    St = new Model.Store();
                    St.Storename = SN.Text;
                    St.UserId = int.Parse(CBU.SelectedValue.ToString());
                    PDb.Stores.Add(St);
                    await PDb.SaveChangesAsync();
                    SN.Clear();
                    Gu();
                    GS();
                    BtnEdit.Enabled = false;
                    BtnDel.Enabled = false;
                    MessageBox.Show("Store Is Saved Successfully ...", "Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Server Is Dowen ...", "warning");
                }
            }
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            SN.Clear();
            Gu();
            GS();
            BtnEdit.Enabled = false;
            BtnDel.Enabled = false;
        }
        private async void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PDb = new Prosalescontext();
            St = new Model.Store();
            if (DGV.Rows.Count > 0)
            {
                SN.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                St = await PDb.Stores.Where(s => s.Storename == SN.Text).FirstOrDefaultAsync();
                if (St != null)
                {
                    LblId.Text = Convert.ToString(St.Id);
                }
                else
                {
                    return;
                }
                CBU.Text = DGV.CurrentRow.Cells[1].Value.ToString();
                BtnAdd.Enabled = false;
                BtnEdit.Enabled = true;
                BtnDel.Enabled = true;
            }
        }
        private async void BtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(LblId.Text);
                PDb = new Prosalescontext();
                var store = await PDb.Stores.Where(X => X.Id == id).FirstOrDefaultAsync();
                PDb.Stores.Remove(store);
                await PDb.SaveChangesAsync();
                SN.Clear();
                Gu();
                GS();
                BtnEdit.Enabled = false;
                BtnDel.Enabled = false;
                MessageBox.Show("Store Is Deleting Successfully ...", "Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Cant delete this store becouse his added to products ...", "warning");
            }
        }
        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(LblId.Text);
                PDb = new Prosalescontext();
                var Store = await PDb.Stores.Where(X => X.Id == id).FirstOrDefaultAsync();
                Store.Storename = SN.Text;
                Store.UserId = int.Parse(CBU.SelectedValue.ToString());
                PDb.Entry(Store).State = EntityState.Modified;
                await PDb.SaveChangesAsync();
                SN.Clear();
                Gu();
                GS();
                BtnEdit.Enabled = false;
                BtnDel.Enabled = false;
                LblId.Text = "0";
                MessageBox.Show("Store Is Editing Successfully ...", "Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Cant delete this store becouse his added to products ...", "warning");
            }
        }
    }
}
