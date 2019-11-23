using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{
    public class HotKeyByCategoryItem
    {
        public string name { get; set; }
    }

    public class HotKeyByCategoryShopeeDto
    {
        public List<HotKeyByCategoryItem> items { get; set; }
    }
}
