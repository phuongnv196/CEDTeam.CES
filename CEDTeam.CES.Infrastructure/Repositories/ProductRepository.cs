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
            "Id", "ProductId", "Name", "Price", "CreatedDate", "Quantity", "CategoryName", "SiteName", "QuantitySold", "CommentCount", "Discount", "UpdatedDate", "Average"
        };

        public async Task<FilterProductDto> GetProductAsync(int start, int length, string search, int columnSort, bool isAsc = true)
        {
            using(var db = _baseRepository.GetConnection())
            {
                string query = $"select count(1) from Product ;"+
                    $" select count(1) FROM Product WHERE Name LIKE N'%{search}%';  " +
                    "SELECT Id, ProductId, Name, Price, CreatedDate, Quantity, CategoryName, SiteName, QuantitySold, CommentCount, Discount, Url, UpdatedDate, ((QuantitySold * Price)/DATEDIFF(NOW(), STR_TO_DATE(CreatedDate, '%d/%m/%Y %H:%i:%s'))) AS Average " +
                    "FROM Product AS P JOIN Category AS C ON P.CategoryId = C.CategoryId " +
                    "JOIN Site AS S ON C.SiteId = S.SiteId "+
                    "WHERE Name LIKE N'%" + search + "%' ";
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

        public async Task<List<String>> GetLazadaCategoryAsync()
        {
            using (var db = _baseRepository.GetConnection())
            {
                string query = "SELECT CategoryName FROM Category WHERE SiteId = 2 AND (Parent IS NULL OR Parent = '')";
                return (await db.QueryAsync<String>(query)).AsList();
            }
        }

        public async Task<List<ShopeeKeywordDto>> GetShopeeKeywordAsync()
        {
            using (var db = _baseRepository.GetConnection())
            {
                string query = "SELECT c.CategoryName, ck.Keyword, c.CategoryUrl FROM category_keyword ck INNER JOIN category c ON c.CategoryId = ck.CategoryId ";
                return (await db.QueryAsync<ShopeeKeywordDto>(query)).AsList();
            }
        }

        public async Task<FilterProductDto> GetProductSiteIdAsync(int start, int length, string search, int columnSort, int siteId, bool isAsc = true)
        {
            string query = $"select count(1) from Product AS P JOIN Category AS C ON P.CategoryId = C.CategoryId JOIN Site AS S ON C.SiteId = S.SiteId WHERE C.SiteId="+siteId+";" +
                    $" select count(1) from Product AS P JOIN Category AS C ON P.CategoryId = C.CategoryId JOIN Site AS S ON C.SiteId = S.SiteId WHERE C.SiteId=" + siteId+$" AND Name LIKE N'%{search}%';  " +
                    "SELECT Id, ProductId, Name, Price, CreatedDate, Quantity, CategoryName, SiteName, QuantitySold, CommentCount, Discount, Url, UpdatedDate, ((QuantitySold * Price)/DATEDIFF(NOW(), STR_TO_DATE(CreatedDate, '%d/%m/%Y %H:%i:%s'))) AS Average " +
                    "FROM Product AS P JOIN Category AS C ON P.CategoryId = C.CategoryId " +
                    "JOIN Site AS S ON C.SiteId = S.SiteId " +
                    "WHERE Name LIKE N'%" + search + "%' " +
                    "AND C.SiteId=" +siteId;
            string orderBy = $" ORDER BY {listColumn[columnSort]} {(!isAsc ? "DESC" : "")}";
            string limit = $" LIMIT {start}, {length}";
            string command = $"{query} {orderBy} {limit}";
            using (var db = _baseRepository.GetConnection())
            {
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
