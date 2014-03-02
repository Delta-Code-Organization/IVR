using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVR.Models
{
    public static class Extension
    {
        public static string ShowMessage(this Msgs Message)
        {
            return Message.ToString().Replace("_"," ");
        }
        public static string ToHours(this DateTime DT)
        {

            return ((DateTime)DT).ToString("hh:mm tt");
        }
    }
}
