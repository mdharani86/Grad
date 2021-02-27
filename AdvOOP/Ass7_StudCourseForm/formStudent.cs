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
    public partial class formStudent : Form
    {
        SortedList<string, Student> studlist = new SortedList<string, Student>(); //students list with key as studentID
        SortedList<string, Course> courseList = new SortedList<string, Course>();  //All course list with courseNum as Key


        public formStudent()
        {
            InitializeComponent();
        }

        private void formStudent_Load(object sender, EventArgs e)
        {
            courseList = (SortedList<string, Course>)this.Tag;

            foreach(Course c in courseList.Values)
            {
                lstCourse.Items.Add(c.CourseNum);
            }
            //txtCourseWorkScore.Text = "NA";
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lstCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstCourse.SelectedIndex != -1)
            {
                lstCourseWork.Items.Clear();
                //txtCourseWorkScore.Clear();
                txtCourseGrade.Clear();
                foreach(CourseWork cw in courseList[lstCourse.SelectedItem.ToString()].cnamescores)
                {
                    lstCourseWork.Items.Add(cw.CSName);
                }
                //come back and check this
                //foreach (KeyValuePair<string, string> cid in courseList[lstCourse.SelectedItem.ToString()].cnamescores)
                //{
                //    lstCourseWork.Items.Add(cid.Key);
                //}
            }
        }

        private void btnAddStud_Click(object sender, EventArgs e)
        {
            if(isvalidIn())
            {
                if(!studlist.ContainsKey(comboStud.Text))
                {
                    Student s = new Student();
                    s.StudID = comboStud.Text;
                    
                    studlist.Add(s.StudID, s);
                    MessageBox.Show("Student " + s.StudID + " added");

                    comboStud.Items.Add(s.StudID);

                    lstTest.Items.Clear();
                    foreach(Student st in studlist.Values)
                    {
                        lstTest.Items.Add(st.Details);
                    }
                }
                else
                {
                    MessageBox.Show("student Already present. Try Update");
                }
            }
        }

        private bool isvalidIn()
        {
            if(comboStud.Text == "")
            {
                MessageBox.Show("Enter Student ID!");
                txtCourseWorkScore.Clear();
                return false;
            }

            //if(lstCourse.SelectedIndex == -1 || lstCourseWork.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Selcet Course Work!");
            //    return false;
            //}

            //if(!double.TryParse(txtCourseWorkScore.Text,out double score))
            //{
            //    if((txtCourseWorkScore.Text == "") || (txtCourseWorkScore.Text == "NA" ))
            //    {
            //        //txtCourseWorkScore.Text = "NA";
            //    }
            //    else
            //    {
            //        MessageBox.Show("Invalid score");
            //        return false;
            //    }
            //}
            //else
            //{
            //    if (score > 100 || score < 0)
            //    {
            //        txtCourseWorkScore.Text = "NA";
            //        MessageBox.Show("Invalid score");
            //        return false;
            //    }
            //}

            if (!int.TryParse(txtxCredits.Text, out int hours))
            {
                if ((txtxCredits.Text == "") || (txtCourseWorkScore.Text == "NA"))
                {
                    txtxCredits.Text = "0";
                }
                else
                {
                    txtxCredits.Text = "0";
                    MessageBox.Show("Invalid Credit Hours");
                    return false;
                }
            }

            return true;
        }

        private void btnUpdateStud_Click(object sender, EventArgs e)
        {
            if(isvalidIn())
            {
                if(studlist.ContainsKey(comboStud.Text))
                {                    
                    if (lstCourse.SelectedIndex != -1 && lstCourseWork.SelectedIndex != -1)
                    {
                        if (studlist[comboStud.Text].StudCourses.ContainsKey(lstCourse.SelectedItem.ToString()))
                            UpdateScore();
                        else
                        {
                            MessageBox.Show("Student Not enrolled to this Course");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select Course and Coursework to be updated");
                    }
                   
                }
                else
                {
                    MessageBox.Show("Student Not present! Try Add Student");
                }
            }
        }

        private void UpdateScore()
        {
            Student s = new Student();
            s.StudID = comboStud.Text;

            s.earnedHours = studlist[comboStud.Text].earnedHours;
            SortedList<string,Course> clist = new SortedList<string,Course>();
            
            foreach (KeyValuePair<string,Course> c in studlist[comboStud.Text].StudCourses)
            {
                Course c1 = new Course();
                //MessageBox.Show("bp01 " + c.Key + " " + lstCourse.SelectedItem.ToString());
                if (c.Key == lstCourse.SelectedItem.ToString())
                {
                    //MessageBox.Show("bpo1 is true");
                    c1.CourseNum = c.Key;
                    foreach (CourseWork cw1 in c.Value.cnamescores)
                    {
                        if (cw1.CSName == lstCourseWork.SelectedItem.ToString())
                        {
                            CourseWork cw2 = new CourseWork();
                            cw2.CSName = lstCourseWork.SelectedItem.ToString();
                            cw2.CScore = txtCourseWorkScore.Text;
                            c1.cnamescores.Add(cw2);
                        }
                        else
                        {
                            c1.cnamescores.Add(cw1);
                        }
                    }
                    
                }
                else
                {
                    //MessageBox.Show("bp02 is false");
                    c1 = c.Value;
                }
                clist.Add(c1.CourseNum, c1);                
            }
            //MessageBox.Show("bp1"+ s.StudCourses.Count().ToString()+ " " + clist.Count);
            s.StudCourses = clist;
            //MessageBox.Show("bp2"+s.StudCourses.Count().ToString());
            //MessageBox.Show("bp3" + studlist.Count);
            studlist.Remove(comboStud.Text);
            //MessageBox.Show("bp4" + studlist.Count);
            studlist.Add(comboStud.Text, s);
            //MessageBox.Show("bp5" + studlist.Count);
            txtCourseGrade.Text = studlist[comboStud.Text].StudCourses[lstCourse.SelectedItem.ToString()].courseGrade.ToString();
            MessageBox.Show("Updated");

            lstTest.Items.Clear();
            foreach (Student st in studlist.Values)
            {
                lstTest.Items.Add(st.Details);
            }
        }

        private void btnRemStud_Click(object sender, EventArgs e)
        {
            if(comboStud.Text != "")
            {
                if(studlist.ContainsKey(comboStud.Text))
                {
                    studlist.Remove(comboStud.Text);
                    comboStud.Items.Remove(comboStud.Text);
                    MessageBox.Show("Student " + comboStud.Text + " Removed!");
                    //test
                    lstTest.Items.Clear();
                    foreach (Student st in studlist.Values)
                    {
                        lstTest.Items.Add(st.Details);
                    }
                }
                else
                {
                    MessageBox.Show("Student Not present!");
                }

            }
            else
            {
                MessageBox.Show("Enter Student ID!");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            comboStud.Text = "";
            lstCourse.SelectedIndex = -1;
            lstCourseWork.Items.Clear();
            txtCourseWorkScore.Text = "NA";
            txtCourseGrade.Clear();
            txtxCredits.Clear();
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.StudID = "ALL";
            s.StudCourses = courseList;
            studlist.Add("ALL", s);

            formSummary fsum = new formSummary();
            fsum.Tag = studlist;
            this.Hide();
            fsum.Show();

        }

        private void txtCourseWorkScore_TextChanged(object sender, EventArgs e)
        {
            //if(isvalidIn())
            //{
            if (lstCourse.SelectedIndex != -1 && lstCourseWork.SelectedIndex != -1)
            {
                if (double.TryParse(txtCourseWorkScore.Text, out double score))
                {
                    if (studlist.ContainsKey(comboStud.Text) && (lstCourse.SelectedIndex != -1) && (lstCourseWork.SelectedIndex != -1))
                    {
                        if (studlist[comboStud.Text].StudCourses.ContainsKey(lstCourse.SelectedItem.ToString()))
                        {
                            //studlist[comboStud.Text].StudCourses[lstCourse.Text].cnamescores[lstCourseWork.Text] = txtCourseWorkScore.Text;
                            txtCourseGrade.Text = studlist[comboStud.Text].StudCourses[lstCourse.SelectedItem.ToString()].courseGrade.ToString();
                        }
                    }
                    else
                    {
                        txtCourseGrade.Clear();
                        //MessageBox.Show("Add student first and update score ");
                    }
                }
                else
                {
                    if (!(txtCourseWorkScore.Text == "" || txtCourseWorkScore.Text == "NA"))
                    {
                        MessageBox.Show("Invalid score");
                    }
                }
            }
            else
            {
                MessageBox.Show("Select course first");
             }
           // }
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            if(comboStud.Text != "" && lstCourse.SelectedIndex != -1)
            {
                if(studlist.ContainsKey(comboStud.Text))
                {
                    if (!studlist[comboStud.Text].StudCourses.ContainsKey(lstCourse.SelectedItem.ToString()))
                    {
                        if (studlist[comboStud.Text].StudCourses.Count < 5)
                        {
                            Course c = new Course();
                            c = courseList[lstCourse.Text];
                            studlist[comboStud.Text].StudCourses.Add(c.CourseNum, c);

                            MessageBox.Show("Enrolled!");
                            //test
                            lstTest.Items.Clear();
                            foreach (Student st in studlist.Values)
                            {
                                lstTest.Items.Add(st.Details);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Only 5 coursed Permitted for each student");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Student already enrolled in this course");
                    }
                }
                else
                {
                    MessageBox.Show("Add Student to enroll in courses");
                }
            }
            else
            {
                MessageBox.Show("Enter Student ID and seclet the course");
            }
        }

        private void btnRemEnroll_Click(object sender, EventArgs e)
        {
            if(comboStud.Text != "")
            {
                if(studlist.ContainsKey(comboStud.Text))
                {
                    if(lstCourse.SelectedIndex != -1)
                    {
                        if(studlist[comboStud.Text].StudCourses.ContainsKey(lstCourse.SelectedItem.ToString()))
                        {
                            studlist[comboStud.Text].StudCourses.Remove(lstCourse.SelectedItem.ToString());
                            MessageBox.Show("Course removed from student enrollment");
                        }
                        else
                        {
                            MessageBox.Show("Student not enrooled to selected course!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select course from course list to remove!!");
                    }
                }
                else
                {
                    MessageBox.Show("Student not present!!");
                }

            }
            else
            {
                MessageBox.Show("Enter Student ID!");
            }

            //test
            lstTest.Items.Clear();
            foreach (Student st in studlist.Values)
            {
                lstTest.Items.Add(st.Details);
            }

        }

        private void lstCourseWork_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnupdatecredits_Click(object sender, EventArgs e)
        {
            if(comboStud.Text != "")
            {
                if(studlist.ContainsKey(comboStud.Text))
                {
                    if(int.TryParse(txtxCredits.Text,out int hours))
                    {
                        studlist[comboStud.Text].earnedHours = hours;
                        MessageBox.Show(" Credit Hours updated for " + comboStud.Text);
                    }
                    else
                    {
                        MessageBox.Show("Invalid credit hours.Update failed!");
                    }
                }
                else
                {
                    MessageBox.Show("Student ID not present. Try Add the student first!");
                }
            }
            else
            {
                MessageBox.Show("Enter Student ID");
            }
        }

        private void lstTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstTest.SelectedIndex != -1)
            {
                MessageBox.Show(lstTest.SelectedItem.ToString());
            }
        }
    }
}
