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
            List<Course> LOOP = corse.GetAllcourses();
            DataTable Dt = new DataTable();
            Dt.Columns.Add("ID", typeof(int));
            Dt.Columns.Add("اسم المادة", typeof(string));
            Dt.Columns.Add("اليوم", typeof(string));
            Dt.Columns.Add("من", typeof(DateTime));
            Dt.Columns.Add("الي", typeof(DateTime));
            foreach (Course item in LOOP)
            {
                //DataRow DR = Dt.NewRow();
                //DR[0] = item.CourseID;
                //DR[1] = item.CourseName;
                foreach (TimeTable TT in item.TimeTable)
                {
                    DataRow DR = Dt.NewRow();
                    DR[0] = item.CourseID;
                    DR[1] = item.CourseName;
                    DR[2] = Enum.GetName(typeof(Dayenum), TT.Day);
                    DR[3] = TT.StartTime;
                    DR[4] = TT.EndTime;
                    Dt.Rows.Add(DR);
                }

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
            if (txtfrom.Text != "" && !DateTime.TryParse(txtfrom.Text, out from))
            {
                errorProvider1.SetError(txtfrom, "من فضلك أدخل الوقت hh:mm");
                check = false;
            }
            DateTime to;
            if (txtto.Text != "" && !DateTime.TryParse(txtto.Text, out to))
            {
                errorProvider1.SetError(txtto, "من فضلك أدخل الوقت hh:mm");
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
            if (txt2materialname.Text != "")
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
        private void comboBoxday_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxday.SelectedItem != null)
                errorProvider1.Clear();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label10.Visible = false;
            bool validation = ValidateControls();
            List<int> LOID = new List<int>();
            List<TimeTable> LOOP = new List<TimeTable>();
            TimeTable time = new TimeTable();
            if (validation == true)
            {
                Course c = new Course();

                if (txt2materialname.Text != "" && comboBoxday.Text == "" && txtfrom.Text == "" && txtto.Text == "")
                {
                    c.CourseName = txt2materialname.Text;
                    var res = c.SearchCoursesByName();
                    if (res.message.ShowMessage() != "Not Found")
                    {
                        LOOP.AddRange(res.Data as List<TimeTable>);
                        //LOID.Add((res.Data as List<TimeTable>).FirstOrDefault().Course.CourseID);
                    }
                }
                if (txt2materialname.Text == "" && comboBoxday.Text != "" && txtfrom.Text == "" && txtto.Text == "")
                {

                    time.Day = (int)comboBoxday.SelectedValue;
                    var res = time.SearchCoursesByDay();
                    if (res.message.ShowMessage() != "Not Found")
                    {
                        LOOP.AddRange(res.Data as List<TimeTable>);
                        //foreach (TimeTable tt in res.Data as List<TimeTable>)
                        //{
                        //    if(!LOID.Contains(tt.TimeTableID))
                        //    {
                        //        LOOP.Add(tt);
                        //        LOID.Add(tt.TimeTableID);
                        //    }
                    }


                }
                if (txt2materialname.Text == "" && comboBoxday.Text == "" && txtfrom.Text != "" && txtto.Text == "")
                {

                    time.StartTime = Convert.ToDateTime(txtfrom.Text);
                    string hour = ((DateTime)time.StartTime).ToHours();
                    var res = time.SearchCoursesByStartTime(hour);
                    if (res.message.ShowMessage() != "Not Found")
                    {
                        LOOP.AddRange(res.Data as List<TimeTable>);

                    }
                }
                if (txt2materialname.Text == "" && comboBoxday.Text == "" && txtfrom.Text == "" && txtto.Text != "")
                {

                    time.EndTime = Convert.ToDateTime(txtto.Text);
                    string hour = ((DateTime)time.EndTime).ToHours();
                    var res = time.SearchCoursesByEndTime(hour);
                    if (res.message.ShowMessage() != "Not Found")
                    {
                        LOOP.AddRange(res.Data as List<TimeTable>);

                    }
                }
                if (txt2materialname.Text == "" && comboBoxday.Text != "" && txtfrom.Text != "" && txtto.Text == "")
                {
                    time.StartTime = Convert.ToDateTime(txtfrom.Text);
                    time.Day = (int)comboBoxday.SelectedValue;
                    string hour = ((DateTime)time.StartTime).ToHours();
                    var res = time.SearchBothDayStart(hour);
                    if (res.message.ShowMessage() != "Not Found")
                    {
                        LOOP.AddRange(res.Data as List<TimeTable>);
                    }

                }
                if (txt2materialname.Text != "" && comboBoxday.Text == "" && txtfrom.Text != "" && txtto.Text == "")
                {
                    time.StartTime = Convert.ToDateTime(txtfrom.Text);
                    c.CourseName = txt2materialname.Text;
                    var corse = c.GetCourse();
                    if (corse.message.ShowMessage() != "Not Found")
                    {
                        string hour = ((DateTime)time.StartTime).ToHours();
                        var res = time.SearchBothNamestart((corse.Data as Course).CourseID, hour);
                        if (res.message.ShowMessage() != "Not Found")
                        {
                            LOOP.AddRange(res.Data as List<TimeTable>);
                        }
                    }
                }
                if (txt2materialname.Text != "" && comboBoxday.Text == "" && txtfrom.Text == "" && txtto.Text != "")
                {
                    time.EndTime = Convert.ToDateTime(txtto.Text);
                    c.CourseName = txt2materialname.Text;
                    var corse = c.GetCourse();
                    if (corse.message.ShowMessage() != "Not Found")
                    {
                        string hour = ((DateTime)time.EndTime).ToHours();
                        var res = time.SearchBothNameEnd((corse.Data as Course).CourseID, hour);
                        if (res.message.ShowMessage() != "Not Found")
                        {
                            LOOP.AddRange(res.Data as List<TimeTable>);
                        }
                    }
                }
                //if (txt2materialname.Text == "" && comboBoxday.Text != "" && txtfrom.Text != "" && txtto.Text == "")
                //{
                //    time.StartTime = Convert.ToDateTime(txtfrom.Text);
                //    time.Day = (int)comboBoxday.SelectedValue;
                //    var res = time.SearchBothDayStart();
                //    var x = res.Data as List<TimeTable>;
                //    if (res.message.ShowMessage() != "Not Found")
                //    {
                //        LOOP.AddRange(res.Data as List<TimeTable>);
                //    }
                //}
                if (txt2materialname.Text == "" && comboBoxday.Text != "" && txtfrom.Text == "" && txtto.Text != "")
                {
                    time.Day = (int)comboBoxday.SelectedValue;
                    time.EndTime = Convert.ToDateTime(txtto.Text);
                    string hour = ((DateTime)time.EndTime).ToHours();
                    var res = time.SearchBothDayEnd(hour);
                    if (res.message.ShowMessage() != "Not Found")
                    {
                        LOOP.AddRange(res.Data as List<TimeTable>);
                    }
                }
                if (txt2materialname.Text == "" && comboBoxday.Text == "" && txtfrom.Text != "" && txtto.Text != "")
                {
                    time.StartTime = Convert.ToDateTime(txtfrom.Text);
                    string shour = ((DateTime)time.StartTime).ToHours();
                    time.EndTime = Convert.ToDateTime(txtto.Text);
                    string ehour = ((DateTime)time.EndTime).ToHours();
                    var res = time.SearchBothStartEnd(shour, ehour);
                    if (res.message.ShowMessage() != "Not Found")
                    {
                        LOOP.AddRange(res.Data as List<TimeTable>);
                    }
                }
                if (comboBoxday.Text != "" && txtfrom.Text != "" && txtto.Text != "" && txt2materialname.Text == "")
                {
                    time.Day = (int)comboBoxday.SelectedValue;
                    time.StartTime = Convert.ToDateTime(txtfrom.Text);
                    string shour = ((DateTime)time.StartTime).ToHours();
                    time.EndTime = Convert.ToDateTime(txtto.Text);
                    string ehour = ((DateTime)time.EndTime).ToHours();
                    var res = time.SearchDayStartEnd(shour, ehour);
                    if (res.message.ShowMessage() != "Not Found")
                    {
                        LOOP.AddRange(res.Data as List<TimeTable>);
                    }
                }
                if (comboBoxday.Text != "" && txtfrom.Text != "" && txt2materialname.Text != "" && txtto.Text == "")
                {
                    c.CourseName = txt2materialname.Text;
                    time.Day = (int)comboBoxday.SelectedValue;
                    time.StartTime = Convert.ToDateTime(txtfrom.Text);
                    string hour = ((DateTime)time.StartTime).ToHours();
                    var corse = c.GetCourse();
                    if (corse.message.ShowMessage() != "Not Found")
                    {
                        var res = time.SearchNameDayStart((corse.Data as Course).CourseID, hour);
                        if (res.message.ShowMessage() != "Not Found")
                        {
                            LOOP.AddRange(res.Data as List<TimeTable>);
                        }
                    }
                }
                if (comboBoxday.Text == "" && txtfrom.Text != "" && txt2materialname.Text != "" && txtto.Text != "")
                {
                    c.CourseName = txt2materialname.Text;
                    time.EndTime = Convert.ToDateTime(txtto.Text);
                    string ehour = ((DateTime)time.EndTime).ToHours();
                    time.StartTime = Convert.ToDateTime(txtfrom.Text);
                    string shour = ((DateTime)time.StartTime).ToHours();
                    var corse = c.GetCourse();
                    if (corse.message.ShowMessage() != "Not Found")
                    {
                        var res = time.SearchNameStartEnd((corse.Data as Course).CourseID, shour, ehour);
                        if (res.message.ShowMessage() != "Not Found")
                        {
                            LOOP.AddRange(res.Data as List<TimeTable>);
                        }
                    }
                }
                if (comboBoxday.Text != "" && txtfrom.Text == "" && txt2materialname.Text != "" && txtto.Text != "")
                {
                    c.CourseName = txt2materialname.Text;
                    time.Day = (int)comboBoxday.SelectedValue;
                    time.EndTime = Convert.ToDateTime(txtto.Text);
                    string hour = (((DateTime)time.EndTime).ToHours());
                    var corse = c.GetCourse();
                    if (corse.message.ShowMessage() != "Not Found")
                    {
                        var res = time.SearchNameDayEnd((corse.Data as Course).CourseID, hour);
                        if (res.message.ShowMessage() != "Not Found")
                        {
                            LOOP.AddRange(res.Data as List<TimeTable>);
                        }
                    }
                }
                if (comboBoxday.Text != "" && txtfrom.Text != "" && txt2materialname.Text != "" && txtto.Text != "")
                {
                    c.CourseName = txt2materialname.Text;
                    time.Day = (int)comboBoxday.SelectedValue;
                    time.StartTime = Convert.ToDateTime(txtfrom.Text);
                    string shour = ((DateTime)time.StartTime).ToHours();
                    time.EndTime = Convert.ToDateTime(txtto.Text);
                    string ehour = ((DateTime)time.EndTime).ToHours();
                    var corse = c.GetCourse();
                    if (corse.message.ShowMessage() != "Not Found")
                    {
                        var res = time.Searchall((corse.Data as Course).CourseID, shour, ehour);
                        if (res.message.ShowMessage() != "Not Found")
                        {
                            LOOP.Add(res.Data as TimeTable);
                        }
                    }
                }
                if (txt2materialname.Text != "" && comboBoxday.Text != "" && txtfrom.Text == "" && txtto.Text == "")
                {
                    time.Day = (int)comboBoxday.SelectedValue;
                    c.CourseName = txt2materialname.Text;
                    var corse = c.GetCourse();
                    if (corse.message.ShowMessage() != "Not Found")
                    {
                        var res = time.SearchBothNameDay((corse.Data as Course).CourseID);
                        List<Course> LOC = new List<Course>();
                        LOC = res.Data as List<Course>;
                        if (res.message.ShowMessage() != "Not Found")
                        {
                            LOOP.AddRange(res.Data as List<TimeTable>);
                        }
                    }
                }
                //}
                if (LOOP.Count != 0)
                {
                    DataTable Dt = new DataTable();
                    Dt.Columns.Add("ID", typeof(int));
                    Dt.Columns.Add("اسم المادة", typeof(string));
                    Dt.Columns.Add("اليوم", typeof(string));
                    Dt.Columns.Add("من", typeof(DateTime));
                    Dt.Columns.Add("الي", typeof(DateTime));
                    foreach (TimeTable TT in LOOP)
                    {
                        DataRow DR = Dt.NewRow();
                        DR[2] = Enum.GetName(typeof(Dayenum), TT.Day);
                        DR[3] = TT.StartTime;
                        DR[4] = TT.EndTime;
                        DR[0] = TT.Course.CourseID;
                        DR[1] = TT.Course.CourseName;
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

        private void ManageMaterials_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainScreen mn = new MainScreen();
            this.Hide();
            mn.ShowDialog();
        }

        

    }
}
