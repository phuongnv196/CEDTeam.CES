using CEDTeam.CES.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CEDTeam.CES.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> InsertFirstLogin(UserDto userDto);
        Task<List<UserDto>> GetAll();
    }
}
