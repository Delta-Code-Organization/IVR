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
    public partial class StudentMaterials : Form
    {
        public StudentMaterials()
        {
            InitializeComponent();
        }

        #region BusinessMethods

        void FillControls()
        {
            Student s = new Student();
            var res = s.GetAllStudents();
            DataTable DT = new DataTable();
            DT.Columns.Add("اسم الطالب", typeof(string));
            DT.Columns.Add("رقم المسلسل", typeof(int));
            foreach (var d in res)
            {
                DataRow DR = DT.NewRow();
                DR[0] = d.S_name;
                DR[1] = d.StudentID;
                DT.Rows.Add(DR);
            }
            comboBoxStudentName.DataSource = DT;
            comboBoxStudentName.DisplayMember = "اسم الطالب";
            comboBoxStudentName.ValueMember = "رقم المسلسل";
            comboBoxStudentName.SelectedIndex = -1;
            Course c = new Course();
            var res2 = c.GetAllcourses();
            DataTable DT2 = new DataTable();
            DT2.Columns.Add("اسم المادة", typeof(string));
            DT2.Columns.Add("رقم المسلسل", typeof(int));
            foreach (var x in res2)
            {
                DataRow DR = DT2.NewRow();
                DR[0] = x.CourseName;
                DR[1] = x.CourseID;
                DT2.Rows.Add(DR);
            }
            comboBoxMaterial.DataSource = DT2;
            comboBoxMaterial.DisplayMember = "اسم المادة";
            comboBoxMaterial.ValueMember = "رقم المسلسل";
            this.comboBoxMaterial.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaterial_SelectedIndexChanged);
            Student student = new Student();
            List<Student> LOS = student.GetAllStudents();
            List<Course> LOC = c.GetAllcourses();
            DataTable DT3 = new DataTable();
            DT3.Columns.Add("StudentID", typeof(int));
            DT3.Columns.Add("CourseID", typeof(int));
            DT3.Columns.Add("اسم الطالب", typeof(string));
            DT3.Columns.Add("اسم المادة", typeof(string));
            DT3.Columns.Add("ميعاد المحاضرة", typeof(string));
            foreach (Student std in LOS)
            {
                if (std.Course.Count != 0)
                {
                    foreach (Course cs in std.Course)
                    {
                        DataRow DR2 = DT3.NewRow();
                        var time = cs.TimeTable.Where(p => p.Section_ID == cs.CourseID).ToList();
                        foreach (TimeTable ttb in time)
                        {
                            DR2[0] = std.StudentID;
                            DR2[1] = cs.CourseID;
                            DR2[2] = std.S_name;
                            DR2[3] = cs.CourseName;
                            DR2[4] = ttb.CourseTime;
                        }
                        DT3.Rows.Add(DR2);
                    }
                }
            }
            dataGridView1.DataSource = DT3;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.Columns[0].DisplayIndex = 5;
            TimeTable startTime = new TimeTable();
            var res3 = startTime.GetCourseStartTime().Data as List<TimeTable>;
            DataTable DT4 = new DataTable();
            DT4.Columns.Add("ID", typeof(int));
            DT4.Columns.Add("بداية المحاضرة", typeof(string));
            foreach (TimeTable t in res3)
            {
                DataRow DR4 = DT4.NewRow();
                DR4[0] = t.Section_ID;
                DR4[1] = t.CourseTime;
                DT4.Rows.Add(DR4);
            }
            comboBoxTime.DataSource = DT4;
            comboBoxTime.DisplayMember = "بداية المحاضرة";
            comboBoxTime.ValueMember = "ID";
            comboBoxTime.SelectedIndex = -1;

        }

        bool ValidateControls()
        {
            errorProvider1.RightToLeft = true;
            bool Check = true;
            if (comboBoxMaterial.SelectedItem == null)
            {
                errorProvider1.SetError(comboBoxMaterial, " من فضلك إختر اسم المادة ");
                Check = false;
            }
            if (comboBoxStudentName.SelectedItem == null)
            {
                errorProvider1.SetError(comboBoxStudentName, "من فضلك إختر اسم الطالب");
                Check = false;
            }

            if (comboBoxTime.SelectedItem == null)
            {
                errorProvider1.SetError(comboBoxTime, "من فضلك إختر ميعاد المحاضره");
                Check = false;
            }
            return Check;
        }

        Course Collect()
        {
            Course c = new Course();
            c.CourseID = (int)comboBoxMaterial.SelectedValue;
            return c;
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


        private void StudentMaterials_Load(object sender, EventArgs e)
        {
            FillControls();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (ValidateControls() == true)
            {
                label8.Visible = false;
                int studentID = (int)comboBoxStudentName.SelectedValue;
                string[] startday = (comboBoxTime.Text).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int day = (int)Enum.Parse(typeof(Dayenum), startday[0]);
                var res = Collect().AddStudentCourse(studentID, startday[1], day);
                var msg = res.message.ShowMessage();
                var result = res.Data as Course;
                label8.Text = msg;
                label8.Visible = true;
                if (msg != "عدد الطلاب مكتمل" && msg != "هذا الطالب مضاف بالفعل لهذه الماده" && msg != "الطالب ليس لديه المتطلبات اللازمه لدراسة هذه المادة")
                {
                    FillControls();
                }
            }

        }

        private void comboBoxMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMaterial.SelectedItem != null)
            {
                errorProvider1.Clear();
            }
            Course c = new Course();
            c.CourseID = (int)comboBoxMaterial.SelectedValue;
            var course = c.GetAllcourses();
            var selectedCourse = course.Where(p => p.CourseID == c.CourseID).SingleOrDefault();
            var time = selectedCourse.TimeTable.Where(p => p.Section_ID == c.CourseID).ToList();
            comboBoxTime.DataSource = time;
            DataTable DT4 = new DataTable();
            DT4.Columns.Add("ID", typeof(int));
            DT4.Columns.Add("بداية المحاضرة", typeof(string));
            foreach (TimeTable t in time)
            {
                DataRow DR4 = DT4.NewRow();
                DR4[0] = t.Section_ID;
                DR4[1] = t.CourseTime;
                DT4.Rows.Add(DR4);
            }
            comboBoxTime.DataSource = DT4;
            comboBoxTime.DisplayMember = "بداية المحاضرة";
            comboBoxTime.ValueMember = "ID";
            comboBoxTime.SelectedIndex = -1;
        }

        private void comboBoxStudentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStudentName.SelectedItem != null)
            {
                errorProvider1.Clear();
            }
        }
        private void comboBoxTime_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxTime.SelectedItem != null)
            {
                errorProvider1.Clear();
            }
        }
        private void comboBoxTime_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                button1_Click_1(sender, e);
        }
        private void comboBoxMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                button1_Click_1(sender, e);
        }

        private void comboBoxStudentName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                button1_Click_1(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Course c = new Course();
            int id = (int)dataGridView1.Rows[e.RowIndex].Cells["StudentID"].Value;
            c.CourseID = (int)dataGridView1.Rows[e.RowIndex].Cells["CourseID"].Value;
            var res = c.DeleteStudentCourse(id);
            dataGridView1.Rows.RemoveAt(e.RowIndex);
            label8.Text = res.message.ShowMessage();
        }

        private void StudentMaterials_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainScreen mn = new MainScreen();
            this.Hide();
            mn.ShowDialog();
        }




    }
}
