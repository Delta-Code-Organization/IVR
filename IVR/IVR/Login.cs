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
    public partial class Login : Form
    {
        public Login()
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
            if (textBoxUserName.Text=="")
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(textBoxUserName, "This field is required");
                check = false;
            }
            if (textBoxPassword.Text=="")
            {
                errorProvider1.RightToLeft = true;
                errorProvider1.SetError(textBoxPassword, "This field is required");
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
            ValidateControls();
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUserName.Text != "")
            {
                errorProvider1.Clear();
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassword.Text != "")
            {
                errorProvider1.Clear();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
