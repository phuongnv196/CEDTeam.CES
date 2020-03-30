using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Constants
{
    public class AppConstant
    {
        public const string SYSTEM_ID = "CDEA812F-81DA-414C-9316-E1AB083630BD";
        public class ErrorMessage
        {
            public const string REQUIRED_USERNAME = "Tên đăng nhập không được trống.";
            public const string REQUIRED_PASSWORD = "Mật khẩu không được trống.";
            public const string REQUIRED_EMAIL = "Email không được trống.";
            public const string REQUIRED_FIRSTNAME = "Tên không được trống.";
            public const string REQUIRED_LASTNAME = "Họ không được trống.";

            public const string USERNAME_EXIST = "Tên người dùng đã tồn tại.";
            public const string EMAIL_EXIST = "Email đã tồn tại.";
            public const string ERROR_ACTIVATE_USER = "Active Key không tồn tại.";
        }
    }
}
