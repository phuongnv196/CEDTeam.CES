using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{

    public class ItemShop
    {
        public string username { get; set; }
        public long shop_collection_id { get; set; }
        public long ctime { get; set; }
        public string seo_url { get; set; }
        public string logo_pc_url { get; set; }
        public long userid { get; set; }
        public long shopid { get; set; }
        public string shop_name { get; set; }
        public string logo_url { get; set; }
        public long brand_label { get; set; }
    }

    public class DataShop
    {
        public List<ItemShop> items { get; set; }
    }

    public class ShopeeShopDto
    {
        public DataShop data { get; set; }
    }

}
