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
       public Student SearchStudentsByName()
       {
           var searchStudent = db.Student.Where(p => p.S_name == this.S_name).SingleOrDefault();
           return searchStudent;
       }
       public Student SearchStudentsByPhone()
       {
           var searchStudent = db.Student.Where(p => p.S_phone == this.S_phone).SingleOrDefault();
           return searchStudent;
       }
       public List<Student> GetAllStudents()
       {
           List<Student> all = db.Student.OrderBy(p => p.StudentID).ToList();
           return all;
       }
    }
}
