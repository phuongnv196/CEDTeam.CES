using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEDTeam.CES.Web.Models
{
    public class HotKeyByCategoryModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public List<string> Keywords { get; set; }
    }
}
