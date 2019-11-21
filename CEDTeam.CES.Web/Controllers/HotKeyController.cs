﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CEDTeam.CES.Core.Interfaces;
using CEDTeam.CES.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using CEDTeam.CES.Web.Models;

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
            return View(_apiService.GetShopeeTopProduct().Adapt<ShopeeTopProductModel>());
        }

        public IActionResult TikiTopProduct()
        {
            return View(_apiService.GetTikiTopProduct().Adapt<TikiCategoryModel>());
        }
    }
}