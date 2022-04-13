using System;
using System.Collections.Generic;
using System.Text;

namespace SafeLinkApp3
{
    public class MainPageViewModel
    {
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private string location;
        public string Location
        {
            get { return  location; }
            set {  location = value; }
        }


        public MainPageViewModel(string name, int age, string location)
        {
            UserName = $"Welcome, {name}!";
            Age = age;
            Location = location;

        }
    }
}
