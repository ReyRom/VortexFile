using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using FastMember;
using VortexFileClient.Extensions;
using VortexFileClient.Models;

namespace VortexFileClient.Data
{
    public static class DALold
    {
        static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        
        static string connectionString =    "Data Source=ROMA1NV1CTUS;" +
                                            "Initial Catalog=VortexFile;" +
                                            "User id=sa;" +
                                            "Password=1;";

        static SqlConnection connection = new SqlConnection(connectionString);

        static List<T> GetData<T>(string tableName) where T : class, new()
        {
            List<T> data = new List<T>();
            try
            {
                connection.Open();
                SqlParameter sqlParameter = new SqlParameter("@tableName", tableName);
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM @tableName", connection);
                sqlCommand.Parameters.Add(sqlParameter);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    data.Add(reader.ConvertToObject<T>());
                }
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
            finally
            {
                connection.Close();
            }
            return data;
        }

        public static User GetUserByLogin(string login)
        {
            User user = null;
            try
            {
                connection.Open();
                SqlParameter sqlParameter = new SqlParameter("@login", login);
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [User] WHERE login = @login", connection);
                sqlCommand.Parameters.Add(sqlParameter);
                var reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    user = reader.ConvertToObject<User>();
                }
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
            finally
            {
                connection.Close();
            }
            return user;
        }

        public static User GetUserByEmail(string email)
        {
            User user = null;
            try
            {
                connection.Open();
                SqlParameter sqlParameter = new SqlParameter("@email", email);
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [User] WHERE Email = @email", connection);
                sqlCommand.Parameters.Add(sqlParameter);
                var reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    user = reader.ConvertToObject<User>();
                }
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
            finally
            {
                connection.Close();
            }
            return user;
        }

        public static User GetUser(string login)
        {
            User user = GetUserByLogin(login);
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
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO [User](Login,Email,Password,Username,Phone) VALUES (@login,@email,@password,NULLIF(@username,''),NULLIF(@phone,''))", connection);
                sqlCommand.Parameters.Add(new SqlParameter("@login", user.Login));
                sqlCommand.Parameters.Add(new SqlParameter("@email", user.Email));
                sqlCommand.Parameters.Add(new SqlParameter("@password", user.Password));
                sqlCommand.Parameters.Add(new SqlParameter("@username", user.Username));
                sqlCommand.Parameters.Add(new SqlParameter("@phone", user.Phone));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
            finally
            {
                connection.Close();
            }
            return GetUserByLogin(user.Login);
        }

        public static User ChangeUserPassword(User user, string newPassword)
        {
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("UPDATE [User] SET Password = @password WHERE IdUser = @idUser", connection);
                sqlCommand.Parameters.Add(new SqlParameter("@idUser", user.IdUser));
                sqlCommand.Parameters.Add(new SqlParameter("@password", newPassword));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Feedback.ErrorMessage(ex);
            }
            finally
            {
                connection.Close();
            }
            return GetUserByLogin(user.Login);
        }

        private static T ConvertToObject<T>(this SqlDataReader rd) where T : class, new()
        {
            Type type = typeof(T);
            var accessor = TypeAccessor.Create(type);
            var members = accessor.GetMembers();
            var t = new T();

            for (int i = 0; i < rd.FieldCount; i++)
            {
                if (!rd.IsDBNull(i))
                {
                    string fieldName = rd.GetName(i);

                    if (members.Any(m => string.Equals(m.Name, fieldName, StringComparison.OrdinalIgnoreCase)))
                    {
                        accessor[t, fieldName] = rd.GetValue(i);
                    }
                }
            }
            return t;
        }
    }
}

