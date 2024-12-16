using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanNuoc.Services
{
    public class DatabaseService
    {
        private string connectionString;

        public DatabaseService()
        {
            connectionString = @"Data Source=QUANGSLAPTOP;Initial Catalog=QLBanNuoc;Integrated Security=True;Trust Server Certificate=True";
        }

        public SqlConnection Connection ()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            return sqlConnection;
        }
    }
}
