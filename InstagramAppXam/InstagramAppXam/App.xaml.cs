using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using InstagramAppXam.Persistence;
using InstagramAppXam.ViewModels;
using InstagramAppXam.Models;

namespace InstagramAppXam
{
	public partial class App : Application
	{
        private const string currentUserIdKey = "CurrentUserId";

        public UserProfileViewModel CurrentUser { get; set; }
        public IEnumerable<UserPost> CurrentUserPosts { get; set; }

        // stores the current user profile as an application property
        public int LoggedInUserId
        {
            get
            {
                if (Properties.ContainsKey(currentUserIdKey)) { return Convert.ToInt32(Properties[currentUserIdKey]); }
                else { return -1; }
            }
            set
            {
                // for redundancy
                // if (value.PostList == null) { value.PostList = new System.Collections.ObjectModel.ObservableCollection<Models.UserPost>(); }
                Properties[currentUserIdKey] = value;
            }
        }

        public static SQLiteUserProfileStorage MasterUserStorage { get; private set; }
        public static SQLiteUserPostStorage MasterPostStorage { get; private set; }

		public App()
		{
			InitializeComponent();

            MasterUserStorage = new SQLiteUserProfileStorage();
            MasterPostStorage = new SQLiteUserPostStorage();
			MainPage = new NavigationPage(new SignInPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
