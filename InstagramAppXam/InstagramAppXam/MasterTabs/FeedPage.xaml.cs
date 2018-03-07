using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using InstagramAppXam.Models;
using InstagramAppXam.ViewModels;

namespace InstagramAppXam
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FeedPage : ContentPage
	{
        public FeedViewModel ViewModel
        {
            get => BindingContext as FeedViewModel;
            set => BindingContext = value;
        }

        public FeedPage()
		{
            ViewModel = new FeedViewModel((Application.Current as App).CurrentUser, (Application.Current as App).CurrentUserPosts,
                new PageService(), App.MasterUserStorage, App.MasterPostStorage);
            InitializeComponent();
		}

        private void MasterListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                masterListView.SelectedItem = null;
            }
        }
    }
}