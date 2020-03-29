using CEDTeam.CES.Core.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEDTeam.CES.Web.Models.User
{
    public class UserModel
    {
        public string UserID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Addresss { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsLocked { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string CreatedBy { get; set; }
        public List<long> Roles { get; set; } = new List<long>();
        public List<long> Rights { get; set; } = new List<long>();
        public List<RoleDto> RoleList { get; set; } = new List<RoleDto>();
        public List<RightDto> RightList { get; set; } = new List<RightDto>();
    }
}
