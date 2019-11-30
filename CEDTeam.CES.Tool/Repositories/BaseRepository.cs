using MySql.Data.MySqlClient;
using System.Data.SqlClient;
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
            return new SqlConnection(_connectString);
        }
    }
}
