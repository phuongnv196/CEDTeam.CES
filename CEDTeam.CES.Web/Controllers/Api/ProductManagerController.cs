using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEDTeam.CES.Core.Interfaces;
using CEDTeam.CES.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CEDTeam.CES.Web.Controllers.Api
{
    
    public class ProductManagerController : BaseAPIController
    {
        private readonly IProductService _productService;
        private readonly IApiService _apiService;
        public ProductManagerController(IProductService productService, IApiService apiService)
        {
            _productService = productService;
            _apiService = apiService;
        }
        [HttpGet]
        public IActionResult GetShopeeProduct(string categoryId, int loadMore = 1)
        {
            var result = _apiService.Shopee_GetTopProductByCategoryId(categoryId.Split("_")[1], loadMore);
            return new ObjectResult(result);
        }

        [HttpGet]
        public IActionResult GetTikiProduct(string categoryId, int loadMore = 1)
        {
            var result = _apiService.Tiki_GetTopProductByCategoryId(categoryId.Split("_")[1], loadMore);
            return new ObjectResult(result);
        }

        [HttpGet]
        public IActionResult GetSendoProduct(string categoryId, int loadMore = 1)
        {
            var result = _apiService.Sendo_GetTopProductByCategoryId(categoryId.Split("_")[1], loadMore);
            return new ObjectResult(result);
        }

        [HttpGet]
        public IActionResult GetShopeeProductDetail(string itemId, string shopId)
        {
            var result = _apiService.Shopee_GetProductDetail(itemId, shopId);
            return new ObjectResult(result);
        }

        [HttpGet]
        public IActionResult GetSendoProductDetail(string urlPath)
        {
            var result = _apiService.Sendo_GetProductDetail(urlPath);
            return new ObjectResult(result);
        }

        [HttpGet]
        public IActionResult GetTikiProductDetail(string urlPath)
        {
            var result = _apiService.Tiki_GetProductDetail(urlPath);
            return new ObjectResult(result);
        }
    }
}