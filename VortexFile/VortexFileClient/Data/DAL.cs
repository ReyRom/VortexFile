using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using FastMember;
using VortexFileClient.Extensions;
using VortexFileClient.Data.Models;

namespace VortexFileClient.Data
{
    public static class DAL
    {
        public static event EventHandler OnUserDelete;

        public static User GetUserByLogin(string login)
        {
            User? user = null;
            try
            {
                user = Core.Context.Users.SingleOrDefault(x => x.Login == login);
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
            return user;
        }

        public static User GetUserByEmail(string email)
        {
            User? user = null; 
            try
            {
                user = Core.Context.Users.SingleOrDefault(x => x.Email == email);
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
            return user;
        }

        public static User? GetUser(string login)
        {
            User? user = GetUserByLogin(login);
            if (user == null)
            {
                user = GetUserByEmail(login);
            }
            return user;
        }

        public static User AddUser(User user)
        {
            try
            {
                var newUser = Core.Context.Users.Add(user);
                Core.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
            return GetUserByLogin(user.Login);
        }

        public static User ChangeUserPassword(User user, string newPassword)
        {
            try
            {
                user.Password = newPassword;
                Core.Context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Core.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
            return GetUserByLogin(user.Login);
        }

        public static List<User> GetUsers()
        {
            return Core.Context.Users.ToList();
        }

        public async static Task<List<User>> GetUsersAsync()
        {
            return await Task.Run(() =>Core.Context.Users.ToList());
        }

        public static void UpdateUser(User user)
        {
            try
            {
                Core.Context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Core.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }
        public static void DeleteUser(User user)
        {
            try
            {
                var login = user.Login;
                Core.Context.Remove(user);
                Core.Context.SaveChanges();
                OnUserDelete.Invoke(login, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
        }
    }
}

