using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{

    public class ItemRating
    {
        public object rating_star { get; set; }
        public List<int> rating_count { get; set; }
        public int rcount_with_image { get; set; }
        public int rcount_with_context { get; set; }
    }

    public class Attribute
    {
        public bool is_pending_qc { get; set; }
        public int idx { get; set; }
        public string value { get; set; }
        public int id { get; set; }
        public bool is_timestamp { get; set; }
        public string name { get; set; }
    }

    public class CoinInfo
    {
        public int spend_cash_unit { get; set; }
        public List<object> coin_earn_items { get; set; }
    }

    public class ItemDetail
    {
        public long itemid { get; set; }
        public int price_max_before_discount { get; set; }
        public string item_status { get; set; }
        public bool can_use_wholesale { get; set; }
        public bool show_free_shipping { get; set; }
        public int estimated_days { get; set; }
        public object is_hot_sales { get; set; }
        public bool is_slash_price_item { get; set; }
        public object upcoming_flash_sale { get; set; }
        public object slash_lowest_price { get; set; }
        public int condition { get; set; }
        public object add_on_deal_info { get; set; }
        public bool is_non_cc_installment_payment_eligible { get; set; }
        public int ctime { get; set; }
        public string name { get; set; }
        public bool show_shopee_verified_label { get; set; }
        public object size_chart { get; set; }
        public bool is_pre_order { get; set; }
        public int service_by_shopee_flag { get; set; }
        public int historical_sold { get; set; }
        public string reference_item_id { get; set; }
        public object recommendation_info { get; set; }
        public long price_max { get; set; }
        public bool has_lowest_price_guarantee { get; set; }
        public int shipping_icon_type { get; set; }
        public List<string> images { get; set; }
        public int price_before_discount { get; set; }
        public int cod_flag { get; set; }
        public int catid { get; set; }
        public bool is_official_shop { get; set; }
        public object coin_earn_label { get; set; }
        public List<string> hashtag_list { get; set; }
        public int sold { get; set; }
        public object makeup { get; set; }
        public ItemRating item_rating { get; set; }
        public bool show_official_shop_label_in_title { get; set; }
        public object discount { get; set; }
        public string reason { get; set; }
        public List<int> label_ids { get; set; }
        public bool has_group_buy_stock { get; set; }
        public List<Attribute> attributes { get; set; }
        public int badge_icon_type { get; set; }
        public bool liked { get; set; }
        public int cmt_count { get; set; }
        public string image { get; set; }
        public bool is_cc_installment_payment_eligible { get; set; }
        public int shopid { get; set; }
        public int normal_stock { get; set; }
        public List<object> video_info_list { get; set; }
        public object installment_plans { get; set; }
        public object view_count { get; set; }
        public bool current_promotion_has_reserve_stock { get; set; }
        public int liked_count { get; set; }
        public bool show_official_shop_label { get; set; }
        public int price_min_before_discount { get; set; }
        public int show_discount { get; set; }
        public object preview_info { get; set; }
        public int flag { get; set; }
        public int current_promotion_reserved_stock { get; set; }
        public List<object> wholesale_tier_list { get; set; }
        public object group_buy_info { get; set; }
        public bool shopee_verified { get; set; }
        public object hidden_price_display { get; set; }
        public string transparent_background_image { get; set; }
        public object welcome_package_info { get; set; }
        public CoinInfo coin_info { get; set; }
        public object is_adult { get; set; }
        public string currency { get; set; }
        public int raw_discount { get; set; }
        public bool is_category_failed { get; set; }
        public long price_min { get; set; }
        public bool can_use_bundle_deal { get; set; }
        public int cb_option { get; set; }
        public string brand { get; set; }
        public int stock { get; set; }
        public int status { get; set; }
        public int bundle_deal_id { get; set; }
        public object is_group_buy_item { get; set; }
        public string description { get; set; }
        public object flash_sale { get; set; }
        public List<object> models { get; set; }
        public long price { get; set; }
        public string shop_location { get; set; }
        public List<object> tier_variations { get; set; }
        public object makeups { get; set; }
        public int welcome_package_type { get; set; }
        public object show_official_shop_label_in_normal_position { get; set; }
        public int item_type { get; set; }
    }

    public class ShopeeProductDetailDto
    {
        public ItemDetail item { get; set; }
        public string version { get; set; }
        public object data { get; set; }
        public object error_msg { get; set; }
        public object error { get; set; }
    }

}
