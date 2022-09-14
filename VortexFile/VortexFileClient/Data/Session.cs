using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            StringBuilder errors = new StringBuilder();
            if (DAL.GetUserByLogin(user.Login) != null)
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
            if (!Regex.IsMatch(user.Email, @"^[A-Z0-9._%+-]+@[A-Z0-9-]+.+.[A-Z]{2,4}$"))
            {
                errors.AppendLine("Введен некорректный почтовый адрес.");
            }
            if (!Regex.IsMatch(user.Password, @"^[a-zA-ZА-Яа-яЁё0-9]{8,50}$") || user.Password.Contains(" "))
            {
                errors.AppendLine("Введен некорректный пароль. Пароль должен состоять из 8 - 50 символов, которые могут быть цифрами, строчными и прописными буквами.");
            }
            if (user.Phone != String.Empty && !Regex.IsMatch(user.Phone, @"^7|8+[0-9]{10}$"))
            {
                errors.AppendLine("Введен некорректный номер телефона.");
            }
            if (errors.Length > 0)
            {
                throw new Exception(errors.ToString());
            }
            return DAL.AddUser(user);
        }
    }
}
