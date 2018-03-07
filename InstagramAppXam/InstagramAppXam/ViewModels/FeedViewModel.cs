using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using InstagramAppXam.Models;

namespace InstagramAppXam.ViewModels
{
    public class FeedViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;
        private readonly IUserProfileStorage _userProfileStorage;
        private readonly IUserPostStorage _userPostStorage;

        public UserProfileViewModel CurrentUser { get; set; }

        // post storage
        public ObservableCollection<UserPost> PostList { get; private set; }
        public bool IsPostListEmpty { get => (PostList.Count == 0); }

        public FeedViewModel(UserProfileViewModel viewModel, IEnumerable<UserPost> userPosts, IPageService pageService, 
            IUserProfileStorage userProfileStorage, IUserPostStorage userPostStorage)
        {
            _pageService = pageService;
            _userProfileStorage = userProfileStorage;
            _userPostStorage = userPostStorage;

            CurrentUser = viewModel;
            PostList = new ObservableCollection<UserPost>(userPosts);
        }
    }
}
