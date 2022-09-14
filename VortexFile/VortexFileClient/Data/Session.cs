using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexFileClient.Data
{
    internal static class Session
    {
        private static User currentUser;

        public static User CurrentUser { get => currentUser; set => currentUser = value; }

        public static string Login
        {
            get => Properties.Settings.Default.Login;
            set
            {
                Properties.Settings.Default.Login = value;
                Properties.Settings.Default.Save();
            }
        }
        public static string Password
        { 
            get => Properties.Settings.Default.Password;
            set
            {
                Properties.Settings.Default.Password = value;
                Properties.Settings.Default.Save();
            }
        }

        public static User? Authorize(string login, string password)
        {
            User ?user = DAL.GetUser(login);
            if (user != null && user.Password == password)
            {
                CurrentUser = user;
            }
            return user;
        }

        public static User Registration(User user)
        {

            return DAL.AddUser(user);
        }

        public static User ResetPassword()
        {
            throw new NotImplementedException();
        }
    }
}
