using MyTimeTracker.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTimeTracker.Core.Service
{

    public interface IService
    {
        Task<IList<Issue>> GetAssociatedIssues();

        void SaveWorklog(Worklog worklog);

        void RestrictActiveSprint();

        void ForgetUserAndPassword();
    }
}
