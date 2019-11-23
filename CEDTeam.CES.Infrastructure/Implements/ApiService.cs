using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Interfaces;
using CEDTeam.CES.Infrastructure.Constants;
using CEDTeam.CES.Infrastructure.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Infrastructure.Implements
{
    public class ApiService : IApiService
    {
        public ShopeeHotSearchDto GetShopeeHotSearch()
        {
            return APIHelper.GetAsync<ShopeeHotSearchDto>(ApiConstant.SHOPEE_HOT_SEARCH_URL);
        }

        public TikiHotSearchDto GetTikiHotSearch()
        {
            return APIHelper.GetAsync<TikiHotSearchDto>(ApiConstant.TIKI_HOT_SEARCH_URL);
        }

        public SendoHotSearchDto GetSendoHotSearch()
        {
            return APIHelper.GetAsync<SendoHotSearchDto>(ApiConstant.SENDO_HOT_SEARCH_URL);
        }

        public ShopeeTopProductDto GetShopeeTopProduct()
        {
            return APIHelper.GetAsync<ShopeeTopProductDto>(ApiConstant.SHOPEE_TOP_PRODUCTS_URL);
        }

        public ShopeeTopProductItem GetShopeeTopProductDetail(ShopeeProductItemCollectionDto listProducts)
        {
            return APIHelper.PostAsync<ShopeeTopProductItem>(ApiConstant.SHOPEE_GET_LIST_URL, JsonConvert.SerializeObject(listProducts), "application/json");
        }

        public TikiCategoryDto GetTikiCategory()
        {
            return APIHelper.GetAsync<TikiCategoryDto>(ApiConstant.TIKI_GET_CATEGORY_URL);
        }

        public TikiTopProductDto GetTikiTopProductByCategory(int id, int limit, int page)
        {
            return APIHelper.GetAsync<TikiTopProductDto>(String.Format(ApiConstant.TIKI_TOP_PRODUCTS_BY_CATEGORY, id, limit, page));  
        }

        public SendoCategoryDto GetSendoCategory()
        {
            return APIHelper.GetAsync<SendoCategoryDto>(ApiConstant.SENDO_GET_CATEGORY_URL);
        }

        public SendoCategoryInfoDto SendoCategoryInfo(string path)
        {
            return APIHelper.GetAsync<SendoCategoryInfoDto>(ApiConstant.SENDO_GET_CATEGORY_ID_URL + path);
        }

        public SendoTopProductDto GetSendoTopProductByCategory(int id, int page)
        {
            return APIHelper.GetAsync<SendoTopProductDto>(String.Format(ApiConstant.SENDO_GET_TOP_PRODUCTS, id, page));  
        }

        public ShopeeHotKeyByCategoryDto ShopeeGetHotKeyByCategory(string cateId)
        {
            return APIHelper.GetAsync<ShopeeHotKeyByCategoryDto>(string.Format(ApiConstant.SHOPEE_GET_KEY_WORD_BY_CATEGORY_URL, cateId));
        }
    }
}
