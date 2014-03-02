using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IVR.Models;

namespace IVR
{
    public partial class Login : Form
    {
        ModifyRegistry Reg = new ModifyRegistry();
        public Login()
        {
            InitializeComponent();
        }

        #region BusinessMethods

        void FillControls()
        {
           
        }

        bool ValidateControls()
        {
            var check = true;
            if (textBoxUserName.Text == "")
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(textBoxUserName, "من فضلك أدخل اسم المستخدم");
                check = false;
            }
            if (textBoxPassword.Text == "")
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(textBoxPassword, "من فضلك ادخل الرقم السري");
                check = false;
            }

            return check;
        }

        void Collect()
        {

        }

        void PushData()
        {

        }

        void Save()
        {

        }

        void Delete()
        {

        }

        #endregion

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUserName.Text != "")
            {
                errorProvider1.Clear();
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassword.Text != "")
            {
                errorProvider1.Clear();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ValidateControls();
            bool validation = ValidateControls();
            if (validation == true)
            {
                SystemUser user = new SystemUser();
                user.Password = textBoxPassword.Text;
                user.UserName = textBoxUserName.Text;
                var res = user.Login().message.ShowMessage();
                if (res == "دخول ناجح")
                {
                    bool r = Reg.Write("Name", textBoxUserName.Text);
                    bool rr = Reg.Write("Password", textBoxPassword);
                    MainScreen MS = new MainScreen();
                    this.Hide();
                    MS.ShowDialog();
                }
                label4.Text = res;
                label4.Visible = true;
            }
        }

        private void textBoxUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                pictureBox2_Click(sender, e);
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                pictureBox2_Click(sender, e);
            }
        }
    }
}
