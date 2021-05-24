using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenSwitch
{
    public partial class Login : Form
    {
        MainForm main;

        public Login(MainForm m)
        {
            InitializeComponent();
            main = m;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            this.CenterToScreen();
            this.Text = Application.ProductName + " - Login";          
            txtPassword.UseSystemPasswordChar = true; //Masks password box with bullet point
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                LoginBL loginBL = new LoginBL();

                int num;
                bool intResult = int.TryParse(txtUsername.Text, out num);
                if (intResult) { 
                Authentication loggedEmp = loginBL.GetAuthentication(PopulateLoginObject());
                if (loggedEmp.getErrors().Count != 0)
                {
                    string msg = "";
                    foreach (Error error in loggedEmp.getErrors())
                    {
                        msg += error.ErrorDescription + Environment.NewLine;
                    }
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.ResetText();
                    txtPassword.ResetText();
                }
                else
                {
                    main.loggedInEmp = loggedEmp;
                        MessageBox.Show("Successful Login! \nUserName is "+ loggedEmp.Username, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                }
                else
                {
                    MessageBox.Show("userId should be number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Authentication PopulateLoginObject()
        {
          
      
                return new Authentication()
                {
                    EmployeeId = Convert.ToInt32(txtUsername.Text),
                    Password = txtPassword.Text
                };
            
        }
    }
}
