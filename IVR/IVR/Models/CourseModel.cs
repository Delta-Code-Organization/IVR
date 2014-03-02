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
                    message = Msgs.إسم_المادة_موجود_بالفعل
                };
            }
            db.Course.Add(this);
            db.SaveChanges();
            var lastCourseName = db.Course.OrderByDescending(p => p.CourseID).FirstOrDefault();
            return new Returner
            {
                Data = lastCourseName,
                message = Msgs.تم_إضافة_المادة_بنجاح
            };
        }
        public Returner AddStudentCourse(int _ID, DateTime _startTime)
        {
            var fullOrEmpty = db.TimeTable.Any(p => p.Section_ID == this.CourseID && p.StartTime == _startTime && p.Registered < p.Capacity);
            if (fullOrEmpty == true)
            {
                var course = db.Course.Where(p => p.CourseID == this.CourseID).SingleOrDefault();
                var student = db.Student.Where(p => p.StudentID == _ID).SingleOrDefault();
                if (course.Student.Any(p => p.StudentID == student.StudentID))
                {
                    return new Returner
                    {
                        message = Msgs.هذا_الطالب_مضاف_بالفعل_لهذه_الماده
                    };
                }
                if (student.Credits_aquired + course.CreditHours <= 12)
                {
                    var time = course.TimeTable.Where(p => p.Section_ID == this.CourseID && p.StartTime == _startTime && p.Registered < p.Capacity).FirstOrDefault();

                    time.Registered++;
                    course.Student.Add(student);
                    db.SaveChanges();
                    return new Returner
                    {
                        Data = course,
                        message = Msgs.تم_إضافة_الطالب_للمادة_بنجاح
                    };
                }
                else
                {
                    return new Returner
                    {
                        message = Msgs.عدد_الساعات_المتاحه_لدي_الطالب_لا_تكفي
                    };
                }
            }

            return new Returner
            {
                message = Msgs.عدد_الطلاب_مكتمل
            };
        }

        public Returner SearchCoursesByName()
        {
            var exist = db.Course.Any(p => p.CourseName == this.CourseName);
            if (exist == true)
            {
                List<TimeTable> LOTT = new List<TimeTable>();
                var searchcourse = db.Course.Where(p => p.CourseName == this.CourseName).SingleOrDefault();
                foreach (TimeTable tt in searchcourse.TimeTable)
                {
                    LOTT.Add(tt);
                }
                return new Returner
                {
                    Data = LOTT,
                    message = Msgs.يوجد_نتائج
                };
            }
            return new Returner
            {
                message = Msgs.لا_يوجد_نتائج
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
                var time = db.TimeTable.Where(p => p.Section_ID == this.CourseID).ToList();
                foreach (TimeTable tt in time)
                {
                    db.TimeTable.Remove(tt);
                    db.SaveChanges();
                }
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
                message = Msgs.تم_حذف_المادة_بنجاح
            };
        }
        public Returner DeleteStudentCourse(int _ID)
        {
            var course = db.Course.Where(p => p.CourseID == this.CourseID).SingleOrDefault();
            var student = db.Student.Where(p => p.StudentID == _ID).SingleOrDefault();
            var time = course.TimeTable.Where(p => p.Section_ID == this.CourseID).ToList();
            foreach (TimeTable tt in time)
            {
                if (tt.Course.Student.Contains(student))
                {
                    course.Student.Remove(student);
                    tt.Registered--;
                    db.SaveChanges();
                }
            }
            return new Returner
            {
                Data = course,
                message = Msgs.تم_حذف_الطالب_من_المادة_بنجاح
            };
        }
        public Returner GetCourse()
        {
            var exist = db.Course.Any(p => p.CourseName == this.CourseName);
            if (exist == true)
            {
                var course = db.Course.Where(p => p.CourseName == this.CourseName).SingleOrDefault();
                return new Returner
                {
                    Data = course,
                    message = Msgs.يوجد_نتائج
                };
            }
            return new Returner
            {
                message = Msgs.لا_يوجد_نتائج
            };
        }
    }
}

