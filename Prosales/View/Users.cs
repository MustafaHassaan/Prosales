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
    public partial class Users : MetroFramework.Forms.MetroForm
    {
        Prosalescontext PDb;
        Model.User user;
        public Users()
        {
            InitializeComponent();
        }
        public async void GetUsers()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from Use in PDb.Users
                          join Pos in PDb.Positions
                          on Use.PositionId equals Pos.Id
                          select new
                          {
                              Use.Fullname,
                              Use.Phonenumber,
                              Use.Password,
                              Pos.Positionname
                          };
                DGV.DataSource = Qua.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }

        //Get Position
        public void GP()
        {
            try
            {
                //string constr = @"Data Source=192.168.3.180;Initial Catalog=Prosales;Persist Security Info=True;User ID=PCServicesAdministrator;Password=PCS2020";
                string constr = Prosalescontext.Con();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, Positionname FROM Positions", con))
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
                        CBP.DataSource = dt;
                        CBP.DisplayMember = "Positionname";
                        CBP.ValueMember = "Id";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ths Server Is Dowen ...", "Error");
                return;
            }
        }

        //Get Position = Combobox
        public async void SBP()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from Use in PDb.Users
                          join Pos in PDb.Positions
                          on Use.PositionId equals Pos.Id
                          where Pos.Positionname == CBP.Text
                          select new
                          {
                              Use.Id,
                              Use.Fullname,
                              Use.Phonenumber,
                              Use.Password,
                              Pos.Positionname
                          };
                DGV.DataSource = Qua.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }

        //Get User
        public async void GU()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from Use in PDb.Users
                          where Use.Fullname.Contains(TSS.Text) || Use.Phonenumber.Contains(TSS.Text)
                          join Pos in PDb.Positions
                          on Use.PositionId equals Pos.Id
                          select new
                          {
                              Use.Id,
                              Use.Fullname,
                              Use.Phonenumber,
                              Use.Password,
                              Pos.Positionname
                          };
                DGV.DataSource = Qua.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }
        private void Users_Load(object sender, EventArgs e)
        {
            GP();
            GetUsers();
        }
        private async void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PDb = new Prosalescontext();
            user = new Model.User();
            if (DGV.Rows.Count > 0)
            {
                TFN.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                TPN.Text = DGV.CurrentRow.Cells[1].Value.ToString();
                TPW.Text = DGV.CurrentRow.Cells[2].Value.ToString();
                CBP.Text = DGV.CurrentRow.Cells[3].Value.ToString();
                user = await PDb.Users.Where(u => u.Fullname == TFN.Text).FirstOrDefaultAsync();
                if (user != null)
                {
                    LblId.Text = Convert.ToString(user.Id);
                }
                else
                {
                    return;
                }
                BtnEdit.Enabled = true;
                BtnDel.Enabled = true;
            }
        }
        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(LblId.Text);
                PDb = new Prosalescontext();
                var Use = await PDb.Users.Where(X => X.Id == id).FirstOrDefaultAsync();
                Use.Fullname = TFN.Text;
                Use.Password = TPW.Text;
                Use.Phonenumber = TPN.Text;
                Use.PositionId = int.Parse(CBP.SelectedValue.ToString());
                PDb.Entry(Use).State = EntityState.Modified;
                await PDb.SaveChangesAsync();
                TFN.Clear();
                TPW.Clear();
                TPN.Clear();
                GetUsers();
                GP();
                MessageBox.Show("User Is Editing Successfully ...", "Successfully");
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
                var id = int.Parse(LblId.Text);
                PDb = new Prosalescontext();
                var Use = await PDb.Users.Where(X => X.Id == id).FirstOrDefaultAsync();
                PDb.Users.Remove(Use);
                await PDb.SaveChangesAsync();
                TFN.Clear();
                TPW.Clear();
                TPN.Clear();
                GetUsers();
                GP();
                MessageBox.Show("User Is Deleting Successfully ...", "Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Cant delete this user becouse his added to store ...", "warning");
            }
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
        private void CBP_SelectedValueChanged(object sender, EventArgs e)
        {
        }
        private void TSS_TextChanged(object sender, EventArgs e)
        {
            GU();
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            TFN.Clear();
            TPW.Clear();
            TPN.Clear();
            TSS.Clear();
            GetUsers();
            GP();
        }
    }
}
