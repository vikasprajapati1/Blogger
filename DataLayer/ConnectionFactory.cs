using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class ConnectionFactory
    {
        private const string ConnectionName = "DefaultConnection";
        private const string ReadConnectionName = "ReadConnection";


        /// <summary>
        /// Creating the database connection
        /// </summary>
        /// <returns></returns>
        public static DbConnection CreateConnection(IConfiguration configuration)
        {
            return new MySqlConnection(configuration.GetConnectionString(ConnectionName));
        }

        public static DbConnection CreateReadConnection(IConfiguration configuration)
        {
            return new MySqlConnection(configuration.GetConnectionString(ReadConnectionName));
        }
    }
}
