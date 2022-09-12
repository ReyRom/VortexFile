using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using FastMember;

namespace VortexFileClient.Data
{
    public static class DAL
    {
        static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        
        static string connectionString =    "Data Source=ROMA1NV1CTUS;" +
                                            "Initial Catalog=VortexFile;" +
                                            "User id=sa;" +
                                            "Password=1;";

        static SqlConnection connection = new SqlConnection(connectionString);

        static List<T> GetData<T>(string tableName) where T : class, new()
        {
            connection.Open();
            SqlParameter sqlParameter = new SqlParameter("@tableName", tableName);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM @tableName",connection);
            sqlCommand.Parameters.Add(sqlParameter);
            var reader = sqlCommand.ExecuteReader();
            List<T> data = new List<T>();
            while (reader.Read())
            {
                data.Add(reader.ConvertToObject<T>());
            }
            return data;
        }

        public static User? GetUserByLogin(string login)
        {
            connection.Open();
            SqlParameter sqlParameter = new SqlParameter("@login", login);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [User] WHERE login = @login", connection);
            sqlCommand.Parameters.Add(sqlParameter);
            var reader = sqlCommand.ExecuteReader();
            User? user = null;
            if (reader.Read())
            {
                user = reader.ConvertToObject<User>();
            }
            return user;
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

