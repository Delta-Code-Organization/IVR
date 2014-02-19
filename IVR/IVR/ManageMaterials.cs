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
            comboBoxday.DataSource = Enum.GetValues(typeof(Dayenum));
            comboBoxday.SelectedIndex = -1;
            FillControls();
        }
        #region  BusinessMethods
        void FillControls()
        {
            Course corse = new Course();
        List<Course> LOOP=corse.GetAllcourses();
        DataTable Dt = new DataTable();
        Dt.Columns.Add("ID", typeof(int));
        Dt.Columns.Add("اسم المادة", typeof(string));
        Dt.Columns.Add("اليوم", typeof(string));
        Dt.Columns.Add("من", typeof(DateTime));
        Dt.Columns.Add("الي", typeof(DateTime));
        foreach (Course item in LOOP)
        {
            DataRow DR = Dt.NewRow();
            DR[0] = item.CourseID;
            DR[1] = item.CourseName;
            foreach (TimeTable TT in item.TimeTable)
            {
                DR[2] = Enum.GetName(typeof(Dayenum), TT.Day);
                DR[3] = TT.StartTime;
                DR[4] = TT.EndTime;
            }
            Dt.Rows.Add(DR);
        }
        dataGridView1.DataSource = Dt;
        dataGridView1.Columns[1].Visible = false;
        dataGridView1.Visible = true;
        dataGridView1.Columns[0].DisplayIndex = 5;
        }

        bool ValidateControls()
        {
            errorProvider1.RightToLeft = true;
            bool check = true;
            if (txt2materialname.Text == "" && comboBoxday.SelectedItem == null && txtfrom.Text == "" && txtto.Text == "")
            {
                errorProvider1.SetError(comboBoxday, "من فضلك أدخل  قيمة للبحث بدلالتها");
                check = false;
            }
            DateTime from;
            if (txtfrom.Text != "" && !DateTime.TryParse(txtfrom.Text,out from))
            {
                errorProvider1.SetError(txtfrom, "من فضلك أدخل التاريخ");
                check = false;
            }
            DateTime to;
            if (txtto.Text != "" && !DateTime.TryParse(txtto.Text, out to))
            {
                errorProvider1.SetError(txtto, "من فضلك أدخل صيغة تاريخ صحيحه");
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
            label10.Visible = false;
            bool validation = ValidateControls();
            if (validation == true)
            {
                Course c = new Course();
                TimeTable tt = new TimeTable();
                List<int> LOID = new List<int>();
                List<Course> LOOP = new List<Course>();
                if (txt2materialname.Text != "" && comboBoxday.Text == "" && txtfrom.Text == "" && txtto.Text == "")
                {
                    c.CourseName = txt2materialname.Text;
                    var res = c.SearchCoursesByName();
                    if (res.message.ShowMessage() != "NotFound")
                    {
                        c.CourseName = txt2materialname.Text;
                        LOOP.Add((Course)res.Data);
                        LOID.Add(((Course)res.Data).CourseID);
                    }
                }
                if (txt2materialname.Text == "" && comboBoxday.Text != "" && txtfrom.Text == "" && txtto.Text == "")
                {
                    tt.Day = (int)comboBoxday.SelectedValue;
                    var res = tt.SearchCoursesByDay();
                    if (res.message.ShowMessage() != "NotFound")
                    {
                        List<Course> LOC = new List<Course>();
                        LOC = res.Data as List<Course>;
                        tt.Day = (int)comboBoxday.SelectedValue;
                        foreach (var r in LOC)
                        {
                            if (!LOID.Contains(r.CourseID))
                            {
                                LOOP.Add(r);
                                LOID.Add(r.CourseID);
                            }
                        }
                    }
                }

                if (txt2materialname.Text == "" && comboBoxday.Text == "" && txtfrom.Text != "" && txtto.Text == "")
                {
                    tt.StartTime = Convert.ToDateTime(txtfrom.Text);
                    var res = tt.SearchCoursesByStartTime();
                    if (res.message.ShowMessage() != "NotFound")
                    {
                        List<Course> LOC = new List<Course>();
                        LOC = res.Data as List<Course>;
                        foreach (Course r in LOC)
                        {
                            if (!LOID.Contains(r.CourseID))
                            {
                                LOOP.Add(r);
                                LOID.Add(r.CourseID);
                            }
                        }
                    }
                }

                if (txt2materialname.Text == "" && comboBoxday.Text == "" && txtfrom.Text == "" && txtto.Text != "")
                {
                    tt.EndTime = Convert.ToDateTime(txtto.Text);
                    var res = tt.SearchCoursesByEndTime();
                    if (res.message.ShowMessage() != "NotFound")
                    {
                        List<Course> LOC = new List<Course>();
                        LOC = res.Data as List<Course>;
                        foreach (Course r in LOC)
                        {
                            if (!LOID.Contains(r.CourseID))
                            {
                                LOOP.Add(r);
                                LOID.Add(r.CourseID);
                            }
                        }
                    }
                }
                if (txt2materialname.Text != "" && comboBoxday.Text != "" && txtfrom.Text == "" && txtto.Text == "")
                {
                    tt.Day = (int)comboBoxday.SelectedValue;
                    c.CourseName = txt2materialname.Text;
                    Course corse = c.SearchCoursesByName().Data as Course;
                    var res = tt.SearchBothNameDay(corse.CourseID);
                    if (res.message.ShowMessage() != "NotFound")
                    {
                        if (!LOID.Contains(((Course)res.Data).CourseID))
                        {
                            LOOP.Add(res.Data as Course);
                            LOID.Add(((Course)res.Data).CourseID);
                        }
                    }
                }
                if (txt2materialname.Text != "" && comboBoxday.Text == "" && txtfrom.Text != "" && txtto.Text == "")
                {
                    tt.StartTime = Convert.ToDateTime(txtfrom.Text);
                    c.CourseName = txt2materialname.Text;
                    Course corse = c.SearchCoursesByName().Data as Course;
                    var res = tt.SearchBothNamestart(corse.CourseID);
                    if (res.message.ShowMessage() != "NotFound")
                    {
                        if (!LOID.Contains(((Course)res.Data).CourseID))
                        {
                            LOOP.Add(res.Data as Course);
                            LOID.Add(((Course)res.Data).CourseID);
                        }
                    }
                }
                if (txt2materialname.Text != "" && comboBoxday.Text == "" && txtfrom.Text == "" && txtto.Text != "")
                {
                    tt.EndTime = Convert.ToDateTime(txtto.Text);
                    c.CourseName = txt2materialname.Text;
                    Course corse = c.SearchCoursesByName().Data as Course;
                    var res = tt.SearchBothNameEnd(corse.CourseID);
                    if (res.message.ShowMessage() != "NotFound")
                    {
                        if (!LOID.Contains(((Course)res.Data).CourseID))
                        {
                            LOOP.Add(res.Data as Course);
                            LOID.Add(((Course)res.Data).CourseID);
                        }
                    }
                }
                if (txt2materialname.Text == "" && comboBoxday.Text != "" && txtfrom.Text != "" && txtto.Text == "")
                {
                    tt.StartTime = Convert.ToDateTime(txtfrom.Text);
                    tt.Day = (int)comboBoxday.SelectedValue;
                    var res = tt.SearchBothDayStart();
                    if (res.message.ShowMessage() != "NotFound")
                    {
                        List<Course> LOC = new List<Course>();
                        LOC = res.Data as List<Course>;
                        foreach (Course r in LOC)
                        {
                            if (!LOID.Contains(r.CourseID))
                            {
                                LOOP.Add(r);
                                LOID.Add(r.CourseID);
                            }
                        }
                    }
                }
                if (txt2materialname.Text == "" && comboBoxday.Text != "" && txtfrom.Text == "" && txtto.Text != "")
                {
                    tt.Day = (int)comboBoxday.SelectedValue;
                    tt.EndTime = Convert.ToDateTime(txtto.Text);
                    var res = tt.SearchBothDayEnd();
                    if (res.message.ShowMessage() != "NotFound")
                    {
                        List<Course> LOC = new List<Course>();
                        LOC = res.Data as List<Course>;
                        foreach (Course r in LOC)
                        {
                            if (!LOID.Contains(r.CourseID))
                            {
                                LOOP.Add(r);
                                LOID.Add(r.CourseID);
                            }
                        }
                    }
                }
                if (txt2materialname.Text == "" && comboBoxday.Text == "" && txtfrom.Text != "" && txtto.Text != "")
                {
                    tt.StartTime = Convert.ToDateTime(txtfrom.Text);
                    tt.EndTime = Convert.ToDateTime(txtto.Text);
                    var res = tt.SearchBothStartEnd();
                    if (res.message.ShowMessage() != "NotFound")
                    {
                        List<Course> LOC = new List<Course>();
                        LOC = res.Data as List<Course>;
                        foreach (Course r in LOC)
                        {
                            if (!LOID.Contains(r.CourseID))
                            {
                                LOOP.Add(r);
                                LOID.Add(r.CourseID);
                            }
                        }
                    }
                }

                if (comboBoxday.Text != "" && txtfrom.Text != "" && txtto.Text != "" && txt2materialname.Text == "")
                {
                    tt.Day = (int)comboBoxday.SelectedValue;
                    tt.StartTime = Convert.ToDateTime(txtfrom.Text);
                    tt.EndTime = Convert.ToDateTime(txtto.Text);
                    var res = tt.SearchDayStartEnd();
                    if (res.message.ShowMessage() != "NotFound")
                    {
                        List<Course> LOC = new List<Course>();
                        LOC = res.Data as List<Course>;
                        foreach (Course r in LOC)
                        {
                            if (!LOID.Contains(r.CourseID))
                            {
                                LOOP.Add(r);
                                LOID.Add(r.CourseID);
                            }
                        }
                    }
                }
                if (comboBoxday.Text != "" && txtfrom.Text != "" && txt2materialname.Text != "" && txtto.Text == "")
                {
                    c.CourseName = txt2materialname.Text;
                    tt.Day = (int)comboBoxday.SelectedValue;
                    tt.StartTime = Convert.ToDateTime(txtfrom.Text);
                    Course corse = c.SearchCoursesByName().Data as Course;
                    var res = tt.SearchNameDayStart(corse.CourseID);
                    if (res.message.ShowMessage() != "NotFound")
                    {
                        if (!LOID.Contains(((Course)res.Data).CourseID))
                        {
                            LOOP.Add(res.Data as Course);
                            LOID.Add(((Course)res.Data).CourseID);
                        }
                    }
                }
                if (comboBoxday.Text == "" && txtfrom.Text != "" && txt2materialname.Text != "" && txtto.Text != "")
                {
                    c.CourseName = txt2materialname.Text;
                    tt.EndTime = Convert.ToDateTime(txtto.Text);
                    tt.StartTime = Convert.ToDateTime(txtfrom.Text);
                    Course corse = c.SearchCoursesByName().Data as Course;
                    var res = tt.SearchNameStartEnd(corse.CourseID);
                    if (res.message.ShowMessage() != "NotFound")
                    {
                        if (!LOID.Contains(((Course)res.Data).CourseID))
                        {
                            LOOP.Add(res.Data as Course);
                            LOID.Add(((Course)res.Data).CourseID);
                        }
                    }
                }
                if (comboBoxday.Text != "" && txtfrom.Text == "" && txt2materialname.Text != "" && txtto.Text != "")
                {
                    c.CourseName = txt2materialname.Text;
                    tt.Day = (int)comboBoxday.SelectedValue;
                    tt.EndTime = Convert.ToDateTime(txtto.Text);
                    Course corse = c.SearchCoursesByName().Data as Course;
                    var res = tt.SearchNameDayEnd(corse.CourseID);
                    if (res.message.ShowMessage() != "NotFound")
                    {
                        if (!LOID.Contains(((Course)res.Data).CourseID))
                        {
                            LOOP.Add(res.Data as Course);
                            LOID.Add(((Course)res.Data).CourseID);
                        }
                    }
                }
                if (comboBoxday.Text != "" && txtfrom.Text != "" && txt2materialname.Text != "" && txtto.Text != "")
                {
                    c.CourseName = txt2materialname.Text;
                    tt.Day = (int)comboBoxday.SelectedValue;
                    tt.StartTime = Convert.ToDateTime(txtfrom.Text);
                    tt.EndTime = Convert.ToDateTime(txtto.Text);
                    Course corse = c.SearchCoursesByName().Data as Course;
                    var res = tt.Searchall(corse.CourseID);
                    if (res.message.ShowMessage() != "NotFound")
                    {
                        if (!LOID.Contains(((Course)res.Data).CourseID))
                        {
                            LOOP.Add(res.Data as Course);
                            LOID.Add(((Course)res.Data).CourseID);
                        }
                    }
                }
             if (LOOP.Count != 0)
             {
                 DataTable Dt = new DataTable();
                 Dt.Columns.Add("ID", typeof(int));
                 Dt.Columns.Add("اسم المادة", typeof(string));
                 Dt.Columns.Add("اليوم", typeof(string));
                 Dt.Columns.Add("من", typeof(DateTime));
                 Dt.Columns.Add("الي", typeof(DateTime));
                 foreach (Course item in LOOP)
                 {
                     DataRow DR = Dt.NewRow();
                     DR[0] = item.CourseID;
                     DR[1] = item.CourseName;
                     foreach (TimeTable TT in item.TimeTable)
                     {
                         DR[2] = Enum.GetName(typeof(Dayenum), TT.Day);
                         DR[3] = TT.StartTime;
                         DR[4] = TT.EndTime;
                     }
                     Dt.Rows.Add(DR);
                 }
                 dataGridView1.DataSource = Dt;
                 dataGridView1.Columns[1].Visible = false;
                 dataGridView1.Visible = true;
                 dataGridView1.Columns[0].DisplayIndex = 5;
             }
             else
             {
                 label10.Text = "لا يوجد نتائج مطابقه للبحث";
                 label10.Visible = true;
                 //dataGridView1.Visible = false;
             }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Course c = new Course();
            c.CourseID = (int)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
            c.DeleteCourse();
            dataGridView1.Rows.RemoveAt(e.RowIndex);
        }
    }
}
