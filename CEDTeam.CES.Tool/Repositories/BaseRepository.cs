using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Tool.Repositories
{
    public class BaseRepository
    {
        private readonly string _connectString = ConfigurationManager.AppSettings["connectString"];
        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectString);
        }
    }
}
