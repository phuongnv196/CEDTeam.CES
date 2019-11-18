using CEDTeam.CES.Tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Newtonsoft.Json;

namespace CEDTeam.CES.Tool.Repositories
{
    public class ProductRepository : BaseRepository
    {
        public void InsertProduct(List<Product> products)
        {
            var listId = CheckExistProduct(products.Select(i => i.ProductId).ToList());
            var listUpdate = products.Where(item => listId.Contains(item.ProductId)).ToList();
            var listInsert = products.Where(item => !listId.Contains(item.ProductId)).ToList();
            if (listUpdate.Count > 0)
            {
                UpdateProduct(listUpdate);
            }
            if(listInsert.Count > 0)
            {
                using (var db = GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("listProduct", JsonConvert.SerializeObject(listInsert));
                    db.Execute("insertProduct", param, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
        } 
        public List<string> CheckExistProduct(List<string> productIds)
        {
            using (var db = GetConnection())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("listProductId", JsonConvert.SerializeObject(productIds));
                var listId = db.Query<string>("checkExistProduct", param, commandType: System.Data.CommandType.StoredProcedure);
                return listId.Select(item => item.Replace("\"", "")).ToList();
            }
        }
        public void UpdateProduct(List<Product> products)
        {
            using (var db = GetConnection())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("listProduct", JsonConvert.SerializeObject(products));
                db.Execute("updateProduct", param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
