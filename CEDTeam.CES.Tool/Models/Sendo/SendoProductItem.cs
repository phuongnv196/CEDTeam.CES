using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Tool.Models.Sendo
{
    public partial class SendoProductItem
    {
        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("result")]
        public Result Result { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("meta_data")]
        public MetaData MetaData { get; set; }

        [JsonProperty("error")]
        public List<object> Error { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("product_id")]
        public long? ProductId { get; set; }

        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("admin_id")]
        public long? AdminId { get; set; }

        [JsonProperty("price")]
        public long? Price { get; set; }

        [JsonProperty("price_max")]
        public long? PriceMax { get; set; }

        [JsonProperty("cat_path")]
        public string CatPath { get; set; }

        [JsonProperty("total_comment")]
        public long? TotalComment { get; set; }

        [JsonProperty("order_count")]
        public long? OrderCount { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("img_url_mob")]
        public Uri ImgUrlMob { get; set; }

        [JsonProperty("brand_id")]
        public long? BrandId { get; set; }

        [JsonProperty("counter_view")]
        public long? CounterView { get; set; }

        [JsonProperty("special_price")]
        public long? SpecialPrice { get; set; }

        [JsonProperty("final_price")]
        public long? FinalPrice { get; set; }

        [JsonProperty("final_price_max")]
        public long? FinalPriceMax { get; set; }

        [JsonProperty("is_promotion")]
        public long? IsPromotion { get; set; }

        [JsonProperty("promotion_percent")]
        public long? PromotionPercent { get; set; }

        [JsonProperty("shop_info")]
        public ShopInfo ShopInfo { get; set; }

        [JsonProperty("options")]
        public Options Options { get; set; }

        [JsonProperty("rating_info")]
        public RatingInfo RatingInfo { get; set; }

        [JsonProperty("is_keyword_ads")]
        public long? IsKeywordAds { get; set; }

        [JsonProperty("sku_user")]
        public string SkuUser { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("product_type")]
        public long? ProductType { get; set; }

        [JsonProperty("discount_app")]
        public long? DiscountApp { get; set; }

        [JsonProperty("product_mall")]
        public long? ProductMall { get; set; }

        [JsonProperty("stock_percent")]
        public string StockPercent { get; set; }

        [JsonProperty("stock_title")]
        public string StockTitle { get; set; }

        [JsonProperty("source_block_id")]
        public string SourceBlockId { get; set; }

        [JsonProperty("is_event")]
        public long? IsEvent { get; set; }

        [JsonProperty("status_new")]
        public long? StatusNew { get; set; }

        [JsonProperty("final_promotion_percent")]
        public long? FinalPromotionPercent { get; set; }

        [JsonProperty("total_rated")]
        public long? TotalRated { get; set; }

        [JsonProperty("url_icon_event")]
        public Uri UrlIconEvent { get; set; }

        [JsonProperty("is_express")]
        public bool IsExpress { get; set; }

        [JsonProperty("original_price")]
        public string OriginalPrice { get; set; }

        [JsonProperty("min_price")]
        public string MinPrice { get; set; }

        [JsonProperty("min_max_price")]
        public string MinMaxPrice { get; set; }

        [JsonProperty("promotion_percent_upto")]
        public string PromotionPercentUpto { get; set; }

        [JsonProperty("is_config_variant")]
        public bool IsConfigVariant { get; set; }

        [JsonProperty("final_price_app")]
        public long? FinalPriceApp { get; set; }

        [JsonProperty("final_price_max_app")]
        public long? FinalPriceMaxApp { get; set; }

        [JsonProperty("default_listing_score")]
        public DefaultListingScore DefaultListingScore { get; set; }

        [JsonProperty("listing_score_v2")]
        public ListingScoreV2 ListingScoreV2 { get; set; }

        [JsonProperty("session_key_server")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? SessionKeyServer { get; set; }

        [JsonProperty("result_type")]
        public long? ResultType { get; set; }

        [JsonProperty("voucher")]
        public Voucher Voucher { get; set; }

        [JsonProperty("is_event_frame")]
        public long? IsEventFrame { get; set; }

        [JsonProperty("shop_brand_type")]
        public long? ShopBrandType { get; set; }

        [JsonProperty("counter_like")]
        public long? CounterLike { get; set; }

        [JsonProperty("img_url")]
        public Uri ImgUrl { get; set; }

        [JsonProperty("shop_name")]
        public string ShopName { get; set; }

        [JsonProperty("percent_star")]
        public double PercentStar { get; set; }

        [JsonProperty("order_count_dd_1000_cod")]
        public long? OrderCountDd1000_Cod { get; set; }

        [JsonProperty("is_certified")]
        public long? IsCertified { get; set; }

        [JsonProperty("free_shipping")]
        public long? FreeShipping { get; set; }

        [JsonProperty("is_product_installment")]
        public bool IsProductInstallment { get; set; }

        [JsonProperty("is_senmall")]
        public long? IsSenmall { get; set; }

        [JsonProperty("algo")]
        public Algo Algo { get; set; }

        [JsonProperty("square_type")]
        public long? SquareType { get; set; }

        [JsonProperty("category_id")]
        public string CategoryId { get; set; }

        [JsonProperty("promotion_note")]
        public string PromotionNote { get; set; }

        [JsonProperty("flash_deal_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? FlashDealId { get; set; }
    }

    public partial class DefaultListingScore
    {
        [JsonProperty("score_cate2")]
        public long? ScoreCate2 { get; set; }

        [JsonProperty("score_cate3")]
        public long? ScoreCate3 { get; set; }
    }

    public partial class ListingScoreV2
    {
        [JsonProperty("score_v2")]
        public long? ScoreV2 { get; set; }

        [JsonProperty("updated_at")]
        public long? UpdatedAt { get; set; }
    }

    public partial class Options
    {
        [JsonProperty("is_shipping_fee_support")]
        public long? IsShippingFeeSupport { get; set; }

        [JsonProperty("is_installment")]
        public bool IsInstallment { get; set; }

        [JsonProperty("is_loyalty")]
        public long? IsLoyalty { get; set; }
    }

    public partial class RatingInfo
    {
        [JsonProperty("total_rated")]
        public long? TotalRated { get; set; }

        [JsonProperty("percent_star_rating")]
        public double PercentStarRating { get; set; }

        [JsonProperty("percent_star")]
        public double PercentStar { get; set; }
    }

    public partial class ShopInfo
    {
        [JsonProperty("shop_name")]
        public string ShopName { get; set; }

        [JsonProperty("good_review_percent")]
        public GoodReviewPercent GoodReviewPercent { get; set; }

        [JsonProperty("is_certified")]
        public IsCertified IsCertified { get; set; }

        [JsonProperty("listTime")]
        public ListTime ListTime { get; set; }

        [JsonProperty("shop_mall")]
        public long? ShopMall { get; set; }

        [JsonProperty("shop_brand_type")]
        public long? ShopBrandType { get; set; }
    }

    public partial class ListTime
    {
        [JsonProperty("delivery_info")]
        public long? DeliveryInfo { get; set; }

        [JsonProperty("installment")]
        public long? Installment { get; set; }
    }

    public partial class Voucher
    {
        [JsonProperty("end_date")]
        public long? EndDate { get; set; }

        [JsonProperty("is_check_date")]
        public bool IsCheckDate { get; set; }

        [JsonProperty("product_type")]
        public long? ProductType { get; set; }

        [JsonProperty("start_date")]
        public long? StartDate { get; set; }
    }

    public partial class MetaData
    {
        [JsonProperty("experiment_id")]
        public long? ExperimentId { get; set; }

        [JsonProperty("special_res")]
        public long? SpecialRes { get; set; }

        [JsonProperty("total_count")]
        public long? TotalCount { get; set; }

        [JsonProperty("type_view")]
        public string TypeView { get; set; }

        [JsonProperty("search_algo")]
        public string SearchAlgo { get; set; }

        [JsonProperty("source_info")]
        public SourceInfo SourceInfo { get; set; }

        [JsonProperty("belong_tab")]
        public string BelongTab { get; set; }

        [JsonProperty("current_page")]
        public long? CurrentPage { get; set; }

        [JsonProperty("duplicate_res")]
        public long? DuplicateRes { get; set; }

        [JsonProperty("suggest_text")]
        public string SuggestText { get; set; }

        [JsonProperty("location_data")]
        public LocationData LocationData { get; set; }

        [JsonProperty("total_page")]
        public long? TotalPage { get; set; }
    }

    public partial class LocationData
    {
        [JsonProperty("city_id")]
        public string CityId { get; set; }

        [JsonProperty("city_name")]
        public string CityName { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }

    public partial class SourceInfo
    {
        [JsonProperty("source_block_id")]
        public string SourceBlockId { get; set; }

        [JsonProperty("source_page_id")]
        public string SourcePageId { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("code")]
        public long? Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public enum Algo { Default };

    public partial struct GoodReviewPercent
    {
        public double? Double;
        public string String;

        public static implicit operator GoodReviewPercent(double Double) => new GoodReviewPercent { Double = Double };
        public static implicit operator GoodReviewPercent(string String) => new GoodReviewPercent { String = String };
    }

    public partial struct IsCertified
    {
        public long? Integer;
        public string String;

        public static implicit operator IsCertified(long Integer) => new IsCertified { Integer = Integer };
        public static implicit operator IsCertified(string String) => new IsCertified { String = String };
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                AlgoConverter.Singleton,
                GoodReviewPercentConverter.Singleton,
                IsCertifiedConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class AlgoConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Algo) || t == typeof(Algo?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "default")
            {
                return Algo.Default;
            }
            throw new Exception("Cannot unmarshal type Algo");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Algo)untypedValue;
            if (value == Algo.Default)
            {
                serializer.Serialize(writer, "default");
                return;
            }
            throw new Exception("Cannot marshal type Algo");
        }

        public static readonly AlgoConverter Singleton = new AlgoConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class GoodReviewPercentConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(GoodReviewPercent) || t == typeof(GoodReviewPercent?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                case JsonToken.Float:
                    var doubleValue = serializer.Deserialize<double>(reader);
                    return new GoodReviewPercent { Double = doubleValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new GoodReviewPercent { String = stringValue };
            }
            throw new Exception("Cannot unmarshal type GoodReviewPercent");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (GoodReviewPercent)untypedValue;
            if (value.Double != null)
            {
                serializer.Serialize(writer, value.Double.Value);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            throw new Exception("Cannot marshal type GoodReviewPercent");
        }

        public static readonly GoodReviewPercentConverter Singleton = new GoodReviewPercentConverter();
    }

    internal class IsCertifiedConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(IsCertified) || t == typeof(IsCertified?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new IsCertified { Integer = integerValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new IsCertified { String = stringValue };
            }
            throw new Exception("Cannot unmarshal type IsCertified");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (IsCertified)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            throw new Exception("Cannot marshal type IsCertified");
        }

        public static readonly IsCertifiedConverter Singleton = new IsCertifiedConverter();
    }

}
