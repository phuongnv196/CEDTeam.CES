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

        [HttpPost]
        public IActionResult GetShopeeProduct(string categoryId, int loadMore = 1)
        {
            var result = _apiService.Shopee_GetTopProductByCategoryId(categoryId.Split("_")[1], loadMore);
            return new ObjectResult(result);
        }

        [HttpPost]
        public IActionResult GetTikiProduct(string categoryId, int loadMore = 1)
        {
            var result = _apiService.Tiki_GetTopProductByCategoryId(categoryId.Split("_")[1], loadMore);
            return new ObjectResult(result);
        }
        
        [HttpPost]
        public IActionResult GetSendoProduct(string categoryId, int loadMore = 1)
        {
            var result = _apiService.Tiki_GetTopProductByCategoryId(categoryId.Split("_")[1], loadMore);
            return new ObjectResult(result);
        }
    }
}