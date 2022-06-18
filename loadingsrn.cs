using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PDEJ
{
    public partial class loadingsrn : Form
    {


        public loadingsrn()
        {
            InitializeComponent();
            ProgressBar1.Value = 0;
        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loadingsrn_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ProgressBar1.Value += 1;
            ProgressBar1.Text = ProgressBar1.Value.ToString() + "%";
                
            if (ProgressBar1.Value == 100)
                {
                timer1.Enabled = false;
                Form1 se_form = new Form1();
                se_form.Show();
                this.Hide();
            }
        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }
    }
}
