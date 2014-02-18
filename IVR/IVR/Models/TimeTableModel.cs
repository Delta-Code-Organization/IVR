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
              List<Course> final = new List<Course>();
              foreach (var s in searchcourse)
              {
                  var res = s.Course;
                  final.Add(res);
              }
              return new Returner
              {
                  Data = final,
                  message = Msgs.Is_Found
              };
          }
          return new Returner
          {
              message = Msgs.Not_Found
          };
      }
      public Returner SearchCoursesByStartTime()
      {
          var exist = db.TimeTable.Any(p => p.StartTime == this.StartTime);
          if (exist == true)
          {
              var searchcourse = db.TimeTable.Where(p => p.StartTime == this.StartTime).ToList();
              List<Course> final = new List<Course>();
              foreach (var s in searchcourse)
              {
                  var res = s.Course;
                  final.Add(res);
              }
              return new Returner
              {
                  Data = final,
                  message = Msgs.Is_Found
              };
          }
          return new Returner
          {
              message = Msgs.Not_Found
          };
      }
      public Returner SearchCoursesByEndTime()
      {
          var exist = db.TimeTable.Any(p => p.EndTime == this.EndTime);
          if (exist == true)
          {
              var searchcourse = db.TimeTable.Where(p => p.EndTime == this.EndTime).ToList();
              List<Course> final = new List<Course>();
              foreach (var s in searchcourse)
              {
                  var res = s.Course;
                  final.Add(res);
              }
              return new Returner
              {
                  Data = final,
                  message = Msgs.Is_Found
              };
          }
          return new Returner
          {
              message = Msgs.Not_Found
          };
      }
      public Returner AddTime()
      {
          db.TimeTable.Add(this);
          db.SaveChanges();
          return new Returner
          {
              message = Msgs.Course_Time_Added_Successfully
          };
      }

      public Returner SearchBothNameDay(int _ID)
      {
          var exist = db.TimeTable.Any(p => p.Section_ID == _ID&&p.Day==this.Day);
          if (exist == true)
          {
              var result = db.TimeTable.Where(p => p.Section_ID == _ID && p.Day == this.Day).SingleOrDefault();
              return new Returner
              {
                  Data = result.Course,
                  message = Msgs.Is_Found
              };
          }
              return new Returner
              {
                  message = Msgs.Not_Found
              };
          }
      public Returner SearchBothNamestart(int _ID)
      {
          var exist = db.TimeTable.Any(p => p.Section_ID == _ID && p.StartTime == this.StartTime);
          if (exist == true)
          {
              var result = db.TimeTable.Where(p => p.Section_ID == _ID && p.StartTime == this.StartTime).SingleOrDefault();
              return new Returner
              {
                  Data = result.Course,
                  message = Msgs.Is_Found
              };
          }
          return new Returner
          {
              message = Msgs.Not_Found
          };
      }
      public Returner SearchBothNameEnd(int _ID)
      {
          var exist = db.TimeTable.Any(p => p.Section_ID == _ID && p.EndTime == this.EndTime);
          if (exist == true)
          {
              var result = db.TimeTable.Where(p => p.Section_ID == _ID && p.EndTime == this.EndTime).SingleOrDefault();
              return new Returner
              {
                  Data = result.Course,
                  message = Msgs.Is_Found
              };
          }
          return new Returner
          {
              message = Msgs.Not_Found
          };
      }
      public Returner SearchNameDayStart(int _ID)
      {
          var exist = db.TimeTable.Any(p => p.Section_ID == _ID && p.Day == this.Day && p.StartTime == this.StartTime);
          if (exist == true)
          {
              var result = db.TimeTable.Where(p => p.Section_ID == _ID && p.Day == this.Day && p.StartTime == this.StartTime).SingleOrDefault();
              return new Returner
              {
                  Data = result.Course,
                  message = Msgs.Is_Found
              };
          }
          return new Returner
          {
              message = Msgs.Not_Found
          };
      }
      public Returner SearchNameStartEnd(int _ID)
      {
          var exist = db.TimeTable.Any(p => p.Section_ID == _ID && p.EndTime == this.EndTime && p.StartTime == this.StartTime);
          if (exist == true)
          {
              var result = db.TimeTable.Where(p => p.Section_ID == _ID && p.EndTime == this.EndTime && p.StartTime == this.StartTime).SingleOrDefault();
              return new Returner
              {
                  Data = result.Course,
                  message = Msgs.Is_Found
              };
          }
          return new Returner
          {
              message = Msgs.Not_Found
          };
      }
      public Returner SearchNameDayEnd(int _ID)
      {
          var exist = db.TimeTable.Any(p => p.Section_ID == _ID && p.EndTime == this.EndTime && p.Day == this.Day);
          if (exist == true)
          {
              var result = db.TimeTable.Where(p => p.Section_ID == _ID && p.EndTime == this.EndTime && p.Day == this.Day).SingleOrDefault();
              return new Returner
              {
                  Data = result.Course,
                  message = Msgs.Is_Found
              };
          }
          return new Returner
          {
              message = Msgs.Not_Found
          };
      }
      public Returner Searchall(int _ID)
      {
          var exist = db.TimeTable.Any(p => p.Section_ID == _ID && p.EndTime == this.EndTime && p.Day == this.Day && p.StartTime == this.StartTime);
          if (exist == true)
          {
              var result = db.TimeTable.Where(p => p.Section_ID == _ID && p.EndTime == this.EndTime && p.Day == this.Day && p.StartTime == this.StartTime).SingleOrDefault();
              return new Returner
              {
                  Data = result.Course,
                  message = Msgs.Is_Found
              };
          }
          return new Returner
          {
              message = Msgs.Not_Found
          };
      }
      public Returner SearchBothDayStart()
      {
          var exist = db.TimeTable.Any(p => p.Day == this.Day && p.StartTime == this.StartTime);
          if (exist == true)
          {
              var result = db.TimeTable.Where(p => p.Day == this.Day && p.StartTime == this.StartTime).ToList();
              List<Course> final = new List<Course>();
              foreach (var s in result)
              {
                  var res = s.Course;
                  final.Add(res);
              }
              return new Returner
              {
                  Data = final,
                  message = Msgs.Is_Found
              };
          }
          return new Returner
          {
              message = Msgs.Not_Found
          };
      }
      public Returner SearchBothDayEnd()
      {
          var exist = db.TimeTable.Any(p => p.Day == this.Day && p.EndTime == this.EndTime);
          if (exist == true)
          {
              var result = db.TimeTable.Where(p => p.Day == this.Day && p.EndTime == this.EndTime).ToList();
              List<Course> final = new List<Course>();
              foreach (var s in result)
              {
                  var res = s.Course;
                  final.Add(res);
              }
              return new Returner
              {
                  Data = final,
                  message = Msgs.Is_Found
              };
          }
          return new Returner
          {
              message = Msgs.Not_Found
          };
      }
      public Returner SearchBothStartEnd()
      {
          var exist = db.TimeTable.Any(p => p.StartTime == this.StartTime && p.EndTime == this.EndTime);
          if (exist == true)
          {
              var result = db.TimeTable.Where(p => p.StartTime == this.StartTime && p.EndTime == this.EndTime).ToList();
              List<Course> final = new List<Course>();
              foreach (var s in result)
              {
                  var res = s.Course;
                  final.Add(res);
              }
              return new Returner
              {
                  Data = final,
                  message = Msgs.Is_Found
              };
          }
          return new Returner
          {
              message = Msgs.Not_Found
          };
      }
      public Returner SearchDayStartEnd()
      {
          var exist = db.TimeTable.Any(p => p.StartTime == this.StartTime && p.EndTime == this.EndTime && p.Day == this.Day);
          if (exist == true)
          {
              var result = db.TimeTable.Where(p => p.StartTime == this.StartTime && p.EndTime == this.EndTime && p.Day == this.Day).ToList();
              List<Course> final = new List<Course>();
              foreach (var s in result)
              {
                  var res = s.Course;
                  final.Add(res);
              }
              return new Returner
              {
                  Data = final,
                  message = Msgs.Is_Found
              };
          }
          return new Returner
          {
              message = Msgs.Not_Found
          };
      }
      }
    }

