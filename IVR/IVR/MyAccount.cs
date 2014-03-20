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
    public partial class MyAccount : Form
    {
        public MyAccount()
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
            if (textBoxPass.Text == "")
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(textBoxPass, "من فضلك ادخل الرقم السري الجديد");
                check = false;
            }
            if (textBoxConfirmPass.Text == "")
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(textBoxConfirmPass, "ادخل الرقم مرة اخري هنا");
                check = false;
            }
            if (textBoxConfirmPass.Text != "" && textBoxPass.Text != textBoxConfirmPass.Text)
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(textBoxConfirmPass, "تأكد من ان الرقمين متطابقين");
                check = false;
            }
            return check;

        }

        SystemUser Collect()
        {
            SystemUser user = new SystemUser();
            user.UserName = Session.Name;
            int id = (user.GetSystemUser().Data as SystemUser).ID;
            user.ID = id;
            user.Password = textBoxPass.Text;
            return user;
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

        private void textBoxPass_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPass.Text != "")
            {
                errorProvider1.Clear();
            }
        }

        private void textBoxConfirmPass_TextChanged(object sender, EventArgs e)
        {
            if (textBoxConfirmPass.Text != "")
            {
                errorProvider1.Clear();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            bool validation = ValidateControls();
            if (validation == true)
            {
                
                var res = Collect().UpdatePassword().message.ShowMessage();
                label7.Text = res;
                label7.Visible = true;
            }
        }

        private void textBoxPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                pictureBox2_Click(sender, e);
            }
        }

        private void textBoxConfirmPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                pictureBox2_Click(sender, e);
            }
        }

        private void MyAccount_Load(object sender, EventArgs e)
        {
            label2.Text = "   المستخدم الحالي   " + Session.Name;
        }

        private void MyAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainScreen mn = new MainScreen();
            this.Hide();
            mn.ShowDialog();
        }

    }
}
