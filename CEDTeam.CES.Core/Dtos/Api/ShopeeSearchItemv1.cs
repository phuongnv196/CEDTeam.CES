using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos.Api
{
    public class QueryRewrite
    {
    }

    public class Adjust
    {
        public int count { get; set; }
    }

    public class PriceAdjust
    {
        public int count { get; set; }
    }

    public class ShopeeSearchItemv1
    {
        public bool? show_disclaimer { get; set; }
        public QueryRewrite query_rewrite { get; set; }
        public Adjust adjust { get; set; }
        public string version { get; set; }
        public string algorithm { get; set; }
        public int total_count { get; set; }
        public List<ShopeeItem> items { get; set; }
        public int total_ads_count { get; set; }
        public string reserved_keyword { get; set; }
        public PriceAdjust price_adjust { get; set; }
        public int suggestion_algorithm { get; set; }
        public List<object> hint_keywords { get; set; }
        public bool? nomore { get; set; }
        public string json_data { get; set; }
    }
}
