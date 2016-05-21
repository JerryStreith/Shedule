using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shedule
{
    public static class Action
    {
        public static List<Ring> GetListRings()
        {
            List<Ring> responseList;
            ServicePointManager.Expect100Continue = false;
            try
            {
                using (var client = new WebClient())
                {   
                    var values = new NameValueCollection();
                    var response = client.UploadValues("http://zschedule.gorlachov.com/libs/get_rings.php",values);
                    var responseString = Encoding.UTF8.GetString(response);

                    responseList = (List<Ring>)Newtonsoft.Json.JsonConvert.DeserializeObject(responseString, typeof(List<Ring>));
                }
            }
            catch (Exception E)
            {
                responseList = new List<Ring>();
            }
            return responseList;
        }

        public static List<SсheduleItem> GetSchedule(string group)
        {
            List<SсheduleItem> sсhedule;
            ServicePointManager.Expect100Continue = false;
            try
            {
                using (var client = new WebClient())
                {
                    var values = new NameValueCollection();
                    values["group"] = group;
                    var response = client.UploadValues("http://zschedule.gorlachov.com/libs/get_schedule.php", values);
                    var responseString = Encoding.UTF8.GetString(response);

                    sсhedule = (List<SсheduleItem>)Newtonsoft.Json.JsonConvert.DeserializeObject(responseString, typeof(List<SсheduleItem>));
                }
            }
            catch (Exception E)
            {
                sсhedule = new List<SсheduleItem>();
            }
            return sсhedule;
        }
    }
}
