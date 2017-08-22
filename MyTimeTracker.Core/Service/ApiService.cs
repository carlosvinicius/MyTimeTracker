using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeTracker.Core.Service
{
    public class ApiService : IApiService
    {
        private string _user;
        private string _password;
        private string _domain;

        public ApiService()
        {

        }

        public ApiService(string domain, string user, string password)
        {
            _domain = domain;
            _user = user;
            _password = password;
        }

        private byte[] convertStringtoByteArray(string userName, string userPassword)
        {
            var byteArray = Encoding.UTF8.GetBytes(userName + ":" + userPassword);
            return byteArray;
        }

        private HttpClient GetClient()
        {
            return GetClient(_user, _password);
        }

        private HttpClient GetClient(string userName, string userPassword)
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
        
        public async Task<bool> ValidateCredentials(string apiUrl)
        {
            var result = await GetClient().GetAsync(apiUrl).ConfigureAwait(false);
            return result.StatusCode == System.Net.HttpStatusCode.Accepted;
        }

        public async Task<bool> ValidateCredentials(string userName, string userPassword, string apiUrl)
        {
            var result = await GetClient(userName, userPassword).GetAsync(apiUrl).ConfigureAwait(false);
            return result.StatusCode == System.Net.HttpStatusCode.Accepted;
        }

        public async Task<T> GetList<T>(string apiUrl)
        {
            var result = await GetClient().GetAsync(apiUrl).Result.Content.ReadAsStringAsync().ConfigureAwait(false);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);
        }

        public async Task<bool> PostItem(string apiUrl, object item)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await GetClient().PostAsync(apiUrl, content).ConfigureAwait(false);

            return result.StatusCode == System.Net.HttpStatusCode.Created;
        }
    }
}
