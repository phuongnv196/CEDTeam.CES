using CEDTeam.CES.Core.Commons;
using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Dtos.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CEDTeam.CES.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserLogin(UserDto user, string userId);
        Task<List<UserDto>> GetListUser(string searchString, string userId);
        Task<ResultData<ActiveUserDto>> InsUpdUser(UserDto user, string userId, string action);
        Task<ResultData<ActiveUserDto>> ActivateUser(string activateKey, string userId);
    }
}
