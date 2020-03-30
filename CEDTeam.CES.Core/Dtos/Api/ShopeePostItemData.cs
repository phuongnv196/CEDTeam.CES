using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{
    public class ShopeeItem
    {
        public long itemid { get; set; }
        public long shopid { get; set; }
    }
    public class ShopeePostItemData
    {
        public List<ShopeeItem> item_shop_ids;
    }
}
