using CEDTeam.CES.Core.Commons;
using CEDTeam.CES.Core.Dtos.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CEDTeam.CES.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserLogin(UserDto user, string userId);
        Task<List<UserDto>> GetListUser(string searchString, string userId);
        Task<ResultData<ActiveUserDto>> InsertUser(UserDto user, string userId);
        Task<ResultData<ActiveUserDto>> UpdateUser(UserDto user, string userId);
        Task<ResultData<ActiveUserDto>> ActivateUser(string activateKey);
    }
}
