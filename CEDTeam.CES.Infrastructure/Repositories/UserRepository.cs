using Dapper;
using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using CEDTeam.CES.Infrastructure.Constants;

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
                return (await connection.QueryAsync<UserDto>(ProcName.User.GET_ALL_USER, commandType: System.Data.CommandType.StoredProcedure)).AsList();
            }
        }
    }
}
