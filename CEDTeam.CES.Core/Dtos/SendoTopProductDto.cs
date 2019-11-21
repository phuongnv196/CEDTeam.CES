using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{
    public class StatusSP
    {
        public int? code { get; set; }
        public string message { get; set; }
    }

    public class ListTime
    {
        public int? delivery_info { get; set; }
        public int? installment { get; set; }
    }

    public class ShopInfo
    {
        public string shop_name { get; set; }
        public double? good_review_percent { get; set; }
        public object is_certified { get; set; }
        public ListTime listTime { get; set; }
        public int? shop_mall { get; set; }
        public int? shop_brand_type { get; set; }
    }

    public class Options
    {
        public int? is_shipping_fee_support { get; set; }
        public bool? is_installment { get; set; }
        public int? is_loyalty { get; set; }
    }

    public class RatingInfo
    {
        public int? total_rated { get; set; }
        public double? percent_star_rating { get; set; }
        public double? percent_star { get; set; }
    }

    public class DefaultListingScore
    {
        public int? score_cate2 { get; set; }
        public int? score_cate3 { get; set; }
    }

    public class ListingScoreV2
    {
        public int? score_v2 { get; set; }
        public int? updated_at { get; set; }
    }

    public class Voucher
    {
        public int? end_date { get; set; }
        public bool? is_check_date { get; set; }
        public int? product_type { get; set; }
        public int? start_date { get; set; }
    }

    public class DataSP
    {
        public int? id { get; set; }
        public int? product_id { get; set; }
        public string uid { get; set; }
        public string name { get; set; }
        public int? admin_id { get; set; }
        public int? price { get; set; }
        public int? price_max { get; set; }
        public string cat_path { get; set; }
        public int? total_comment { get; set; }
        public int? order_count { get; set; }
        public string image { get; set; }
        public string img_url_mob { get; set; }
        public int? brand_id { get; set; }
        public int? counter_view { get; set; }
        public int? special_price { get; set; }
        public int? final_price { get; set; }
        public int? final_price_max { get; set; }
        public int? is_promotion { get; set; }
        public int? promotion_percent { get; set; }
        public ShopInfo shop_info { get; set; }
        public Options options { get; set; }
        public RatingInfo rating_info { get; set; }
        public int? is_keyword_ads { get; set; }
        public string sku_user { get; set; }
        public string sku { get; set; }
        public int? product_type { get; set; }
        public int? discount_app { get; set; }
        public int? product_mall { get; set; }
        public string stock_percent { get; set; }
        public string stock_title { get; set; }
        public string source_block_id { get; set; }
        public int? is_event { get; set; }
        public int? status_new { get; set; }
        public int? final_promotion_percent { get; set; }
        public int? total_rated { get; set; }
        public string url_icon_event { get; set; }
        public bool? is_express { get; set; }
        public string original_price { get; set; }
        public string min_price { get; set; }
        public string min_max_price { get; set; }
        public string promotion_percent_upto { get; set; }
        public bool? is_config_variant { get; set; }
        public int? final_price_app { get; set; }
        public int? final_price_max_app { get; set; }
        public DefaultListingScore default_listing_score { get; set; }
        public ListingScoreV2 listing_score_v2 { get; set; }
        public int? score_cate3_norm { get; set; }
        public int? score_v2_norm_cate2 { get; set; }
        public int? score_v2_norm_cate3 { get; set; }
        public int? ctr { get; set; }
        public int? ctr_norm_cate2 { get; set; }
        public int? ctr_norm_cate3 { get; set; }
        public string session_key_server { get; set; }
        public int? result_type { get; set; }
        public Voucher voucher { get; set; }
        public int? is_event_frame { get; set; }
        public int? shop_brand_type { get; set; }
        public int? counter_like { get; set; }
        public string img_url { get; set; }
        public string shop_name { get; set; }
        public double? percent_star { get; set; }
        public int? order_count_dd_1000_cod { get; set; }
        public int? is_certified { get; set; }
        public int? free_shipping { get; set; }
        public bool? is_product_installment { get; set; }
        public int? is_senmall { get; set; }
        public string algo { get; set; }
        public int? square_type { get; set; }
        public string category_id { get; set; }
        public string promotion_note { get; set; }
        public int? flash_deal_id { get; set; }
    }

    public class SourceInfoSP
    {
        public string source_block_id { get; set; }
        public string source_page_id { get; set; }
    }

    public class LocationData
    {
        public string city_id { get; set; }
        public string city_name { get; set; }
        public string address { get; set; }
    }

    public class MetaDataSP
    {
        public int? experiment_id { get; set; }
        public int? special_res { get; set; }
        public int? total_count { get; set; }
        public string type_view { get; set; }
        public string search_algo { get; set; }
        public SourceInfoSP source_info { get; set; }
        public string belong_tab { get; set; }
        public int? current_page { get; set; }
        public int? duplicate_res { get; set; }
        public string suggest_text { get; set; }
        public LocationData location_data { get; set; }
        public int? total_page { get; set; }
    }

    public class ResultSP
    {
        public List<DataSP> data { get; set; }
        public MetaDataSP meta_data { get; set; }
        public List<object> error { get; set; }
    }

    public class SendoTopProductDto
    {
        public StatusSP status { get; set; }
        public ResultSP result { get; set; }
    }
}
