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
	public partial class CameraPage : ContentPage
	{
        public NewPostPageModel ViewModel
        {
            get => BindingContext as NewPostPageModel;
            set => BindingContext = value;
        }

        public CameraPage()
		{
            ViewModel = new NewPostPageModel((Application.Current as App).CurrentUser, new PageService(), App.MasterUserStorage, App.MasterPostStorage);
			InitializeComponent();
		}
	}
}