using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEDTeam.CES.Web.Models
{
    public class ShopeeProductItem
    {
        public long itemid { get; set; }
        public long shopid { get; set; }
    }
    public class ShopeeProductItemCollectionModel
    {
        public List<ShopeeProductItem> item_shop_ids;
    }
}
