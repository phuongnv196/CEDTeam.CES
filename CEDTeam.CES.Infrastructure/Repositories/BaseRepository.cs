using Microsoft.Extensions.Options;
using CEDTeam.CES.Core.Configs;
using CEDTeam.CES.Core.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using System.Threading.Tasks;

namespace CEDTeam.CES.Infrastructure.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly IOptions<AppConfig> _config;
        private readonly string _connectString;
        public static string _ConnectionString;

        public BaseRepository() { }

        public BaseRepository(IOptions<AppConfig> config)
        {
            _config = config;
            _connectString = config.Value.ConnectString;
        }
        public IDbConnection GetConnection()
        {
            return new SqlConnection(_config.Value.ConnectString);
        }

        public IDbConnection GetConnectionDev()
        {
            return new SqlConnection(_config.Value.ConnectStringDev);
        }

        protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {
                    await connection.OpenAsync();
                    return await getData(connection);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
            }
            catch (SqlException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
            }
        }

        public string JInputSerialize(object data)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new UpperCaseNamingPolicy(),
                WriteIndented = true
            };
            return JsonSerializer.Serialize(data, options);
        }
        public class UpperCaseNamingPolicy : JsonNamingPolicy
        {
            public override string ConvertName(string name) =>
                name.ToUpper();
        }
    }
}
