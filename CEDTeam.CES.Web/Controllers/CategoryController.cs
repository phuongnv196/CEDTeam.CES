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

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var model = (await _categoryService.GetSubCategoryById("")).Adapt<List<CategoryViewModel>>();
            return View(model);
        }

        [Route("get-category-by-id")]
        public async Task<IActionResult> GetCategoryById(string categoryId)
        {
            return new ObjectResult(await _categoryService.GetCategoryById(categoryId));
        }

        [Route("get-sub-category-by-id")]
        public async Task<IActionResult> GetSubCategoryById(string categoryId)
        {
            return new ObjectResult(await _categoryService.GetSubCategoryById(categoryId));
        }
    }
}