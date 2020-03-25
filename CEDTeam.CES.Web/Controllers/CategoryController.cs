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
    [Route("category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // Get All Cagegory Level 1
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var model = (await _categoryService.GetSubCategoryById("")).Adapt<List<CategoryViewModel>>();
            return View(model);
        }

        // Get All Cagegory by id return Level 2 & 3
        [Route("get-category-by-id")]
        public async Task<IActionResult> GetCategoryById(string categoryId)
        {
            return new ObjectResult(await _categoryService.GetCategoryById(categoryId));
        }

        // Get Cagegory by id return Level 1 Or 2 Or 3
        [Route("get-sub-category-by-id")]
        public async Task<IActionResult> GetSubCategoryById(string categoryId)
        {
            return new ObjectResult(await _categoryService.GetSubCategoryById(categoryId));
        }
    }
}