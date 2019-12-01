using CEDTeam.CES.Tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using System.Data;
using CEDTeam.CES.Tool.Helpers;

namespace CEDTeam.CES.Tool.Repositories
{
    public class ProductRepository : BaseRepository
    {
        public int InsertProducts(List<Product> products)
        {
            try
            {
                products = products.Distinct().ToList();
                DynamicParameters dynamicParameters = new DynamicParameters();
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ProductId", typeof(string));
                dataTable.Columns.Add("Name", typeof(string));
                dataTable.Columns.Add("Price", Nullable.GetUnderlyingType(typeof(float?)));
                dataTable.Columns.Add("CreatedProductDate", typeof(DateTime));
                dataTable.Columns.Add("Quantity", Nullable.GetUnderlyingType(typeof(int?)));
                dataTable.Columns.Add("CategoryUrl", typeof(string));
                dataTable.Columns.Add("QuantitySold", Nullable.GetUnderlyingType(typeof(int?)));
                dataTable.Columns.Add("CommentCount", Nullable.GetUnderlyingType(typeof(int?)));
                dataTable.Columns.Add("Discount", typeof(string));
                dataTable.Columns.Add("VariableJson", typeof(string));
                dataTable.Columns.Add("Url", typeof(string));

                products.ForEach(item =>
                {
                    var row = dataTable.NewRow();
                    row["ProductId"] = item.ProductId;
                    row["Name"] = item.Name;
                    row["Price"] = item.Price;
                    row["CreatedProductDate"] = item.CreatedProductDate??DateTime.UtcNow;
                    row["Quantity"] = (object)item.Quantity ?? DBNull.Value;
                    row["CategoryUrl"] = item.CategoryUrl;
                    row["QuantitySold"] = (object)item.QuantitySold ?? DBNull.Value;
                    row["CommentCount"] = (object)item.CommentCount ?? DBNull.Value;
                    row["Discount"] = item.Discount?.Replace("%", "").Replace("-", "");
                    row["VariableJson"] = item.VariableJson;
                    row["Url"] = item.Url;
                    dataTable.Rows.Add(row);
                });

                dynamicParameters.Add("@Products", dataTable.AsTableValuedParameter("ProductType")); ;
                using (var db = GetConnection())
                {
                    return db.Execute("spInsertProducts", dynamicParameters, commandType: CommandType.StoredProcedure);
                }
            } catch(Exception e)
            {
                throw e;
            }
            
        }
    }
}
