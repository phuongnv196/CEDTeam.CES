using System.Collections.Generic;

namespace CEDTeam.CES.Core.Dtos.User
{
    public class RoleDto
    {
        public long RoleID { get; set; }
        public string RoleName { get; set; }
        public string RoleConfigName { get; set; }
        public List<RightDto> RightList { get; set; }

    }
    public class RightDto
    {
        public long RightID { get; set; }
        public string RightName { get; set; }
        public string RightConfigName { get; set; }
    }
}
