using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEDTeam.CES.Core.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CEDTeam.CES.Web.Models;

namespace CEDTeam.CES.Web.Controllers.api
{
    public class CategoryController : BaseAPIController
    {
        private readonly ICategoryService _categoryService;
        private readonly IShopeeService _shopeeService;

        public CategoryController(ICategoryService categoryService, IShopeeService shopeeService)
        {
            _categoryService = categoryService;
            _shopeeService = shopeeService;
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
                return new ObjectResult(_shopeeService.GetShopByCategoryId(id).Adapt<ShopeeShopModel>());
            }
            return new ObjectResult(null);
        }
    }
}