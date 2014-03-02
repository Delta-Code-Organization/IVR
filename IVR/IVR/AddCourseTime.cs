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
    public partial class AddCourseTime : Form
    {
        public AddCourseTime()
        {
            InitializeComponent();
        }
        #region  BusinessMethods
        void FillControls()
        {
            TimeTable time = new TimeTable();
            List<TimeTable> LOTT = time.GetAllTimes().Data as List<TimeTable>;
            DataTable DT = new DataTable();
            DT.Columns.Add("ID", typeof(int));
            DT.Columns.Add("اسم المادة", typeof(string));
            DT.Columns.Add("من", typeof(DateTime));
            DT.Columns.Add("إلي", typeof(DateTime));
            DT.Columns.Add("عدد الطلاب", typeof(int));
            DT.Columns.Add("اليوم", typeof(string));
            foreach (TimeTable tt in LOTT)
            {
                DataRow DR = DT.NewRow();
                DR[0] = tt.TimeTableID;
                DR[1] = tt.Course.CourseName;
                DR[2] = tt.StartTime;
                DR[3] = tt.EndTime;
                DR[4] = tt.Capacity;
                DR[5] = Enum.GetName(typeof(Dayenum), tt.Day); ;
                DT.Rows.Add(DR);
            }
            dataGridView1.DataSource = DT;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.Columns[0].DisplayIndex = 6;
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
            comboBoxMaterial.SelectedIndex = -1;
        }
        bool ValidateControls()
        {
            errorProvider1.RightToLeft = true;
            bool check = true;
            if (comboBoxMaterial.SelectedItem == null)
            {
                errorProvider1.SetError(comboBoxMaterial, "من فضلك إختر اسم المادة");
                check = false;
            }
            if (txtcapacity.TextLength < 1)
            {
                errorProvider1.SetError(txtcapacity, "من فضلك أدخل عدد الطلاب");
                check = false;
            }
            int hours;
            if (txtcapacity.TextLength > 1 && !int.TryParse(txtcapacity.Text, out hours))
            {
                errorProvider1.SetError(txtcapacity, "لابد ان تكون قيمة رقمية");
                check = false;
            }
            if (txtstartdate.Text == "")
            {
                errorProvider1.SetError(txtstartdate, "من فضلك ادخل موعد بدء المحاضره");
                check = false;
            }
            DateTime from;
            if (txtstartdate.Text != "" && !DateTime.TryParse(txtstartdate.Text, out from))
            {
                errorProvider1.SetError(txtstartdate, "من فضلك أدخل التاريخ");
                check = false;
            }
            if (comboBoxday.SelectedItem == null)
            {
                errorProvider1.SetError(comboBoxday, "من فضلك إختر يوم المحاضره");
                check = false;
            }
            if (txtenddate.Text == "")
            {
                errorProvider1.SetError(txtenddate, "من فضلك ادخل موعد إنتهاء المحاضره");
                check = false;
            }
            DateTime to;
            if (txtenddate.Text != "" && !DateTime.TryParse(txtenddate.Text, out to))
            {
                errorProvider1.SetError(txtenddate, "من فضلك أدخل التاريخ");
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
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            label9.Visible = false;
            bool validation = ValidateControls();
            if (validation == true)
            {

                TimeTable tt = new TimeTable();
                Course course = new Course();
                course.CourseName = comboBoxMaterial.Text;
                var res = course.GetCourse();
                string msg = res.message.ShowMessage();
                int ID = (res.Data as Course).CourseID;
                tt.Section_ID = ID;
                tt.Capacity = Convert.ToInt32(txtcapacity.Text);
                tt.Day = (int)comboBoxday.SelectedValue;
                tt.Registered = 0;
                tt.StartTime = Convert.ToDateTime(txtstartdate.Text);
                tt.EndTime = Convert.ToDateTime(txtenddate.Text);
                tt.AddTime();
                FillControls();
            }
        }

        private void comboBoxMaterial_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxMaterial.SelectedItem != null)
                errorProvider1.Clear();
        }

        private void txtcapacity_TextChanged(object sender, EventArgs e)
        {
            if (txtcapacity.Text != "")
                errorProvider1.Clear();
        }

        private void comboBoxday_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxday.SelectedItem != null)
                errorProvider1.Clear();
        }

        private void txtstartdate_TextChanged(object sender, EventArgs e)
        {
            if (txtstartdate.Text != "")
                errorProvider1.Clear();
        }

        private void txtenddate_TextChanged(object sender, EventArgs e)
        {
            if (txtenddate.Text != "")
                errorProvider1.Clear();
        }

        private void AddCourseTime_Load_1(object sender, EventArgs e)
        {
            comboBoxday.DataSource = Enum.GetValues(typeof(Dayenum));
            comboBoxday.SelectedIndex = -1;
            FillControls();
        }

        private void comboBoxMaterial_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                pictureBox2_Click_1(sender, e);
        }

        private void txtstartdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                pictureBox2_Click_1(sender, e);
        }
        private void comboBoxday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                pictureBox2_Click_1(sender, e);
        }
        private void txtenddate_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                pictureBox2_Click_1(sender, e);
        }
        private void txtcapacity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                pictureBox2_Click_1(sender, e);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeTable time = new TimeTable();
            time.TimeTableID = (int)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
            time.DeleteTime();
            dataGridView1.Rows.RemoveAt(e.RowIndex);
        }

        private void AddCourseTime_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainScreen mn = new MainScreen();
            this.Hide();
            mn.ShowDialog();
        }

    
    }
}
