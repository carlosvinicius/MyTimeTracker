using System.Collections.Generic;
using Xamarin.Auth;
using MyTimeTracker.Core.Provider;
using Android.Content;

namespace MyTimeTracker.Android.Provider
{
    public class SecuredDataProvider : ISecuredDataProvider
    {
        private const string ProviderName = "Atlassian";
        private Context _context;

        public SecuredDataProvider(Context context)
        {
            _context = context;
        }

        public void Store(string userId, IDictionary<string, string> data)
        {
            Clear();
            var account = new Account(userId, data);
            AccountStore.Create(_context).Save(account, ProviderName);
        }

        public void Clear()
        {
            var store = AccountStore.Create(_context);
            var accounts = store.FindAccountsForService(ProviderName);
            foreach (var account in accounts)
            {
                store.Delete(account, ProviderName);
            }
        }

        public Dictionary<string, string> Retrieve()
        {
            foreach (var account in AccountStore.Create(_context).FindAccountsForService(ProviderName))
            {
                return account.Properties;
            }
            return new Dictionary<string, string>();
        }
    }
}