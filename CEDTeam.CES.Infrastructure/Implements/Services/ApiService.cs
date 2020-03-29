using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Dtos.Api;
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
        public ShopeeHotSearchDto Shopee_GetHotSearch()
        {
            return APIHelper.GetAsync<ShopeeHotSearchDto>(ApiConstant.SHOPEE_HOT_SEARCH_URL);
        }

        public TikiHotSearchDto Tiki_GetHotSearch()
        {
            return APIHelper.GetAsync<TikiHotSearchDto>(ApiConstant.TIKI_HOT_SEARCH_URL);
        }

        public SendoHotSearchDto Sendo_GetHotSearch()
        {
            return APIHelper.GetAsync<SendoHotSearchDto>(ApiConstant.SENDO_HOT_SEARCH_URL);
        }

        public ShopeeTopProductDto Shopee_GetTopProduct()
        {
            return APIHelper.GetAsync<ShopeeTopProductDto>(ApiConstant.SHOPEE_TOP_PRODUCTS_URL);
        }

        public ShopeeTopProductItem Shopee_GetTopProductDetail(ShopeeProductItemCollectionDto listProducts)
        {
            return APIHelper.PostAsync<ShopeeTopProductItem>(ApiConstant.SHOPEE_GET_LIST_URL, JsonConvert.SerializeObject(listProducts), "application/json");
        }

        public TikiCategoryDto Tiki_GetCategory()
        {
            return APIHelper.GetAsync<TikiCategoryDto>(ApiConstant.TIKI_GET_CATEGORY_URL);
        }

        public TikiTopProductDto Tiki_GetTopProductByCategory(int id, int limit, int page)
        {
            return APIHelper.GetAsync<TikiTopProductDto>(String.Format(ApiConstant.TIKI_TOP_PRODUCTS_URL, id, limit, page));
        }

        public SendoCategoryDto Sendo_GetCategory()
        {
            return APIHelper.GetAsync<SendoCategoryDto>(ApiConstant.SENDO_GET_CATEGORY_URL);
        }

        public SendoCategoryInfoDto Sendo_GetCategoryInfo(string path)
        {
            return APIHelper.GetAsync<SendoCategoryInfoDto>(ApiConstant.SENDO_GET_CATEGORY_ID_URL + path);
        }

        public SendoTopProductDto Sendo_GetTopProductByCategory(int id, int page)
        {
            return APIHelper.GetAsync<SendoTopProductDto>(String.Format(ApiConstant.SENDO_TOP_PRODUCTS_URL, id, page));
        }

        public LazadaProductDto Lazada_GetTopProductByCategory(string name)
        {
            return APIHelper.GetAsync<LazadaProductDto>(String.Format(ApiConstant.LAZADA_TOP_PRODUCTS_URL, name));
        }

        public ShopeeShopDto Shopee_GetShopByCategory(string categoryId)
        {
            return APIHelper.GetAsync<ShopeeShopDto>(String.Format(ApiConstant.SHOPEE_GET_SHOPS_URL, categoryId));
        }

        public TikiShopDto Tiki_GetShopByCategory(string categoryId)
        {
            return APIHelper.GetAsync<TikiShopDto>(String.Format(ApiConstant.TIKI_GET_SHOPS_URL, categoryId));
        }

        public SendoShopDto Sendo_GetShopByCategory(string categoryId)
        {
            return APIHelper.GetAsync<SendoShopDto>(String.Format(ApiConstant.SENDO_GET_SHOPS_URL, categoryId));
        }

        public LazadaProductDto Lazada_GetMoreLzdByCategory(string categoryPath)
        {
            return APIHelper.GetAsync<LazadaProductDto>(String.Format(ApiConstant.LAZADA_GET_MORE_URL, categoryPath));
        }

        public IEnumerable<ShopeeProduct> Shopee_GetTopProductByCategoryId(string categoryId)
        {
            var listShpeeProduct = new List<ShopeeProduct>();
            var taskList = new List<Task>();
            var newest = 100;
            do
            {
                string uri = $"{ApiConstant.Shopee.SHOPEE_BASE}{string.Format(ApiConstant.Shopee.SEARCH_ITEMS, categoryId, newest)}";
                var task = new Task(() =>
                {
                    var result = APIHelper.GetAsync<ShopeeSearchItem>(uri);
                    if(result != null)
                    {
                        lock (listShpeeProduct)
                        {
                            listShpeeProduct.AddRange(result.items);
                        }
                    }
                });
                task.Start();
                taskList.Add(task);
                newest += 100;
            } while (newest <= 1000);
            Task.WaitAll(taskList.ToArray());
            return listShpeeProduct;
        }
    }
}
