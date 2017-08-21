using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyTimeTracker.Core.Model;

namespace MyTimeTracker.Android.Adapter
{
    public class MyIssueAdapter : BaseAdapter<Issue>
    {
        IList<Issue> items;
        Activity context;

        public MyIssueAdapter(Activity context, IList<Issue> items) : base()
        {
            this.items = items;
            this.context = context;
        }

        public override Issue this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            if(convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.IssueRowView, null);
            }

            convertView.FindViewById<TextView>(Android.Resource.Id.txtIssueTitle).Text = item.key;
            convertView.FindViewById<TextView>(Android.Resource.Id.txtIssueId).Text = item.id;

            long totalTime = long.Parse(item.fields.timespent.ToString());
            TimeSpan time = TimeSpan.FromSeconds(totalTime);

            var txtTotalTimeSpent = convertView.FindViewById<TextView>(Android.Resource.Id.txtTotalTimeSpent);
            txtTotalTimeSpent.Text = string.Format("Total: {0}", time.ToString(@"hh\:mm\:ss"));

            var chrono = convertView.FindViewById<Chronometer>(Android.Resource.Id.chronoCurrentTime);

            convertView.FindViewById<ImageButton>(Android.Resource.Id.btnStartPause).Click += (sender, args) =>
            {
                chrono.Base = 0 ;
                chrono.Start();
            };

            convertView.FindViewById<ImageButton>(Android.Resource.Id.btnStop).Click += (sender, args) =>
            {
                chrono.Stop();
                totalTime = long.Parse(item.fields.timespent.ToString()) + (((SystemClock.ElapsedRealtime() + chrono.Base) / 1000) % 60);

                time = TimeSpan.FromSeconds(totalTime);
                txtTotalTimeSpent.Text = string.Format("Total: {0}", time.ToString(@"hh\:mm\:ss"));
            };

            chrono.ChronometerTick += (sender, args) =>
            {

            };

            return convertView;
        }
    }
}