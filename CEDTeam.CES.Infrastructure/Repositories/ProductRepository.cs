using CEDTeam.CES.Core.Configs;
using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using Dapper;
using System.Threading.Tasks;

namespace CEDTeam.CES.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository 
    {
        private IBaseRepository _baseRepository;
        public ProductRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        List<string> listColumn = new List<string>
        {
            "Id", "ProductId", "Name", "Price", "CreatedDate", "Quantity", "CategoryId", "QuantitySold", "CommentCount", "Discount", "Url"
        };

        public async Task<FilterProductDto> GetProductAsync(int start, int length, string search, int columnSort, bool isAsc = true)
        {
            using(var db = _baseRepository.GetConnection())
            {
                string query = $"select count(1) from Product ;"+
                    $" select count(1) FROM Product WHERE Name LIKE N'%{search}%';  " +
                    "SELECT Id, ProductId, Name, Price, CreatedDate, Quantity, CategoryId, QuantitySold, CommentCount, Discount, Url " +
                    "FROM Product WHERE Name LIKE N'%" + search + "%' ";
                string orderBy = $" ORDER BY {listColumn[columnSort]} {(!isAsc ? "DESC" : "")}";
                string limit = $" LIMIT {start}, {length}";
                string command = $"{query} {orderBy} {limit}";
                var result = await db.QueryMultipleAsync(command);
                var filterProductDto = new FilterProductDto();
                filterProductDto.RecordsTotal = await result.ReadFirstAsync<long>();
                filterProductDto.RecordsFiltered = await result.ReadFirstAsync<long>();
                filterProductDto.Data = (await result.ReadAsync<ProductDto>()).AsList();
                return filterProductDto;
            }
        }
    }
}
