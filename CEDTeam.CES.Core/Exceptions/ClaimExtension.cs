using CEDTeam.CES.Core.Dtos.User;
using CEDTeam.CES.Core.Enums;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace CEDTeam.CES.Core.Exceptions
{
    public static class ClaimExtension
    {
        public static string GetUserID(this IPrincipal principal)
        {
            var claimsPrincipal = (ClaimsPrincipal)principal;
            var claim = claimsPrincipal.FindFirst("UserInfo");
            if (claim != null)
            {
                var user = JsonConvert.DeserializeObject<UserDto>(claim.Value);
                return user.UserID;
            }
            return null;
        }

        public static UserDto GetUserInfor(this IPrincipal principal)
        {
            var claimsPrincipal = (ClaimsPrincipal)principal;
            var claim = claimsPrincipal.FindFirst("UserInfo");
            if (claim != null)
            {
                var user = JsonConvert.DeserializeObject<UserDto>(claim.Value);
                return user;
            }
            return null;
        }
        public static bool IsInRight(this IPrincipal principal, params Right[] rights)
        {
            var claimsPrincipal = (ClaimsPrincipal)principal;
            var claim = claimsPrincipal.FindAll("Rights");
            if (claim != null)
            {
                var right = claim.Select(p => p.Value);
                return rights.All(x => right.Contains(((int)x).ToString()));
            }
            return false;
        }
    }
}
