using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{
    public class ShopeeKeyWordItem
    {
        public string display_name { get; set; }
    }

    public class ShopeeHotKeyByCategoryDto
    {
        public List<ShopeeKeyWordItem> items { get; set; }
    }
}
