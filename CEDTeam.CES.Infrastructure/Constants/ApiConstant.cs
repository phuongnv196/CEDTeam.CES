using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Infrastructure.Constants
{
    public class ApiConstant
    {
        //SHOPEE
        public const string SHOPEE_TRENDING_SEARCH_URL = "https://shopee.vn/api/v2/recommendation/trending_searches_v2?limit=20&offset=0";

        public const string SHOPEE_HOT_SEARCH_URL = "https://shopee.vn/api/v2/recommendation/hot_search_words?limit=8&offset=0";

        public const string SHOPEE_TOP_PRODUCTS_URL = "https://shopee.vn/api/v2/recommendation/top_products/meta_lite?item_limit=40&sorttype=0";
        //
        public const string SHOPEE_GET_LIST_URL = "https://shopee.vn/api/v2/item/get_list"; //POST

        public const string SHOPEE_GET_SHOPS_URL = "https://shopee.vn/api/v2/content/official_shop?catid={0}";

        //TIKI
        public const string TIKI_HOT_SEARCH_URL = "https://tiki.vn/api/v2/personalization/v2/keywords";

        public const string TIKI_GET_CATEGORY_URL = "https://tiki.vn/api/v2/personalization/v2/personalized_categories";
        //
        public const string TIKI_TOP_PRODUCTS_URL = "https://tiki.vn/api/v2/products?category_id={0}&limit={1}&page={2}&sort=top_seller";

        public const string TIKI_GET_SHOPS_URL = "https://tiki.vn/api/v2/products?category_id={0}&limit=1";

        //SENDO
        public const string SENDO_HOT_SEARCH_URL = "https://www.sendo.vn/m/wap_v2/home/top-keyword";

        public const string SENDO_GET_CATEGORY_URL = "https://www.sendo.vn/m/wap_v2/home/recommend-category";
        //
        public const string SENDO_GET_CATEGORY_ID_URL = "https://www.sendo.vn/m/wap_v2/cate-info/";
        //
        public const string SENDO_TOP_PRODUCTS_URL = "https://www.sendo.vn/m/wap_v2/category/product?category_id={0}&p={1}&sortType=norder_30_desc";

        public const string SENDO_GET_SHOPS_URL = "https://www.sendo.vn/m/wap_v2/category/product?category_id={0}&listing_algo=algo14&p=1&platform=web&s=100&shop_warehouse_city_id=1,2,15,17,20&sortType=vasup_desc";

        //LAZADA
        public const string LAZADA_TOP_PRODUCTS_URL = "https://www.lazada.vn/catalog/?ajax=true&from=input&q={0}&sort=popularity";

        public const string LAZADA_GET_MORE_URL = "https://www.lazada.vn/{0}?ajax=true&page=1&style=list&rating=5";

        public const string LAZADA_GET_SHOP_INFO_URL = "https://my.lazada.vn/seller/listSellerReviews?sellerId={0}&pageNo=1&pageSize=1";

    }
}
