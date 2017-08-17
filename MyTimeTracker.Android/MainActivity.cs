using Android.App;
using Android.Widget;
using Android.OS;
using MyTimeTracker.Core.Service;

namespace MyTimeTracker.Android
{
    [Activity(Label = "My Time Tracker", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private IService _service;

        public MainActivity()
        {
            _service = new Core.Service.Service();       
        }

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);

            var associatedTask = await  _service.GetAssociatedIssues(new Core.Model.Assignee());
        }
    }
}

