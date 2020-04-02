using System;
using System.Collections.Generic;

namespace CEDTeam.CES.Core.Dtos.User
{
    public class UserDto
    {
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Addresss { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsActived { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string RoleJson { get; set; }
        public string RightJson { get; set; }
        public List<int> SelectedRoles { get; set; }
        public List<RoleDto> RoleList { get; set; } = new List<RoleDto>();
        public List<RightDto> RightList { get; set; } = new List<RightDto>();
    }
}
