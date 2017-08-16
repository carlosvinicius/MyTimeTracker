using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeTracker.Core
{
    public class HttpTestClass
    {
        public static async Task basicAuthTask(string userName, string userPassword, string apiUrl)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(convertStringtoByteArray(userName, userPassword)));

                using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, apiUrl))
                {
                    httpRequestMessage.Headers.Add("ApiKey", "KeyValue");
                    using (var httpResponse = await httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false))
                    {
                        string readHttpResponse = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    }
                }
            }
        }    

        public static byte[] convertStringtoByteArray(string userName, string userPassword)
        {
            var byteArray = Encoding.UTF8.GetBytes(userName + ":" + userPassword);
            return byteArray;
        }
    }
}
