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
    public class ProductRepository : BaseRepository,IProductRepository 
    {
        public ProductRepository(IOptions<AppConfig> config) : base(config)
        {
        }
        List<string> listColumn = new List<string>
        {
            "Id", "ProductId", "Name", "Price", "CreatedDate", "Quantity", "CategoryId", "QuantitySold", "CommentCount", "Discount", "Url"
        };

        public async Task<List<ProductDto>> GetProductAsync(int start, int length, string search, int columnSort, bool isAsc = true)
        {
            using(var db = GetConnection())
            {
                string query = "SELECT Id, ProductId, Name, Price, CreatedDate, Quantity, CategoryId, QuantitySold, CommentCount, Discount, Url "+
                    "FROM Product WHERE Name LIKE N'%" + search + "%' ";
                string orderBy = $" ORDER BY {listColumn[columnSort]} {(!isAsc ? "DESC" : "")}";
                string limit = $" LIMIT {start}, {length}";
                return (await db.QueryAsync<ProductDto>($"{query} {orderBy} {limit}")).AsList();
            }
        }
    }
}
