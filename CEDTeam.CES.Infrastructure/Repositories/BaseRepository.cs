using Microsoft.Extensions.Options;
using CEDTeam.CES.Core.Configs;
using CEDTeam.CES.Core.Interfaces;
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CEDTeam.CES.Infrastructure.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly IOptions<AppConfig> _config;
        private readonly string _connectString;
        
        public BaseRepository(IOptions<AppConfig> config)
        {
            _config = config;
            _connectString = config.Value.ConnectString;
        }
        public IDbConnection GetConnection()
        {
            return new MySqlConnection(_config.Value.ConnectString);
        }
    }
}
