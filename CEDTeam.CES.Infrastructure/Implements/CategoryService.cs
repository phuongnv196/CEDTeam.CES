using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Infrastructure.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<CategoryDto> GetCategorysBySiteId(int siteId)
        {
            return _categoryRepository.GetCategorysBySiteId(siteId);
        }
    }
}
