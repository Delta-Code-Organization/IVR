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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }
        #region BusinessMethods

        void FillControls()
        {

        }

        bool ValidateControls()
        {
            bool check = true;
            errorProvider1.RightToLeft = true;
            if (txtusername.Text == "")
            {
                errorProvider1.SetError(txtusername, "من فضلك أدخل اسم الطالب");
                check = false;
            }
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "من فضلك أدخل الرقم السري");
                check = false;
            }
                int hours;
            if(!int.TryParse(textBox2.Text,out hours))
            {
                 errorProvider1.SetError(textBox2, "من فضلك أدخل قيمة رقمية");
                check = false;
            }
            if (textBox2.TextLength<1)
            {
                errorProvider1.SetError(textBox2, "من فضلك أدخل عدد الساعات");
                check = false;
            }
            if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox3, "من فضلك أدخل البريد الالكتروني");
                check = false;
            }
            if (!int.TryParse(textBox4.Text, out hours))
            {
                errorProvider1.SetError(textBox4, "من فضلك أدخل قيمة رقمية");
                check = false;
            }
            if (textBox4.Text == "")
            {
                errorProvider1.SetError(textBox4, "من فضلك أدخل رقم الهاتف"); 
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
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
        bool validation=ValidateControls();
        if (validation == true)
        {
            Student s = new Student();
            s.S_email = textBox3.Text;
            s.S_name = txtusername.Text;
            s.S_phone = textBox4.Text;
            s.S_pw = textBox1.Text;
            s.Credits_aquired = Convert.ToInt32(textBox2.Text);
            var retun = s.CreateStudent();
            label7.Text = retun.message.ShowMessage();
            label7.Visible = true;
            if (label7.Text != "StudentNameDublicated")
            {
                Student res = retun.Data as Student;
                DataTable DT = new DataTable();
                DT.Columns.Add("اسم الطالب", typeof(string));
                DT.Columns.Add("الايميل", typeof(string));
                DT.Columns.Add("رقم الهاتف", typeof(string));
                DT.Columns.Add("الرقم السري", typeof(string));
                DT.Columns.Add("عدد الساعات", typeof(string));
                DataRow DR = DT.NewRow();
                DR[0] = res.S_name;
                DR[1] = res.S_email;
                DR[2] = res.S_phone;
                DR[3] = res.S_pw;
                DR[4] = res.Credits_aquired;
                DT.Rows.Add(DR);
                dataGridView1.DataSource = DT;
                dataGridView1.Visible = true;
            }
        }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            if (txtusername.Text != "")
                errorProvider1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                errorProvider1.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
                errorProvider1.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
                errorProvider1.Clear();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
                errorProvider1.Clear();
        }
    }
}
