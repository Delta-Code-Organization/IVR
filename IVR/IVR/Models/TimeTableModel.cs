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
      public Returner SearchCoursesByDay()
      {
          var exist = db.TimeTable.Any(p => p.Day == this.Day);
          if (exist == true)
          {
              var searchcourse = db.TimeTable.Where(p => p.Day == this.Day).ToList();
              // List<Course> final = new List<Course>();
              //foreach (var s in searchcourse)
              //{
              //    var res = s.Course;
              //    final.Add(res);
              //}
              return new Returner
              {
                  Data = searchcourse,
                  message = Msgs.يوجد_نتائج
              };
          }
          return new Returner
          {
              message = Msgs.لا_يوجد_نتائج
          };
      }
      public Returner SearchCoursesByStartTime(string _Hour)
      {
          List<TimeTable> LOTT = new List<TimeTable>();
          var searchcourse = db.TimeTable.OrderBy(p => p.TimeTableID);
          foreach (TimeTable tt in searchcourse)
          {

              var time = ((DateTime)tt.StartTime).ToHours();
              if (time == _Hour)
              {
                  LOTT.Add(tt);
              }
          }
          if (LOTT.Count != 0)
          {
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
      public Returner SearchCoursesByEndTime(string _Hour)
      {
          List<TimeTable> LOTT = new List<TimeTable>();
          var searchcourse = db.TimeTable.OrderBy(p => p.TimeTableID);
          foreach (TimeTable tt in searchcourse)
          {

              var time = ((DateTime)tt.EndTime).ToHours();
              if (time == _Hour)
              {
                  LOTT.Add(tt);
              }
          }
          if (LOTT.Count != 0)
          {
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

      public Returner SearchBothNameDay(int _ID)
      {
          var exist = db.TimeTable.Any(p => p.Section_ID == _ID && p.Day == this.Day);
          if (exist == true)
          {
              var result = db.TimeTable.Where(p => p.Section_ID == _ID && p.Day == this.Day).ToList();
              return new Returner
              {
                  Data = result,
                  message = Msgs.يوجد_نتائج
              };
          }
          return new Returner
          {
              message = Msgs.لا_يوجد_نتائج
          };
      }
      public Returner SearchBothNamestart(int _ID, string _Hour)
      {
          var searchcourse = db.TimeTable.Where(p => p.Section_ID == _ID).ToList();
          List<TimeTable> LOTT = new List<TimeTable>();
          foreach (TimeTable tt in searchcourse)
          {
              var time = ((DateTime)tt.StartTime).ToHours();
              if (time == _Hour)
              {
                  LOTT.Add(tt);
              }
          }
          if (LOTT.Count != 0)
          {
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
      public Returner SearchBothNameEnd(int _ID, string _Hour)
      {
          var searchcourse = db.TimeTable.Where(p => p.Section_ID == _ID).ToList();
          List<TimeTable> LOTT = new List<TimeTable>();
          foreach (TimeTable tt in searchcourse)
          {
              var time = ((DateTime)tt.EndTime).ToHours();
              if (time == _Hour)
              {
                  LOTT.Add(tt);
              }
          }
          if (LOTT.Count != 0)
          {
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
      public Returner SearchNameDayStart(int _ID, string _Hour)
      {
          var searchcourse = db.TimeTable.Where(p => p.Section_ID == _ID && p.Day == this.Day).ToList();
          List<TimeTable> LOTT = new List<TimeTable>();
          foreach (TimeTable tt in searchcourse)
          {
              var time = ((DateTime)tt.StartTime).ToHours();
              if (time == _Hour)
              {
                  LOTT.Add(tt);
              }
          }
          if (LOTT.Count != 0)
          {
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
      public Returner SearchNameStartEnd(int _ID, string _Shour, string _Ehour)
      {
          var searchcourse = db.TimeTable.Where(p => p.Section_ID == _ID).ToList();
          List<TimeTable> LOTT = new List<TimeTable>();
          foreach (TimeTable tt in searchcourse)
          {
              var stime = ((DateTime)tt.StartTime).ToHours();
              var etime = ((DateTime)tt.EndTime).ToHours();
              if (stime == _Shour && etime == _Ehour)
              {
                  LOTT.Add(tt);
              }
          }
          if (LOTT.Count != 0)
          {
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
      public Returner SearchNameDayEnd(int _ID, string _Hour)
      {
          var searchcourse = db.TimeTable.Where(p => p.Section_ID == _ID && p.Day == this.Day).ToList();
          List<TimeTable> LOTT = new List<TimeTable>();
          foreach (TimeTable tt in searchcourse)
          {
              var time = ((DateTime)tt.EndTime).ToHours();
              if (time == _Hour)
              {
                  LOTT.Add(tt);
              }
          }
          if (LOTT.Count != 0)
          {
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
      public Returner Searchall(int _ID, string _Shour, string _Ehour)
      {
          var searchcourse = db.TimeTable.Where(p => p.Section_ID == _ID && p.Day == this.Day).ToList();
          List<TimeTable> LOTT = new List<TimeTable>();
          foreach (TimeTable tt in searchcourse)
          {
              var stime = ((DateTime)tt.StartTime).ToHours();
              var etime = ((DateTime)tt.EndTime).ToHours();
              if (stime == _Shour && etime == _Ehour)
              {
                  LOTT.Add(tt);
              }
          }
          if (LOTT.Count != 0)
          {
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
      public Returner SearchBothDayStart(string _Hour)
      {
          var searchcourse = db.TimeTable.Where(p => p.Day == this.Day).ToList();
          List<TimeTable> LOTT = new List<TimeTable>();
          foreach (TimeTable tt in searchcourse)
          {
              var time = ((DateTime)tt.StartTime).ToHours();
              if (time == _Hour)
              {
                  LOTT.Add(tt);
              }
          }
          if (LOTT.Count != 0)
          {
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
      public Returner SearchBothDayEnd(string _Hour)
      {
          var searchcourse = db.TimeTable.Where(p => p.Day == this.Day).ToList();
          List<TimeTable> LOTT = new List<TimeTable>();
          foreach (TimeTable tt in searchcourse)
          {
              var time = ((DateTime)tt.EndTime).ToHours();
              if (time == _Hour)
              {
                  LOTT.Add(tt);
              }
          }
          if (LOTT.Count != 0)
          {
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
      public Returner SearchBothStartEnd(string _Shour, string _Ehour)
      {
          var searchcourse = db.TimeTable.OrderBy(p => p.TimeTableID).ToList();
          List<TimeTable> LOTT = new List<TimeTable>();
          foreach (TimeTable tt in searchcourse)
          {
              var stime = ((DateTime)tt.StartTime).ToHours();
              var etime = ((DateTime)tt.EndTime).ToHours();
              if (stime == _Shour && etime == _Ehour)
              {
                  LOTT.Add(tt);
              }
          }
          if (LOTT.Count != 0)
          {
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
      public Returner SearchDayStartEnd(string _Shour, string _Ehour)
      {
          var searchcourse = db.TimeTable.Where(p => p.Day == this.Day).ToList();
          List<TimeTable> LOTT = new List<TimeTable>();
          foreach (TimeTable tt in searchcourse)
          {
              var stime = ((DateTime)tt.StartTime).ToHours();
              var etime = ((DateTime)tt.EndTime).ToHours();
              if (stime == _Shour && etime == _Ehour)
              {
                  LOTT.Add(tt);
              }
          }
          if (LOTT.Count != 0)
          {
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

      public Returner GetAllTimes()
      {
          var times = db.TimeTable.OrderBy(p => p.TimeTableID).ToList();
          return new Returner
          {
              Data = times
          };
      }

      public Returner DeleteTime()
      {
          var time = db.TimeTable.Where(p => p.TimeTableID == this.TimeTableID).SingleOrDefault();
          db.TimeTable.Remove(time);
          db.SaveChanges();
          return new Returner
          {
              message = Msgs.تم_حذف_ميعاد_المادة_بنجاح
          };
      }


      public Returner GetCourseStartTime()
      {
          var time = db.TimeTable.OrderBy(p => p.Section_ID).ToList();
          return new Returner
          {
              Data = time
          };
      }
      public Returner AddTime()
      {
          db.TimeTable.Add(this);
          db.SaveChanges();
          return new Returner
          {
              message = Msgs.تم_إضافة_ميعاد_للمادة_بنجاح
          };
      }
      }
    }

