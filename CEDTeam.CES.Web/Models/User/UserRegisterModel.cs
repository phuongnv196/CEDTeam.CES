using CEDTeam.CES.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CEDTeam.CES.Web.Models.User
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = AppConstant.ErrorMessage.REQUIRED_USERNAME)]
        public string Username { get; set; }
        [Required(ErrorMessage = AppConstant.ErrorMessage.REQUIRED_FIRSTNAME)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = AppConstant.ErrorMessage.REQUIRED_LASTNAME)]
        public string LastName { get; set; }
        [Required(ErrorMessage = AppConstant.ErrorMessage.REQUIRED_EMAIL)]
        public string Email { get; set; }

        [Required(ErrorMessage = AppConstant.ErrorMessage.REQUIRED_PASSWORD)]
        public string Password { get; set; }
        public string Addresss { get; set; }
        public string PhoneNumber { get; set; }
    }
}
