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
	public partial class EditProfilePage : ContentPage
	{
        public EditProfileViewModel ViewModel
        {
            get => BindingContext as EditProfileViewModel;
            set => BindingContext = value;
        }

        public EditProfilePage(UserProfileViewModel viewModel)
		{
            ViewModel = new EditProfileViewModel(viewModel, new PageService(), App.MasterUserStorage);
            InitializeComponent();
		}
	}
}