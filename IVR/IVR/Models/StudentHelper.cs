﻿using System;
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
                    message = Msgs.Student_Name_Dublicated
                };
            }
            db.Student.Add(S);

            db.SaveChanges();
            return new Returner
            {
                message = Msgs.Student_Added_Successfully
            };
        }
        public Returner Time(int _ID)
        {
            List<TimeTable> LOTT = new List<TimeTable>();
            Student student = db.Student.Where(p => p.StudentID == _ID).SingleOrDefault();
            //var courses = db.Course.Where(p=>p.Student.Contains(student)).ToList();
            if (student.Course.Any())
            {
                var courses = student.Course;
                foreach (Course c in courses)
                {
                    var time = c.TimeTable.SingleOrDefault();
                    LOTT.Add(time);
                }
                return new Returner
                {
                    Data = LOTT
                };
            }
            return new Returner
            {
                message = Msgs.Not_Found
            };
        }
    }
}