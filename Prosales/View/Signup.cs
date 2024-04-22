using Prosales.Controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prosales.View
{
    public partial class Signup : MetroFramework.Forms.MetroForm
    {
        Prosalescontext PDb;
        public Signup()
        {
            InitializeComponent();
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
        private void Signup_Load(object sender, EventArgs e)
        {
            GP();
            PB.BackgroundImage = IL.Images["Show.png"];
        }
        private async void Btnsign_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TUN.Text) || string.IsNullOrEmpty(TPW.Text) || string.IsNullOrEmpty(TP.Text) || CBP.Text == "-- All --")
            {
                MessageBox.Show("Please Insert UserName , "+"\n"+"Password , Phone"+"\n"+"& Position ...", "warning");
                return;
            }
            else if (!string.IsNullOrEmpty(TPW.Text) && TPW.TextLength < 8)
            {
                MessageBox.Show("The Password Less Than 8 Charcter ... " + "\n" + "Must Be Equal 8 Or More Than ...", "warning");
                return;
            }
            else if (!string.IsNullOrEmpty(TP.Text) && TP.TextLength < 11)
            {
                MessageBox.Show("The Phone Less Than 11 Charcter ... " + "\n" + "Must Be Eual 11 ...", "warning");
                return;
            }
            else
            {
                try
                {
                    PDb = new Prosalescontext();
                    Model.User Us;
                    Us = new Model.User();
                    Us.Fullname = TUN.Text;
                    Us.Phonenumber = TP.Text;
                    Us.Password = TPW.Text;
                    Us.PositionId = int.Parse(CBP.SelectedValue.ToString());
                    PDb.Users.Add(Us);
                    await PDb.SaveChangesAsync();
                    TUN.Clear();
                    TP.Clear();
                    TPW.Clear();
                    GP();
                    MessageBox.Show("User Is Saved Successfully ...", "Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Server Is Dowen ...", "warning");
                }
            }
        }
        private void Btnsign_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void TP_KeyPress(object sender, KeyPressEventArgs e)
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
        private void PB_Click(object sender, EventArgs e)
        {
            PB.BackgroundImage = IL.Images["Hide.png"];
            if (TPW.UseSystemPasswordChar == true)
            {
                TPW.UseSystemPasswordChar = false;
            }
            else
            {
                PB.BackgroundImage = IL.Images["Show.png"];
                TPW.UseSystemPasswordChar = true;
            }
        }
    }
}
