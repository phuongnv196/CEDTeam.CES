using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CEDTeam.CES.Web.Controllers
{
    public class HotKeyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}