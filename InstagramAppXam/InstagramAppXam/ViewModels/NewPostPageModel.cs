using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;

using Xamarin.Forms;

//using Plugin.Media;
//using Plugin.Media.Abstractions;

using InstagramAppXam.Models;

namespace InstagramAppXam.ViewModels
{
    public class NewPostPageModel : BaseViewModel
    {
        private string _description;
        private string _postImage;

        private readonly IPageService _pageService;
        private readonly IUserProfileStorage _userProfileStorage;
        private readonly IUserPostStorage _userPostStorage;

        public UserProfileViewModel CurrentUser { get; set; }
        // for dynamic updates
        public string Description { get => _description; set => SetValue(ref _description, value); }
        public string PostImage { get => _postImage; set => SetValue(ref _postImage, value); }

        public ICommand TakeAPhotoCommand { get; private set; }
        public ICommand OpenGalleryCommand { get; private set; }
        public ICommand PostCommand { get; private set; }

        public NewPostPageModel(UserProfileViewModel viewModel, IPageService pageService, IUserProfileStorage userProfileStorage,
            IUserPostStorage userPostStorage)
        {
            _pageService = pageService;
            _userProfileStorage = userProfileStorage;
            _userPostStorage = userPostStorage;

            CurrentUser = viewModel;

            TakeAPhotoCommand = new Command(async () => await TakeAPhoto());
            OpenGalleryCommand = new Command(async () => await OpenGallery());
            PostCommand = new Command(async () => await Post());
        }


        private async Task TakeAPhoto()
        {
            //if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            //{
            //    MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            //    {
            //        SaveToAlbum = true,
            //        Directory = "UserPosts",
            //        Name = $"{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.jpg"
            //    });

            //    if (file == null) { await _pageService.DisplayAlert("Error", "Failed to take a photo", "OK"); }

            //    PostImage = file.Path;
            //}
            //else { await _pageService.DisplayAlert("Error", "Your device does not support taking pictures", "OK"); }
        }

        private async Task OpenGallery()
        {
            //if (CrossMedia.Current.IsPickPhotoSupported)
            //{
            //    MediaFile photo = await CrossMedia.Current.PickPhotoAsync();
            //    PostImage = photo.Path;
            //}
            //else { await _pageService.DisplayAlert("Error", "Failed to access the gallery", "OK"); }
        }

        private async Task Post()
        {
            var newPost = new UserPost()
            {
                Description = _description,
                Image = _postImage
            };

            Description = string.Empty;
            PostImage = string.Empty;
        }
    }
}
