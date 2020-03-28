using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Web.Models
{
    public class ListItem
    {
        public string name { get; set; }
        public string nid { get; set; }
        public List<object> icons { get; set; }
        public string productUrl { get; set; }
        public string image { get; set; }
        public string originalPrice { get; set; }
        public string originalPriceShow { get; set; }
        public string price { get; set; }
        public string promotionId { get; set; }
        public string priceShow { get; set; }
        public string discount { get; set; }
        public string ratingScore { get; set; }
        public string review { get; set; }
        public string installment { get; set; }
        public string tItemType { get; set; }
        public string location { get; set; }
        public string cheapest_sku { get; set; }
        public string sku { get; set; }
        public List<string> description { get; set; }
        public string brandId { get; set; }
        public string brandName { get; set; }
        public string sellerId { get; set; }
        public string mainSellerId { get; set; }
        public string sellerName { get; set; }
        public int? restrictedAge { get; set; }
        public List<int> categories { get; set; }
        public string clickTrace { get; set; }
        public string itemId { get; set; }
        public string voucherId { get; set; }
        public string skuId { get; set; }
        public bool inStock { get; set; }
    }

    public class Mods
    {
        public List<ListItem> listItems { get; set; }
    }

    public class LazadaProductModel
    {
        public Mods mods { get; set; }
    }
}