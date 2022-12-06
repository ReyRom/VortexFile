using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Logging;
using Org.BouncyCastle.Crypto.Operators;
using VortexFileClient.Data.Models;
using VortexFileClient.Extensions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace VortexFileClient.Data
{
    public static class DAL
    {
        public static event EventHandler<UserEventArgs> OnUserDelete;

        public static event EventHandler<UserEventArgs> OnUserCreate;

        public async static Task<User?> GetUserByLoginAsync(string login)
        {
            return await Core.Context.Users.SingleOrDefaultAsync(x => x.Login == login);
        }

        public async static Task<User?> GetUserByEmailAsync(string email)
        {
            return await Core.Context.Users.SingleOrDefaultAsync(x => x.Email == email);
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

