using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Dtos.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Core.Interfaces
{
    public interface IApiService
    {
        //Shopee
        ShopeeHotSearchDto Shopee_GetHotSearch();
        ShopeeTopProductDto Shopee_GetTopProduct();
        ShopeeShopDto Shopee_GetShopByCategory(string categoryId);
        IEnumerable<ShopeeItemData> Shopee_GetTopProductByCategoryId(string categoryId, int loadMore);
        ShopeeProductDetailDto Shopee_GetProductDetail(string itemid, string shopid);

        //Tiki
        TikiHotSearchDto Tiki_GetHotSearch();    
        TikiCategoryDto Tiki_GetCategory();
        TikiTopProductDto Tiki_GetTopProductByCategory(int id, int limit, int page);
        TikiShopDto Tiki_GetShopByCategory(string categoryId);
        IEnumerable<TikiProduct> Tiki_GetTopProductByCategoryId(string categoryId, int page = 1);
        object Tiki_GetProductDetail(string urlPath);

        //Sendo
        SendoHotSearchDto Sendo_GetHotSearch();
        ShopeeTopProductItem Shopee_GetTopProductDetail(ShopeeProductItemCollectionDto listProducts);
        SendoCategoryDto Sendo_GetCategory();
        SendoCategoryInfoDto Sendo_GetCategoryInfo(string path);
        SendoTopProductDto Sendo_GetTopProductByCategory(int id, int page);
        SendoShopDto Sendo_GetShopByCategory(string categoryId);
        IEnumerable<SendoProduct> Sendo_GetTopProductByCategoryId(string categoryId, int page = 1);
        SendoProductDetailDto Sendo_GetProductDetail(string urlPath);

        //Lazada
        LazadaProductDto Lazada_GetTopProductByCategory(string name);
        LazadaProductDto Lazada_GetProductByCategory(string categoryPath);
    }
}
