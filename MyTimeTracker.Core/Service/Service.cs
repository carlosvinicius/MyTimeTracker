using MyTimeTracker.Core.Model;
using System.Collections.Generic;

namespace MyTimeTracker.Core.Service
{
    public class Service : IService
    {
        public Service()
        {

        }

        public IList<Issue> GetAssociatedIssues(Assignee assignee)
        {
            return new List<Issue>();
        }

        public IList<Issue> GetAvailableIssues()
        {
            return new List<Issue>();
        }

        public void SaveWorkLog(Issue issue, int seconds)
        {
            
        }

        public void RestrictActiveSprint()
        {
            
        }

        public void ForgetUserAndPassword()
        {

        }
    }
}
