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
    public partial class ManageMaterials : Form
    {
        public ManageMaterials()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
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
            if (txt2materialname.Text=="")
            {
                errorProvider1.SetError(txt2materialname, "please enter material name");
                check = false;
            }
            if (txtday.Text=="")
            {
                errorProvider1.SetError(txtday, "please enter the day");
                check = false;
            }
            DateTime from;
            if (!DateTime.TryParse(txtfrom.Text, out from))
            {
                errorProvider1.SetError(txtfrom, "Must be a date/time value");
            }
            DateTime to;
            if (!DateTime.TryParse(txtto.Text,out to))
            {
                errorProvider1.SetError(txtto, "Must be a date/time value");
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
        private void button1_Click_2(object sender, EventArgs e)
        {
            ValidateControls();
        }

        private void txt2materialname_TextChanged(object sender, EventArgs e)
        {
            if (txt2materialname.Text!= "")
                errorProvider1.Clear();
        }

        private void txtfrom_TextChanged(object sender, EventArgs e)
        {
            if (txtfrom.Text != "")
                errorProvider1.Clear();
        }

        private void txtday_TextChanged(object sender, EventArgs e)
        {
            if (txtday.Text != "")
                errorProvider1.Clear();
        }

        private void txtto_TextChanged(object sender, EventArgs e)
        {
            if (txtto.Text != "")
                errorProvider1.Clear();
        }
    }
}
