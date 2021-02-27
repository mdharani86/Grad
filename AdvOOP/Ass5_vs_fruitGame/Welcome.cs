using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass5_vs
{
    public partial class Welcome : Form
    {

        Form1 f1;
        public Welcome()
        {
            InitializeComponent();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            string welcome_text = "(a) Welcome to Assignment 5 by Dharani Manian.\n\n" +
                                  "(b) This program allows you to play a simple game by matching three fruit pictures.\n\n " +
                                  "(c) You may choose to flip each picture once or twice per second at any time during a game.\n\n" +
                                  "(d) You will see the total games you win and lose displayed on the form title.\n\n" +
                                  "(e) You may play as many games as you like until you double click on its form to close it and return here.\n\n" +
                                  "(f) To begin a game, double click on this form.";

            labWelcome.Text = welcome_text;
        }

        private void Welcome_DoubleClick(object sender, EventArgs e)
        {
            f1 = new Form1();
            f1.ShowDialog();
        }

        private void labWelcome_DoubleClick(object sender, EventArgs e)
        {
            f1 = new Form1();
            f1.ShowDialog();
        }
    }
}
