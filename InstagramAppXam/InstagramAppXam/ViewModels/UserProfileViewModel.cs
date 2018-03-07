using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using InstagramAppXam.Models;

namespace InstagramAppXam.ViewModels
{
    public class UserProfileViewModel : BaseViewModel
    {
        private string _username;

        public int Id { get; }

        public string Username
        {
            get { return _username; }
            set
            {
                SetValue(ref _username, value);
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

        // public ObservableCollection<UserPost> PostList { get; set; }

        public UserProfileViewModel() { } // for clean initialization

        public UserProfileViewModel(UserProfile userProfile)
        {
            Id = userProfile.Id;
            Username = userProfile.Username;
            Password = userProfile.Password;
            Gender = userProfile.Gender;
            Email = userProfile.Email;
            Image = userProfile.Image;
            //PostList = userProfile.PostList;
        }
    }
}
