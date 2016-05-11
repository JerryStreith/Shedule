using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule
{
    public class ScheduleItem
    {
        public string number = "";
        public string subject = "";
        public string type = "";
        public string pozition = "";
        
        public ScheduleItem(string _number, string _subject, string _type, string _pozition)
        {
            number = _number;
            subject = _subject;
            type = _type;
            pozition = _pozition;
        }

        public string ScheduleItemToString()
        {
            string result = "";
            result += number + ")"+ " " + subject + ";" + " " + type +"; " + pozition + ";";
            return result;
        }
    }
}
