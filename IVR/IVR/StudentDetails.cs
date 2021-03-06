﻿using System;
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
            Student student = new Student();
            List<Student> LOS = student.GetAllStudents();
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

        Student Collect()
        {
            Student student = new Student();
            student.S_name = textBoxName.Text;
            student.S_phone = textBoxNumber.Text;
            return student;
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
            if (ValidateControls() == true)
            {
                var res = Collect().SearchStudents().Data as Student;
                if (res != null)
                {
                    DataTable DT = new DataTable();
                    DT.Columns.Add("ID", typeof(int));
                    DT.Columns.Add("اسم الطالب", typeof(string));
                    DT.Columns.Add("رقم التليفون", typeof(string));
                    DataRow DR = DT.NewRow();
                    DR[0] = res.StudentID;
                    DR[1] = res.S_name;
                    DR[2] = res.S_phone;
                    DT.Rows.Add(DR);
                    dataGridView1.DataSource = DT;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Visible = true;
                    dataGridView1.Columns[0].DisplayIndex = 4;
                    dataGridView1.Columns[1].DisplayIndex = 3;
                }
                else
                {
                    dataGridView1.Visible = false;
                    label6.Visible = true;
                    label6.Text = "لا يوجد نتائج بحث مطابقه";
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
            label7.Visible = false;
            Student s = new Student();
            s.StudentID = (int)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
            if (e.ColumnIndex == 0)
            {
                s.DeleteStudent();
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
            if (e.ColumnIndex == 1)
            {
                Session.ID = s.StudentID;
                UpdateStudent us = new UpdateStudent();
                this.Hide();
                us.ShowDialog();
            }
        }

        private void StudentDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainScreen mn = new MainScreen();
            this.Hide();
            mn.ShowDialog();
        }
    }
}
