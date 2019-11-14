using Dapper;
using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CEDTeam.CES.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IBaseRepository _baseRepository;
        public UserRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> InsertFirstLogin(UserDto userDto)
        {
            return true;
        }

        public async Task<List<UserDto>> GetAll()
        {
            using(var connection = _baseRepository.GetConnection())
            {
                return (await connection.QueryAsync<UserDto>("SELECT * FROM User")).AsList();
            }
        }
    }
}
