using MyTimeTracker.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTimeTracker.Core.Service
{
    public class Service : IService
    {
        public Service()
        {

        }

        public async Task<IList<Issue>> GetAssociatedIssues()
        {
            return await ServiceWrapper.GetList<Issue>("carlos@gbdentretenimento.com.br", "C@rlitos83",

                "https://gbdentretenimento.atlassian.net/rest/api/2/search?jql=assignee=currentUser()&sprint%20in%20openSprints%20()+order+by+duedate&fields=timespent,summary");

            var items = new List<Issue>()
            {
                new Issue() { id = "ECOM-01", key = "Teste de Issue 1", fields =  new Fields() { timespent = 10}},
                new Issue() { id = "ECOM-02", key = "Teste de Issue 2", fields =  new Fields() { timespent = 20}},
                new Issue() { id = "ECOM-03", key = "Teste de Issue 3", fields =  new Fields() { timespent = 30}},
            };

            return items;
        }

        public async void SaveWorklog(Worklog worklog)
        {
            var apiUrl = string.Format(
                "https://gbdentretenimento.atlassian.net/rest/api/2/issue/{0}/worklog",
                "ICGERAL-4");// worklog.issueId);

            ServiceWrapper.SaveWorklog("carlos@gbdentretenimento.com.br", "C@rlitos83", apiUrl, worklog);
        }

        public void RestrictActiveSprint()
        {

        }

        public void ForgetUserAndPassword()
        {

        }
    }
}
