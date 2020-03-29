using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos.Email
{
    public class OutlookMailDto
    {
        public string EmailAdress { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Html { get; set; }
    }
}
