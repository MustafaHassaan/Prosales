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
    public partial class Categories : MetroFramework.Forms.MetroForm
    {
        Prosalescontext PDb;
        Model.Category Cat;
        public Categories()
        {
            InitializeComponent();
        }
        public async void Getcategories()
        {
            PDb = new Prosalescontext();
            try
            {
                var Qua = from cat in PDb.Categories
                          select new
                          {
                              cat.Categoryname
                          };
                DGV.DataSource = Qua.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Is Dowen ...", "warning");
            }
        }
        private void Categories_Load(object sender, EventArgs e)
        {
            Getcategories();
        }
        private void TCN_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TCN.Text))
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
            Cat = new Model.Category();
            if (DGV.Rows.Count > 0)
            {
                LblId.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                TCN.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                Cat = await PDb.Categories.Where(c => c.Categoryname == TCN.Text).FirstOrDefaultAsync();
                if (Cat != null)
                {
                    LblId.Text = Convert.ToString(Cat.Id);
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
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TCN.Text))
            {
                MessageBox.Show("Please Insert Category Name ...", "warning");
                return;
            }
            else
            {
                try
                {
                    PDb = new Prosalescontext();
                    Cat = new Model.Category();
                    Cat.Categoryname = TCN.Text;
                    PDb.Categories.Add(Cat);
                    await PDb.SaveChangesAsync();
                    Getcategories();
                    TCN.Clear();
                    MessageBox.Show("Category Is Saved Successfully ...", "Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Server Is Dowen ...", "warning");
                }
            }
        }
        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(LblId.Text);
                PDb = new Prosalescontext();
                var cat = await PDb.Categories.Where(X => X.Id == id).FirstOrDefaultAsync();
                cat.Categoryname = TCN.Text;
                PDb.Entry(cat).State = EntityState.Modified;
                await PDb.SaveChangesAsync();
                Getcategories();
                TCN.Clear();
                LblId.Text = "0";
                BtnEdit.Enabled = false;
                BtnDel.Enabled = false;
                MessageBox.Show("Category Is Editing Successfully ...", "Successfully");
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
                var cat = await PDb.Categories.Where(X => X.Id == id).FirstOrDefaultAsync();
                cat.Categoryname = TCN.Text;
                PDb.Categories.Remove(cat);
                await PDb.SaveChangesAsync();
                Getcategories();
                TCN.Clear();
                BtnEdit.Enabled = false;
                BtnDel.Enabled = false;
                MessageBox.Show("Category Is Deleting Successfully ...", "Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Cant delete this category becouse his added to products ...", "warning");
            }
        }
    }
}
