using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Linq;

using Xamarin.Forms;

using InstagramAppXam.Models;

namespace InstagramAppXam.ViewModels
{
    public class ProfileDetailsViewModel : BaseViewModel
    {
        private string _username;
        private string _email;
        private string _gender;
        private string _photo;

        private readonly IPageService _pageService;
        private readonly IUserProfileStorage _userProfileStorage;

        public ICommand EditProfileCommand { get; private set; }
        public ICommand SignOutCommand { get; private set; }

        public UserProfileViewModel Profile { get; set; }
        // for the form to be notified of value changes on the editing page
        public string Username { get => _username; set => SetValue(ref _username, value); }
        public string Email { get => _email; set => SetValue(ref _email, value); }
        public string Gender { get => _gender; set => SetValue(ref _gender, value); }
        public string Photo { get => _photo; set => SetValue(ref _photo, value); }

        public ProfileDetailsViewModel(UserProfileViewModel viewModel, IPageService pageService, IUserProfileStorage userProfileStorage)
        {
            _pageService = pageService;
            _userProfileStorage = userProfileStorage;

            Profile = viewModel;
            UpdateFields();

            EditProfileCommand = new Command(async () => await EditProfile());
            SignOutCommand = new Command(async () => await SignOut());

            // handles the profile changed on the profile editing page
            MessagingCenter.Subscribe<EditProfileViewModel, UserProfile>(this, Events.UserProfileEdited, (source, up) =>
            {
                Profile.Username = up.Username;
                Profile.Email = up.Email;
                Profile.Gender = up.Gender;
                Profile.Image = up.Gender;

                UpdateFields();
            });
        }

        private async Task EditProfile()
        {
            await _pageService.PushModalAsync(new EditProfilePage(Profile));
        }

        private async Task SignOut()
        {
            throw new NotImplementedException();
        }

        private void UpdateFields()
        {
            Username = Profile.Username;
            Email = Profile.Email;
            Gender = Profile.Gender;
            Photo = Profile.Image;
        }
    }
}
