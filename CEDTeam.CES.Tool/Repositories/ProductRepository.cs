using CEDTeam.CES.Tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

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
                    //DynamicParameters param = new DynamicParameters();
                    //param.Add("listProduct", JsonConvert.SerializeObject(listInsert));
                    //try
                    //{
                    //    db.Execute("insertProduct", param, commandType: System.Data.CommandType.StoredProcedure);

                    //}
                    //catch(Exception e)
                    //{

                    //}
                    var a = products.FirstOrDefault().CategoryUrl;
                    var cateId = db.ExecuteScalar<long>($"select CategoryId from Category where CategoryUrl = '{MySqlHelper.EscapeString(a)}' limit 1;");
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine();
                    stringBuilder.AppendLine("insert into Product(ProductId, Name, Price, CreatedDate, Quantity, CategoryId, QuantitySold, CommentCount, Discount, VariableJson, Url) ");
                    stringBuilder.AppendLine("VALUES ");
                    int count = 0;
                    listInsert.ForEach(item => {
                        count++;
                        if (count < listInsert.Count)
                        {
                            stringBuilder.AppendLine($"('{item.ProductId ?? ""}'," +
                                $"'{MySqlHelper.EscapeString(item.Name ?? "")}'," +
                                $"{item.Price}," +
                                $"'{MySqlHelper.EscapeString(item.CreatedDate.HasValue? item.CreatedDate.Value.ToString("dd/mm/yyyy hh:MM:ss tt") : "")}'," +
                                $"{item.Quantity}," +
                                $"{cateId}," +
                                $"{item.QuantitySold}," +
                                $"{item.CommentCount}," +
                                $"'{MySqlHelper.EscapeString(item.Discount ?? "")}'," +
                                $"'{MySqlHelper.EscapeString(item.VariableJson ?? "")}'," +
                                $"'{MySqlHelper.EscapeString(item.Url ?? "")}'),");
                        }
                        else
                        {
                            stringBuilder.AppendLine($"({item.ProductId ?? ""}," +
                                $"'{MySqlHelper.EscapeString(item.Name ?? "")}'," +
                                $"{item.Price}," +
                                $"'{MySqlHelper.EscapeString(item.CreatedDate.HasValue ? item.CreatedDate.Value.ToString("dd/mm/yyyy hh:MM:ss tt") : "")}'," +
                                $"{item.Quantity}," +
                                $"{cateId}," +
                                $"{item.QuantitySold}," +
                                $"{item.CommentCount}," +
                                $"'{MySqlHelper.EscapeString(item.Discount ?? "")}'," +
                                $"'{MySqlHelper.EscapeString(item.VariableJson ?? "")}'," +
                                $"'{MySqlHelper.EscapeString(item.Url ?? "")}');");
                        }
                    });

                    db.Execute(stringBuilder.ToString());
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
                return listId.ToList();
            }
        }
        public void UpdateProduct(List<Product> products)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("SET SQL_SAFE_UPDATES = 0;");
            products.ForEach(item => {
                stringBuilder.AppendLine($"update Product set  " +
                    $"Name='{MySqlHelper.EscapeString(item.Name??"")}', " +
                    $"Price={item.Price}, " +
                    $"Quantity={item.Quantity}, " +
                    $"QuantitySold={item.QuantitySold}, " +
                    $"CommentCount={item.CommentCount}, " +
                    $"Discount='{MySqlHelper.EscapeString(item.Discount??"")}', " +
                    $"VariableJson='{MySqlHelper.EscapeString(item.VariableJson??"")}', " +
                    $"Url='{MySqlHelper.EscapeString(item.Url??"")}' " +
                    $"where ProductId = '{MySqlHelper.EscapeString(item.ProductId ?? "")}';");
            });
            stringBuilder.Append("SET SQL_SAFE_UPDATES = 1;");

            using (var db = GetConnection())
            {
                //DynamicParameters param = new DynamicParameters();
                //param.Add("listProduct", JsonConvert.SerializeObject(products));
                //db.Execute("updateProduct", param, commandType: System.Data.CommandType.StoredProcedure);
                db.Execute(stringBuilder.ToString());
            }
        }
    }
}
