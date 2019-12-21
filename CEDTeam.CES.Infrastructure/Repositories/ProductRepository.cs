﻿using CEDTeam.CES.Core.Configs;
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
            "ProductId", "Name", "Price", "Quantity", "QuantitySold", "CommentCount", "Discount", "CreatedProductDate", "CreatedDate", "UpdatedDate", "Average", "SiteName", "CategoryName"
        };

        public async Task<FilterProductDto> GetProductAsync(int start, int length, string search, int columnSort, bool isAsc = true)
        {
            using(var db = _baseRepository.GetConnection())
            {
                //EXEC spGetProducts_Test @offset = 10,  @pageSize = 10, @searchString = N'', @orderBy = 'ProductId'
                var param = new DynamicParameters();
                param.Add("@offset", start);
                param.Add("@pageSize", length);
                param.Add("@searchString", search);
                param.Add("@orderBy", listColumn[columnSort]);
                param.Add("@isAsc", isAsc);


                /*string query = $"SELECT COUNT_BIG(1) FROM Product ;" +
                    $" SELECT COUNT_BIG(1) FROM Product {(string.IsNullOrWhiteSpace(search) ? "":$"WHERE CONTAINS(Name, {search})")};  " +
                    "SELECT Id, ProductId, Name, Price, Quantity, CategoryName, SiteName, QuantitySold, CommentCount, Discount, Url, CreatedProductDate, CreatedDate, UpdatedDate, CASE DATEDIFF(DAY, P.CreatedProductDate, GETUTCDATE()) WHEN 0 THEN 0 ELSE (QuantitySold/ DATEDIFF(DAY, P.CreatedProductDate, GETUTCDATE())) END AS Average " +
                    "FROM Product AS P JOIN Category AS C ON P.CategoryId = C.CategoryId " +
                    "JOIN Site AS S ON C.SiteId = S.SiteId "+
                    $"{(string.IsNullOrWhiteSpace(search) ? "":$"WHERE CONTAINS(Name, {search})")}";
                string orderBy = $" ORDER BY {listColumn[columnSort]} {(!isAsc ? "DESC" : "")}";
                string limit = $" OFFSET {start} ROWS FETCH NEXT  {length} ROWS ONLY";
                string command = $"{query} {orderBy} {limit}";

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@search", search.Replace("'", "''").Replace("%", "[%]"));
                */
                //var result = await db.QueryMultipleAsync(command, dynamicParameters);
                var result = await db.QueryMultipleAsync("spGetProducts", param, commandType: System.Data.CommandType.StoredProcedure);
                var filterProductDto = new FilterProductDto();
                filterProductDto.RecordsTotal = await result.ReadSingleAsync<long>();
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
                string query = "SELECT c.CategoryName, ck.Keyword, c.CategoryUrl FROM CategoryKeyword ck INNER JOIN Category c ON c.CategoryId = ck.CategoryId ";
                return (await db.QueryAsync<ShopeeKeywordDto>(query)).AsList();
            }
        }

        public async Task<FilterProductDto> GetProductSiteIdAsync(int start, int length, string search, int columnSort, int siteId, bool isAsc = true)
        {

            //
            //EXEC spGetProducts_Test @offset = 10,  @pageSize = 10, @searchString = N'', @orderBy = 'ProductId'
            var param = new DynamicParameters();
            param.Add("@offset", start);
            param.Add("@pageSize", length);
            param.Add("@searchString", search);
            param.Add("@siteId", siteId);
            param.Add("@orderBy", listColumn[columnSort]);
            param.Add("@isAsc", isAsc);
            //string query = $"SELECT COUNT_BIG(1) FROM Product AS P JOIN Category AS C ON P.CategoryId = C.CategoryId JOIN Site AS S ON C.SiteId = S.SiteId WHERE C.SiteId=" +siteId+";" +
            //        $" SELECT COUNT_BIG(1) FROM Product AS P JOIN Category AS C ON P.CategoryId = C.CategoryId JOIN Site AS S ON C.SiteId = S.SiteId WHERE C.SiteId=" + siteId+$" {(string.IsNullOrWhiteSpace(search) ? "" : $"WHERE CONTAINS(Name, {search})")};  " +
            //        "SELECT Id, ProductId, Name, Price, Quantity, CategoryName, SiteName, QuantitySold, CommentCount, Discount, Url, CreatedProductDate, CreatedDate, UpdatedDate, CASE DATEDIFF(DAY, P.CreatedProductDate, GETUTCDATE()) WHEN 0 THEN 0 ELSE (QuantitySold/ DATEDIFF(DAY, P.CreatedProductDate, GETUTCDATE())) END AS Average " +
            //        "FROM Product AS P JOIN Category AS C ON P.CategoryId = C.CategoryId " +
            //        "JOIN Site AS S ON C.SiteId = S.SiteId " +
            //        $"{(string.IsNullOrWhiteSpace(search) ? "":$"WHERE CONTAINS(Name, {search})")}" +
            //        "AND C.SiteId=" +siteId;
            //string orderBy = $" ORDER BY {listColumn[columnSort]} {(!isAsc ? "DESC" : "")}";
            //string limit = $" OFFSET {start} ROWS FETCH NEXT  {length} ROWS ONLY";
            //string command = $"{query} {orderBy} {limit}";
            using (var db = _baseRepository.GetConnection())
            {
                //DynamicParameters dynamicParameters = new DynamicParameters();
                //dynamicParameters.Add("@search", search.Replace("'", "''").Replace("%", "[%]"));
                var result = await db.QueryMultipleAsync("spGetProductsBySite", param, commandType: System.Data.CommandType.StoredProcedure);
                var filterProductDto = new FilterProductDto();
                filterProductDto.RecordsTotal = await result.ReadFirstAsync<long>();
                filterProductDto.RecordsFiltered = await result.ReadFirstAsync<long>();
                filterProductDto.Data = (await result.ReadAsync<ProductDto>()).AsList();
                return filterProductDto;
            }
        }
    }
}
