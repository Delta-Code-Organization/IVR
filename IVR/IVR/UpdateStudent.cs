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
    public partial class UpdateStudent : Form
    {
        ModifyRegistry Reg = new ModifyRegistry();
        public UpdateStudent()
        {
            InitializeComponent();
        }
        #region  BusinessMethods
        void FillControls()
        {
            Student s = new Student();
            s.StudentID = Convert.ToInt32(Reg.Read("ID"));
            s = (Student)s.GetStudent().Data;
            txtname.Text = s.S_name;
            txtmail.Text = s.S_email;
            txtphone.Text = s.S_phone;
            txtpass.Text = s.S_pw;
            txtcredit.Text = Convert.ToString(s.Credits_aquired);
        }

        //bool ValidateControls()
        //{
        //}

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

        private void button1_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.StudentID = Convert.ToInt32(Reg.Read("ID"));
            s.S_name = txtname.Text;
            s.S_email = txtmail.Text;
            s.S_phone = txtphone.Text;
            s.S_pw = txtpass.Text;
            s.Credits_aquired = Convert.ToInt32(txtcredit.Text);
            s.UpdateStudent();
            StudentDetails detail = new StudentDetails();
            this.Hide();
            detail.ShowDialog();
        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                button1_Click(sender, e);
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                button1_Click(sender, e);
        }

        private void txtcredit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                button1_Click(sender, e);
        }

        private void txtmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                button1_Click(sender, e);
        }

        private void txtphone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                button1_Click(sender, e);
        }

        private void UpdateStudent_Load(object sender, EventArgs e)
        {
            FillControls();
        }

        private void UpdateStudent_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            StudentDetails sd = new StudentDetails();
            this.Hide();
            sd.ShowDialog();

        }
    }
}
