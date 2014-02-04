using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVR.Models
{
   partial class Student
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
           Student s = new Student();
           s.S_name = this.S_name;
           s.S_email = this.S_email;
           s.S_phone = this.S_phone;
           s.S_pw = this.S_pw;
           db.Student.Add(this);
           db.SaveChanges();
           var lastStudent = db.Student.OrderByDescending(p => p.StudentID).FirstOrDefault();
           return new Returner
           {
               message = Msgs.Student_Name_created_Successfuly,
               Data = lastStudent
           };
       }
    }
}
