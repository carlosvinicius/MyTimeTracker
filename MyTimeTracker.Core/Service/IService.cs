using MyTimeTracker.Core.Model;
using System.Collections.Generic;

namespace MyTimeTracker.Core.Service
{
    public interface IService
    {
        IList<Issue> GetAssociatedIssues(Assignee assignee);

        IList<Issue> GetAvailableIssues();

        void RestrictActiveSprint();

        void ForgetUserAndPassword();
    }
}
