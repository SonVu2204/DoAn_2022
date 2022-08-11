
using ModelAuto.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.ResponseModel
{
    public class AccountResponse
    {
        public string username{get; set;}
        public string email { get; set; }
        public string password { get; set; }
    }

    public class ChangePassResponse
    {
        public string username { get; set; }
        public string fromMail { get; set; }
        public string pass { get; set; }
        public string tomail { get; set; }
        public string content { get; set; }
        public string subject { get; set; }
        public List<string> listCC { get; set; }
        public List<string> listBC { get; set; }
    }
    public static class ApiCall
    {
        public static string GetApi(string ApiUrl)
        {

            var responseString = "";
            var request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            request.Method = "GET";
            request.ContentType = "application/json";

            using (var response1 = request.GetResponse())
            {
                using (var reader = new StreamReader(response1.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }
            }
            return responseString;

        }
    }
}
