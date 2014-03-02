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
    public partial class AddMaterial : Form
    {
        public AddMaterial()
        {
            InitializeComponent();
        }
        #region  BusinessMethods
        void FillControls()
        {
            Course c = new Course();
            List<Course> LOC = c.GetAllcourses();
            DataTable DT = new DataTable();
            DT.Columns.Add("ID", typeof(int));
            DT.Columns.Add("اسم المادة", typeof(string));
            DT.Columns.Add("كود المادة", typeof(int));
            DT.Columns.Add("الفصل الدراسي", typeof(string));
            DT.Columns.Add("عدد الساعات", typeof(int));
            foreach (Course corse in LOC)
            {
                DataRow DR = DT.NewRow();
                DR[0] = corse.CourseID;
                DR[1] = corse.CourseName;
                DR[2] = corse.CourseCode;
                DR[3] = corse.Term_associated;
                DR[4] = corse.CreditHours;
                DT.Rows.Add(DR);
            }
            dataGridView1.DataSource = DT;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.Columns[0].DisplayIndex = 5;
        }

        bool ValidateControls()
        {
            errorProvider1.RightToLeft = true;
            bool check = true;
            if (txtMaterialname.Text == "")
            {
                errorProvider1.SetError(txtMaterialname, "من فضلك ادخل اسم المادة");
                check = false;
            }
            if (txtyear.Text == "")
            {
                errorProvider1.SetError(txtyear, "من فضلك ادخل الفصل الدراسي");
                check = false;
            }
            if (txthoursno.TextLength < 1)
            {
                errorProvider1.SetError(txthoursno, "من فضلك أدخل عدد الساعات");
                check = false;
            }
            int hours;
            if (txthoursno.TextLength > 1 && !int.TryParse(txthoursno.Text, out hours))
            {
                errorProvider1.SetError(txthoursno, "لابد ان تكون قيمة رقمية");
                check = false;
            }
            if (textBoxcode.TextLength < 1)
            {
                errorProvider1.SetError(textBoxcode, "من فضلك أدخل كود المادة");
                check = false;
            }
            if (textBoxcode.TextLength > 1 && !int.TryParse(textBoxcode.Text, out hours))
            {
                errorProvider1.SetError(textBoxcode, "لابد ان تكون قيمة رقمية");
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

        private void txtMaterialname_TextChanged(object sender, EventArgs e)
        {
            if (txtMaterialname.Text != "")
                errorProvider1.Clear();
        }

        private void txtyear_TextChanged(object sender, EventArgs e)
        {
            if (txtyear.Text != "")
                errorProvider1.Clear();
        }

        private void txthoursno_TextChanged_1(object sender, EventArgs e)
        {
            if (txthoursno.Text != "")
                errorProvider1.Clear();
        }

        private void textBoxcode_TextChanged_1(object sender, EventArgs e)
        {
            if (textBoxcode.Text != "")
                errorProvider1.Clear();
        }
        private void txtMaterialname_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                pictureBox2_Click(sender, e);
        }

        private void txtyear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                pictureBox2_Click(sender, e);
        }

        private void txthoursno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                pictureBox2_Click(sender, e);
        }

        private void textBoxcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                pictureBox2_Click(sender, e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            bool validation = ValidateControls();
            if (validation == true)
            {
                Course c = new Course();
                c.CourseName = txtMaterialname.Text;
                c.CreditHours = Convert.ToInt32(txthoursno.Text);
                c.Term_associated = txtyear.Text;
                c.CourseCode = Convert.ToInt32(textBoxcode.Text);
                var corse = c.CreateCourse();
                var msg = corse.message.ShowMessage();
                label9.Text = msg;
                label9.Visible = true;
                if (msg != " إسم المادة موجود بالفعل")
                {
                    FillControls();
                }
                else
                {
                    label9.Text = msg;
                    label9.Visible = true;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Course c = new Course();
            c.CourseID = (int)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
            c.DeleteCourse();
            dataGridView1.Rows.RemoveAt(e.RowIndex);
        }

        private void AddMaterial_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainScreen mn = new MainScreen();
            this.Hide();
            mn.ShowDialog();
        }

        private void AddMaterial_Load(object sender, EventArgs e)
        {
            FillControls();
        }

    }
}
