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
            //comboBoxMaterial.SelectedIndex = -1;
            this.comboBoxMaterial.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaterial_SelectedIndexChanged);
            Student student = new Student();
            List<Student> LOS = student.GetAllStudents();
            List<Course> LOC =c.GetAllcourses();
            DataTable DT3 = new DataTable();
            DT3.Columns.Add("StudentID", typeof(int));
            DT3.Columns.Add("CourseID", typeof(int));
            DT3.Columns.Add("اسم الطالب", typeof(string));
            DT3.Columns.Add("اسم المادة", typeof(string));
            DT3.Columns.Add("ميعاد المحاضرة", typeof(DateTime));
            foreach (Student std in LOS)
            {
                if(std.Course.Count!=0)
                {
                    foreach(Course cs in std.Course)
                    {
                        DataRow DR2 = DT3.NewRow();
                        DR2[0] = std.StudentID;
                        DR2[1] =cs.CourseID;
                        try { DR2[2] = std.S_name; }
                        catch (Exception x)
                        {
                            throw x;
                        }
                        DR2[3] = cs.CourseName;
                        var time = cs.TimeTable.Where(p => p.Section_ID == cs.CourseID).SingleOrDefault();
                        DR2[4] = time.StartTime;
                        textBox1.Text = Convert.ToString(time.StartTime);
                        DT3.Rows.Add(DR2);
                    }
                }
                }
            dataGridView1.DataSource = DT3;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.Columns[0].DisplayIndex = 5;
            }

        bool ValidateControls()
        {
            bool Check = true;
            if (comboBoxMaterial.SelectedItem == null)
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(comboBoxMaterial, " من فضلك اختر اسم المادة ");
                Check = false;
            }
            if (comboBoxStudentName.SelectedItem == null)
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(comboBoxStudentName, "من فضلك ادخل اسم الطالب");
                Check = false;
            }
            return Check;
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void StudentMaterials_Load(object sender, EventArgs e)
        {
            FillControls();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            ValidateControls();
            bool validation = ValidateControls();
            if (validation == true)
            {
                label8.Visible = false;
                Course c = new Course();
                int studentID = (int)comboBoxStudentName.SelectedValue;
                c.CourseID = (int)comboBoxMaterial.SelectedValue;
                var res = c.AddStudentCourse(studentID);
                var msg = res.message.ShowMessage();
                var result = res.Data as Course;
                if (msg != "ThisCourseIsFull" && msg != "StudentAlreadyExistInThisCourse")
                {
                    FillControls();
                    label8.Text = msg;
                    label8.Visible = true;
                }
                else
                {
                    label8.Text = msg;
                    label8.Visible = true;
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
            var time = selectedCourse.TimeTable.Where(p => p.Section_ID == c.CourseID).SingleOrDefault();
            
            var startTime = time.StartTime;
            textBox1.Text = Convert.ToString(time.StartTime);
        }

        private void comboBoxStudentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStudentName.SelectedItem != null)
            {
                errorProvider1.Clear();
            }
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
            var res=c.DeleteStudentCourse(id);
            dataGridView1.Rows.RemoveAt(e.RowIndex);
            label8.Text = res.message.ShowMessage(); 
        }
    }
}
