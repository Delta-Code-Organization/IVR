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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        #region  BusinessMethods
        void FillControls()
        {

        }

        bool ValidateControls()
        {
            errorProvider1.RightToLeft = true;
            bool check = true;
            if (txtusername.Text=="")
            {
                errorProvider1.SetError(txtusername, "please enter user name");
                check = false;
            }
            int hours;
            if (!int.TryParse(txtuserhours.Text,out hours))
            {
                errorProvider1.SetError(txtuserhours, "Must be number");
                check = false;
            }
            if (comboBox1.SelectedItem ==null)
            {
                errorProvider1.SetError(comboBox1, "please select ayear");
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

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            if (txtusername.Text != "")
                errorProvider1.Clear();
        }

        private void txtuserhours_TextChanged(object sender, EventArgs e)
        {
            if (txtuserhours.Text != "")
                errorProvider1.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
                errorProvider1.Clear();
        }

    }
}
