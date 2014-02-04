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
    public partial class MyAccount : Form
    {
        public MyAccount()
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
            if (textBoxPass.Text == "")
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(textBoxPass, "This field is required");
                check = false;
            }
            if (textBoxConfirmPass.Text == "")
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(textBoxConfirmPass, "This field is required");
                check = false;
            }
            if (textBoxPass.Text != textBoxConfirmPass.Text)
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(textBoxConfirmPass, "Not Matched password");
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidateControls();
        }

        private void textBoxPass_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPass.Text != "")
            {
                errorProvider1.Clear();
            }
        }

        private void textBoxConfirmPass_TextChanged(object sender, EventArgs e)
        {
            if (textBoxConfirmPass.Text != "")
            {
                errorProvider1.Clear();
            }
        }
    }
}
