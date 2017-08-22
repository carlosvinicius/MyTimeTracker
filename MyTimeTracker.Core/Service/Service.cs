using MyTimeTracker.Core.Model;
using MyTimeTracker.Core.Provider;
using System.Collections.Generic;

namespace MyTimeTracker.Core.Service
{
    public class Service
    {
        private const string _baseUrl = "https://#DOMAIN#.atlassian.net/rest/api/2/";
        private const string _issueQry = "search?jql=assignee=currentUser()&sprint%20in%20openSprints%20()+order+by+duedate&fields=timespent,summary";
        private const string _worklogQry = "issue/{0}/worklog";
        private string _domain;

        private ISecuredDataProvider _provider;
        private IApiService _apiService;

        public Service(ISecuredDataProvider provider)
        {
            _provider = provider;
            var properties = _provider.Retrieve();

            _domain = properties.ContainsValue("Domain") ? properties["Domain"] : string.Empty;
            var userName = properties.ContainsValue("User") ? properties["User"] : string.Empty;
            var password = properties.ContainsValue("Password") ? properties["Password"] : string.Empty;

            _apiService = new ApiService(_domain, userName, password);
        }

        public bool Login()
        {
            var apiUrl = _baseUrl.Replace("#DOMAIN#", string.IsNullOrEmpty(_domain) ? "www" : _domain);
            return _apiService.ValidateCredentials(apiUrl).Result;
        }

        public bool ValidateCredentials(string domain, string userName, string password)
        {
            var apiUrl = _baseUrl.Replace("#DOMAIN#", domain);
            return _apiService.ValidateCredentials(userName, password, apiUrl).Result;
        }

        public IList<Issue> GetAssociatedIssues()
        {
            var apiUrl = _baseUrl.Replace("#DOMAIN#", _domain) + _issueQry;
            return _apiService.GetList<Example>(apiUrl).Result.issues;
        }

        public bool SaveWorklog(Worklog worklog)
        {
            var apiUrl = string.Format(_baseUrl.Replace("#DOMAIN#", _domain) + _worklogQry, worklog.IssueId);

            var item = new
            {
                comment = "My TimeTracker Input",
                started = worklog.Started.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzz00"),
                timeSpentSeconds = worklog.TimeSpentInSeconds < 60 ? 60 : worklog.TimeSpentInSeconds
            };

            return _apiService.PostItem(apiUrl, item).Result;
        }
    }
}
