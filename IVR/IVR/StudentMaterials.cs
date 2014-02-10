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
       // ModifyRegistry Reg;//define in the public

        public StudentMaterials()
        {
            InitializeComponent();
        }

        #region BusinessMethods
        
        void FillControls() 
        {
            //bool rr = Reg.Write("ID", 1);//(اسم ال key,القيمة)
           // string X = Reg.Read("ID");//اي شيء يرجع علي هيئةstring
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
            Course c = new Course();
            var res2 = c.GetAllcourses();
            DataTable DT2 = new DataTable();
            DT2.Columns.Add("اسم المادة", typeof(string));
            DT2.Columns.Add("رقم المسلسل", typeof(int));
            foreach (var x in res2)
            {
                DataRow DR = DT2.NewRow();
                DR[0]=x.CourseName;
                DR[1] = x.CourseID;
                DT2.Rows.Add(DR);
            }
            comboBoxMaterial.DataSource = DT2;
            comboBoxMaterial.DisplayMember = "اسم المادة";
            comboBoxMaterial.ValueMember = "رقم المسلسل";
        }

        bool ValidateControls()
        {
            bool Check = true;
            if (comboBoxMaterial.SelectedItem ==null)
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(comboBoxMaterial, "من فضلك أدخل اسسم الطالب");
                Check = false;
            }
            if (comboBoxStudentName.SelectedItem==null)
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(comboBoxStudentName, "من فضلك ادخل اسم المادة");
                Check = false;
            }
            //if (comboBoxLectureTime.SelectedItem==null)
            //{
            //    errorProvider1.RightToLeft = true;
            //    errorProvider1.SetError(comboBoxLectureTime, "من فضلك أدخل ميعاد المحاضرة");
            //    Check = false;
            //}
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void StudentMaterials_Load(object sender, EventArgs e)
        {
            FillControls();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ValidateControls();
            bool validation = ValidateControls();
            if (validation == true)
            {
                Course c = new Course();
                int studentID =(int)comboBoxStudentName.SelectedValue;
                c.CourseID =(int)comboBoxMaterial.SelectedValue;
               var result=c.AddStudentCourse(studentID);
               DataTable DT = new DataTable();
               DT.Columns.Add("اسم الطالب",typeof(string));
               DT.Columns.Add("اسم المادة", typeof(string));
               DT.Columns.Add("ميعاد المحاضرة", typeof(DateTime));
               DataRow DR = DT.NewRow();
              DR[1]= result.CourseName;
             var name=result.Student.Where(p => p.StudentID == studentID).SingleOrDefault();
             DR[0] = name.S_name;
             var time = result.TimeTable.Where(p => p.Section_ID == c.CourseID).SingleOrDefault();
             DR[2] = time.StartTime;
              DT.Rows.Add(DR);
              dataGridView1.DataSource = DT;
              dataGridView1.Visible = true;
            }
        }

        private void comboBoxMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMaterial.SelectedItem != null)
            {
                errorProvider1.Clear();
            }
        }

        private void comboBoxStudentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStudentName.SelectedItem != null)
            {
                errorProvider1.Clear();
            }
        }

        private void comboBoxLectureTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLectureTime.SelectedItem != null)
            {
                errorProvider1.Clear();
            }
        }

        private void comboBoxMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                button1_Click_1(sender,e);
        }

        private void comboBoxStudentName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                button1_Click_1(sender, e);
        }
    }
}
