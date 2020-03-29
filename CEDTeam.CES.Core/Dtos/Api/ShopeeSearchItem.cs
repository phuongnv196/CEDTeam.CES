﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos.Api
{
    public class ItemRating
    {
        public double? rating_star { get; set; }
        public List<int> rating_count { get; set; }
        public int? rcount_with_image { get; set; }
        public int? rcount_with_context { get; set; }
    }

    public class ShopeeProduct
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
        public object raw_discount { get; set; }
        public bool? show_free_shipping { get; set; }
        public List<object> video_info_list { get; set; }
        public object ads_keyword { get; set; }
        public object collection_id { get; set; }
        public List<string> images { get; set; }
        public object match_type { get; set; }
        public object price_before_discount { get; set; }
        public bool is_category_failed { get; set; }
        public int? show_discount { get; set; }
        public int? cmt_count { get; set; }
        public object view_count { get; set; }
        public object display_name { get; set; }
        public int? catid { get; set; }
        public object json_data { get; set; }
        public object upcoming_flash_sale { get; set; }
        public bool? is_official_shop { get; set; }
        public string brand { get; set; }
        public object price_min { get; set; }
        public int? liked_count { get; set; }
        public bool? can_use_bundle_deal { get; set; }
        public bool? show_official_shop_label { get; set; }
        public object coin_earn_label { get; set; }
        public object price_min_before_discount { get; set; }
        public int? cb_option { get; set; }
        public object sold { get; set; }
        public object deduction_info { get; set; }
        public int? stock { get; set; }
        public int? status { get; set; }
        public object price_max { get; set; }
        public object add_on_deal_info { get; set; }
        public object is_group_buy_item { get; set; }
        public object flash_sale { get; set; }
        public object price { get; set; }
        public string shop_location { get; set; }
        public ItemRating item_rating { get; set; }
        public bool show_official_shop_label_in_title { get; set; }
        public List<object> tier_variations { get; set; }
        public object is_adult { get; set; }
        public string discount { get; set; }
        public int? flag { get; set; }
        public bool? is_non_cc_installment_payment_eligible { get; set; }
        public bool? has_lowest_price_guarantee { get; set; }
        public object has_group_buy_stock { get; set; }
        public object preview_info { get; set; }
        public int? welcome_package_type { get; set; }
        public string name { get; set; }
        public object distance { get; set; }
        public object adsid { get; set; }
        public double? ctime { get; set; }
        public List<object> wholesale_tier_list { get; set; }
        public bool? show_shopee_verified_label { get; set; }
        public object campaignid { get; set; }
        public object show_official_shop_label_in_normal_position { get; set; }
        public string item_status { get; set; }
        public bool? shopee_verified { get; set; }
        public object hidden_price_display { get; set; }
        public object size_chart { get; set; }
        public int? item_type { get; set; }
        public object shipping_icon_type { get; set; }
        public object campaign_stock { get; set; }
        public List<object> label_ids { get; set; }
        public int? service_by_shopee_flag { get; set; }
        public int? badge_icon_type { get; set; }
        public int? historical_sold { get; set; }
        public string transparent_background_image { get; set; }
        public dynamic models { get; set; }
    }

    public class ShopeeSearchItem
    {
        public int? total_count { get; set; }
        public string json_data { get; set; }
        public List<ShopeeProduct> items { get; set; }
    }
}
