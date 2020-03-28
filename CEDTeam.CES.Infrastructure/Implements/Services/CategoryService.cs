using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Infrastructure.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<CategoryDto>> GetCategoryById(string cateId)
        {
            return await _categoryRepository.GetCategoryById(cateId);
        }
        
        public async Task<List<CategoryDto>> GetSubCategoryById(string cateId)
        {
            return await _categoryRepository.GetSubCategoryById(cateId);
        }
    }
}
