using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Infrastructure.Constants
{
    public class ApiConstant
    {
        // HOT KEYWORDS
        public const string SHOPEE_HOT_SEARCH_URL = "https://shopee.vn/api/v2/recommendation/hot_search_words?limit=100&offset=0";

        public const string TIKI_HOT_SEARCH_URL = "https://tiki.vn/api/v2/personalization/v2/keywords";

        public const string SENDO_HOT_SEARCH_URL = "https://www.sendo.vn/m/wap_v2/home/top-keyword";

        public const string LAZADA_HOT_SEARCH_URL = "";

        // TOP PRODUCTS
        public const string SHOPEE_TOP_PRODUCTS_URL = "https://shopee.vn/api/v2/recommendation/top_products/meta_lite?item_limit=40&sorttype=0";


        // TRENDING
        public const string SHOPEE_TRENDING_SEARCH_URL = "https://shopee.vn/api/v2/recommendation/trending_searches_v2?limit=20&offset=0";

        // OTHERS
        public const string SHOPEE_GET_LIST_URL = "https://shopee.vn/api/v2/item/get_list";
    }
}
