using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass7
{
    public partial class formCourse : Form
    {
        SortedList<string, Course> courseList = new SortedList<string, Course>();

        public formCourse()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtCourseNum.Text == "" || comboCourse.Text == "" || txtCourseName.Text == "")
            {
                MessageBox.Show("Incomplete input!");
            }
            else
            {
                AddCourse();
            }
            

        }

        private void AddCourse()
        {
            string Cnum = txtCourseNum.Text;
            CourseWork cw = new CourseWork();
            cw.CSName = comboCourse.Text + "." + txtCourseName.Text;
            cw.CScore = "NA";
            
            if(courseList.ContainsKey(Cnum))
            {                
                if(courseList[Cnum].cnamescores.Contains(cw))
                {
                    MessageBox.Show("Course work name already exist! Try a new name!!");
                }
                else
                {
                    bool ispresent = false;
                    foreach(CourseWork cwchk in courseList[Cnum].cnamescores)
                    {
                        if (cwchk.CSName == cw.CSName)
                            ispresent = true;
                    }
                    if(ispresent)
                    {
                        MessageBox.Show("Course already present");
                    }
                    else
                    {
                        courseList[Cnum].cnamescores.Add(cw);
                        MessageBox.Show("Course work " + Cnum + " Added!"); 
                    }                   
                }
            }
            else
            {
                Course cnew = new Course();
                cnew.CourseNum = Cnum;
                cnew.cnamescores.Add(cw);
                courseList.Add(Cnum, cnew);
                MessageBox.Show("Course work " + Cnum + " Added!!!");
            }

            
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCourseNum.Clear();
            txtCourseName.Clear();
            comboCourse.Text = "";

        }

        private void btnStudForm_Click(object sender, EventArgs e)
        {
            formStudent fs = new formStudent();
            fs.Tag = courseList;
            fs.ShowDialog();
            this.Hide();
        }
    }
}
