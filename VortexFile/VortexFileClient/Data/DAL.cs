using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Logging;
using Org.BouncyCastle.Crypto.Operators;
using VortexFileClient.Data.Models;
using VortexFileClient.Extensions;

namespace VortexFileClient.Data
{
    public static class DAL
    {
        public static event EventHandler<UserEventArgs> OnUserDelete;

        public static event EventHandler<UserEventArgs> OnUserCreate;

        public async static Task<User?> GetUserByLoginAsync(string login)
        {
            var users = await Core.Context.Users.ToListAsync();
            return users.SingleOrDefault(x => x.Login == login);
        }

        public async static Task<User?> GetUserByEmailAsync(string email)
        {
            var users = await Core.Context.Users.ToListAsync();
            return users.SingleOrDefault(x => x.Email == email);
        }

        public async static Task<User?> GetUserAsync(string login)
        {
            User? user = await GetUserByLoginAsync(login);
            if (user == null)
            {
                user = await GetUserByEmailAsync(login);
            }
            return user;
        }

        public static User AddUser(User user)
        {
            //user.homedir = $"/srv/ftp/vortexfile/{user.Login}";
            //user.hash = "d4c45911de055183ebc73cee140d3fb2";
            Core.Context.Users.Add(user);
            Core.Context.SaveChanges();
            OnUserCreate?.Invoke(user.Login, new UserEventArgs(user));
            return GetUserByLoginAsync(user.Login).Result;
        }

        public static User ChangeUserPassword(User user, string newPassword)
        {
            user.Password = newPassword.EncryptString();
            Core.Context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Core.Context.SaveChanges();
            return GetUserByLoginAsync(user.Login).Result;
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
            OnUserDelete.Invoke(login, new UserEventArgs(user));
            Core.Context.Remove(user);
            Core.Context.SaveChanges();
        }
    }
}

