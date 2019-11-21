using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{
    public class ShopeeProductItem
    {
        public long itemid { get; set; }
        public long shopid { get; set; }
    }
    public class ShopeeProductItemCollectionDto
    {
        public List<ShopeeProductItem> item_shop_ids;
    }
}
