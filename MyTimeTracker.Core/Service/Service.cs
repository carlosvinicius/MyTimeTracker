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

        public async Task<IList<Issue>> GetAssociatedIssues(Assignee assignee)
        {
            return await ServiceWrapper.GetList<Issue>("x", "x", "x");
        }

        public async Task<IList<Issue>> GetAvailableIssues()
        {
            return await ServiceWrapper.GetList<Issue>("x", "x", "x");
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
