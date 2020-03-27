using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{

    public class ItemShop
    {
        public string username { get; set; }
        public int shop_collection_id { get; set; }
        public int ctime { get; set; }
        public string seo_url { get; set; }
        public string logo_pc_url { get; set; }
        public int userid { get; set; }
        public int shopid { get; set; }
        public string shop_name { get; set; }
        public string logo_url { get; set; }
        public int brand_label { get; set; }
    }

    public class DataShop
    {
        public List<ItemShop> items { get; set; }
        public int tab_index { get; set; }
    }

    public class ShopeeShopDto
    {
        public string version { get; set; }
        public DataShop data { get; set; }
        public object error_msg { get; set; }
        public int error { get; set; }
    }

}
