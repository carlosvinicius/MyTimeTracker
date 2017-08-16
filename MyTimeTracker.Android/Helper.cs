
using Android.App;
using Android.Content;

namespace MyTimeTracker.Android
{
    public class Helper
    {
        public void RestrictActiveSprint(bool restric)
        {
            SetConfiguration("RestrictActiveSprint", restric.ToString());
        }

        public void SaveUserAndPassword(string user, string password)
        {
            SetConfiguration("User", user);
            SetConfiguration("Password", password);
        }

        public void ForgetUserAndPassword()
        {
            SetConfiguration("User", string.Empty);
            SetConfiguration("Password", string.Empty);
        }

        public string GetConfiguration(string key)
        {
            var prefs = Application.Context.GetSharedPreferences("MTT", FileCreationMode.Private);
            return prefs.GetString(key, null);
        }

        public void SetConfiguration(string key, string value)
        {
            var prefs = Application.Context.GetSharedPreferences("MTT", FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutString(key, value);
            prefEditor.Commit();
        }
    }
}