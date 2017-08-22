
using System.Collections.Generic;

namespace MyTimeTracker.Core.Provider
{
    public interface ISecuredDataProvider
    {
        void Store(string userId, IDictionary<string, string> data);

        void Clear();

        Dictionary<string, string> Retrieve();

    }
}
