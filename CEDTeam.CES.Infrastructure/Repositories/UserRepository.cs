using Dapper;
using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using CEDTeam.CES.Infrastructure.Constants;
using System.Data;
using Newtonsoft.Json;
using CEDTeam.CES.Core.Dtos.User;
using CEDTeam.CES.Core.Helpers;
using CEDTeam.CES.Core.Commons;

namespace CEDTeam.CES.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public async Task<UserDto> GetUserLogin(UserDto user, string userId)
        {
            return await WithConnection(async connect =>
            {
                user.Password = user.Password.ToMD5String();
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
        
        public async Task<ResultData<ActiveUserDto>> InsUpdUser(UserDto user, string userId, string action)
        {
            return await WithConnection(async connect =>
            {
                var parameter = new DynamicParameters();
                parameter.Add(ParameterName.JInput, JInputSerialize(user));
                parameter.Add(ParameterName.UserRequestedID, userId);
                parameter.Add(ParameterName.OutputString, direction: ParameterDirection.Output, size: int.MaxValue);
                parameter.Add(ParameterName.Action, action);
                parameter.Add(ParameterName.ReturnValue, direction: ParameterDirection.ReturnValue);

                await connect.ExecuteAsync(StoreProcedure.UspInsUpdUser, parameter, commandType: CommandType.StoredProcedure);
                var resultData = new ResultData<ActiveUserDto>();
                resultData.ReturnValue = parameter.Get<int>(ParameterName.ReturnValue);
                resultData.Success = 1.Equals(resultData.ReturnValue);
                if (resultData.Success) 
                {
                    var result = parameter.Get<string>(ParameterName.OutputString);
                    resultData.Result =  JsonConvert.DeserializeObject<ActiveUserDto>(result);
                }
                return resultData;
            });
        }

        public async Task<ResultData<ActiveUserDto>> ActivateUser(string activateKey, string userId)
        {
            return await WithConnection(async connect =>
            {
                var parameter = new DynamicParameters();
                parameter.Add(ParameterName.JInput, JInputSerialize(new { ActivateKey = activateKey}));
                parameter.Add(ParameterName.UserRequestedID, userId);
                parameter.Add(ParameterName.OutputString, direction: ParameterDirection.Output, size: int.MaxValue);
                parameter.Add(ParameterName.Action, ActionName.Active);
                parameter.Add(ParameterName.ReturnValue, direction: ParameterDirection.ReturnValue);

                await connect.ExecuteAsync(StoreProcedure.UspInsUpdUser, parameter, commandType: CommandType.StoredProcedure);
                var resultData = new ResultData<ActiveUserDto>();
                resultData.ReturnValue = parameter.Get<int>(ParameterName.ReturnValue);
                resultData.Success = 1.Equals(resultData.ReturnValue);
                if (resultData.Success)
                {
                    var result = parameter.Get<string>(ParameterName.OutputString);
                    resultData.Result = JsonConvert.DeserializeObject<ActiveUserDto>(result);
                }
                return resultData;
            });
        }
    }
}
