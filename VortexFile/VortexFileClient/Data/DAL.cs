using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace VortexFileClient.Data
{
    public static class DAL
    {
        static string connectionString = "";

        static SqlConnection connection = new SqlConnection(connectionString);


    }
}

