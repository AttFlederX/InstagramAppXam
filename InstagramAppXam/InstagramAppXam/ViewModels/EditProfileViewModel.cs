using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Linq;

using Xamarin.Forms;

using InstagramAppXam.Models;
using InstagramAppXam.ViewModels;
using InstagramAppXam.Services;

namespace InstagramAppXam.ViewModels
{
    public class EditProfileViewModel : BaseViewModel
    {
        private string _username;
        private string _email;
        private string _gender;
        private string _photo;

        private readonly IPageService _pageService;
        private readonly IUserProfileStorage _userProfileStorage;

        public ICommand SaveProfileCommand { get; private set; }

        public UserProfileViewModel Profile { get; set; }
        public string Username { get => _username; set => SetValue(ref _username, value); }
        public string Email { get => _email; set => SetValue(ref _email, value); }
        public string Gender { get => _gender; set => SetValue(ref _gender, value); }
        public string Photo { get => _photo; set => SetValue(ref _photo, value); }

        public EditProfileViewModel(UserProfileViewModel viewModel, IPageService pageService, IUserProfileStorage userProfileStorage)
        {
            _pageService = pageService;
            _userProfileStorage = userProfileStorage;

            Profile = viewModel;
            Username = Profile.Username;
            Email = Profile.Email;
            Gender = Profile.Gender;
            Photo = Profile.Image;

            SaveProfileCommand = new Command(async () => await SaveProfile());
        }

        private async Task SaveProfile()
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                await _pageService.DisplayAlert("Error", "Please fill in your username", "OK");
                return;
            }

            if (Username != Profile.Username)
            {
                var userProfile = await _userProfileStorage.LoadUserProfile(Username); // query user by username (should be unique)

                if (userProfile != null) // user already exists
                {
                    await _pageService.DisplayAlert("Error", "This username is already taken. Please pick another one", "OK");
                    return;
                }
            }

            if (!ValidationService.IsEmailValid(Email))
            {
                await _pageService.DisplayAlert("Error", "Please enter a valid email address", "OK");
            }
            else if (string.IsNullOrWhiteSpace(Gender))
            {
                await _pageService.DisplayAlert("Error", "Please specify your gender", "OK");
            }
            else
            {
                Profile.Username = Username;
                Profile.Email = Email;
                Profile.Image = Photo;
                Profile.Gender = Gender;

                var updUserProfile = new UserProfile()
                {
                    Id = Profile.Id,
                    Username = Profile.Username,
                    Email = Profile.Email,
                    Password = Profile.Password,
                    Image = Profile.Image,
                    Gender = Profile.Gender,
                    // PostList = Profile.PostList
                };

                await _userProfileStorage.UpdateAsync(updUserProfile);
                MessagingCenter.Send(this, Events.UserProfileEdited, updUserProfile); // updates the profile info page

                await _pageService.DisplayAlert("Success", "Your account has been updated", "OK");
                await _pageService.PopModalAsync();
            }
        }
    }
}
