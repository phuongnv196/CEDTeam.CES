using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CEDTeam.CES.Tool.Models;
using Dapper;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using CEDTeam.CES.Tool.Helpers;

namespace CEDTeam.CES.Tool.Repositories
{
    public class CategoryRepository : BaseRepository
    {
        public void AddCategory(List<Category> categories)
        {
            using (var db = GetConnection())
            {
               DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@category", categories.ToDataTable<Category>(new string[]{ "CategorySiteId", "CategoryName", "SiteId", "CategoryUrl", "Parent" }).AsTableValuedParameter("CategoryType"));
                db.Execute("spInsertCategories", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public bool CheckCategory(string id)
        {
            using(var db = GetConnection())
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("siteId", id, System.Data.DbType.Int32);
                var result = db.ExecuteScalar<int>("spCheckCategory", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}
