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
    public partial class Customers : MetroFramework.Forms.MetroForm
    {
        Prosalescontext PDb;
        Model.Customer Cust;
        public void GetCust()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from cust in PDb.Customers

                              //Get User Entry
                          join user in PDb.Users
                          on cust.UserId equals user.Id

                          //Get Customer Type
                          join TCust in PDb.TOCustomers
                          on cust.Tcustid equals TCust.Id

                          select new
                          {
                              cust.Customername,
                              cust.Email,
                              cust.Phone,
                              cust.AnotherPhone,
                              cust.Address,
                              TCust.TOCname,
                              user.Fullname
                          };
                DGV.DataSource = Qua.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }
        //Get Type Of Customers
        public void GTC()
        {
            try
            {
                //string constr = @"Data Source=192.168.3.180;Initial Catalog=Prosales;Persist Security Info=True;User ID=PCServicesAdministrator;Password=PCS2020";
                string constr = Prosalescontext.Con();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, TOCname FROM TOCustomers", con))
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
                        CBC.DataSource = dt;
                        CBC.DisplayMember = "TOCname";
                        CBC.ValueMember = "Id";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ths Server Is Dowen ...", "Error");
                return;
            }
        }
        public void Reall()
        {
            TCustName.Clear();
            TCustEmail.Clear();
            TCustAPhone.Clear();
            TCustPhone.Clear();
            TCustAddress.Clear();
            GetCust();
            GTC();
            Lblsid.Text = "0";
            BtnAdd.Enabled = true;
            BtnDel.Enabled = false;
            BtnEdit.Enabled = false;
        }
        public Customers()
        {
            InitializeComponent();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            LblId.Text = Login.IDPassing;
            GetCust();
            GTC();
        }
        private void TCustPhone_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TCustAPhone_KeyPress(object sender, KeyPressEventArgs e)
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
            if (string.IsNullOrEmpty(TCustName.Text) || 
                string.IsNullOrEmpty(TCustPhone.Text) || 
                string.IsNullOrEmpty(TCustEmail.Text) || 
                string.IsNullOrEmpty(TCustAddress.Text)|| CBC.Text == "-- All --")
            {
                MessageBox.Show("Please Insert Customer Name,"+"\n"+"Phone, Email,"+"\n"+"Address & Type Of Customer ...", "warning");
                return;
            }
            else
            {
                try
                {
                    PDb = new Prosalescontext();
                    Cust = new Model.Customer();
                    Cust.Customername = TCustName.Text;
                    Cust.Phone = TCustPhone.Text;
                    Cust.Email = TCustEmail.Text;
                    Cust.AnotherPhone = TCustAPhone.Text;
                    Cust.Address = TCustAddress.Text;
                    Cust.UserId = Convert.ToInt32(LblId.Text);
                    Cust.Tcustid = int.Parse(CBC.SelectedValue.ToString());
                    PDb.Customers.Add(Cust);
                    await PDb.SaveChangesAsync();
                    Reall();
                    MessageBox.Show("Customer Is Saved Successfully ...", "Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Server Is Dowen ...", "warning");
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
                var id = int.Parse(Lblsid.Text);
                PDb = new Prosalescontext();
                var Cust = await PDb.Customers.Where(X => X.Id == id).FirstOrDefaultAsync();
                Cust.Customername = TCustName.Text;
                Cust.Phone = TCustPhone.Text;
                Cust.Email = TCustEmail.Text;
                Cust.AnotherPhone = TCustAPhone.Text;
                Cust.Address = TCustAddress.Text;
                Cust.UserId = Convert.ToInt32(LblId.Text);
                Cust.Tcustid = int.Parse(CBC.SelectedValue.ToString());
                PDb.Entry(Cust).State = EntityState.Modified;
                await PDb.SaveChangesAsync();
                Reall();
                MessageBox.Show("Customer Is Editing Successfully ...", "Successfully");
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
                var id = int.Parse(Lblsid.Text);
                PDb = new Prosalescontext();
                var Cust = await PDb.Customers.Where(X => X.Id == id).FirstOrDefaultAsync();
                Cust.Customername = TCustName.Text;
                Cust.Phone = TCustPhone.Text;
                Cust.Email = TCustEmail.Text;
                Cust.AnotherPhone = TCustAPhone.Text;
                Cust.Address = TCustAddress.Text;
                Cust.UserId = Convert.ToInt32(LblId.Text);
                Cust.Tcustid = int.Parse(CBC.SelectedValue.ToString());
                PDb.Customers.Remove(Cust);
                await PDb.SaveChangesAsync();
                Reall();
                MessageBox.Show("Customer Is Deleting Successfully ...", "Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Cant delete this customer becouse his have order ...", "warning");
            }
        }
        private async void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PDb = new Prosalescontext();
            Cust = new Model.Customer();
            if (DGV.Rows.Count > 0)
            {
                TCustName.Text= DGV.CurrentRow.Cells[0].Value.ToString();
                Cust = await PDb.Customers.Where(c => c.Customername == TCustName.Text).FirstOrDefaultAsync();
                if (Cust != null)
                {
                    Lblsid.Text = Convert.ToString(Cust.Id);
                }
                else
                {
                    return;
                }
                TCustEmail.Text= DGV.CurrentRow.Cells[1].Value.ToString();
                TCustPhone.Text = DGV.CurrentRow.Cells[2].Value.ToString();
                TCustAPhone.Text= DGV.CurrentRow.Cells[3].Value.ToString();
                TCustAddress.Text= DGV.CurrentRow.Cells[4].Value.ToString();
                CBC.Text = DGV.CurrentRow.Cells[5].Value.ToString();
                BtnAdd.Enabled = false;
                BtnEdit.Enabled = true;
                BtnDel.Enabled = true;
            }
        }
    }
}
