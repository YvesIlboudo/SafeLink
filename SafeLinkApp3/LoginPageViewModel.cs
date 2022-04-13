using SafeLinkApp3.Service;
using SafeLinkApp3.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SafeLinkApp3
{
    public class LoginPageViewModel : ParentViewModel
    {
        private string userName;

        public string UserNameProperty
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        private string userPasswordProperty;
        public string UserPasswordProperty
        {
            get { return userPasswordProperty; }
            set { userPasswordProperty = value; }
        }

        private Command loginCommand;
        public Command LoginCommand
        {
            get { return loginCommand; }
            set { loginCommand = value; }
        }

        public Command RegisterCommand { get; set; }
        public LoginPageViewModel()
        {
            LoginCommand = new Command(async () => await LoginFunction());
            RegisterCommand = new Command(async () => await RegsiterCommand());
        }

        private async Task RegsiterCommand()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        private async Task LoginFunction()
        {
            var userService = new UserService();
            var result = await userService.LoginUser(UserNameProperty, UserPasswordProperty);
            if (result != null)
            {
                Preferences.Set("UserName", UserNameProperty);
                Preferences.Set("Age", result.Object.Age);
                Preferences.Set("Location", result.Object.Location);
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage(result.Object.UserName,
                    result.Object.Age,result.Object.Location));
            }
            else
            {
               await Application.Current.MainPage.DisplayAlert("Error", "User name or password is incorrect", "OK");

            }

        }


    }
}
