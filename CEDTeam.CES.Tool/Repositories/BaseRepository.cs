using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace CEDTeam.CES.Tool.Repositories
{
    public class BaseRepository
    {
        private readonly string _connectString = ConfigurationManager.AppSettings["connectString"];
        public IDbConnection GetConnection()
        {
            return new MySqlConnection(_connectString);
        }
    }
}
