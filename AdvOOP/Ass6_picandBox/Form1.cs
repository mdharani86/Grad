using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass6
{
    public partial class Form1 : Form
    {
        int picint = 1;
        Form2 f2 = new Form2();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (picint)
            {
                case 1:
                    pic1.Image = Properties.Resources.Tampa;
                    this.Text = "Tampa";
                    picint++;
                    break;
                case 2:
                    pic1.Image = Properties.Resources.Orlando;
                    picint++;
                    this.Text = "Orlando";
                    break;
                case 3:
                    pic1.Image = Properties.Resources.Miami;
                    picint++;
                    this.Text = "Miami";
                    break;
                case 4:
                    pic1.Image = Properties.Resources.Jacksonville;
                    picint = 1;
                    this.Text = "Jacksonville";
                    break;
                default:
                    pic1.Image = Properties.Resources.Tampa;
                    picint = 1;
                    this.Text = "Tampa";
                    break;

            }

        }

        private void pic1_Click(object sender, EventArgs e)
        {
            this.Hide();
            f2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chkFreeze.Top = this.ClientSize.Height - chkFreeze.Height-10;
            chkFreeze.Left = this.ClientSize.Width - chkFreeze.Width -10;
        }

        private void chkFreeze_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = !chkFreeze.Checked;

        }

        private void freezePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chkFreeze.Checked = true;
        }

        private void unfreezePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chkFreeze.Checked = false;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
