using System.Net.Http;
using System.Threading.Tasks;

namespace MyTimeTracker.Core.Service
{
    public interface IApiService
    {
        Task<bool> ValidateCredentials(string apiUrl);

        Task<bool> ValidateCredentials(string userName, string userPassword, string apiUrl);

        Task<T> GetList<T>(string apiUrl);

        Task<bool> PostItem(string apiUrl, object item);
    }
}
