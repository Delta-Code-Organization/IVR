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
            var lastCourseName = db.Course.OrderByDescending(p => p.CourseID).FirstOrDefault();
            return new Returner
            {
                Data = lastCourseName,
                message = Msgs.Course_Name_Created_Successfully
            };
        }
        public Returner AddStudentCourse(int _ID)
        {
            var fullOrEmpty = db.TimeTable.Any(p => p.Section_ID == this.CourseID && p.Registered < p.Capacity);
            if (fullOrEmpty == true)
            {
                var course = db.Course.Where(p => p.CourseID == this.CourseID).SingleOrDefault();
                var student = db.Student.Where(p => p.StudentID == _ID).SingleOrDefault();
                var time = course.TimeTable.Where(p => p.Section_ID == this.CourseID).SingleOrDefault();
                time.Registered++;
                course.Student.Add(student);
                db.SaveChanges();
                return new Returner
                {
                    Data = course
                };
            }
            return new Returner
            {
                message = Msgs.This_Course_Is_Full
            };
        }
        public Returner SearchCoursesByName()
        {
            var exist = db.Course.Any(p => p.CourseName == this.CourseName);
            if (exist == true)
            {
                var searchcourse = db.Course.Where(p => p.CourseName == this.CourseName).SingleOrDefault();
                return new Returner
                {
                    Data = searchcourse,
                    message = Msgs.Is_Found
                };
            }
            return new Returner
            {
                message = Msgs.Not_Found
            };
        }
        public List<Course> GetAllcourses()
        {
            var all = db.Course.OrderBy(p => p.CourseID).ToList();
            return all;
        }

        public Returner DeleteCourse()
        {
            var course = db.Course.Where(p => p.CourseID == this.CourseID).SingleOrDefault();
            if (db.TimeTable.Any(p => p.Section_ID == this.CourseID))
            {
                var time = db.TimeTable.Where(p => p.Section_ID == this.CourseID).SingleOrDefault();
               // course.TimeTable.Remove(time);
               db.TimeTable.Remove(time);
            }
            var exit = course.Student.Any();
            if (exit == true)
            {
                List<Student> LOS = course.Student.ToList();
                foreach (Student s in LOS)
                {
                    s.Course.Remove(course);
                    db.SaveChanges();
                }
            }
            db.Course.Remove(course);
            db.SaveChanges();
            return new Returner
            {
                Data = course,
                message = Msgs.Course_Deleted_Successfully
            };
        }
        public Returner DeleteStudentCourse(int _ID)
        {
                var course = db.Course.Where(p => p.CourseID == this.CourseID).SingleOrDefault();
                var student = db.Student.Where(p => p.StudentID == _ID).SingleOrDefault();
                course.Student.Remove(student);
                var time = course.TimeTable.Where(p => p.Section_ID == this.CourseID).SingleOrDefault();
                time.Registered--;
                db.SaveChanges();
                return new Returner
                {
                    Data = course,
                    message = Msgs.Student_Deleted_From_Course_Successfully
                };
        }
    }
}

