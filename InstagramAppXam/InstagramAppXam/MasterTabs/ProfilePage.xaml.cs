using System;
using System.Collections.Generic;
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
	public partial class ProfilePage : ContentPage
	{
        public ProfileDetailsViewModel ViewModel
        {
            get => BindingContext as ProfileDetailsViewModel;
            set => BindingContext = value;
        }

        public ProfilePage()
		{
            ViewModel = new ProfileDetailsViewModel((Application.Current as App).CurrentUser, new PageService(), App.MasterUserStorage);
            InitializeComponent();
		}
	}
}