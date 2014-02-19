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
                   message = Msgs.Student_Name_Dublicated
               };
           }
           db.Student.Add(this);
           db.SaveChanges();
           var lastStudent = db.Student.OrderByDescending(p => p.StudentID).FirstOrDefault();
           return new Returner
           {
               message = Msgs.Student_created_Successfuly,
               Data = lastStudent
           };
       }
       public Returner SearchStudentsByName()
       {
               var exist = db.Student.Any(p => p.S_name == this.S_name);
               if (exist == true)
               {
                   var searchStudent = db.Student.Where(p => p.S_name == this.S_name).SingleOrDefault();
                   return new Returner
                   {
                       Data = searchStudent,
                       message = Msgs.Is_Found
                   };
               }
               return new Returner
               {
                   message = Msgs.Not_Found
               };
           }
       
       public Returner SearchStudentsByPhone()
       {
           var exist = db.Student.Any(p => p.S_phone == this.S_phone);
           if (exist == true)
           {
               var searchStudent = db.Student.Where(p => p.S_phone == this.S_phone).SingleOrDefault();
               return new Returner
               {
                   Data = searchStudent,
                   message = Msgs.Is_Found
               };
           }
           return new Returner
           {
               message = Msgs.Not_Found
           };
       }
       public Returner SearchStudentsByNameAndPhone()
       {
           var exist = db.Student.Any(p => p.S_phone == this.S_phone&&p.S_name==this.S_name);
           if (exist == true)
           {
               var searchStudent = db.Student.Where(p => p.S_phone == this.S_phone && p.S_name == this.S_name).SingleOrDefault();
               return new Returner
               {
                   Data = searchStudent,
                   message = Msgs.Is_Found
               };
           }
           return new Returner
           {
               message = Msgs.Not_Found
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
           var allcourses = c.GetAllcourses();
           var student = db.Student.Where(p => p.StudentID == this.StudentID).SingleOrDefault();
           foreach (Course crse in allcourses)
           {
               if (student.Course.Any(p => p.CourseID == crse.CourseID))
               {
                   crse.DeleteStudentCourse(student.StudentID);
                   //student.Course.Remove(crse);
                   //db.SaveChanges();
               }
           }
           student.Delete();
           //var student1 = db.Student.Where(p => p.StudentID == this.StudentID).SingleOrDefault();
           //db.Student.Remove(student1);
           //db.SaveChanges();
               return new Returner
               {
                   Data = student,
                   message = Msgs.Student_Deleted_Successfully
               };
       }
        public Returner UpdateStudent()
       {
           var student = db.Student.Where(p => p.StudentID == this.StudentID).SingleOrDefault();
           student.S_name= this.S_name;
           student.S_email = this.S_email;
           student.S_phone = this.S_phone;
           student.S_pw = this.S_pw;
           student.Credits_aquired = this.Credits_aquired;
           db.SaveChanges();
           return new Returner
           {
               Data = student,
               message = Msgs.Student_Updated_Successfully
           };
       }
       public Returner Delete()
       {
           var student = db.Student.Where(p => p.StudentID == this.StudentID).SingleOrDefault();
           db.Student.Remove(student);
           db.SaveChanges();
           return new Returner
           {
               message = Msgs.Student_Deleted_Successfully
           };
       }
    }
}
