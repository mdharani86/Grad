using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass7
{
    class Student
    {
        string dtl;
        public string StudID { get; set; }
        public int earnedHours { get; set; }
        public SortedList<string, Course> StudCourses = new SortedList<string, Course>();

        public string Details
        {
            get
            {   dtl = "  Student ID:" + this.StudID + " \n";
                foreach(Course c in StudCourses.Values)
                {
                    dtl += c.Details;
                }
                return dtl;
            }
        }
    }
}
