using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVR.Models
{
    public partial class Student
    {
        IVRDBEntities2 db = new IVRDBEntities2();
        public Returner CreateStudent()
        {
            var student = db.Student.Any(p => p.S_name == this.S_name);
            if (student == true)
            {
                return new Returner
                {
                    message = Msgs.إسم_الطالب_موجود_بالفعل
                };
            }
            db.Student.Add(this);
            db.SaveChanges();
            var lastStudent = db.Student.OrderByDescending(p => p.StudentID).FirstOrDefault();
            return new Returner
            {
                message = Msgs.تم_إضافة_الطالب_بنجاح,
                Data = lastStudent
            };
        }
        public Returner SearchStudents()
        {
            List<Student> all = db.Student.OrderBy(p => p.StudentID).ToList();
            if (this.S_name != "")
                all = all.Where(p => p.S_name == this.S_name).ToList();
            if (this.S_phone != "")
                all = all.Where(p => p.S_phone == this.S_phone).ToList();
            if (this.S_phone != "" && this.S_name != "")
                all = all.Where(p => p.S_phone == this.S_phone && p.S_name == this.S_name).ToList();
            if (all.Count == 0)
            {
                return new Returner
                {
                    message = Msgs.لا_يوجد_نتائج
                };
            }
            return new Returner
            {
                Data = all.FirstOrDefault(),
                message = Msgs.يوجد_نتائج
            };
        }
        public List<Student> GetAllStudents()
        {
            List<Student> all = db.Student.OrderBy(p => p.StudentID).ToList();
            return all;
        }
        public Returner GetStudent()
        {
            Student student = db.Student.Where(p => p.StudentID == this.StudentID).SingleOrDefault();
            return new Returner
            {
                Data = student
            };
        }
        public Returner DeleteStudent()
        {
            Course c = new Models.Course();
            var student = db.Student.Where(p => p.StudentID == this.StudentID).SingleOrDefault();
            var allcourses = student.Course.ToList();
            foreach (Course crse in allcourses)
            {
                if (student.Course.Any(p => p.CourseID == crse.CourseID))
                {
                    crse.DeleteStudentCourse(student.StudentID);
                }
            }
            student.Delete();
            return new Returner
            {
                Data = student,
                message = Msgs.تم_حذف_الطالب_بنجاح
            };
        }
        public Returner UpdateStudent()
        {
            var student = db.Student.Where(p => p.StudentID == this.StudentID).SingleOrDefault();
            student.S_name = this.S_name;
            student.S_email = this.S_email;
            student.S_phone = this.S_phone;
            student.S_pw = this.S_pw;
            student.Credits_aquired = this.Credits_aquired;
            db.SaveChanges();
            return new Returner
            {
                Data = student,
                message = Msgs.نم_تعديل_بيانات_الطالب_بنجاح
            };
        }
        public Returner Delete()
        {
            var student = db.Student.Where(p => p.StudentID == this.StudentID).SingleOrDefault();
            db.Student.Remove(student);
            db.SaveChanges();
            return new Returner
            {
                message = Msgs.تم_حذف_الطالب_بنجاح
            };
        }
    }
}
