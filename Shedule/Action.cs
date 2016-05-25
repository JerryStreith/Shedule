using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Shedule
{
    public static class Action
    {
        //public static List<Ring> GetListRings()
        //{
        //    List<Ring> responseList;
        //    ServicePointManager.Expect100Continue = false;
        //    try
        //    {
        //        using (var client = new WebClient())
        //        {   
        //            var values = new NameValueCollection();
        //            var response = client.UploadValues("http://zschedule.gorlachov.com/libs/get_rings.php",values);
        //            var responseString = Encoding.UTF8.GetString(response);

        //            responseList = JsonConvert.DeserializeObject<Ring>(responseString);
        //        }
        //    }
        //    catch
        //    {
        //        responseList = new List<Ring>();
        //    }
        //    return responseList;
        //}

        public static Sсhedule GetSchedule(string group)
        {
            Sсhedule sсhedule = null;
            ServicePointManager.Expect100Continue = false;
            try
            {
                using (var client = new WebClient())
                {
                    var values = new NameValueCollection();
                    values["group"] = group;
                    var response = client.UploadValues("http://zschedule.gorlachov.com/libs/get_schedule.php", values);
                    var responseString = Encoding.UTF8.GetString(response);

                    sсhedule = JsonConvert.DeserializeObject<Sсhedule>(responseString);
                }
            }
            catch
            {
                
            }
            return sсhedule;
        }

        public static Sсhedule GetFaculty(string group)
        {
            Sсhedule sсhedule = null;
            ServicePointManager.Expect100Continue = false;
            try
            {
                using (var client = new WebClient())
                {
                    var values = new NameValueCollection();
                    values["group"] = group;
                    var response = client.UploadValues("http://zschedule.gorlachov.com/libs/get_schedule.php", values);
                    var responseString = Encoding.UTF8.GetString(response);

                    sсhedule = JsonConvert.DeserializeObject<Sсhedule>(responseString);
                }
            }
            catch
            {

            }
            return sсhedule;
        }
    }
}
