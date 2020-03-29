//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using CEDTeam.CES.Core.Interfaces;
//using CEDTeam.CES.Web.Models;
//using Microsoft.AspNetCore.Mvc;
//using Mapster;
//using Newtonsoft.Json;
//using CEDTeam.CES.Core.Dtos;
//using CEDTeam.CES.Web.Helpers;

//namespace CEDTeam.CES.Web.Controllers.Api
//{
//    public class HotKeyController : BaseAPIController
//    {
//        private readonly IApiService _apiService;
//        private readonly IProductService _productService;
//        public HotKeyController(IApiService apiService, IProductService productService)
//        {
//            _apiService = apiService;
//            _productService = productService;
//        }

//        [HttpGet]
//        public IActionResult ShopeeTopProduct()
//        {
//            var model = _apiService.Shopee_GetTopProduct().Adapt<ShopeeTopProductModel>();
//            return new ObjectResult(model);
//        }

//        [HttpPost]
//        public IActionResult ShopeeHotProductDetail([FromBody]ShopeeProductItemCollectionModel productItems)
//        {
//            var model = _apiService.Shopee_GetTopProductDetail(productItems.Adapt<ShopeeProductItemCollectionDto>()).Adapt<ShopeeTopProductItemModel>();
//            return new ObjectResult(model);
//        }

//        [HttpGet]
//        public IActionResult ShopeeKeywordByCategory()
//        {
//            var model = _productService.GetShopeeKeywordAsync().Result.Adapt<List<ShopeeKeywordModel>>();
//            return new ObjectResult(model.GroupBy(item => item.CategoryName).ToList());
//        }

//        [HttpGet]
//        public IActionResult TikiTopProduct()
//        {
//            var model = _apiService.Tiki_GetCategory().Adapt<TikiCategoryModel>();
//            return new ObjectResult(model);
//        }

//        [HttpGet]
//        public IActionResult TikiTopProductByCategory(int id, int limit = 100, int page = 1)
//        {
//            var model = _apiService.Tiki_GetTopProductByCategory(id, limit, page).Adapt<TikiTopProductModel>();
//            return new ObjectResult(model);
//        }

//        [HttpGet]
//        public IActionResult SendoTopProduct()
//        {
//            var model = _apiService.Sendo_GetCategory().Adapt<SendoCategoryModel>();
//            return new ObjectResult(model);
//        }

//        [HttpGet]
//        public IActionResult SendoTopProductByCategory(string path)
//        {
//            var model = _apiService.Sendo_GetCategoryInfo(path).Adapt<SendoCategoryInfoDto>();
//            int id = model.result.meta_data.category_id;
//            var model1 = _apiService.Sendo_GetTopProductByCategory(id, 1).Adapt<SendoTopProductModel>();
//            return new ObjectResult(model1);
//        }

//        [HttpGet]
//        public IActionResult LazadaTopProduct()
//        {
//            var model = _productService.GetLazadaCategoryAsync();
//            return new ObjectResult(model.Result);
//        }

//        [HttpGet]
//        public IActionResult LazadaTopProductByCategory(string name)
//        {
//            var result = _apiService.Lazada_GetTopProductByCategory(name);
//            var model = result.Adapt<LazadaProductModel>();
//            return new ObjectResult(model);
//        }
//    }
//}