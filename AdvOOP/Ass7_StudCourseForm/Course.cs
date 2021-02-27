using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass7
{
    class Course
    {
        //double scores;
        double ssum;
        double stot;
        string grade;
        string dtl;
        public String CourseNum { get; set; }
        double avg;
        //public SortedList<string, string> cnamescores = new SortedList<string, string>();
        public List<CourseWork> cnamescores = new List<CourseWork>();
        public string courseGrade
        {
            get
            {
                ssum = 0;
                stot = 0;
                //oreach(KeyValuePair<string,string> cscore in cnamescores)
                foreach(CourseWork cw in cnamescores)
                {
                    if(double.TryParse(cw.CScore,out double scores))
                    {
                        ssum = ssum + scores;
                        stot++;
                    }
                }
                if (stot != 0)
                {
                    avg = ssum / stot;
                    if (avg >= 90)
                        grade = "A";
                    else if (avg >= 80)
                        grade = "B";
                    else if (avg >= 70)
                        grade = "C";
                    else if (avg >= 60)
                        grade = "D";
                    else
                        grade = "F";
                }
                else
                {
                    avg = 0;
                    grade = "NA";
                }
                
                return grade;
            }
        }

        public string Details
        {
            get
            {
                dtl = "CourseID :" + CourseNum + ", "+ " Grade: " + courseGrade + " \n";
                
                foreach(CourseWork cw in cnamescores)
                {
                    dtl += "(" + cw.CSName + " = " + cw.CScore + " )";
                }

                dtl += "\n";
                return dtl;
            }
        }
    }
}
