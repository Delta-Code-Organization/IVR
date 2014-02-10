using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVR.Models
{
public partial class Course
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
                db.Course.Add(this);
                db.SaveChanges();
            var lastCourseName=db.Course.OrderByDescending(p=>p.CourseID).FirstOrDefault();
                return new Returner
                {
                    Data=lastCourseName,
                    message = Msgs.Course_Name_Created_Successfully
                };
           }
       public Course AddStudentCourse(int _ID)
       {
           var course = db.Course.Where(p => p.CourseID == this.CourseID).SingleOrDefault();
           var student = db.Student.Where(p => p.StudentID == _ID).SingleOrDefault();
           course.Student.Add(student);
           db.SaveChanges();
           return course;
       }
       public List<Course> SearchCoursesByName()
       {
           var searchcourse = db.Course.Where(p => p.CourseName == this.CourseName).ToList();
           return searchcourse;
       }
       public List<Course> GetAllcourses()
       {
           var all = db.Course.OrderBy(p => p.CourseID).ToList();
           return all;
       }
        }
    }

