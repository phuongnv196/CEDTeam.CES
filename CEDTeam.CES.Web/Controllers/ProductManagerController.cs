using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEDTeam.CES.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CEDTeam.CES.Web.Controllers
{
    [Route("product-manager")]
    public class ProductManagerController : Controller
    {
        private IProductService _productService;
        public ProductManagerController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("get-product")]
        public async Task<IActionResult> GetProduct()
        {
            int draw = int.Parse(Request.Query["draw"]);
            int start = int.Parse(Request.Query["start"]);
            int length = int.Parse(Request.Query["length"]);
            string search = Request.Query["search[value]"];

            var result = await _productService.GetProductAsync(start, length, "", 0, true);
            return new ObjectResult(result);
        }
    }
}