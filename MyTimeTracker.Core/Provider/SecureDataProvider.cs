using System.Collections.Generic;
using Xamarin.Auth;
using System.Linq;

namespace MyTimeTracker.Core.Provider
{
    public class SecuredDataProvider
    {
        private const string ProviderName = "Atlassian";

        public static void Store(string userId, IDictionary<string, string> data)
        {
            Clear();
            var accountStore = AccountStore.Create();
            var account = new Account(userId, data);
            accountStore.Save(account, ProviderName);
        }

        public static void Clear()
        {
            var accountStore = AccountStore.Create();
            var accounts = accountStore.FindAccountsForService(ProviderName);
            foreach (var account in accounts)
            {
                accountStore.Delete(account, ProviderName);
            }
        }

        public static Dictionary<string, string> Retrieve()
        {
            var accountStore = AccountStore.Create();
            var accounts = accountStore.FindAccountsForService(ProviderName).FirstOrDefault();

            return (accounts != null) ? accounts.Properties : new Dictionary<string, string>();
        }
    }
}
