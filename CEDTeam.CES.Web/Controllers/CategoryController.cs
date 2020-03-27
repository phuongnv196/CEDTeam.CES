using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEDTeam.CES.Core.Interfaces;
using CEDTeam.CES.Web.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace CEDTeam.CES.Web.Controllers
{
    [Route("Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IShopeeService _shopeeService;

        public CategoryController(ICategoryService categoryService, IShopeeService shopeeService)
        {
            _categoryService = categoryService;
            _shopeeService = shopeeService;
        }

        // Get All Cagegory Level 1
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var model = (await _categoryService.GetSubCategoryById("")).Adapt<List<CategoryViewModel>>();
            return View(model);
        }

        // Get Cagegory by id return Level 1 Or 2 Or 3
        [Route("get-sub-category-by-id")]
        public async Task<IActionResult> GetSubCategoryById(string categoryId)
        {
            return new ObjectResult(await _categoryService.GetSubCategoryById(categoryId));
        }

        [HttpGet]
        [Route("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(string categoryId)
        {
            return new ObjectResult(await _categoryService.GetSubCategoryById(categoryId));
        }

        [HttpGet]
        [Route("GetShopById")]
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