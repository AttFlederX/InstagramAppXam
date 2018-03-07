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
    public class SignInViewModel : BaseViewModel
    {
        private bool _isLoading;
        private string _username;
        private string _password;

        private readonly IPageService _pageService;
        private readonly IUserProfileStorage _userProfileStorage;
        private readonly IUserPostStorage _userPostStorage;

        public ICommand LoginCommand { get; private set; }
        public ICommand RegisterCommand { get; private set; }
        public ICommand SignInViaFacebookCommand { get; private set; }

        public string Logo { get => "InstagramAppXam.Images.icons8-instagram-96.png"; }
        public bool IsLoading { get => _isLoading; set => SetValue(ref _isLoading, value); }
        public string Username { get => _username; set => SetValue(ref _username, value); }
        public string Password { get => _password; set => SetValue(ref _password, value); }


        public SignInViewModel(UserProfileViewModel viewModel, int userId, IPageService pageService, IUserProfileStorage userProfileStorage, 
            IUserPostStorage userPostStorage)
        {
            _pageService = pageService;
            _userProfileStorage = userProfileStorage;
            _userPostStorage = userPostStorage;

            if (userId >= 0) // if the user has logged in before
            {
                // Username = 
            }

            LoginCommand = new Command(async () => await Login());
            RegisterCommand = new Command(async () => await Register());
            SignInViaFacebookCommand = new Command(async () => await SignInViaFacebook());
        }

        private async 

        private async Task Login()
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                await _pageService.DisplayAlert("Error", "Please enter your username", "OK");
                return;
            }

            IsLoading = true; // displays the activity indicator
            var userProfile = await _userProfileStorage.LoadUserProfile(Username); // query user by username (should be unique)

            IsLoading = false;
            if (userProfile == null)
            {
                await _pageService.DisplayAlert("Error", $"User \"{Username}\" does not exist. Try re-entering your credentials", "OK");
                Password = string.Empty;
                return;
            }

            if (userProfile.Password != Password)
            {
                await _pageService.DisplayAlert("Error", $"The password is incorrect. Try re-entering your credentials.", "OK");
                Password = string.Empty;
                return;
            }

            (Application.Current as App).CurrentUser = new UserProfileViewModel(userProfile); // save the current user profile
            (Application.Current as App).CurrentUserPosts = await _userPostStorage.LoadUserPosts(userProfile.Username);
            await _pageService.PushAsync(new MasterTabbedPage());
        }

        private async Task Register()
        {
            await _pageService.PushAsync(new RegistrationPage());
        }

        private async Task SignInViaFacebook()
        {
            throw new NotImplementedException();
        }
    }
}
