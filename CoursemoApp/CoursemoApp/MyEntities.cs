using System;
using System.Collections.Generic;
using System.Data;

namespace CoursemoApp
{
  public partial class Student
  {
    public override string ToString()
    {
      return string.Format("{0}, {1}", LastName, FirstName);
    }
  }//class

  public partial class Course
  {
    public override string ToString()
    {
      return string.Format("{0} {1}: {2}", Department, CourseNum, CRN);
    }

        public string waitlistToString()
        {
            return string.Format("{0} {1}: {2} (Waitlist)", Department, CourseNum, CRN);
        }

        public string printSemYear()
        {
            return string.Format("{0} {1}", Semester, Year);
        }

        public string printDayTime()
        {
            if (Char.IsNumber(ClassTime[1]))
            {
                /*string start, startHr, startMin, end, endHr, endMin;
                string[] val = ClassTime.Split('-');
                start = val[0];
                end = val[1];
                startHr = start.Substring(0, 2);
                startMin = start.Substring(2, 2);
                endHr = end.Substring(0, 2);
                endMin = end.Substring(2, 2);*/
                return string.Format("{0} {1}", Day, ClassTime);
                //return string.Format("{0} {1}-{2}", Day, start, end);
                //return string.Format("{0} {1}:{2}-{3}:{4}", Day, startHr, startMin, endHr, endMin);
            }
            return string.Format("{0} {1}", Day, ClassTime);
        }
    }//class

    public partial class StudentCourse
    {
        
    }

    public partial class Waitlist
    {
        /*public Waitlist (int crn, string netid)
        {
            CRN = crn;
            NetID = netid;
        }*/
    }

}//namespace
