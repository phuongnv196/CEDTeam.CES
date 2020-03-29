using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEDTeam.CES.Core.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using CEDTeam.CES.Web.Models;
using CEDTeam.CES.Web.Controllers.Api;

namespace CEDTeam.CES.Web.Controllers.Api
{
    public class CategoryController : BaseAPIController
    {
        private readonly ICategoryService _categoryService;
        private readonly IApiService _apiService;

        public CategoryController(ICategoryService categoryService, IApiService apiService)
        {
            _categoryService = categoryService;
            _apiService = apiService;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetCategoryById(string categoryId)
        //{
        //    return new ObjectResult(await _categoryService.GetCategoryById(categoryId));
        //}

        [HttpGet]
        public async Task<IActionResult> GetCategoryById(string categoryId)
        {
            return new ObjectResult(await _categoryService.GetSubCategoryById(categoryId));
        }

        [HttpGet]
        public IActionResult GetShopById(string categoryId)
        {
            string id = categoryId.Split("_")[1];
            if (categoryId.IndexOf("shopee") > -1)
            {
                return new ObjectResult(_apiService.Shopee_GetShopByCategory(id).Adapt<ShopeeShopModel>());
            }
            else if (categoryId.IndexOf("tiki") > -1)
            {
                return new ObjectResult(_apiService.Tiki_GetShopByCategory(id).Adapt<TikiShopModel>());
            }
            else if (categoryId.IndexOf("sendo") > -1)
            {
                return new ObjectResult(_apiService.Sendo_GetShopByCategory(id).Adapt<SendoShopModel>());
            }
            return new ObjectResult(null);
        }

        [HttpGet]
        public IActionResult GetMoreLzdByUrl(string categoryPath)
        {
            return new ObjectResult(_apiService.Lazada_GetMoreLzdByCategory(categoryPath).Adapt<LazadaProductModel>());
        }
    }
}