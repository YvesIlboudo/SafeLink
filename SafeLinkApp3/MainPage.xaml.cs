using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SafeLinkApp3
{
    public partial class MainPage : TabbedPage
    {
        //Step 1 - > In order to give connection to viewmodel using binding context
        //Step 2 - Create property in viewmodel that we want to bind to the UI -> propfull (press tab twice)
        //Step 3 - Assign value to the property in view model that we need to display in UI
        //Step 4 - Bind that property name in xaml - E.g -> Text = {Binding yourpropertynamefromviewmodel}
        public MainPage(string name, int age, string location)
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel(name,age,location);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("UserName", "");
            Preferences.Set("Age", 0);
            Preferences.Set("Location", "");
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
    }
}
