using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Web.Models
{


    public class ShopInfoSDS
    {
        public string shop_name { get; set; }
        public object good_review_percent { get; set; }
        public object is_certified { get; set; }
        public int shop_mall { get; set; }
        public int shop_brand_type { get; set; }
    }

    public class DataSDS
    {
        public int admin_id { get; set; }
        public ShopInfoSDS shop_info { get; set; }
        public int is_keyword_ads { get; set; }
        public bool is_event { get; set; }
        public int status_new { get; set; }
        public int final_promotion_percent { get; set; }
        public int total_rated { get; set; }
        public string promotion_percent_upto { get; set; }
        public int shop_brand_type { get; set; }
        public int counter_like { get; set; }
        public string img_url { get; set; }
        public string shop_name { get; set; }
        public double percent_star { get; set; }
        public int is_certified { get; set; }
        public bool free_shipping { get; set; }
        public bool is_product_installment { get; set; }
        public int is_senmall { get; set; }
    }

    public class ResultSDS
    {
        public List<DataSDS> data { get; set; }
    }

    public class SendoShopModel
    {
        public ResultSDS result { get; set; }
    }
}
