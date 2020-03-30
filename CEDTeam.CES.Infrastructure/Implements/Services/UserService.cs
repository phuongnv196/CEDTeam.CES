using CEDTeam.CES.Core.Commons;
using CEDTeam.CES.Core.Constants;
using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Dtos.User;
using CEDTeam.CES.Core.Helpers;
using CEDTeam.CES.Core.Interfaces;
using CEDTeam.CES.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Infrastructure.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDto> GetUserLogin(UserDto user, string userId)
        {
            return await _userRepository.GetUserLogin(user, userId);
        }
        public async Task<List<UserDto>> GetListUser(string searchString, string userId)
        {
            return await _userRepository.GetListUser(searchString, userId);
        }
        public async Task<ResultData<ActiveUserDto>> InsertUser(UserDto user, string userId)
        {
            user.Password = user.Password.ToMD5String();
            return await _userRepository.InsUpdUser(user, userId, ActionName.Insert);
        }
        
        public async Task<ResultData<ActiveUserDto>> UpdateUser(UserDto user, string userId)
        {
            return await _userRepository.InsUpdUser(user, userId, ActionName.Update);
        }
        public async Task<ResultData<ActiveUserDto>> ActivateUser(string activateKey)
        {
            return await _userRepository.ActivateUser(activateKey, AppConstant.SYSTEM_ID);
        }
    }
}
