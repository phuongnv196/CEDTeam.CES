using CEDTeam.CES.Core.Dtos;
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

        public async Task<List<UserDto>> Get()
        {
            return await _userRepository.GetAll();
        }

        public async Task<bool> Insert(UserDto userDto)
        {
            return true;
        }

        public async Task<bool> InsertFirstLogin(UserDto userDto)
        {
            return await _userRepository.InsertFirstLogin(userDto);
        }
    }
}
