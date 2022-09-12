using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexFileClient.Data
{
    internal class Session
    {
        private User currentUser;

        public User CurrentUser { get => currentUser; set => currentUser = value; }

        public string Login
        {
            get => Properties.Settings.Default.Login;
            set
            {
                Properties.Settings.Default[Login] = value;
                Properties.Settings.Default.Save();
            }
        }
        public string Password
        { 
            get => Properties.Settings.Default.Password;
            set
            {
                Properties.Settings.Default[Password] = value;
                Properties.Settings.Default.Save();
            }
        }

        public User? Authorize(string login, string password)
        {
            User ?user = DAL.GetUserByLogin(login);
            if (user == null)
            {
                user = DAL.GetUserByEmail(login);
            }
            if (user != null && user.Password == password)
            {
                CurrentUser = user;
            }
            return user;
        }

        public User Registration(User user)
        {

            return DAL.AddUser(user);
        }

        public User ResetPassword()
        {
            throw new NotImplementedException();
        }
    }
}
