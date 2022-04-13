using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database.Query;
using System.Threading.Tasks;
using SafeLinkApp3.Models;
using System.Linq;

namespace SafeLinkApp3.Service
{
    public class UserService
    {
        #region Private Members
        private FirebaseClient client;
        #endregion

        #region Constructor
        public UserService()
        {
            client = new FirebaseClient("https://safelinklogindata-default-rtdb.firebaseio.com/");
        }
        #endregion

        #region Functions
        /// <summary>
        /// Function to check if user exists in cloud
        /// </summary>
        /// <param name="userName">Username to check</param>
        /// <returns>true if exists</returns>
        public async Task<bool> IsUserExist(string userName)
        {
            var user = (await client.Child("Users").OnceAsync<User>()).Where(i =>
            i.Object.UserName == userName
                ).FirstOrDefault();
            if (user == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="age"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public async Task<bool> RegisterUser(string userName, string password
            , int age, string location)
        {
            bool isUserExists = await IsUserExist(userName);
            if (!isUserExists)
            {
                await client.Child("Users").PostAsync(new User()
                {
                    UserName = userName,
                    Password = password,
                    Age = age,
                    Location = location
                });
                return true;
            }
            else 
            { 
                return false;
            }
        }

        public async Task<FirebaseObject<User>> LoginUser(string userName, string password )
        {
            FirebaseObject<User> user = (await client.Child("Users").OnceAsync<User>()).Where(u => u.Object.UserName
             == userName).Where(u => u.Object.Password == password).FirstOrDefault();

            return user;
        }
        #endregion


    }
}
