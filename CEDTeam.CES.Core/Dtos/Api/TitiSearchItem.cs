using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos.Api
{
    public class TikiProduct
    {
        public double? id { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public string url_key { get; set; }
        public string url_path { get; set; }
        public string type { get; set; }
        public string short_description { get; set; }
        public double? price { get; set; }
        public double? list_price { get; set; }
        public double? discount { get; set; }
        public double? discount_rate { get; set; }
        public double? rating_average { get; set; }
        public double? review_count { get; set; }
        public double? order_count { get; set; }
        public double? favourite_count { get; set; }
        public string thumbnail_url { get; set; }
        public double? thumbnail_width { get; set; }
        public double? thumbnail_height { get; set; }
        public bool? has_ebook { get; set; }
        public string inventory_status { get; set; }
        public bool? is_visible { get; set; }
        public string productset_group_name { get; set; }
        public bool? is_flower { get; set; }
        public bool? is_gift_card { get; set; }
        public string url_attendant_input_form { get; set; }
        public string salable_type { get; set; }
        public double? seller_product_id { get; set; }
    }

    public class TitiSearchItem
    {
        public List<TikiProduct> data { get; set; }
    }
}
