using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CEDTeam.CES.Core.Interfaces;
using CEDTeam.CES.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using Newtonsoft.Json;
using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Web.Helpers;

namespace CEDTeam.CES.Web.Controllers
{
    [CustomAuthorize]
    public class HotKeyController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IProductService _productService;
        public HotKeyController(IApiService apiService, IProductService productService)
        {
            _apiService = apiService;
            _productService = productService;
        }
        public IActionResult Index()
        {
            var model = new HotKeyModel()
            {
                Shopee = _apiService.GetShopeeHotSearch().Adapt<ShopeeHotSearchModel>(),
                Tiki = _apiService.GetTikiHotSearch().Adapt<TikiHotSearchModel>(),
                Sendo = _apiService.GetSendoHotSearch().Adapt<SendoHotSearchModel>()
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ShopeeTopProduct()
        {
            var model = _apiService.GetShopeeTopProduct().Adapt<ShopeeTopProductModel>();
            ViewBag.Json = JsonConvert.SerializeObject(model.data.categories);
            return View(model);
        }

        [HttpPost]
        public IActionResult ShopeeHotProductDetail([FromBody]ShopeeProductItemCollectionModel productItems)
        {
            var model = _apiService.GetShopeeTopProductDetail(productItems.Adapt<ShopeeProductItemCollectionDto>()).Adapt<ShopeeTopProductItemModel>();
            return PartialView(model);
        }

        public IActionResult ShopeeKeywordByCategory()
        {
            var model = _productService.GetShopeeKeywordAsync().Result.Adapt<List<ShopeeKeywordModel>>();
            return PartialView(model.GroupBy(item => item.CategoryName).ToList());
        }

        public IActionResult TikiTopProduct()
        {
            var model = _apiService.GetTikiCategory().Adapt<TikiCategoryModel>();
            return View(model);
        }

        public IActionResult TikiTopProductByCategory(int id, int limit = 100, int page = 1)
        {
            var model = _apiService.GetTikiTopProductByCategory(id, limit, page).Adapt<TikiTopProductModel>();
            return PartialView(model);
        }

        public IActionResult SendoTopProduct()
        {
            var model = _apiService.GetSendoCategory().Adapt<SendoCategoryModel>();
            return View(model);
        }

        public IActionResult SendoTopProductByCategory(string path)
        {
            var model = _apiService.SendoCategoryInfo(path).Adapt<SendoCategoryInfoDto>();
            int id = model.result.meta_data.category_id;
            var model1 = _apiService.GetSendoTopProductByCategory(id, 1).Adapt<SendoTopProductModel>();
            return PartialView(model1);
        }

        public IActionResult LazadaTopProduct()
        {
            var model = _productService.GetLazadaCategoryAsync();
            return View(model.Result);
        }

        public IActionResult LazadaTopProductByCategory(string name)
        {
            var result = _apiService.GetLazadaTopProductByCategory(name);
            var model = result.Adapt<LazadaTopProductModel>();
            return PartialView(model);
        }
    }
}