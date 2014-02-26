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
    public partial class MainScreen : Form
    {
        ModifyRegistry Reg=new ModifyRegistry();
        public MainScreen()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            StudentDetails sd = new StudentDetails();
            this.Hide();
            sd.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ManageMaterials mm = new ManageMaterials();
            this.Hide();
            mm.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            AddMaterial am = new AddMaterial();
            this.Hide();
            am.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            AddStudent ads = new AddStudent();
            this.Hide();
            ads.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            StudentMaterials sm = new StudentMaterials();
            this.Hide();
            sm.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            MyAccount ma = new MyAccount();
            this.Hide();
            ma.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            AddUser au = new AddUser();
            this.Hide();
            au.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CallForm cf = new CallForm();
            this.Hide();
            cf.ShowDialog();
        }
       
        private void MainScreen_Load(object sender, EventArgs e)
        {
          label2.Text =" مرحبا " +Reg.Read("Name");
        }

        private void MainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login log = new Login();
            this.Hide();
            log.ShowDialog();
        }
    }
}
