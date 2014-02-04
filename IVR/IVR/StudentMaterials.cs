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
    public partial class StudentMaterials : Form
    {
        public StudentMaterials()
        {
            InitializeComponent();
        }

        #region BusinessMethods
        
        void FillControls() 
        {
            
        }

        bool ValidateControls()
        {
            bool Check = true;
            if (comboBoxMaterial.SelectedItem ==null)
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(comboBoxMaterial, "This field is required");
                Check = false;
            }
            if (comboBoxStudentName.SelectedItem==null)
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(comboBoxStudentName, "This field is required");
                Check = false;
            }
            if (comboBoxLectureTime.SelectedItem==null)
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(comboBoxLectureTime, "This field is required");
                Check = false;
            }
            return Check;
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void StudentMaterials_Load(object sender, EventArgs e)
        {
            FillControls();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ValidateControls();
        }

        private void comboBoxMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMaterial.SelectedItem != null)
            {
                errorProvider1.Clear();
            }
        }

        private void comboBoxStudentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStudentName.SelectedItem != null)
            {
                errorProvider1.Clear();
            }
        }

        private void comboBoxLectureTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLectureTime.SelectedItem != null)
            {
                errorProvider1.Clear();
            }
        }
    }
}
