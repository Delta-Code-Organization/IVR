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
 
        }

        bool ValidateControls()
        {
            errorProvider1.RightToLeft = true;
            bool check = true;
            if (txtMaterialname.Text == "")
            {
                errorProvider1.SetError(txtMaterialname,"من فضلك ادخل اسم المادة");
                check = false;
            }
            if (txtyear.Text=="")
            {
                errorProvider1.SetError(txtyear, "من فضلك ادخل الفصل الدراسي");
                check = false;
            }
            if (txthoursno.TextLength<1)
            {
                errorProvider1.SetError(txthoursno, "من فضلك أدخل عدد الساعات");
                check = false;
            }
            int hours;
            if (txthoursno.TextLength>1&&!int.TryParse(txthoursno.Text,out hours))
            {
                errorProvider1.SetError(txthoursno, "لابد ان تكون قيمة رقمية");
                check = false;
            }
            if (textBoxcode.TextLength<1)
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

        private void button1_Click(object sender, EventArgs e)
        {
            ValidateControls();

        }

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

        private void txthoursno_TextChanged(object sender, EventArgs e)
        {
            if (txthoursno.Text != "")
                errorProvider1.Clear();
        }

        private void textBoxcode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxcode.Text != "")
                errorProvider1.Clear();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
         bool validation=ValidateControls();
         if (validation == true)
         {
             Course c = new Course();
             c.CourseName = txtMaterialname.Text;
             c.CreditHours = Convert.ToInt32(txthoursno.Text);
             c.Term_associated = txtyear.Text;
             c.CourseCode = Convert.ToInt32(textBoxcode.Text);
             Course res = c.CreateCourse().Data as Course;
             DataTable DT = new DataTable();
             DT.Columns.Add("كود المادة", typeof(int));
             DT.Columns.Add("اسم المادة", typeof(string));
             DT.Columns.Add("الفصل الدراسي", typeof(string));
             DT.Columns.Add("عدد الساعات", typeof(int));
             DataRow DR = DT.NewRow();
             DR[0] = res.CourseCode;
             DR[1] = res.CourseName;
             DR[2] = res.Term_associated;
             DR[3] = res.CreditHours;
             DT.Rows.Add(DR);
             dataGridView1.DataSource = DT;
             dataGridView1.Visible = true;
         }
        }
    }
}
