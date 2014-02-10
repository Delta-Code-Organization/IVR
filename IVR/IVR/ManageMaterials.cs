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
    public partial class ManageMaterials : Form
    {
       


        public ManageMaterials()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxStudentName.DataSource = Enum.GetValues(typeof(Dayenum));
        }
        #region  BusinessMethods
        void FillControls()
        {

        }

        bool ValidateControls()
        {
            errorProvider1.RightToLeft = true;
            bool check = true;
            if (txt2materialname.Text == "" && comboBoxStudentName.SelectedItem == null && txtfrom.Text == "" && txtto.Text == "")
            {
                errorProvider1.SetError(comboBoxStudentName, "من فضلك أدخل  قيمة للبحث بدلالتها");
                check = false;
            }
            DateTime from;
            if (txtfrom.Text != "" && !DateTime.TryParse(txtfrom.Text, out from))
            {
                errorProvider1.SetError(txtfrom, "من فضلك أدخل التاريخ ");
                check = false;
            }
            DateTime to;
            if (txtto.Text != "" && !DateTime.TryParse(txtto.Text, out to))
            {
                errorProvider1.SetError(txtto, "من فضلك أدخل قيمة تاريخ صحيحه");
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
        private void button1_Click_2(object sender, EventArgs e)
        {
            ValidateControls();
        }

        private void txt2materialname_TextChanged(object sender, EventArgs e)
        {
            if (txt2materialname.Text!= "")
                errorProvider1.Clear();
        }

        private void txtfrom_TextChanged(object sender, EventArgs e)
        {
            if (txtfrom.Text != "")
                errorProvider1.Clear();
        }

        private void txtto_TextChanged(object sender, EventArgs e)
        {
            if (txtto.Text != "")
                errorProvider1.Clear();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            bool validation = ValidateControls();
         if (validation == true)
        {
            Course c = new Course();
             TimeTable tt = new TimeTable();
             List<int> LOID = new List<int>();
             List<Course> LOOP = new List<Course>();
             if (txt2materialname.Text != "")
             {
                 c.CourseName = txt2materialname.Text;
                 List<Course> res = c.SearchCoursesByName();
                 foreach(var r in res)
                 {
                     LOOP.Add(r);
                     LOID.Add(r.CourseID);
                 }
             }
             if (comboBoxStudentName.Text != "")
             {
                 tt.Day = (int)comboBoxStudentName.SelectedValue;
                 List<Course> res = tt.SearchCoursesByDay();
                 foreach (var r in res)
                 {
                     if (!LOID.Contains(r.CourseID))
                     {
                         LOOP.Add(r);
                         LOID.Add(r.CourseID);
                     }
                 }
             }
             if (txtfrom.Text != "")
             {
                 tt.StartTime = Convert.ToDateTime(txtfrom.Text);
                 List<Course> res = tt.SearchCoursesByStartTime();
                 foreach (var r in res)
                 {
                     if (!LOID.Contains(r.CourseID))
                     {
                         LOOP.Add(r);
                         LOID.Add(r.CourseID);
                     }
                 }
             }
             if (txtto.Text != "")
             {
                 tt.StartTime = Convert.ToDateTime(txtfrom.Text);
                 List<Course> res = tt.SearchCoursesByEndTime();
                 foreach (var r in res)
                 {
                     if (!LOID.Contains(r.CourseID))
                     {
                         LOOP.Add(r);
                         LOID.Add(r.CourseID);
                     }
                 }
             }
             DataTable Dt = new DataTable();
             Dt.Columns.Add("اسم المادة", typeof(string));
             Dt.Columns.Add("اليوم", typeof(string));
             Dt.Columns.Add("من", typeof(DateTime));
             Dt.Columns.Add("الي", typeof(DateTime));
             foreach (Course item in LOOP)
             {
                 DataRow DR = Dt.NewRow();
                 DR[0] = item.CourseName;
                 foreach (TimeTable TT in item.TimeTable)
                 {
                     DR[1] = Enum.GetName(typeof(Dayenum), TT.Day);
                     DR[2] = TT.StartTime;
                     DR[3] = TT.EndTime;
                 }
                 Dt.Rows.Add(DR);
             }
             dataGridView1.DataSource = Dt;
             dataGridView1.Visible = true;
         }
         }
        private void txt2materialname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                pictureBox2_Click(sender, e);
            }
        }

        private void txtfrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                pictureBox2_Click(sender, e);
            }
        }

        private void txtto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                pictureBox2_Click(sender, e);
            }
        }

        private void comboBoxStudentName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                pictureBox2_Click(sender, e);
            }
        }
    }
}
