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

        //public Task<IList<Issue>> GetAssociatedIssues(Assignee assignee)
        public IList<Issue> GetAssociatedIssues(Assignee assignee)
        {
            // return await ServiceWrapper.GetList<Issue>("carlos@gbdentretenimento.com.br", "C@rlitos83", "https://gbdentretenimento.atlassian.net/rest/api/2/search?jql=assignee=raphael+order+by+duedate");

            var items = new List<Issue>()
            {
                new Issue() { id = "ECOM-01", key = "Teste de Issue 1", fields =  new Fields() { timespent = 10}},
                new Issue() { id = "ECOM-02", key = "Teste de Issue 2", fields =  new Fields() { timespent = 20}},
                new Issue() { id = "ECOM-03", key = "Teste de Issue 3", fields =  new Fields() { timespent = 30}},
            };

            return items;
        }

        public async Task<IList<Issue>> GetAvailableIssues()
        {
            return await ServiceWrapper.GetList<Issue>("x", "x", "x");
        }

        public async void SaveWorkLog(Issue issue, int seconds)
        {
            await ServiceWrapper.SaveWorklog("x", "x", "x");
        }

        public void RestrictActiveSprint()
        {

        }

        public void ForgetUserAndPassword()
        {

        }
    }
}
