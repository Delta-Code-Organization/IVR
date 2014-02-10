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
    public partial class StudentDetails : Form
    {
        public StudentDetails()
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
            if (textBoxName.Text == "" && textBoxNumber.Text == "")
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(textBoxNumber, "من فضلك أدخل قيمه للبحث بدلالتها");
                check = false;
            }
            int num;
            bool isNum = int.TryParse(textBoxNumber.Text.Trim(), out num);
            if (!isNum && textBoxNumber.Text != "")
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(textBoxNumber, "من فضلك أدخل قيمه رقميه");
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
        private void pictureBox2_Click(object sender, EventArgs e)
        {
         bool validation=ValidateControls();
         if (validation == true)
         {
             List<Student> LOS = new List<Student>();
             Student s = new Student();
             if (textBoxName.Text != "")
             {
                 s.S_name = textBoxName.Text;
                 var res = s.SearchStudentsByName();
                 LOS.Add(res);
             }
             if (textBoxNumber.Text != "")
             {
                 s.S_phone = textBoxNumber.Text;
                 var res = s.SearchStudentsByPhone();
                 LOS.Add(res);
             }
             DataTable DT = new DataTable();
             DT.Columns.Add("اسم الطالب", typeof(string));
            // DT.Columns.Add("البريد الألكتروني", typeof(string));
             DT.Columns.Add("رقم التليفون", typeof(string));
           //  DT.Columns.Add("الرقم السري", typeof(string));
            // DT.Columns.Add("الساعات المعتمدة", typeof(string));
             foreach (var v in LOS)
             {
                 DataRow DR = DT.NewRow();
                 DR[0] = v.S_name;
                // DR[1] = v.S_email;
                 DR[1] = v.S_phone;
                // DR[3] = v.S_pw;
                 //DR[4] = v.Credits_aquired;
                 DT.Rows.Add(DR);
             }
             dataGridView1.DataSource = DT;
             dataGridView1.Visible = true;
         }
        }
        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                pictureBox2_Click(sender, e);
            }
        }

        private void textBoxNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                pictureBox2_Click(sender, e);
            }
        }
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text != "")
            {
                errorProvider1.Clear();
            }
        }

        private void textBoxNumber_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNumber.Text != "")
            {
                errorProvider1.Clear();
            }
        }
    }
}
