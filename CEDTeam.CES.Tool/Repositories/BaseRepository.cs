using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace CEDTeam.CES.Tool.Repositories
{
    public class BaseRepository
    {
        private readonly string _connectString = ConfigurationManager.AppSettings["connectString"];
        private IDbConnection connection;
        public IDbConnection GetConnection()
        {
            if (connection == null)
                connection = new MySqlConnection(_connectString);
            return connection;
        }
    }
}
