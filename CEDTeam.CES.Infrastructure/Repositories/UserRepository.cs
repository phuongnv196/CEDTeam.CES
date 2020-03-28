using Dapper;
using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using CEDTeam.CES.Infrastructure.Constants;
using System.Data;
using Newtonsoft.Json;
using CEDTeam.CES.Core.Dtos.User;

namespace CEDTeam.CES.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public async Task<UserDto> GetUserLogin(UserDto user, string userId)
        {
            return await WithConnection(async connect =>
            {
                var parameter = new DynamicParameters();
                parameter.Add(ParameterName.JInput, JInputSerialize(user));
                parameter.Add(ParameterName.UserRequestedID, userId);
                parameter.Add(ParameterName.OutputString, direction: ParameterDirection.Output, size: int.MaxValue);
                parameter.Add(ParameterName.Action, ActionName.Get);
                var result = await connect.QueryFirstOrDefaultAsync<UserDto>(StoreProcedure.UspGetUserLogin, parameter, commandType: CommandType.StoredProcedure);
                if (result != null && result.RoleJson != null)
                {
                    result.RoleList = JsonConvert.DeserializeObject<List<RoleDto>>(result.RoleJson);
                }
                if (result != null && result.RightJson != null)
                {
                    result.RightList = JsonConvert.DeserializeObject<List<RightDto>>(result.RightJson);
                }
                return result;
            });
        }

        public async Task<List<UserDto>> GetListUser(string searchString, string userId)
        {
            return await WithConnection(async connect =>
            {
                var parameter = new DynamicParameters();
                parameter.Add(ParameterName.JInput, JInputSerialize(new { SEARCHSTRING = searchString }));
                parameter.Add(ParameterName.UserRequestedID, userId);
                parameter.Add(ParameterName.OutputString, direction: ParameterDirection.Output, size: int.MaxValue);
                parameter.Add(ParameterName.Action, ActionName.Get);
                var result = await connect.QueryAsync<UserDto>(StoreProcedure.UspGetUserList, parameter, commandType: CommandType.StoredProcedure);
                return result.AsList();
            });
        }
    }
}
