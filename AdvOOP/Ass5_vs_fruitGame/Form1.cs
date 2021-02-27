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
    public partial class Form1 : Form
    {
        Random r = new Random();
        int winCount, loseCount;
        int toggle_mode = 0;
        bool game_start = false;
        int pressed_cnt = 0;      //count the number of times user clicks while spinning

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSpin_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            pressed_cnt = 0;
            this.Text = "Win: " + winCount + "  Lose: " + loseCount;
            game_start = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int picNum = r.Next(1, 5);
            label1.Text = picNum.ToString();
            pic1.Image = load_pic(picNum);
         }

        public Image load_pic(int picNum=0)
        {
            switch (picNum)
            {
                case 1:
                    return Properties.Resources.Banana;
                    break;
                case 2:
                    return Properties.Resources.Cherry;
                    break;
                case 3:
                    return Properties.Resources.Orange;
                    break;
                default:
                    return Properties.Resources.Watermelon;
                    break;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            pressed_cnt++;
            check_cnt();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            pressed_cnt++;
            check_cnt();

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            pressed_cnt++;
            check_cnt();
        }

        public void check_cnt()
        {
            string message = "Game Over";
            if (game_start)
            {
                if (pressed_cnt == 3)
                {
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    timer3.Enabled = false;

                    if (label1.Text == label2.Text && label2.Text == label3.Text)
                    {
                        message = "You Win!!!";
                        winCount++;
                    }
                    else
                    {
                        message = "You Lose...";
                        loseCount++;
                    }
                    MessageBox.Show(message);
                    reset_game();
                }
            }
            else
            {
                MessageBox.Show("Spin and try again..");
            }
        }

        public void reset_game()
        {
            pic1.Image = load_pic();
            pic2.Image = load_pic();
            pic3.Image = load_pic();
            this.Text = "Win: " + winCount + "  Lose: " + loseCount;
            game_start = false;
            pressed_cnt = 0;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int picNum = r.Next(1, 5);
            label2.Text = picNum.ToString();
            pic2.Image = load_pic(picNum);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int picNum = r.Next(1, 5);
            label3.Text = picNum.ToString();
            pic3.Image = load_pic(picNum);
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            int interval;
            if (toggle_mode == 0)
            {
                toggle_mode = 1;
                interval = 500;
                btnToggle.Text = "Flip once/second";
            }
            else
            {
                toggle_mode = 0;
                interval = 1000;
                btnToggle.Text = "Flip twice/second";
            }

            timer1.Interval = interval;
            timer2.Interval = interval;
            timer3.Interval = interval;
        }

    }
}
