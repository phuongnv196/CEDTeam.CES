using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Tool.Constants
{
    public static class ApiConstant
    {
        public static class Shopee
        {
            public const string SHOPEE_BASE = "https://shopee.vn/";
            public const string CATEGORIES = "api/v2/category_list/get";
            public const string SEARCH_ITEMS = "api/v2/search_items/?by=pop&limit=50&match_id={0}&newest={1}&order=desc&page_type=search&version=2";
            public const string PROD_DETAIL = "api/v2/item/get?itemid={0}&shopid={1}";
        }
        public static class Lazada
        {
            public const string LAZADA_BASE = "https://www.lazada.vn/";
            public const string GET_PROD_AJAX = "?ajax=true&page={0}";
        }
        public static class Tiki
        {
            public const string TIKI_BASE = "https://tiki.vn/";
        }
        public static class Sendo
        {
            public const string SENDO_BASE = "https://www.sendo.vn/";
            public const string GET_PROD_AJAX = "m/wap_v2/category/product?category_id={0}&listing_algo=algo5&p={1}&platform=web&s=60&sortType=vasup_desc";
        }
    }
}
