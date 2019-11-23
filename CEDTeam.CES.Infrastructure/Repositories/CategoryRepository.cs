using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace CEDTeam.CES.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IBaseRepository _baseRepository;
        public CategoryRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public List<CategoryDto> GetCategorysBySiteId(int siteId)
        {
            using(var db = _baseRepository.GetConnection())
            {
                return db.Query<CategoryDto>($"select CategoryId as Id, CategoryName as Name, CategorySiteId as SiteId, CategoryUrl as Url, Parent from Category where SiteId = {siteId} AND (Parent <> '')").AsList();
            }
        }
    }
}
