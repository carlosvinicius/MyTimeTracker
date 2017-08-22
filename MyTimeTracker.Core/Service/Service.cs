using MyTimeTracker.Core.Model;
using MyTimeTracker.Core.Provider;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTimeTracker.Core.Service
{
    public class Service
    {
        private const string _baseUrl = "https://#DOMAIN#.atlassian.net/rest/api/2/";
        private const string _issueQry = "search?jql=assignee=currentUser()&sprint%20in%20openSprints%20()+order+by+duedate&fields=timespent,summary";
        private const string _worklogQry = "issue/{0}/worklog";
        
        public static bool Login()
        {
            var properties = SecuredDataProvider.Retrieve();
            var domain = properties.ContainsValue("Domain") ? properties["Domain"] : string.Empty;
            var userName = properties.ContainsValue("User") ? properties["User"] : string.Empty;
            var password = properties.ContainsValue("Password") ? properties["Password"] : string.Empty;

            return ValidateCredentials(domain, userName, password);
        }

        public static bool ValidateCredentials(string domain, string userName, string password)
        {
            var apiUrl = _baseUrl.Replace("#DOMAIN#", domain);
            return ApiService.ValidateCredentials(userName, password, apiUrl).Result;
        }

        public static IList<Issue> GetAssociatedIssues()
        {
            var apiUrl = _baseUrl.Replace("#DOMAIN#", GetDomain()) + _issueQry;
            return ApiService.GetList<Example>(apiUrl).Result.issues;
        }

        public static bool SaveWorklog(Worklog worklog)
        {
            var apiUrl = string.Format(_baseUrl.Replace("#DOMAIN#", GetDomain()) + _worklogQry, worklog.IssueId);

            var item = new
            {
                comment = "My TimeTracker Input",
                started = worklog.Started.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzz00"),
                timeSpentSeconds = worklog.TimeSpentInSeconds < 60 ? 60 : worklog.TimeSpentInSeconds
            };

            return ApiService.PostItem(apiUrl, item).Result;
        }

        private static string GetDomain()
        {
            var properties = SecuredDataProvider.Retrieve();
            return properties.ContainsValue("Domain") ? properties["Domain"] : string.Empty;
        }
    }
}
