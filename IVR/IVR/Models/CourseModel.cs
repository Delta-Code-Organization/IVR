using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVR.Models
{
  partial class Course
    {
      IVRDBEntities2 db = new IVRDBEntities2();
       public Returner CreateCourse()
        {
            var course = db.Course.Any(p => p.CourseName == this.CourseName);
            if (course == true)
            {
                return new Returner
                {
                    message = Msgs.Course_Name_Dublicated
                };
            }
            Course corse=new Course ();
            corse.CourseName=this.CourseName;
            corse.CreditHours=this.CreditHours;
            corse.Term_associated=this.Term_associated;
                db.Course.Add(this);
                db.SaveChanges();
            var lastCourseName=db.Course.OrderByDescending(p=>p.CourseID).FirstOrDefault();
                return new Returner
                {
                    Data=lastCourseName,
                    message = Msgs.Course_Name_Created_Successfully
                };


            }
        }
    }

