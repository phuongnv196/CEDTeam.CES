using CEDTeam.CES.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CEDTeam.CES.Core.Interfaces
{
    public interface IUserService
    {
        Task<bool> InsertFirstLogin(UserDto userDto);
        Task<List<UserDto>> Get();
        Task<bool> Insert(UserDto userDto);
    }
}
