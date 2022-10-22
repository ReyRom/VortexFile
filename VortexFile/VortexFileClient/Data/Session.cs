using System.Text;
using System.Text.RegularExpressions;
using VortexFileClient.Data.Models;

namespace VortexFileClient.Data
{
    internal static class Session
    {
        private static User? currentUser;

        private static User Public = new User() { Login = "Public", Password = "" };
        public static User? CurrentUser { get => currentUser; set => currentUser = value; }

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

        public static User Authorize(string login, string password)
        {
            CurrentUser = null;
            User? user = DAL.GetUser(login);
            if (user != null && user.Password == password.EncryptString())
            {
                CurrentUser = user;
            }
            return CurrentUser;
        }

        public static User AuthorizeOffline()
        {
            return CurrentUser = Public;
        }

        public static User Registration(User user)
        {
            StringBuilder errors = new StringBuilder();
            if (DAL.GetUserByLogin(user.Login) != null && user.Login != Public.Login)
            {
                errors.AppendLine("Логин занят другим пользователем.");
            }
            if (DAL.GetUserByEmail(user.Email) != null)
            {
                errors.AppendLine("Почта занята другим пользователем.");
            }
            if (!Regex.IsMatch(user.Login, @"^[a-zA-Z0-9]{2,20}$") || user.Login.Contains(" "))
            {
                errors.AppendLine("Введен некорректный логин. Логин должен состоять из 2 - 30 символов, которые могут быть строчными и прописными латинскими буквами и цифрами.");
            }
            if (!Regex.IsMatch(user.Email, @"^([A-Za-z0-9]+[.-_])*[A-Za-z0-9]+@[A-Za-z0-9-]+(\.[A-Z|a-z]{2,})+$"))
            {
                errors.AppendLine("Введен некорректный почтовый адрес.");
            }
            if (!Regex.IsMatch(user.Password, @"^[a-zA-ZА-Яа-яЁё0-9]{8,20}$") || user.Password.Contains(" "))
            {
                errors.AppendLine("Введен некорректный пароль. Пароль должен состоять из 8 - 20 символов, которые могут быть цифрами, строчными и прописными буквами.");
            }
            if (user.Phone != String.Empty && !Regex.IsMatch(user.Phone, @"^7|8+[0-9]{10}$"))
            {
                errors.AppendLine("Введен некорректный номер телефона.");
            }
            if (errors.Length > 0)
            {
                throw new Exception(errors.ToString());
            }
            user.Password = user.Password.EncryptString();
            return DAL.AddUser(user);
        }
    }
}
