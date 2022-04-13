using SafeLinkApp3.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SafeLinkApp3.ViewModels
{
    public class RegisterPageViewModel : ParentViewModel
    {
        private string userNameProperty;
        public string UserNameProperty
        {
            get { return userNameProperty; }
            set { userNameProperty = value; OnPropertyChanged("UserNameProperty"); }
        }

        private string userPasswordProperty;
        public string UserPasswordProperty
        {
            get { return userPasswordProperty; }
            set { userPasswordProperty = value; OnPropertyChanged("UserPasswordProperty"); }
        }

        private int userAgeProperty;
        public int UserAgeProperty
        {
            get { return userAgeProperty; }
            set { userAgeProperty = value; OnPropertyChanged("UserAgeProperty"); }
        }

        private string userLocationProperty;
        public string UserLocationProperty
        {
            get { return userLocationProperty; }
            set { userLocationProperty = value; OnPropertyChanged("UserLocationProperty"); }
        }

        public Command RegisterCommand { get; set; }


        public RegisterPageViewModel()
        {
            RegisterCommand = new Command(async () => await RegisterUserAsync());
        }

        private async Task RegisterUserAsync()
        {
            var userService = new UserService();
            bool result = await userService.RegisterUser(UserNameProperty, UserPasswordProperty
                , UserAgeProperty, UserLocationProperty);
            if(result)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "User registered successfully.", "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "User already exists.", "OK");
            }
        }
    }
}
