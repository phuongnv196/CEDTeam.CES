using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEDTeam.CES.Web.Models
{
    public class HotKeyByCategoryItem
    {
        public string name { get; set; }
    }

    public class HotKeyByCategoryShopeeModel
    {
        public List<HotKeyByCategoryItem> items { get; set; }
    }
}
