using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEDTeam.CES.Core.Interfaces;
using CEDTeam.CES.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CEDTeam.CES.Web.Controllers
{
    [CustomAuthorize]
    [Route("product-manager")]
    public class ProductManagerController : Controller
    {
        private readonly IProductService _productService;
        public ProductManagerController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(int? siteId)
        {
            ViewBag.Title = "Quản lý sản phẩm";
            switch (siteId)
            {
                case 0: ViewBag.Title = "Quản lý sản phẩm - Tất cả"; break;
                case 1: ViewBag.Title = "Quản lý sản phẩm - Shopee"; break;
                case 2: ViewBag.Title = "Quản lý sản phẩm - Lazada"; break;
                case 3: ViewBag.Title = "Quản lý sản phẩm - Tiki"; break;
                case 4: ViewBag.Title = "Quản lý sản phẩm - Sendo"; break;
            }
            return View(siteId);
        }

        [Route("get-product")]
        [HttpPost]
        public async Task<IActionResult> GetProduct()
        {
            int draw = int.Parse(Request.Form["draw"]);
            int start = int.Parse(Request.Form["start"]);
            int length = int.Parse(Request.Form["length"]);
            string search = Request.Form["search[value]"];
            int columnOrder = int.Parse(Request.Form["order[0][column]"]);
            bool isAsc = "asc".Equals(Request.Form["order[0][dir]"]);
            var result = await _productService.GetProductAsync(start, length, search, columnOrder, isAsc);
            result.Draw = draw;
            return new ObjectResult(result);
        }

        [Route("get-shopee-product")]
        [HttpPost]
        public async Task<IActionResult> GetShopeeProduct()
        {
            int draw = int.Parse(Request.Form["draw"]);
            int start = int.Parse(Request.Form["start"]);
            int length = int.Parse(Request.Form["length"]);
            string search = Request.Form["search[value]"];
            int columnOrder = int.Parse(Request.Form["order[0][column]"]);
            bool isAsc = "asc".Equals(Request.Form["order[0][dir]"]);
            var result = await _productService.GetProductWithSiteIdAsync(start, length, search, columnOrder, 1, isAsc);
            result.Draw = draw;
            return new ObjectResult(result);
        }

        [Route("get-lazada-product")]
        [HttpPost]
        public async Task<IActionResult> GetLazadaProduct()
        {
            int draw = int.Parse(Request.Form["draw"]);
            int start = int.Parse(Request.Form["start"]);
            int length = int.Parse(Request.Form["length"]);
            string search = Request.Form["search[value]"];
            int columnOrder = int.Parse(Request.Form["order[0][column]"]);
            bool isAsc = "asc".Equals(Request.Form["order[0][dir]"]);
            var result = await _productService.GetProductWithSiteIdAsync(start, length, search, columnOrder, 2, isAsc);
            result.Draw = draw;
            return new ObjectResult(result);
        }

        [Route("get-tiki-product")]
        [HttpPost]
        public async Task<IActionResult> GetTikiProduct()
        {
            int draw = int.Parse(Request.Form["draw"]);
            int start = int.Parse(Request.Form["start"]);
            int length = int.Parse(Request.Form["length"]);
            string search = Request.Form["search[value]"];
            int columnOrder = int.Parse(Request.Form["order[0][column]"]);
            bool isAsc = "asc".Equals(Request.Form["order[0][dir]"]);
            var result = await _productService.GetProductWithSiteIdAsync(start, length, search, columnOrder, 3, isAsc);
            result.Draw = draw;
            return new ObjectResult(result);
        }

        [Route("get-sendo-product")]
        [HttpPost]
        public async Task<IActionResult> GetSendoProduct()
        {
            int draw = int.Parse(Request.Form["draw"]);
            int start = int.Parse(Request.Form["start"]);
            int length = int.Parse(Request.Form["length"]);
            string search = Request.Form["search[value]"];
            int columnOrder = int.Parse(Request.Form["order[0][column]"]);
            bool isAsc = "asc".Equals(Request.Form["order[0][dir]"]);
            var result = await _productService.GetProductWithSiteIdAsync(start, length, search, columnOrder, 4, isAsc);
            result.Draw = draw;
            return new ObjectResult(result);
        }
    }
}