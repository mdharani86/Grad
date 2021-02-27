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
    public partial class formSummary : Form
    {

        SortedList<string, Course> courseList = new SortedList<string, Course>();
        SortedList<string, Student> studList = new SortedList<string, Student>();

        public formSummary()
        {
            InitializeComponent();
        }

        private void formSummary_Load(object sender, EventArgs e)
        {
            // Build Student and Course List form Tag
            studList = (SortedList<string, Student>)this.Tag;

            foreach (Course c in studList["ALL"].StudCourses.Values)
            {
                courseList.Add(c.CourseNum, c);
            }

            studList.Remove("ALL");

            //Load the Course list

            foreach (string c in courseList.Keys)
            {
                lstCourse.Items.Add(c);
            }

            //Load student list

            foreach (string s in studList.Keys)
            {
                lstStud.Items.Add(s);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstCourse.SelectedIndex = -1;
            lstStud.SelectedIndex = -1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lstCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCourse.SelectedIndex != -1)
            {
                string msg;
                int studCourseCnt = 0;
                msg = courseList[lstCourse.SelectedItem.ToString()].Details + "\n";

                foreach (Student s in studList.Values)
                {
                    if (s.StudCourses.ContainsKey(lstCourse.SelectedItem.ToString()))
                        studCourseCnt++;
                }

                msg += "Number of Students Enrolled = " + studCourseCnt;

                MessageBox.Show(msg, "Course Details");
            }
        }

        private void lstStud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStud.SelectedIndex != -1)
            {
                double sumgpa = 0;
                double cntgpa = 0;
                string msg;
                msg = studList[lstStud.SelectedItem.ToString()].Details;
                foreach (Course c in studList[lstStud.SelectedItem.ToString()].StudCourses.Values)
                {
                    switch (c.courseGrade)
                    {
                        case "A":
                            sumgpa += 4;
                            cntgpa += 1;
                            break;
                        case "B":
                            sumgpa += 3;
                            cntgpa += 1;
                            break;
                        case "C":
                            sumgpa += 2;
                            cntgpa += 1;
                            break;
                        case "D":
                            sumgpa += 1;
                            cntgpa += 1;
                            break;
                        case "F":
                            sumgpa += 0;
                            cntgpa += 1;
                            break;
                    }
                }
                double gpa;
                if (cntgpa != 0)
                    gpa = sumgpa / cntgpa;
                else
                    gpa = 0;

                msg += "Student GPA is : " + gpa.ToString("0.##");

                MessageBox.Show(msg);
            }
        }
    }
}
