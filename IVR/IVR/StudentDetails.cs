using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IVR
{
    public partial class StudentDetails : Form
    {
        public StudentDetails()
        {
            InitializeComponent();
        }

        #region BusinessMethods

        void FillControls()
        {

        }

        bool ValidateControls()
        {
            var check = true;
            if (textBoxName.Text == "")
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(textBoxName, "This field is required");
                check = false;
            }
            if (textBoxNumber.Text == "")
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(textBoxNumber, "This field is required");
                check = false;
            }
            int num;
            bool isNum = int.TryParse(textBoxNumber.Text.Trim(), out num);
            if (!isNum)
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(textBoxNumber, "this field must be numeric");
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

        void Delete()
        {

        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ValidateControls();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text != "")
            {
                errorProvider1.Clear();
            }
        }

        private void textBoxNumber_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNumber.Text != "")
            {
                errorProvider1.Clear();
            }
        }
    }
}
