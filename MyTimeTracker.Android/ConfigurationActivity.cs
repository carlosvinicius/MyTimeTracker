using System;
using Android.App;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;
using MyTimeTracker.Core.Provider;
using MyTimeTracker.Android.Provider;
using Service = MyTimeTracker.Core.Service.Service;

namespace MyTimeTracker.Android
{
    [Activity(Label = "Configuration")]
    public class ConfigurationActivity : Activity
    {
        #region Components
        private TextView _domainEditText;
        private TextView _userEditText;
        private TextView _passwordEditText;
        private Button _SaveButton;
        private Button _ConnectionTestButton;
        #endregion

        private ISecuredDataProvider _provider;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ConfigurationView);

            _provider = new SecuredDataProvider(this.BaseContext);

            InitializeComponents();
            EventHandlers();
            FindData();
        }

        private void FindData()
        {
            var properties = _provider.Retrieve();
            _domainEditText.Text = properties.ContainsValue("Domain") ? properties["Domain"] : string.Empty;
            _userEditText.Text = properties.ContainsValue("User") ? properties["User"] : string.Empty;
            _passwordEditText.Text = properties.ContainsValue("Password") ? properties["Password"] : string.Empty;
        }

        private void InitializeComponents()
        {
            _domainEditText = FindViewById<TextView>(Resource.Id.DomainEditText);
            _userEditText = FindViewById<TextView>(Resource.Id.UserEditText);
            _passwordEditText = FindViewById<TextView>(Resource.Id.PasswordEditText);
            _SaveButton = FindViewById<Button>(Resource.Id.SaveButton);
            _ConnectionTestButton = FindViewById<Button>(Resource.Id.ConnectionTestButton);
        }

        private void EventHandlers()
        {
            _SaveButton.Click += SaveButtonClick;
            _ConnectionTestButton.Click += ConnectionTestButtonClick;
        }

        private void ConnectionTestButtonClick(object sender, EventArgs e)
        {
            if (new Service(new SecuredDataProvider(this.BaseContext)).ValidateCredentials(_domainEditText.Text,
                                            _userEditText.Text,
                                            _passwordEditText.Text))
            {
                Toast.MakeText(this,
                                GetString(Resource.String.ConnectionTestSucceedMessage),
                                ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, 
                                GetString(Resource.String.ConnectionTestFailedMessage),
                                ToastLength.Short).Show();
            }
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            var properties = new Dictionary<string, string>();

            properties.Add("Domain", _domainEditText.Text);
            properties.Add("User", _userEditText.Text);
            properties.Add("Password", _passwordEditText.Text);

            _provider.Store(_userEditText.Text, properties);

            if (new Service(new SecuredDataProvider(this.BaseContext)).Login())
            {
                Toast.MakeText(this, GetString(Resource.String.InvalidConnectionDataMessage), ToastLength.Short).Show();
            }
            else
            {
                this.Finish();
            }
        }

        public override void Finish()
        {
            base.Finish();
            StartActivity(typeof(MyIssuesActivity));
        }
    }
}