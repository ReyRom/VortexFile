using System.Data.Entity;
using VortexFileClient.Data.Models;
using VortexFileClient.Extensions;

namespace VortexFileClient.Data
{
    public static class DAL
    {
        public static event EventHandler<UserDeleteEventArgs> OnUserDelete;

        public static User GetUserByLogin(string login)
        {
            User? user = null;
            user = Core.Context.Users.SingleOrDefault(x => x.Login == login);
            return user;
        }

        public static User GetUserByEmail(string email)
        {
            User? user = null;
            user = Core.Context.Users.SingleOrDefault(x => x.Email == email);
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
            user.homedir = $"/srv/ftp/vortexfile/{user.Login}";
            user.shell = "/sbin/nologin";
            user.hash = "d4c45911de055183ebc73cee140d3fb2";
            user.accessed = user.modified = DateTime.Now;
            Core.Context.Users.Add(user);
            Core.Context.SaveChanges();
            return GetUserByLogin(user.Login);
        }

        public static User ChangeUserPassword(User user, string newPassword)
        {
            user.Password = newPassword.EncryptString();
            Core.Context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Core.Context.SaveChanges();
            return GetUserByLogin(user.Login);
        }

        public static List<User> GetUsers()
        {
            return Core.Context.Users.ToList();
        }

        public async static Task<List<User>> GetUsersAsync()
        {
            return await Core.Context.Users.ToListAsync();
        }

        public static void UpdateUser(User user)
        {
            Core.Context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Core.Context.SaveChanges();
        }
        public static void DeleteUser(User user)
        {
            var login = user.Login;
            OnUserDelete.Invoke(login, new UserDeleteEventArgs(user));
            Core.Context.Remove(user);
            Core.Context.SaveChanges();
        }
    }
}

