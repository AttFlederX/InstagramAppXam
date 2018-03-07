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
	public partial class RegistrationPage : ContentPage
	{
        public RegistrationViewModel ViewModel
        {
            get => BindingContext as RegistrationViewModel;
            set => BindingContext = value;
        }

        public RegistrationPage()
		{
            ViewModel = new RegistrationViewModel(new PageService(), App.MasterUserStorage);
            InitializeComponent();
		}
	}
}