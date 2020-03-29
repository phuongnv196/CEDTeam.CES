using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Dtos.User;
using CEDTeam.CES.Core.Interfaces;
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
    }
}
