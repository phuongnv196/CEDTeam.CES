using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{
   public class Option2
    {
        public string value { get; set; }
        public string title { get; set; }
        public int order { get; set; }
    }

    public class Option
    {
        public string value { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public int order { get; set; }
        public string id { get; set; }
        public List<Option2> options { get; set; }
    }

    public class FilterItem
    {
        public List<Option> options { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string unfoldRow { get; set; }
        public string title { get; set; }
        public string urlKey { get; set; }
        public object value { get; set; }
        public bool hidden { get; set; }
        public bool locked { get; set; }
        public string pid { get; set; }
        public string showMin { get; set; }
        public string showMax { get; set; }
    }

    public class Filter
    {
        public string tItemType { get; set; }
        public List<FilterItem> filterItems { get; set; }
        public string bizData { get; set; }
        public int pos { get; set; }
    }

    public class ItemLP
    {
        public string title { get; set; }
        public string url { get; set; }
    }

    public class TryAlso
    {
        public string tItemType { get; set; }
        public List<ItemLP> items { get; set; }
        public string bizData { get; set; }
        public int pos { get; set; }
    }

    public class Sku
    {
        public string id { get; set; }
    }

    public class Thumb
    {
        public string image { get; set; }
        public string productUrl { get; set; }
        public string sku { get; set; }
        public string skuId { get; set; }
    }

    public class AddToCartSku
    {
        public string sku { get; set; }
        public string skuId { get; set; }
        public int count { get; set; }
    }

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
        public List<Sku> skus { get; set; }
        public List<string> description { get; set; }
        public string brandId { get; set; }
        public string brandName { get; set; }
        public string sellerId { get; set; }
        public string mainSellerId { get; set; }
        public string sellerName { get; set; }
        public List<Thumb> thumbs { get; set; }
        public int restrictedAge { get; set; }
        public List<int> categories { get; set; }
        public string clickTrace { get; set; }
        public List<AddToCartSku> addToCartSkus { get; set; }
        public string itemId { get; set; }
        public string voucherId { get; set; }
        public string skuId { get; set; }
        public bool inStock { get; set; }
    }

    public class Breadcrumb
    {
        public string url { get; set; }
        public string title { get; set; }
    }

    public class SortItem
    {
        public string name { get; set; }
        public string tip { get; set; }
        public string isActive { get; set; }
        public string value { get; set; }
        public string key { get; set; }
        public string tabName { get; set; }
    }

    public class SortBar
    {
        public string tItemType { get; set; }
        public string filter { get; set; }
        public string style { get; set; }
        public List<SortItem> sortItems { get; set; }
        public bool hiddenLayoutBtn { get; set; }
    }

    public class BestShown
    {
        public string title { get; set; }
        public string url { get; set; }
    }

    public class Keyword
    {
        public string text { get; set; }
    }

    public class ResultTips
    {
        public string tItemType { get; set; }
        public string tips { get; set; }
        public string brandLink { get; set; }
        public List<Keyword> keywords { get; set; }
    }

    public class Mods
    {
        public Filter filter { get; set; }
        public TryAlso tryAlso { get; set; }
        public List<ListItem> listItems { get; set; }
        public List<Breadcrumb> breadcrumb { get; set; }
        public SortBar sortBar { get; set; }
        public BestShown bestShown { get; set; }
        public ResultTips resultTips { get; set; }
    }

    public class LayoutInfo
    {
        public List<string> listHeader { get; set; }
        public List<string> stickyHeader { get; set; }
    }

    public class TrackParams
    {
    }

    public class Style
    {
        public double width { get; set; }
        public double height { get; set; }
    }

    public class Theme
    {
        public string key { get; set; }
        public string isImgIcon { get; set; }
        public string url { get; set; }
        public string locaLang { get; set; }
        public string enLang { get; set; }
        public Style style { get; set; }
        public string text { get; set; }
    }

    public class Core
    {
        public string country { get; set; }
        public string layoutType { get; set; }
        public string language { get; set; }
        public string currencyCode { get; set; }
    }

    public class Page
    {
        public string internalSearchTerm { get; set; }
        public string bucket_id { get; set; }
        public string regCategoryId { get; set; }
        public string xParams { get; set; }
        public string SortingPattern { get; set; }
        public List<object> filters { get; set; }
        public string rn { get; set; }
        public int resultNr { get; set; }
        public string internalSearchResultType { get; set; }
    }

    public class DataLayer
    {
        public string pagetype { get; set; }
        public string pdt_category { get; set; }
        public Core core { get; set; }
        public string seller_name { get; set; }
        public int v_voya { get; set; }
        public string search_engine_used { get; set; }
        public string brand_name { get; set; }
        public Page page { get; set; }
        public string seller_id { get; set; }
        public List<string> top_catalog_skus { get; set; }
        public string brand_id { get; set; }
    }

    public class SelectedFilters
    {
    }

    public class MainInfo
    {
        public string errorMsg { get; set; }
        public int bizCode { get; set; }
        public bool isShowFloatCart { get; set; }
        public bool isHideAddToCart { get; set; }
        public string totalResults { get; set; }
        public string pageSize { get; set; }
        public string page { get; set; }
        public string RN { get; set; }
        public string style { get; set; }
        public LayoutInfo layoutInfo { get; set; }
        public string pageType { get; set; }
        public TrackParams trackParams { get; set; }
        public string anonUid { get; set; }
        public string pageTitle { get; set; }
        public string lang { get; set; }
        public string venture { get; set; }
        public string currency { get; set; }
        public string currencyOnRight { get; set; }
        public string currencySpace { get; set; }
        public string isShowFeedbackForm { get; set; }
        public string showThumbs { get; set; }
        public string addToCartURL { get; set; }
        public List<Theme> themes { get; set; }
        public string q { get; set; }
        public DataLayer dataLayer { get; set; }
        public int column { get; set; }
        public string bucketId { get; set; }
        public int auctionType { get; set; }
        public SelectedFilters selectedFilters { get; set; }
    }

    public class LazadaTopProductDto
    {
        public Mods mods { get; set; }
        public MainInfo mainInfo { get; set; }
    }
}
