using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using InstagramAppXam.ViewModels;

namespace InstagramAppXam
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignInPage : ContentPage
	{
        public SignInViewModel ViewModel
        {
            get => BindingContext as SignInViewModel;
            set => BindingContext = value;
        }

		public SignInPage()
		{
            ViewModel = new SignInViewModel((Application.Current as App).CurrentUser, (Application.Current as App).LoggedInUserId, new PageService(), 
                App.MasterUserStorage, App.MasterPostStorage);

            InitializeComponent();
            logoImage.Source = ImageSource.FromResource(ViewModel.Logo);
		}
	}
}