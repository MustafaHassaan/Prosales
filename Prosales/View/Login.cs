using Prosales.Controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prosales.View
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        Prosalescontext PDb;
        public static string UNPassing;
        public static string IDPassing;
        public static int Position;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            PB.BackgroundImage = IL.Images["Show.png"];
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            PDb = new Prosalescontext();
            if (string.IsNullOrEmpty(TUN.Text) || string.IsNullOrEmpty(TPW.Text))
            {
                MessageBox.Show("Please Insert UserName & Phone ...", "Error");
                return;
            }
            else if (!string.IsNullOrEmpty(TUN.Text) && !string.IsNullOrEmpty(TPW.Text))
            {
                try
                {
                    foreach (var user in PDb.Users)
                    {
                        if (user.Fullname == TUN.Text && user.Password == TPW.Text)
                        {
                            MessageBox.Show("Login Is Successfullu ...", "Success");
                            UNPassing = user.Fullname;
                            Position = user.PositionId;
                            IDPassing = Convert.ToString(user.Id);
                            Home FH = new Home();
                            FH.Show();
                            this.Hide();
                            return;
                        }

                        //else if (user.UserName == TUserName.Text && user.Password == TPassword.Text && user.PositionId == 3)
                        //{
                        //    MessageBox.Show("Dont Have Permotion To Open This Window ...", "Warning");
                        //    return;
                        //}
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Server Is Dowen ...", "Warning");
                    return;
                }
            }
            if (!string.IsNullOrEmpty(TUN.Text) && !string.IsNullOrEmpty(TPW.Text))
            {
                MessageBox.Show("Login Is Faild Please Try Again OR Signe UP ...", "Faild");
                return;
            }
        }
        private void TPW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PDb = new Prosalescontext();
                if (string.IsNullOrEmpty(TUN.Text) || string.IsNullOrEmpty(TPW.Text))
                {
                    MessageBox.Show("Please Insert UserName & Phone ...", "Error");
                    return;
                }
                else if (!string.IsNullOrEmpty(TUN.Text) && !string.IsNullOrEmpty(TPW.Text))
                {
                    try
                    {
                        foreach (var user in PDb.Users)
                        {
                            if (user.Fullname == TUN.Text && user.Password == TPW.Text)
                            {
                                MessageBox.Show("Login Is Successfullu ...", "Success");
                                UNPassing = user.Fullname;
                                Position = user.PositionId;
                                IDPassing = Convert.ToString(user.Id);
                                Home FH = new Home();
                                FH.Show();
                                this.Hide();
                                return;
                            }

                            //else if (user.UserName == TUserName.Text && user.Password == TPassword.Text && user.PositionId == 3)
                            //{
                            //    MessageBox.Show("Dont Have Permotion To Open This Window ...", "Warning");
                            //    return;
                            //}
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Server Is Dowen ...", "Warning");
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(TUN.Text) && !string.IsNullOrEmpty(TPW.Text))
                {
                    MessageBox.Show("Login Is Faild Please Try Again OR Signe UP ...", "Faild");
                    return;
                }
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
