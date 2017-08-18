using Android.App;
using Android.Widget;
using Android.OS;
using MyTimeTracker.Core.Service;
using MyTimeTracker.Core.Model;
using MyTimeTracker.Android.Adapter;
using System;

namespace MyTimeTracker.Android
{
    [Activity(Label = "My Time Tracker", MainLauncher = true, Icon = "@drawable/icon")]
    public class MyIssueActivity : Activity
    {
        private IService _service;
        
        public MyIssueActivity()
        {
            _service = new Core.Service.Service();
        }

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MyIssueView);

            // var associatedTask = await _service.GetAssociatedIssues(new Core.Model.Assignee());
            var associatedTask = _service.GetAssociatedIssues(new Core.Model.Assignee());

            var listView = FindViewById<ListView>(Resource.Id.MyIssuesListView);
            listView.Adapter = new MyIssueAdapter(this, associatedTask);
            listView.FastScrollEnabled = true;

            EventHandlers();
        }

        private void EventHandlers()
        {
            
        }
    }
}

