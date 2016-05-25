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

        public static Sсhedule GetSchedule(string id)
        {
           Sсhedule sсhedule = null;
            ServicePointManager.Expect100Continue = false;
            try
            {
                using (var client = new WebClient())
                {
                    var values = new NameValueCollection();
                    values.Add("group id",id);
                    var response = client.UploadValues("http://zschedule.gorlachov.com/libs/get_schedule.php?group_id="+id, values);
                    var responseString = Encoding.UTF8.GetString(response);

                    sсhedule = JsonConvert.DeserializeObject<Sсhedule>(responseString);
                }
            }
            catch
            {
                
            }
            return sсhedule;
        }

        public static List<Faculty> GetFaculty()
        {
            List<Faculty> faculty=new List<Faculty>();
            ServicePointManager.Expect100Continue = false;
            try
            {
                using (var client = new WebClient())
                {
                    var values = new NameValueCollection();
                    var response = client.UploadValues("http://zschedule.gorlachov.com/libs/get_faculties.php",values);
                    var responseString = Encoding.UTF8.GetString(response);

                    faculty = JsonConvert.DeserializeObject<List<Faculty>>(responseString);
                }
            }
            catch
            {

            }
            return faculty;
        }

        public static List<Specialti> GetSpecialties()
        {
            List<Specialti> specialties = new List<Specialti>();
            ServicePointManager.Expect100Continue = false;
            try
            {
                using (var client = new WebClient())
                {
                    var values = new NameValueCollection();
                    var response = client.UploadValues("http://zschedule.gorlachov.com/libs/get_specialties.php", values);
                    var responseString = Encoding.UTF8.GetString(response);

                    specialties = JsonConvert.DeserializeObject<List<Specialti>>(responseString);
                }
            }
            catch
            {

            }
            return specialties;
        }

        public static List<Group> GetGroups()
        {
            List<Group> groups = new List<Group>();
            ServicePointManager.Expect100Continue = false;
            try
            {
                using (var client = new WebClient())
                {
                    var values = new NameValueCollection();
                    var response = client.UploadValues("http://zschedule.gorlachov.com/libs/get_groups.php", values);
                    var responseString = Encoding.UTF8.GetString(response);

                    groups = JsonConvert.DeserializeObject<List<Group>>(responseString);
                }
            }
            catch
            {

            }
            return groups;
        }
    }
}
