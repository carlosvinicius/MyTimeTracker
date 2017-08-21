using MyTimeTracker.Core.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeTracker.Core
{
    public class ServiceWrapper
    {
        public static async Task<IList<Issue>> GetList<T>(string userName, string userPassword, string apiUrl)
        {
            var result = await GetClient(userName, userPassword).GetAsync(apiUrl).Result.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Example>(result).issues;
        }

        private static HttpClient GetClient(string userName, string userPassword)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders
                        .Authorization = new AuthenticationHeaderValue(
                                                            "Basic",
                                                            Convert.ToBase64String(
                                                                        convertStringtoByteArray(
                                                                                    userName,
                                                                                    userPassword)));

            return httpClient;
        }

        internal static void SaveWorklog(string userName, string userPassword, string apiUrl, Worklog worklog)
        {/*
            {
                "comment": "I did some work here.",
                "visibility": {
                                "type": "group",
                    "value": "jira-developers"
                },
                "started": "2017-08-17T10:52:10.475+0000",
                "timeSpentSeconds": 12000
            }*/
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(
                    new
                    {
                        comment = "I did some work here.",
                        started = "2017-08-17T10:52:10.475+0000",
                        timeSpentSeconds = 12000
                    }; //,  "remainingEstimateSeconds": 59400


                        //worklog.started.ToString("yyyy -MM-dd'T'HH:mm:ss.fffzzz"),
                        //timeSpent = "20m"//,                        timeSpentSeconds = 1200
        });//worklog.timeSpentSeconds);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = GetClient(userName, userPassword).PostAsync(apiUrl, content).Result;
        }

        public static byte[] convertStringtoByteArray(string userName, string userPassword)
        {
            var byteArray = Encoding.UTF8.GetBytes(userName + ":" + userPassword);
            return byteArray;
        }
    }
}
