using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Interfaces.Services
{
    public interface IEmailService
    {
        void SendEmailWellcome(string email);
        void SendEmailActivateUser(string firstName, string email, string activateKey);
    }
}
