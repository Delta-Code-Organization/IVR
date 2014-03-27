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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }
        #region BusinessMethods

        void FillControls()
        {
            Student s = new Student();
            List<Student> LOS = s.GetAllStudents();
            DataTable DT = new DataTable();
            DT.Columns.Add("ID", typeof(int));
            DT.Columns.Add("اسم الطالب", typeof(string));
            DT.Columns.Add("الايميل", typeof(string));
            DT.Columns.Add("رقم الهاتف", typeof(string));
            DT.Columns.Add("الرقم السري", typeof(string));
            DT.Columns.Add("عدد الساعات", typeof(string));
            foreach (Student student in LOS)
            {
                DataRow DR = DT.NewRow();
                DR[0] = student.StudentID;
                DR[1] = student.S_name;
                DR[2] = student.S_email;
                DR[3] = student.S_phone;
                DR[4] = student.S_pw;
                DR[5] = student.Credits_aquired;
                DT.Rows.Add(DR);
            }
            dataGridView1.DataSource = DT;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.Columns[0].DisplayIndex = 6;
        }

        bool ValidateControls()
        {
            bool check = true;
            errorProvider1.RightToLeft = true;
            if (txtusername.Text == "")
            {
                errorProvider1.SetError(txtusername, "من فضلك أدخل اسم الطالب");
                check = false;
            }
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "من فضلك أدخل الرقم السري");
                check = false;
            }
            int hours;
            if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox3, "من فضلك أدخل البريد الالكتروني");
                check = false;
            }
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            //  System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (textBox3.Text != "" && !rEmail.IsMatch(textBox3.Text.Trim()))
            {
                errorProvider1.SetError(textBox3, "أدخل بريد إلكتروني صحيح");
                check = false;
            }
            if (!int.TryParse(textBox4.Text, out hours))
            {
                errorProvider1.SetError(textBox4, "من فضلك أدخل قيمة رقمية");
                check = false;
            }
            if (textBox4.Text == "")
            {
                errorProvider1.SetError(textBox4, "من فضلك أدخل رقم الهاتف");
                check = false;
            }
            return check;
        }

        Student Collect()
        {
            Student s = new Student();
            s.S_email = textBox3.Text;
            s.S_name = txtusername.Text;
            s.S_phone = textBox4.Text;
            s.S_pw = textBox1.Text;
            s.Credits_aquired = 0;
            return s;
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

        private void AddStudent_Load(object sender, EventArgs e)
        {
            FillControls();
        }
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            ValidateControls();
            if (ValidateControls() == true)
            {
                label7.Visible = false;
                var retun = Collect().CreateStudent();
                label7.Text = retun.message.ShowMessage();
                label7.Visible = true;
                if (label7.Text != "إسم الطالب موجود بالفعل")
                {
                    FillControls();
                }
            }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            if (txtusername.Text != "")
                errorProvider1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                errorProvider1.Clear();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
                errorProvider1.Clear();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
                errorProvider1.Clear();
        }
        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                pictureBox2_Click_1(sender, e);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                pictureBox2_Click_1(sender, e);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                pictureBox2_Click_1(sender, e);
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                pictureBox2_Click_1(sender, e);
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                pictureBox2_Click_1(sender, e);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label7.Visible = false;
            Student s = new Student();
            s.StudentID = (int)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
            s.DeleteStudent();
            dataGridView1.Rows.RemoveAt(e.RowIndex);
        }

        private void AddStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainScreen mn = new MainScreen();
            this.Hide();
            mn.ShowDialog();
        }
    }
}
