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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        #region  BusinessMethods
        void FillControls()
        {

        }

        bool ValidateControls()
        {
            errorProvider1.RightToLeft = true;
            bool check = true;
            if (txtusername.Text == "")
            {
                errorProvider1.SetError(txtusername, "من فضلك أدخل اسم المستخدم");
                check = false;
            }

            if (txtuserpassword.Text == "")
            {
                errorProvider1.SetError(txtuserpassword, "من فضلك أدخل الرقم السري");
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
        #endregion
        private void button1_Click_1(object sender, EventArgs e)
        {
             bool validation = ValidateControls();
            if (validation == true)
            {
                SystemUser su = new SystemUser();
                su.Password = txtuserpassword.Text;
                su.UserName = txtusername.Text;
                su.Status = 1;
                var res = su.CreateUser();
                var msg=res.message.ShowMessage();
                if (msg != "UserNameAlreadyExist")
                {
                    DataTable DT = new DataTable();
                    DT.Columns.Add("اسم المستخدم", typeof(string));
                    DT.Columns.Add("الرقم السري", typeof(string));
                    DataRow DR = DT.NewRow();
                    DR[0] = (res.Data as SystemUser).UserName;
                    DR[1] = (res.Data as SystemUser).Password;
                    DT.Rows.Add(DR);
                    dataGridView1.DataSource = DT;
                    dataGridView1.Visible = true;
                    label3.Text = msg;
                    label3.Visible = true;
                }
                label3.Visible = true;
            }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            if (txtusername.Text != "")
                errorProvider1.Clear();
        }
        private void txtuserpassword_TextChanged_1(object sender, EventArgs e)
        {
            if (txtuserpassword.Text != "")
                errorProvider1.Clear();
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                button1_Click_1(sender,e);
        }

        private void txtuserpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                button1_Click_1(sender, e);
        }
    }
}
