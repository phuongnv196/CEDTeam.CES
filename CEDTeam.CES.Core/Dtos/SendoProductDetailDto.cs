using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{
    public class Medium
    {
        public string image { get; set; }
        public string image_500x500 { get; set; }
        public string image_50x50 { get; set; }
        public string type { get; set; }
    }

    public class SendoValue
    {
        public double? option_id { get; set; }
        public string product_option_id { get; set; }
        public string name { get; set; }
    }

    public class SendoAttribute
    {
        public double? attribute_id { get; set; }
        public string name { get; set; }
        public string product_option { get; set; }
        public double? show_required { get; set; }
        public string type { get; set; }
        public List<SendoValue> value { get; set; }
        public string search_key { get; set; }
    }

    public class SendoRatingInfo
    {
        public double? total_rated { get; set; }
        public double percent_star { get; set; }
        public double? percent_star1 { get; set; }
        public double? percent_star2 { get; set; }
        public double? percent_star3 { get; set; }
        public double? percent_star4 { get; set; }
        public double? percent_star5 { get; set; }
        public double? star1 { get; set; }
        public double? star2 { get; set; }
        public double? star3 { get; set; }
        public double? star4 { get; set; }
        public double? star5 { get; set; }
        public double percent_number { get; set; }
    }

    public class SendoShopInfo
    {
        public double? shop_id { get; set; }
        public double? customer_id { get; set; }
        public string shop_name { get; set; }
        public string shop_logo { get; set; }
        public double good_review_percent { get; set; }
        public double? score { get; set; }
        public double? is_certified { get; set; }
        public double? lotus { get; set; }
        public string lotus_class { get; set; }
        public double? warehourse_region_id { get; set; }
        public string warehourse_region_name { get; set; }
        public double? shop_external_id { get; set; }
        public string phone_number { get; set; }
        public List<object> self_transport { get; set; }
        public string shop_url { get; set; }
        public double? shop_mall { get; set; }
        public bool? is_self_transport { get; set; }
        public double rating_avg { get; set; }
        public double? rating_count { get; set; }
        public string response_time { get; set; }
        public double? product_total { get; set; }
        public string sale_on_sendo { get; set; }
        public string time_prepare_product { get; set; }
        public string percent_response { get; set; }
        public double? shop_brand_type { get; set; }
        public double warehouse_longitude { get; set; }
        public double warehouse_latitude { get; set; }
    }

    public class ReturnPolicy
    {
        public string title { get; set; }
        public string color { get; set; }
        public string icon { get; set; }
        public string tooltip_title { get; set; }
        public string tooltip_content { get; set; }
        public bool? enable { get; set; }
        public string position { get; set; }
    }

    public class PriceDiscount
    {
        public string total_min_price { get; set; }
        public string total_max_price { get; set; }
        public List<object> list_discount { get; set; }
    }

    public class CategoryInfo
    {
        public double? id { get; set; }
        public string title { get; set; }
        public string path { get; set; }
        public string url_key { get; set; }
        public List<object> images { get; set; }
    }

    public class RelateTag
    {
        public string title { get; set; }
        public string link { get; set; }
    }

    public class FlashSale
    {
        public double? id { get; set; }
        public double? start_time { get; set; }
        public double? end_time { get; set; }
        public bool? is_active { get; set; }
        public double? slot_id { get; set; }
        public bool? is_mega_sale { get; set; }
        public double? type { get; set; }
        public string link { get; set; }
    }

    public class InstallmentInfo
    {
        public bool? is_active { get; set; }
        public double? min_installment_price { get; set; }
        public double? max_installment_term { get; set; }
    }

    public class SendoVoucher
    {
        public double? end_date { get; set; }
        public bool? is_check_date { get; set; }
        public double? product_type { get; set; }
        public double? start_date { get; set; }
    }

    public class AttributeOption
    {
        public double? __invalid_name__698 { get; set; }
    }

    public class Variant
    {
        public string attribute_hash { get; set; }
        public double? promotion_percent { get; set; }
        public double? is_promotion { get; set; }
        public string sku_user { get; set; }
        public double? price { get; set; }
        public double? special_price { get; set; }
        public double? final_price { get; set; }
        public double? is_flashdeal_price { get; set; }
        public double? flashdeal_price { get; set; }
        public double? flashdeal_quantity { get; set; }
        public double? flashdeal_remain { get; set; }
        public int stock { get; set; }
        public List<int> options { get; set; }
        public AttributeOption attribute_option { get; set; }
    }

    public class SendoItemDetail
    {
        public double? id { get; set; }
        public string name { get; set; }
        public double? admin_id { get; set; }
        public double? price { get; set; }
        public double? price_max { get; set; }
        public double? weight { get; set; }
        public string category_id { get; set; }
        public string cat_path { get; set; }
        public double? total_comment { get; set; }
        public string url_key { get; set; }
        public double? quantity { get; set; }
        public string sku { get; set; }
        public string sku_user { get; set; }
        public bool? belong_cate_self_transport { get; set; }
        public bool? has_options { get; set; }
        public string product_relateds { get; set; }
        public double? shop_free_shipping { get; set; }
        public double? status { get; set; }
        public double? status_new { get; set; }
        public double? stock_status { get; set; }
        public double? order_count { get; set; }
        public List<Medium> media { get; set; }
        public List<object> brand_info { get; set; }
        public double? counter_view { get; set; }
        public double? special_price { get; set; }
        public double? final_price { get; set; }
        public double? final_price_max { get; set; }
        public double? promotion_percent { get; set; }
        public string required_options { get; set; }
        public List<SendoAttribute> attribute { get; set; }
        public string description { get; set; }
        public string short_description { get; set; }
        public SendoRatingInfo rating_info { get; set; }
        public SendoShopInfo shop_info { get; set; }
        public List<ReturnPolicy> return_policy { get; set; }
        public PriceDiscount price_discount { get; set; }
        public string size_guide { get; set; }
        public List<CategoryInfo> category_info { get; set; }
        public List<RelateTag> relate_tags { get; set; }
        public double? discount_app { get; set; }
        public string image { get; set; }
        public double? length_product { get; set; }
        public double? height_product { get; set; }
        public bool? has_voucher { get; set; }
        public double? witdh_product { get; set; }
        public double? product_mall { get; set; }
        public double? is_event { get; set; }
        public double? is_event_frame { get; set; }
        public FlashSale flash_sale { get; set; }
        public string promotion_note { get; set; }
        public bool? is_express { get; set; }
        public bool? is_config_variant { get; set; }
        public bool? is_installment { get; set; }
        public InstallmentInfo installment_info { get; set; }
        public List<object> label_sale_event { get; set; }
        public double? is_shop_ads { get; set; }
        public SendoVoucher voucher { get; set; }
        public double? updated_at { get; set; }
        public double? counter_like { get; set; }
        public string product_status { get; set; }
        public double? shipping_express { get; set; }
        public double? shop_brand_type { get; set; }
        public List<Variant> variants { get; set; }
    }

    public class SendoBreadcrumb
    {
        public string title { get; set; }
        public string url { get; set; }
        public bool? clickable { get; set; }
        public bool? isExternalUrl { get; set; }
        public bool? hidden { get; set; }
    }

    public class SendoMetaData
    {
        public string page_title { get; set; }
        public string description { get; set; }
        public string heading_search { get; set; }
        public string og_title { get; set; }
        public string og_description { get; set; }
        public string og_image { get; set; }
        public bool? index { get; set; }
        public bool? follow { get; set; }
        public string keywords { get; set; }
        public List<SendoBreadcrumb> breadcrumb { get; set; }
        public string headerStyle { get; set; }
    }

    public class SendoResult
    {
        public SendoItemDetail data { get; set; }

    }
    public class SendoProductDetailDto
    {
        public SendoResult result { get; set; }
        public SendoMetaData meta_data { get; set; }
        public List<object> error { get; set; }
    }
}
