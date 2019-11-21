using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CEDTeam.CES.Core.Interfaces;
using CEDTeam.CES.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using CEDTeam.CES.Web.Models;
using Newtonsoft.Json;
using CEDTeam.CES.Core.Dtos;

namespace CEDTeam.CES.Web.Controllers
{
    public class HotKeyController : Controller
    {
        private readonly IApiService _apiService;
        public HotKeyController(IApiService apiService)
        {
            _apiService = apiService;
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

        public IActionResult TikiTopProduct()
        {
            var aa = _apiService.GetTikiCategory().Adapt<TikiCategoryModel>();
            return View(aa);
        }

        public IActionResult GetTikiTopProductByCategory(int id, int limit = 10, int page = 1)
        {
            var aa = _apiService.GetTikiTopProductByCategory(id, limit, page).Adapt<TikiTopProductModel>();
            return new ObjectResult(aa);
        }
    }
}