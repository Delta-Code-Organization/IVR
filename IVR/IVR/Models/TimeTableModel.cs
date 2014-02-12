using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVR.Models
{
  public partial class TimeTable
    {
      IVRDBEntities2 db = new IVRDBEntities2();
      public List<Course> SearchCoursesByDay()
      {
           var searchcourse = db.TimeTable.Where(p => p.StartTime == this.StartTime).ToList();
          List<Course> final = new List<Course>();
          foreach (var s in searchcourse)
          {
              var res = s.Course;
              final.Add(res);
          }
          return final;
      }
      public List<Course> SearchCoursesByStartTime()
      {
          var searchcourse = db.TimeTable.Where(p => p.StartTime == this.StartTime).ToList();
          List<Course> final = new List<Course>();
          foreach (var s in searchcourse)
          {
              var res = s.Course;
              final.Add(res);
          }

          return final;
      }
      public List<Course> SearchCoursesByEndTime()
      {
          var searchcourse = db.TimeTable.Where(p => p.EndTime == this.EndTime).ToList();
          List<Course> final = new List<Course>();
          foreach (var s in searchcourse)
          {
              var res = s.Course;
              final.Add(res);
          }

          return final;
      }
    }
}
