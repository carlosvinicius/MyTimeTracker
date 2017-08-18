using MyTimeTracker.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTimeTracker.Core.Service
{

    public interface IService
    {
        // Task<IList<Issue>> GetAssociatedIssues(Assignee assignee);
        IList<Issue> GetAssociatedIssues(Assignee assignee);

        Task<IList<Issue>> GetAvailableIssues();

        void RestrictActiveSprint();

        void ForgetUserAndPassword();
    }
}
