using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Dtos.Api;
using CEDTeam.CES.Core.Interfaces;
using CEDTeam.CES.Infrastructure.Constants;
using CEDTeam.CES.Infrastructure.Helpers;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
            return APIHelper.GetAsync<ShopeeShopDto>(String.Format(ApiConstant.Shopee.GET_SHOPS, categoryId));
        }

        public TikiShopDto Tiki_GetShopByCategory(string categoryId)
        {
            return APIHelper.GetAsync<TikiShopDto>(String.Format(ApiConstant.Tiki.GET_SHOPS, categoryId));
        }

        public SendoShopDto Sendo_GetShopByCategory(string categoryId)
        {
            return APIHelper.GetAsync<SendoShopDto>(String.Format(ApiConstant.Sendo.GET_SHOPS, categoryId));
        }
        public ShopeeProductDetailDto Shopee_GetProductDetail(string itemid, string shopid)
        {
            return APIHelper.GetAsync<ShopeeProductDetailDto>(String.Format(ApiConstant.Shopee.GET_PRODUCT_DETAIL, itemid, shopid));
        }
        public LazadaProductDto Lazada_GetProductByCategory(string categoryPath)
        {
            return APIHelper.GetAsync<LazadaProductDto>(String.Format(ApiConstant.Lazada.GET_PRODUCTS, categoryPath));
        }

        public IEnumerable<ShopeeItemData> Shopee_GetTopProductByCategoryId(string categoryId, int loadMore)
        {
            loadMore = loadMore > 0 ? loadMore : 1;
            var taskList = new List<Task>();
            var newest = (loadMore - 1) * 1000 + 100;
            ShopeePostItemData listProducts = new ShopeePostItemData();
            listProducts.item_shop_ids = new List<ShopeeItem>();
            do
            {
                try
                {
                    string Url = String.Format(ApiConstant.Shopee.GET_PRODUCTS, categoryId, newest);
                    var task = new Task(() =>
                    {
                        var result = APIHelper.GetAsync<ShopeeSearchItemv1>(Url);
                        if (result != null)
                        {
                            lock (listProducts.item_shop_ids)
                            {
                                listProducts.item_shop_ids.AddRange(result.items);
                            }
                        }
                    });
                    task.Start();
                    taskList.Add(task);
                }
                catch
                {
                    break;
                }
                newest += 100;
            } while (newest <= loadMore * 1000);
            Task.WaitAll(taskList.ToArray());
            ShopeeSearchItemData shopeeSearchItemData = APIHelper.PostAsync<ShopeeSearchItemData>(ApiConstant.Shopee.POST_PRODUCTS, JsonConvert.SerializeObject(listProducts), "application/json");
            return shopeeSearchItemData.items;
        }

        //public IEnumerable<ShopeeProduct> Shopee_GetTopProductByCategoryId(string categoryId, int loadMore)
        //{
        //    loadMore = loadMore > 0 ? loadMore : 1;
        //    var listShpeeProduct = new List<ShopeeProduct>();
        //    var taskList = new List<Task>();
        //    var newest = (loadMore - 1) * 1000 + 100;
        //    do
        //    {
        //        string Url = String.Format(ApiConstant.Shopee.GET_PRODUCTS, categoryId, newest);
        //        var task = new Task(() =>
        //        {
        //            var result = APIHelper.GetAsync<ShopeeSearchItem>(Url);
        //            if (result != null)
        //            {
        //                lock (listShpeeProduct)
        //                {
        //                    listShpeeProduct.AddRange(result.items);
        //                }
        //            }
        //        });
        //        task.Start();
        //        taskList.Add(task);
        //        newest += 100;
        //    } while (newest <= loadMore * 1000);
        //    Task.WaitAll(taskList.ToArray());
        //    return listShpeeProduct;
        //}

        public IEnumerable<TikiProduct> Tiki_GetTopProductByCategoryId(string categoryId, int page = 1)
        {
            var listTikiProduct = new List<TikiProduct>();
            var taskList = new List<Task>();
            page = (page < 1 ? 1 : page);
            for (int p = 4 * page - 3; p <= page * 4; p++)
            {
                string Url = String.Format(ApiConstant.Tiki.GET_PRODUCTS, categoryId, page);
                var task = new Task(() =>
                {
                    var result = APIHelper.GetAsync<TitiSearchItem>(Url);
                    if (result != null)
                    {
                        lock (listTikiProduct)
                        {
                            listTikiProduct.AddRange(result.data);
                        }
                    }
                });
                task.Start();
                taskList.Add(task);
            }
            Task.WaitAll(taskList.ToArray());
            return listTikiProduct;
        }

        public IEnumerable<SendoProduct> Sendo_GetTopProductByCategoryId(string categoryId, int page = 1)
        {
            var listSendoProduct = new List<SendoProduct>();
            var taskList = new List<Task>();
            page = (page < 1 ? 1 : page);
            for (int p = 10 * page - 9; p <= 10 * page; p++)
            {
                string uri = string.Format(ApiConstant.Sendo.GET_PRODUCTS, categoryId, page);
                var task = new Task(() =>
                {
                    var result = APIHelper.GetAsync<SendoSearchItem>(uri);
                    if (result != null)
                    {
                        lock (listSendoProduct)
                        {
                            listSendoProduct.AddRange(result.result.data);
                        }
                    }
                });
                task.Start();
                taskList.Add(task);
            }
            Task.WaitAll(taskList.ToArray());
            return listSendoProduct;
        }

        public SendoProductDetailDto Sendo_GetProductDetail(string urlPath)
        {
            return APIHelper.GetAsync<SendoProductDetailDto>(String.Format(ApiConstant.Sendo.GET_PRODUCT_DETAIL, urlPath));
        }

        public TikiProductDetailDto Tiki_GetProductDetail(string urlPath)
        {

            var rawHtml = APIHelper.GetAsync($"{ApiConstant.Tiki.TIKI_BASE}{urlPath}", false);
            
            var els = new HtmlNodeCollection(null);
            string uri = string.Format(ApiConstant.Tiki.TIKI_BASE + urlPath);
            var doc = APIHelper.GetAsync(uri, false);
            els = doc.DocumentNode.SelectNodes("//div[@data-seller-product-id]");
            return null;
        }
    }
}
