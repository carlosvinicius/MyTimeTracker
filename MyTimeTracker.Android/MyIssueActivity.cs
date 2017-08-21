using Android.App;
using Android.Widget;
using Android.OS;
using MyTimeTracker.Core.Service;
using MyTimeTracker.Core.Model;
using MyTimeTracker.Android.Adapter;
using System.Timers;
using System.Collections.Generic;
using System;
using Android.Views;

namespace MyTimeTracker.Android
{
    [Activity(Label = "My Time Tracker", MainLauncher = true, Icon = "@drawable/icon")]
    public class MyIssueActivity : Activity
    {
        private IService _service;
        private Timer _timer;
        private Worklog _currentWorklog;
        private IList<Issue> _associatedIssueList;
        private IList<Worklog> _worklogList;
        private int _position;

        #region Components
        private ListView _listview;
        private TextView _currentIssueTracking;
        private ImageButton _stopTrackingImageButton;
        private TableLayout _trakingTableLayout;
        #endregion

        public MyIssueActivity()
        {
            _service = new Core.Service.Service();
            _worklogList = new List<Worklog>();
            _timer = new Timer(1000);
        }

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MyIssueView);

            _associatedIssueList = await _service.GetAssociatedIssues();

            FindData();
            EventHandlers();

            _listview.Adapter = new MyIssueAdapter(this, _associatedIssueList);
            _listview.FastScrollEnabled = true;
        }

        private void FindData()
        {
            _listview = FindViewById<ListView>(Resource.Id.MyIssuesListView);
            _currentIssueTracking = FindViewById<TextView>(Resource.Id.IssueTrakingTextView);
            _stopTrackingImageButton = FindViewById<ImageButton>(Resource.Id.StopTrackingImageButton);
            _trakingTableLayout = FindViewById<TableLayout>(Resource.Id.TrackingTableLayout);
        }

        private void EventHandlers()
        {
            _listview.ItemClick += StartTracking;
            _stopTrackingImageButton.Click += StopTracking;
        }

        private void StopTracking()
        {
            if(_currentWorklog == null)
            {
                return;
            }

            _currentWorklog.timeSpentSeconds = (int)DateTime.Now
                                                        .Subtract(_currentWorklog.started)
                                                        .TotalSeconds;
            //_worklogList.Add(_currentWorklog);
            _service.SaveWorklog(_currentWorklog);

            var totalTime = int.Parse(_associatedIssueList[_position].fields.timespent.ToString());
            _associatedIssueList[_position].fields.timespent = totalTime + _currentWorklog.timeSpentSeconds;
            _listview.Adapter = new MyIssueAdapter(this, _associatedIssueList);

            _currentWorklog = null;
            _currentIssueTracking.Text = Resources.GetString(Resource.String.SelectIssueToTrack);

            Toast.MakeText(this, "Worklog Saved", ToastLength.Short).Show();
        }

        private void StopTracking(object sender, EventArgs e)
        {
            _timer.Stop();
            StopTracking();
        }

        private void StartTracking(object sender, AdapterView.ItemClickEventArgs e)
        {
            _position = e.Position;
            var selectedIssue = _associatedIssueList[_position];            

            if (_currentWorklog != null)
            {
                if (_currentWorklog.issueId == selectedIssue.id)
                {
                    return;
                }

                if (_currentWorklog.issueId != selectedIssue.id)
                {
                    StopTracking();
                }
            }

            _currentWorklog = new Worklog();
            _currentWorklog.issueId = selectedIssue.id;
            _currentWorklog.started = DateTime.Now;

            _timer.Start();
            _timer.Elapsed += UpdateStatus;
            
            Toast.MakeText(this, "Tracking Started", ToastLength.Short).Show();
        }

        private void UpdateStatus(object sender, ElapsedEventArgs e)
        {
            this.RunOnUiThread(() =>
                                    _currentIssueTracking.Text =
                                                string.Format("{0} | Current Time: {1}",
                                                                    _associatedIssueList[_position].key,
                                                                    GetFormmatedTimeSpent()));
        }

        private string GetFormmatedTimeSpent()
        {
            return
                TimeSpan.FromSeconds(
                                    DateTime.Now
                                        .Subtract(_currentWorklog.started)
                                        .TotalSeconds)
                                    .ToString(@"dd\:hh\:mm\:ss");
        }

        protected override void OnPause()
        {
            base.OnPause();
        }
    }
}

