using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass4_vs
{
    public partial class Form1 : Form
    {
        Random r = new Random();

        int min, max;               // user inputs
        int randnum1, randnum2;     // random generated numbers
        int above, below, between;  // counters
        //
        //update_counter_label method check the gernerated output, increment the appropriate counter and update the label.
        //
        private void update_counter_label(int ans)
        {
            if (ans < min)
                below++;
            else if (ans > max)
                above++;
            else
                between++;

            labAbove.Text = "Above " + max + " : " + above;
            labBelow.Text = "Below " + min + " : " + below;
            labBetween.Text = "Between " + min + " and " + max + " : " + between;
        }
        //        
        public Form1()
        {
            InitializeComponent();
        }
        //
        //when the user press enter button, inputs are validated and random numbers are generated.
        //Appropiate error is displayed for invalid inputs. 
        //The textbox is locked for valid inputs.
        //
        private void btnEnter_Click(object sender, EventArgs e)
        {
            bool isvalidinputs = false;
            string error = null;

            //Input validation starts

            if (txtNum1.Text.Length <= 0 || txtNum2.Text.Length <= 0)
                error = "Input fields cannot be empty";
            else
            {
                if (int.TryParse(txtNum1.Text, out min) & int.TryParse(txtNum2.Text, out max))
                {
                    if (min <= max)
                        isvalidinputs = true;
                    else
                        error = "1st number should be less than or equal to 2nd number";
                }
                else
                    error = "Enter integer inputs";
            }

            // Input valudation ends

            if (isvalidinputs)
            {
                labInErr.Visible = false;
                randnum1 = r.Next(min, max + 1);
                randnum2 = r.Next(min, max + 1);


                labRandom1.Text = randnum1.ToString();
                labRandom2.Text = randnum2.ToString();

                if (txtNum1.Enabled || txtNum2.Enabled)
                {
                    txtNum1.Enabled = false;
                    txtNum2.Enabled = false;
                }

                labResult.Text = "?";
            }
            else
            {
                labInErr.Text = error;
                labInErr.Visible = true;
            }
        }
       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int result = randnum1 + randnum2;
            labResult.Text = result.ToString();
            update_counter_label(result);
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            int result = randnum1 - randnum2;
            labResult.Text = result.ToString();
            update_counter_label(result);
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            int result = randnum1 * randnum2;
            labResult.Text = result.ToString();
            update_counter_label(result);
        }
                
        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            string error;
            float result;

            if (randnum2 == 0)
            {
                error = "Cannot divide by zero!";
                labResult.Text = error;
            }
            else
            {
                result =  (float)randnum1 / randnum2;
                labResult.Text = result.ToString("0.##");
                update_counter_label((int)result);
            }
            
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            string error;
            int result;

            if (randnum2 == 0)
            {
                error = "Cannot divide by zero!";
                labResult.Text = error;
            }
            else
            {
                result = randnum1 % randnum2;
                labResult.Text = result.ToString();
                update_counter_label(result);
            }
        }

        private void btnAvg_Click(object sender, EventArgs e)
        {
            float result;
            float n = 2;

            result = (randnum1+randnum2) / n;
            labResult.Text = result.ToString("0.##");
            update_counter_label((int)result);
        }
    }
}
