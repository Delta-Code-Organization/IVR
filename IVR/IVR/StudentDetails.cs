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
        ModifyRegistry Reg = new ModifyRegistry();
        public StudentDetails()
        {
            InitializeComponent();
        }

        #region BusinessMethods

        void FillControls()
        {
            Student student = new Student();
           List<Student> LOS=student.GetAllStudents();
            DataTable DT = new DataTable();
            DT.Columns.Add("ID", typeof(int));
            DT.Columns.Add("اسم الطالب", typeof(string));
            DT.Columns.Add("رقم التليفون", typeof(string));
            foreach (var v in LOS)
            {
                DataRow DR = DT.NewRow();
                DR[0] = v.StudentID;
                DR[1] = v.S_name;
                DR[2] = v.S_phone;
                DT.Rows.Add(DR);
            }

            dataGridView1.DataSource = DT;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.Columns[0].DisplayIndex = 4;
            dataGridView1.Columns[1].DisplayIndex = 3;
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

        private void StudentDetails_Load(object sender, EventArgs e)
        {
            FillControls();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
         bool validation=ValidateControls();
         if (validation == true)
         {
             List<Student> LOS = new List<Student>();
             List<int> LOID = new List<int>();
             Student s = new Student();
             if (textBoxName.Text!= "")
             {
                 s.S_name = textBoxName.Text;
                 var res = s.SearchStudentsByName();
                 if (res.message.ShowMessage() != "NotFound")
                 {
                     LOS.Add(res.Data as Student);
                     LOID.Add((res.Data as Student).StudentID);
                 }
             }
             if (textBoxNumber.Text != "")
             {
                 s.S_phone = textBoxNumber.Text;
                 var res = s.SearchStudentsByPhone();
                 if (res.message.ShowMessage() != "NotFound")
                 {
                     if (!LOID.Contains((res.Data as Student).StudentID))
                         LOS.Add(res.Data as Student);
                 }
             }
             if (LOS.Count != 0)
             {
                 DataTable DT = new DataTable();
                 DT.Columns.Add("ID",typeof(int));
                 DT.Columns.Add("اسم الطالب", typeof(string));
                 DT.Columns.Add("رقم التليفون", typeof(string));
                 foreach (var v in LOS)
                 {
                     DataRow DR = DT.NewRow();
                     DR[0] = v.StudentID;
                     DR[1] = v.S_name;
                     DR[2] = v.S_phone;
                     DT.Rows.Add(DR);
                 }

                 dataGridView1.DataSource = DT;
                 dataGridView1.Columns[2].Visible = false;
                 dataGridView1.Visible = true;
                 dataGridView1.Columns[0].DisplayIndex = 4;
                 dataGridView1.Columns[1].DisplayIndex = 3;
             }
             else
             {
                 label6.Text = "لا يوجد نتائج بحث مطابقه";
                 label6.Visible = true;
                 dataGridView1.Visible = false;
             }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Student s = new Student();
            s.StudentID = (int)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
            if (e.ColumnIndex ==0)
            {
                s.DeleteStudent();
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
            if (e.ColumnIndex ==1)
            {
                Reg.Write("ID", s.StudentID.ToString());
                UpdateStudent us = new UpdateStudent();
                this.Hide();
                us.ShowDialog();
            }
        }
    }
}
