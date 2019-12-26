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
            using (var connection = new SqlConnection("Data Source=vinet.ddns.net,2021;Initial Catalog=CES_Crawl_Dev;Persist Security Info=True;User ID=sa;Password=ces@2019"))
            {
                var param = new DynamicParameters();
                param.Add("@CategoriID", cateId);
                param.Add("@ReturnValue", null, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
                var result = await connection.QueryAsync<CategoryDto>("spGetCategoriesByID", param, commandType: System.Data.CommandType.StoredProcedure);
                return 1.Equals(param.Get<int>("@ReturnValue")) ? result.AsList() : new List<CategoryDto>();
            }
        }
    }
}
