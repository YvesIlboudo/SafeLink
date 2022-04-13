using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafeLinkApp3
{
    
    public partial class App : Application
    {
        public App()
        {
            DevExpress.XamarinForms.Charts.Initializer.Init();
            InitializeComponent();
            string uname = Preferences.Get("UserName", string.Empty);
            int age = Preferences.Get("Age", 0);
            string location = Preferences.Get("Location", string.Empty);
           if(string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(location))
            {
                MainPage = new NavigationPage(new LoginPage());

            }
            else
            {
                MainPage = new NavigationPage(new MainPage(uname,age,location));
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
