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
                errorProvider1.SetError(txtMaterialname,"please enter material name");
                check = false;
            }
            if (txtyear.Text=="")
            {
                errorProvider1.SetError(txtyear, "please enter ayear");
                check = false;
            }
            int hours;
            if (!int.TryParse(txthoursno.Text,out hours))
            {
                errorProvider1.SetError(txthoursno, "must be number");
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

        private void AddMaterial_Load(object sender, EventArgs e)
        {
            Course c = new Course();
            c.CourseName = "math";
            c.CreditHours = 50;
            c.Term_associated = "second";
            c.CreateCourse();
        }
    }
}
