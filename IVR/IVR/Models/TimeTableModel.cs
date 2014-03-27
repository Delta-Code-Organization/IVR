using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVR.Models
{
    public partial class TimeTable
    {
        #region Properties
        public string CourseTime
        {
            get
            {
                TimeSpan TS = ((DateTime)StartTime).TimeOfDay;
                string D = Enum.GetName(typeof(Dayenum), Day);
                return D.ToString() + " " + TS.ToString(@"hh\:mm");
            }
        }
        #endregion
        IVRDBEntities2 db = new IVRDBEntities2();
        public Returner searchCourses(string _Name, string _Day, string _Start, string _End)
        {
            List<TimeTable> LOTT = new List<TimeTable>();
            List<TimeTable> LOC = new List<TimeTable>();
            List<TimeTable> LOCT = new List<TimeTable>();
            LOTT = db.TimeTable.OrderBy(p => p.TimeTableID).ToList();
            if (_Name != "")
            {
                LOTT = LOTT.Where(p => p.Course.CourseName == _Name).ToList();
            }
            if (_Day != "")
                LOTT = LOTT.Where(p => p.Day == (int)Enum.Parse(typeof(Dayenum), _Day)).ToList();
            if (_Start != "")
            {
                var searchTime = (Convert.ToDateTime(_Start)).ToString("hh:mm tt");
                foreach (TimeTable tt in LOTT)
                {
                    var time = ((DateTime)tt.StartTime).ToString("hh:mm tt");
                    if (time == searchTime)
                        LOC.Add(tt);
                }
                LOTT = LOC;
            }
            if (_End != "")
            {
                var searchTime = (Convert.ToDateTime(_End)).ToString("hh:mm tt");
                foreach (TimeTable tt in LOTT)
                {

                    var time = ((DateTime)tt.EndTime).ToString("hh:mm tt");
                    if (time == searchTime)
                        LOCT.Add(tt);
                }
                LOTT = LOCT;
            }
            return new Returner
            {
                Data = LOTT
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

