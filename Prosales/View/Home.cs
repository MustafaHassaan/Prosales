using Prosales.Controler;
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
    public partial class Home : MetroFramework.Forms.MetroForm
    {
        public static string UNPassing;
        public static string IDPassing;
        public Home()
        {
            InitializeComponent();
        }
        Prosalescontext PDb;
        Model.Position Pos;
        private async void Home_Load(object sender, EventArgs e)
        {
            LblFN.Text = Login.UNPassing;
            LblId.Text = Login.IDPassing;
            PLd.Text = Convert.ToString(Login.Position);
            PDb = new Prosalescontext();
            Pos = new Model.Position();
            var id = Convert.ToInt32(PLd.Text);
            Pos = await PDb.Positions.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (Pos.Positionname == "Admin")
            {
                BtnTcust.Enabled = true;
                BtnCustomers.Enabled = true;
                BtnTOS.Enabled = true;
                BtnSupplirs.Enabled = true;
                BtnStore.Enabled = true;
                Btnr.Enabled = true;
                BtnCash.Enabled = true;
                BtnExpenses.Enabled = true;
                Btnunits.Enabled = true;
                BtnCategories.Enabled = true;
                BtnProducts.Enabled = true;
                BtnTsales.Enabled = true;
                BtnPOS.Enabled = true;
                BtnSignup.Enabled = true;
                BtnPositions.Enabled = true;
                BtnUsers.Enabled = true;
                Btnminimize.Enabled = true;
                Btnmaximize.Enabled = true;
                Btnlogout.Enabled = true;
                BtnBC.Enabled = true;
                Supreport.Enabled = true;
            }
            if (Pos.Positionname == "Sales")
            {
                Btnr.Enabled = true;
                BtnCash.Enabled = true;
                BtnExpenses.Enabled = true;
                BtnPOS.Enabled = true;
                Btnminimize.Enabled = true;
                Btnmaximize.Enabled = true;
                Btnlogout.Enabled = true;
            }
            if (Pos.Positionname == "Data Entry")
            {
                BtnTcust.Enabled = true;
                BtnCustomers.Enabled = true;
                BtnTOS.Enabled = true;
                BtnSupplirs.Enabled = true;
                BtnStore.Enabled = true;
                Btnunits.Enabled = true;
                BtnCategories.Enabled = true;
                BtnProducts.Enabled = true;
                Btnminimize.Enabled = true;
                Btnmaximize.Enabled = true;
                Btnlogout.Enabled = true;
                BtnBC.Enabled = true;
            }
            if (WindowState == FormWindowState.Maximized)
            {
                Btnmaximize.Text = "Normal";
            }
            else
            {
                Btnmaximize.Text = "Maximized";
            }
        }
        private void BtnSignup_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            signup.ShowDialog();
        }
        private void BtnPositions_Click(object sender, EventArgs e)
        {
            Position position = new Position();
            position.ShowDialog();
        }
        private void BtnUsers_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.ShowDialog();
        }
        private void BtnSupplirs_Click(object sender, EventArgs e)
        {
            Suppliers suppliers = new Suppliers();
            IDPassing = Convert.ToString(LblId.Text);
            suppliers.ShowDialog();
        }
        private void BtnStore_Click(object sender, EventArgs e)
        {
            Store store = new Store();
            store.ShowDialog();
        }
        private void BtnCategories_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories();
            categories.ShowDialog();
        }
        private void BtnProducts_Click(object sender, EventArgs e)
        {
            Products FP = new Products();
            IDPassing = Convert.ToString(LblId.Text);
            FP.ShowDialog();
        }
        private void Btnlogout_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("Prosales"))
            {
                process.Kill();
            }
        }
        private void Btnminimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void Btnmaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                Btnmaximize.Text = "Maximized";
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                Btnmaximize.Text = "Normal";
            }
        }
        private void Btnunits_Click(object sender, EventArgs e)
        {
            Unit UF = new Unit();
            UF.ShowDialog();
        }
        private void BtnPOS_Click(object sender, EventArgs e)
        {
            POS FPOS = new POS();
            IDPassing = Convert.ToString(LblId.Text);
            UNPassing = Convert.ToString(LblFN.Text);
            FPOS.ShowDialog();
        }
        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            Customers FCust = new Customers();
            IDPassing = Convert.ToString(LblId.Text);
            UNPassing = Convert.ToString(LblFN.Text);
            FCust.ShowDialog();
        }
        private void BtnTsales_Click(object sender, EventArgs e)
        {
            Tsale FTS = new Tsale();
            IDPassing = Convert.ToString(LblId.Text);
            UNPassing = Convert.ToString(LblFN.Text);
            FTS.ShowDialog();
        }
        private void BtnTcust_Click(object sender, EventArgs e)
        {
            Tcust FTC = new Tcust();
            IDPassing = Convert.ToString(LblId.Text);
            UNPassing = Convert.ToString(LblFN.Text);
            FTC.ShowDialog();
        }
        private void BtnCash_Click(object sender, EventArgs e)
        {
            Cash FC = new Cash();
            IDPassing = Convert.ToString(LblId.Text);
            FC.ShowDialog();
        }
        private void BtnExpenses_Click(object sender, EventArgs e)
        {
            Expenses FE = new Expenses();
            IDPassing = Convert.ToString(LblId.Text);
            FE.ShowDialog();
        }
        private void BtnTOS_Click(object sender, EventArgs e)
        {
            TOSupplier FTOS = new TOSupplier();
            FTOS.ShowDialog();
        }
        private void BtnrClick(object sender, EventArgs e)
        {
            Returned FR = new Returned();
            FR.ShowDialog();
        }
        private void Btnss_Click(object sender, EventArgs e)
        {
            View.Sales FS = new View.Sales();
            FS.ShowDialog();
        }
        private void BtnBC_Click(object sender, EventArgs e)
        {
            Barcode FBC = new Barcode();
            FBC.ShowDialog();
        }

        private void Supreport_Click(object sender, EventArgs e)
        {
            Supreport FSR = new Supreport();
            FSR.ShowDialog();
        }
    }
}

