using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEDTeam.CES.Tool.Models;
using Dapper;
using Newtonsoft.Json;

namespace CEDTeam.CES.Tool.Repositories
{
    public class CategoryRepository : BaseRepository
    {
        public void AddCategory(Category categorie)
        {
            using (var db = GetConnection())
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                string json = JsonConvert.SerializeObject(categorie);
                dynamicParameters.Add("category", json, System.Data.DbType.String);
                db.Execute("insertCategory", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void AddCategory(List<Category> categories)
        {
            using (var db = GetConnection())
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                string json = JsonConvert.SerializeObject(categories);
                dynamicParameters.Add("category", json, System.Data.DbType.String);
                db.Execute("insertCategories", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: 20);
            }
        }
        public bool CheckCategory(string id)
        {
            using(var db = GetConnection())
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("siteId", id, System.Data.DbType.String);
                return db.ExecuteScalar<int>("spCheckCategory", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure) > 0;
            }
        }
    }
}
