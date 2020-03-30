using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Infrastructure.Constants
{
    public class ParameterName
    {
        public static readonly string Action = "@Action";
        public static readonly string UserRequestedID = "@UserRequestedID";
        public static readonly string JInput = "@JInput";
        public static readonly string OutputString = "@OutputString";
        public static readonly string ReturnValue = "@ReturnValue";
    }
    public class ActionName
    {
        public static readonly string Get = "Get";
        public static readonly string Insert = "Insert";
        public static readonly string Update = "Update";
        public static readonly string Active = "Active";
    }
}
