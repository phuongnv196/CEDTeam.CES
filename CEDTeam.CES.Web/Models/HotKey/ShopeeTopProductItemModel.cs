using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEDTeam.CES.Web.Models
{
    public class TopProductItem
    {
        public object itemid { get; set; }
        public object welcome_package_info { get; set; }
        public bool? liked { get; set; }
        public object recommendation_info { get; set; }
        public object price_max_before_discount { get; set; }
        public string image { get; set; }
        public bool? is_cc_installment_payment_eligible { get; set; }
        public int? shopid { get; set; }
        public bool? can_use_wholesale { get; set; }
        public object group_buy_info { get; set; }
        public string reference_item_id { get; set; }
        public string currency { get; set; }
        public int? raw_discount { get; set; }
        public bool? show_free_shipping { get; set; }
        public List<string> images { get; set; }
        public object price_before_discount { get; set; }
        public bool? is_category_failed { get; set; }
        public int? show_discount { get; set; }
        public int? cmt_count { get; set; }
        public int? view_count { get; set; }
        public int? catid { get; set; }
        public bool? is_official_shop { get; set; }
        public string brand { get; set; }
        public object price_min { get; set; }
        public int? liked_count { get; set; }
        public bool? show_official_shop_label { get; set; }
        public object price_min_before_discount { get; set; }
        public int? sold { get; set; }
        public int? stock { get; set; }
        public int? status { get; set; }
        public object price_max { get; set; }
        public object is_group_buy_item { get; set; }
        public object flash_sale { get; set; }
        public object price { get; set; }
        public string shop_location { get; set; }
        public bool? show_official_shop_label_in_title { get; set; }
        public object is_adult { get; set; }
        public string discount { get; set; }
        public object preview_info { get; set; }
        public string name { get; set; }
        public int? ctime { get; set; }
        public bool? show_shopee_verified_label { get; set; }
        public object show_official_shop_label_in_normal_position { get; set; }
        public string item_status { get; set; }
        public bool? shopee_verified { get; set; }
        public object shipping_icon_type { get; set; }
        public int? service_by_shopee_flag { get; set; }
        public int? historical_sold { get; set; }
    }

    public class ShopeeTopProductItemModel
    {
        public List<TopProductItem> items { get; set; }
    }
}
