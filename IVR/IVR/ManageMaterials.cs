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
            FillControls();
        }
        #region  BusinessMethods
        void FillControls()
        {
            comboBoxday.DataSource = Enum.GetValues(typeof(Dayenum));
            comboBoxday.SelectedIndex = -1;
            Course corse = new Course();
            List<Course> LOOP = corse.GetAllcourses();
            DataTable Dt = new DataTable();
            Dt.Columns.Add("ID", typeof(int));
            Dt.Columns.Add("اسم المادة", typeof(string));
            Dt.Columns.Add("اليوم", typeof(string));
            Dt.Columns.Add("من", typeof(string));
            Dt.Columns.Add("الي", typeof(string));
            foreach (Course item in LOOP)
            {
                foreach (TimeTable TT in item.TimeTable)
                {
                    DataRow DR = Dt.NewRow();
                    DR[0] = item.CourseID;
                    DR[1] = item.CourseName;
                    DR[2] = Enum.GetName(typeof(Dayenum), TT.Day);
                    DR[3] = ((DateTime)TT.StartTime).ToString("hh:mm tt");
                    DR[4] = ((DateTime)TT.EndTime).ToString("hh:mm tt");
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
            if (ValidateControls() == true)
            {
                TimeTable time = new TimeTable();
                var coursename = txt2materialname.Text;
                var day = comboBoxday.Text;
                var start = txtfrom.Text;
                var end = txtto.Text;
                var res = time.searchCourses(coursename, day, start, end).Data as List<TimeTable>;
                if (res.Count != 0)
                {
                    DataTable Dt = new DataTable();
                    Dt.Columns.Add("ID", typeof(int));
                    Dt.Columns.Add("اسم المادة", typeof(string));
                    Dt.Columns.Add("اليوم", typeof(string));
                    Dt.Columns.Add("من", typeof(string));
                    Dt.Columns.Add("الي", typeof(string));
                    foreach (TimeTable TT in res)
                    {
                        DataRow DR = Dt.NewRow();
                        DR[2] = Enum.GetName(typeof(Dayenum), TT.Day);
                        DR[3] = ((DateTime)TT.StartTime).ToString("hh:mm tt");
                        DR[4] = ((DateTime)TT.EndTime).ToString("hh:mm tt");
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
