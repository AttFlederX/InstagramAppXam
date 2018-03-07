using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Linq;

using Xamarin.Forms;

using InstagramAppXam.Models;
using InstagramAppXam.Services;

namespace InstagramAppXam.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        private string _username;
        private string _email;
        private string _password;
        private string _repeatPassword;
        private string _gender;

        private readonly IPageService _pageService;
        private readonly IUserProfileStorage _userProfileStorage;


        public ICommand RegisterCommand { get; private set; }

        public string Username { get => _username; set => SetValue(ref _username, value); }
        public string Email { get => _email; set => SetValue(ref _email, value); }
        public string Password { get => _password; set => SetValue(ref _password, value); }
        public string RepeatPassword { get => _repeatPassword; set => SetValue(ref _repeatPassword, value); }
        public string Gender { get => _gender; set => SetValue(ref _gender, value); }


        public RegistrationViewModel(IPageService pageService, IUserProfileStorage userProfileStorage)
        {
            _pageService = pageService;
            _userProfileStorage = userProfileStorage;

            RegisterCommand = new Command(async () => await Register());
        }

        /// <summary>
        /// New user registration method
        /// </summary>
        /// <returns></returns>
        private async Task Register()
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                await _pageService.DisplayAlert("Error", "Please enter your username", "OK");
                return;
            }
            var userProfile = await _userProfileStorage.LoadUserProfile(Username.ToLowerInvariant()); // query user by username (should be unique)

            if (userProfile != null) // user already exists
            {
                await _pageService.DisplayAlert("Error", "This username is already taken. Please pick another one", "OK");
                Password = string.Empty;
                return;
            }

            if (!ValidationService.IsEmailValid(Email))
            {
                await _pageService.DisplayAlert("Error", "Please enter a valid email address", "OK");
            }
            else if (!ValidationService.IsPasswordValid(Password))
            {
                await _pageService.DisplayAlert("Error", $"Please enter a valid password ({ValidationService.PasswordCriteria})", "OK");
                Password = string.Empty;
                RepeatPassword = string.Empty;
            }
            else if (Password != RepeatPassword)
            {
                await _pageService.DisplayAlert("Error", "The passwords don't match", "OK");
                Password = string.Empty;
                RepeatPassword = string.Empty;
            }
            else if (string.IsNullOrWhiteSpace(Gender))
            {
                await _pageService.DisplayAlert("Error", "Please specify your gender", "OK");
            }
            else
            {
                var newUserProfile = new UserProfile()
                {
                    Username = _username.ToLowerInvariant(),
                    Email = _email,
                    Password = _password,
                    Image = "http://placehold.it/100x100",
                    Gender = _gender,
                   // PostList = new System.Collections.ObjectModel.ObservableCollection<UserPost>()
                };

                await _userProfileStorage.InsertAsync(newUserProfile);
                await _pageService.DisplayAlert("Success", "Your account has been registered", "OK");
                await _pageService.PopAsync();
            }
        }
    }
}
