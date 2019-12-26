using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private IBaseRepository _baseRepository;
        public CategoryRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<List<CategoryDto>> GetCategoryById(string cateId)
        {
            using (var connection = _baseRepository.GetConnectionDev())
            {
                var param = new DynamicParameters();
                param.Add("@CategoriID", cateId);
                param.Add("@ReturnValue", null, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
                var result = await connection.QueryAsync<CategoryDto>("spGetCategoriesByID", param, commandType: System.Data.CommandType.StoredProcedure);
                return 1.Equals(param.Get<int>("@ReturnValue")) ? result.AsList() : new List<CategoryDto>();
            }
        }
        
        public async Task<List<CategoryDto>> GetSubCategoryById(string cateId)
        {
            using (var connection = _baseRepository.GetConnectionDev())
            {
                var param = new DynamicParameters();
                param.Add("@CategoriID", cateId);
                var result = await connection.QueryAsync<CategoryDto>("spGetSubCategoryById", param, commandType: System.Data.CommandType.StoredProcedure);
                return result == null ? new List<CategoryDto>() : result.AsList();
            }
        }
    }
}
