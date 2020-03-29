using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos.Api
{
    public class SendoProduct
    {
        public double? id { get; set; }
        public double? product_id { get; set; }
        public string uid { get; set; }
        public string name { get; set; }
        public double? admin_id { get; set; }
        public double? price { get; set; }
        public double? price_max { get; set; }
        public string cat_path { get; set; }
        public double? total_comment { get; set; }
        public double? order_count { get; set; }
        public string image { get; set; }
        public string img_url_mob { get; set; }
        public double? brand_id { get; set; }
        public double? counter_view { get; set; }
        public double? special_price { get; set; }
        public double? final_price { get; set; }
        public double? final_price_max { get; set; }
        public bool? is_promotion { get; set; }
        public double? promotion_percent { get; set; }
        public double? is_keyword_ads { get; set; }
        public string sku_user { get; set; }
        public string sku { get; set; }
        public double? product_type { get; set; }
        public double? discount_app { get; set; }
        public double? product_mall { get; set; }
        public string stock_percent { get; set; }
        public string stock_title { get; set; }
        public string source_block_id { get; set; }
        public bool? is_event { get; set; }
        public double? status_new { get; set; }
        public double? final_promotion_percent { get; set; }
        public double? total_rated { get; set; }
        public string url_icon_event { get; set; }
        public bool? is_express { get; set; }
        public string original_price { get; set; }
        public string min_price { get; set; }
        public string min_max_price { get; set; }
        public string promotion_percent_upto { get; set; }
        public bool? is_config_variant { get; set; }
        public double? final_price_app { get; set; }
        public double? final_price_max_app { get; set; }
        public double? score_cate3_norm { get; set; }
        public double? score_v2_norm_cate2 { get; set; }
        public double? score_v2_norm_cate3 { get; set; }
        public double? ctr { get; set; }
        public double? ctr_norm_cate2 { get; set; }
        public double? ctr_norm_cate3 { get; set; }
        public string session_key_server { get; set; }
        public double? result_type { get; set; }
        public bool? is_event_frame { get; set; }
        public double? shop_brand_type { get; set; }
        public double? counter_like { get; set; }
        public string img_url { get; set; }
        public string shop_name { get; set; }
        public double percent_star { get; set; }
        public double? order_count_dd_1000_cod { get; set; }
        public double? is_certified { get; set; }
        public bool? free_shipping { get; set; }
        public bool? is_product_installment { get; set; }
        public double? is_senmall { get; set; }
        public string algo { get; set; }
        public double? square_type { get; set; }
        public string category_id { get; set; }
        public string promotion_note { get; set; }
    }

    public class Result
    {
        public List<SendoProduct> data { get; set; }
    }

    public class SendoSearchItem
    {
        public Result result { get; set; }
    }
}