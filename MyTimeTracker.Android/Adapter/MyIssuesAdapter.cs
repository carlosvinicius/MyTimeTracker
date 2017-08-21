﻿using Android.App;
using Android.Views;
using Android.Widget;
using MyTimeTracker.Core.Model;
using System;
using System.Collections.Generic;

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

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.IssueRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.txtIssueTitle).Text = item.fields.summary;
            convertView.FindViewById<TextView>(Resource.Id.txtIssueId).Text = item.key;

            var totalTime = long.Parse(item.fields.timespent.ToString());
            var time = TimeSpan.FromSeconds(totalTime);

            var txtTotalTimeSpent = convertView.FindViewById<TextView>(Resource.Id.txtTotalTimeSpent);
            txtTotalTimeSpent.Text = string.Format("Total Time Spent: {0}", time.ToString(@"dd\:hh\:mm\:ss"));

            return convertView;
        }
    }
}