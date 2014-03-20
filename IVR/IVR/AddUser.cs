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
        #region  BusinessMethods
        void FillControls()
        {
            SystemUser user = new SystemUser();
            List<SystemUser> LOU = user.GetAllUsers();
            DataTable DT = new DataTable();
            DT.Columns.Add("ID", typeof(int));
            DT.Columns.Add("اسم المستخدم", typeof(string));
            DT.Columns.Add("الرقم السري", typeof(string));
            foreach (SystemUser su in LOU)
            {
                DataRow DR = DT.NewRow();
                DR[0] = su.ID;
                DR[1] = su.UserName;
                DR[2] = su.Password;
                DT.Rows.Add(DR);
            }
            dataGridView1.DataSource = DT;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.Columns[0].DisplayIndex = 3;
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

        SystemUser Collect()
        {
            SystemUser su = new SystemUser();
            su.Password = txtuserpassword.Text;
            su.UserName = txtusername.Text;
            su.Status = 1;
            return su;
        }

        void PushData()
        {

        }

        void Save()
        {

        }
        #endregion

        private void AddUser_Load(object sender, EventArgs e)
        {
            FillControls();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (ValidateControls() == true)
            {
                label3.Visible = false;
                var res = Collect().CreateUser();
                var msg = res.message.ShowMessage();
                label3.Text = msg;
                label3.Visible = true;
                if (msg != "إسم المستخدم موجود بالفعل")
                {
                    FillControls();
                }
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
                button1_Click_1(sender, e);
        }

        private void txtuserpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                button1_Click_1(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SystemUser su = new SystemUser();
            su.ID = (int)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
            su.DeleteSystemUser();
            dataGridView1.Rows.RemoveAt(e.RowIndex);
        }

        private void AddUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainScreen mn = new MainScreen();
            this.Hide();
            mn.ShowDialog();
        }
    }
}
