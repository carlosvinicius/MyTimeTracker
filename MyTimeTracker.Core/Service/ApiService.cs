using MyTimeTracker.Core.Provider;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeTracker.Core.Service
{
    public class ApiService
    {
        private static byte[] convertStringtoByteArray(string userName, string userPassword)
        {
            var byteArray = Encoding.UTF8.GetBytes(userName + ":" + userPassword);
            return byteArray;
        }

        private static HttpClient GetClient()
        {
            var properties = SecuredDataProvider.Retrieve();

            var user = properties.ContainsValue("User") ? properties["User"] : string.Empty;
            var password = properties.ContainsValue("Password") ? properties["Password"] : string.Empty;

            return GetClient(user, password);
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

        public static async Task<bool> ValidateCredentials(string userName, string userPassword, string apiUrl)
        {
            var result = await GetClient(userName, userPassword).GetAsync(apiUrl);
            return result.StatusCode == System.Net.HttpStatusCode.Accepted;
        }

        public static async Task<T> GetList<T>(string apiUrl)
        {
            var result = await GetClient().GetAsync(apiUrl).Result.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);
        }

        public static async Task<bool> PostItem(string apiUrl, object item)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await GetClient().PostAsync(apiUrl, content);

            return result.StatusCode == System.Net.HttpStatusCode.Created;
        }
    }
}
