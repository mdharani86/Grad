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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Width = 400;
            this.Height = 250;
            btn.Top = 0;
            btn.Left = 0;
            btn.Height = 40;
            btn.Width = 40;
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int minX = 0;
            int minY = 0;
            int maxX = this.ClientSize.Width-btn.Width;
            int maxY = this.ClientSize.Height-btn.Height;
            int step = 10;
            int X = btn.Location.X;
            int Y = btn.Location.Y;

            if (radCounterClock.Checked)
            {
                btn.Left = get_X_counter(minX, minY, maxX, maxY, step, X, Y);
                btn.Top = get_Y_counter(minX, minY, maxX, maxY, step, X,Y); 
            }
            else
            {
                btn.Left = get_X_clock(minX, minY, maxX, maxY, step, X, Y);
                btn.Top = get_Y_clock(minX, minY, maxX, maxY, step, X, Y);

            }
        }

        private static int get_X_clock(int minX, int minY, int maxX, int maxY,int step,int X, int Y)
        {
            if (Y == minY)
            {
                if (maxX - X < 10)
                    step = maxX - X;
                X = X + step;
            }
            else if (Y == maxY)
            {
                if (X - minX < 10)
                    step = X - minX;
                X = X - step;
            }
            return X;

        }

        private static int get_Y_clock(int minX, int minY, int maxX, int maxY,int step, int X, int Y)
        {
            if (X == minX)
            {
                if (Y - minY < 10)
                    step = Y - minY;
                Y = Y - step;
            }
            else if (X == maxX)
            {
                if (maxY - Y < 10)
                    step = maxY - Y;
                Y = Y + step;
            }

            return Y;
        }

        private static int get_X_counter(int minX, int minY, int maxX, int maxY,int step, int X, int Y)
        {
            if (Y == minY)
            {
                if (X - minX < 10)
                    step = X - minX;
                X = X - step;
                Y = minY;
            }
            else if (Y == maxY)
            {
                if (maxX - X < 10)
                    step = maxX - X;
                X = X + step;
            }

            return X;
        }

        private int get_Y_counter(int minX, int minY, int maxX, int maxY,int step, int X,int Y)
        {
            if (X == minX)
            {
                if (maxY - Y < 10)
                    step = maxY - Y;
                Y = Y + step;
            }
            else if (X == maxX)
            {
                if (Y - minY < 10)
                    step = Y - minY;
                Y = Y - step;
            }

            return Y;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if(timer2.Enabled)
            {
                timer2.Enabled = false;
                btn.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                timer2.Enabled = true;
                btn.BackColor = System.Drawing.Color.Blue;
            }
        }

        private void Form2_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radClock.Checked = true;
        }

        private void counterClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radCounterClock.Checked = true;
        }
    }
}
