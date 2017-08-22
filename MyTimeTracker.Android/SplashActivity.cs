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
using MyTimeTracker.Android.Provider;
using Service = MyTimeTracker.Core.Service.Service;

namespace MyTimeTracker.Android
{
    [Activity(MainLauncher = true, Theme = "@style/SplashTheme", NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (new Service(new SecuredDataProvider(this.BaseContext)).Login())
            {
                StartActivity(typeof(MyIssuesActivity)); 
            }
            else
            {
                StartActivity(typeof(ConfigurationActivity));
            }
        }
    }
}