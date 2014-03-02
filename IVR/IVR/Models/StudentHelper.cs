using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVR.Models
{
    public class StudentHelper
    {
        IVRDBEntities2 db = new IVRDBEntities2();
        public Returner Add(Student S)
        {

            var student = db.Student.Any(p => p.S_name ==S.S_name);
            if (student == true)
            {
                return new Returner
                {
                    message = Msgs.إسم_الطالب_موجود_بالفعل
                };
            }
            db.Student.Add(S);

            db.SaveChanges();
            return new Returner
            {
                message = Msgs.تم_إضافة_الطالب_بنجاح
            };
        }
        public Returner Time(int _ID)
        {
            List<TimeTable> LOTT = new List<TimeTable>();
            Student student = db.Student.Where(p => p.StudentID == _ID).SingleOrDefault();
            if (student.Course.Any())
            {
                var courses = student.Course;
                foreach (Course c in courses)
                {
                    var time = c.TimeTable.ToList();
                    LOTT.AddRange(time);
                }
                return new Returner
                {
                    Data = LOTT
                };
            }
            return new Returner
            {
                message = Msgs.لا_يوجد_نتائج
            };
        }
    }
}
