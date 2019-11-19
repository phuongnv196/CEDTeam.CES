using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Infrastructure.Implements
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<FilterProductDto> GetProductAsync(int start, int length, string search, int columnSort, bool isAsc = true)
        {
            return await _productRepository.GetProductAsync(start, length, search, columnSort, isAsc);
        }
    }
}
