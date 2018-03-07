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
    public partial class MasterTabbedPage : TabbedPage
    {
        public MasterTabbedPage()
        {
            if ((Application.Current as App).CurrentUser == null) { throw new NullReferenceException("No user has been logged in"); }

            InitializeComponent();
        }

        // disable the hardware return button so that the user cannot return to the login screen
        protected override bool OnBackButtonPressed()
        {
            Application.Current.SavePropertiesAsync();
            Environment.Exit(0);
            return true;
        }
    }
}