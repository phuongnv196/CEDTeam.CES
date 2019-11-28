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
        public int InsertProduct(List<Product> products)
        {
            try
            {
                var listId = CheckExistProduct(products.Select(i => i.ProductId).ToList());
                var listUpdate = products.Where(item => listId.Contains(item.ProductId)).ToList();
                var listInsert = products.Where(item => !listId.Contains(item.ProductId)).ToList();
                int countRowAffected = 0;
                if (listUpdate.Count > 0)
                {
                    UpdateProduct(listUpdate);
                    countRowAffected += listUpdate.Count;
                }
                if (listInsert.Count > 0)
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
                        stringBuilder.AppendLine("insert into Product(ProductId, Name, Price, CreatedDate, Quantity, CategoryId, QuantitySold, CommentCount, Discount, VariableJson, Url, Created_Date) ");
                        stringBuilder.AppendLine("VALUES ");
                        int count = 0;
                        listInsert.ForEach(item =>
                        {
                            count++;
                            if (count < listInsert.Count)
                            {
                                stringBuilder.AppendLine($"('{item.ProductId ?? ""}'," +
                                    $"'{MySqlHelper.EscapeString(item.Name ?? "")}'," +
                                    $"{item.Price}," +
                                    $"'{MySqlHelper.EscapeString(item.CreatedDate.HasValue ? item.CreatedDate.Value.ToString("dd/MM/yyyy hh:mm:ss tt") : (DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")))}'," +
                                    $"{item.Quantity}," +
                                    $"{cateId}," +
                                    $"{item.QuantitySold}," +
                                    $"{item.CommentCount}," +
                                    $"'{MySqlHelper.EscapeString(item.Discount ?? "")}'," +
                                    $"'{MySqlHelper.EscapeString(item.VariableJson ?? "")}'," +
                                    $"'{MySqlHelper.EscapeString(item.Url ?? "")}', " +
                                    $"utc_timestamp()),");
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
                                    $"'{MySqlHelper.EscapeString(item.Url ?? "")}', " +
                                    $"utc_timestamp());");
                            }
                        });

                        countRowAffected += db.Execute(stringBuilder.ToString());
                    }
                }
                return countRowAffected;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<string> CheckExistProduct(List<string> productIds)
        {
            using (var db = GetConnection())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("listProductId", JsonConvert.SerializeObject(productIds));
                var listId = db.Query<string>("checkExistProducts", param, commandType: System.Data.CommandType.StoredProcedure);
                return listId.ToList();
            }
        }
        public int UpdateProduct(List<Product> products)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("SET SQL_SAFE_UPDATES = 0;");
            //products.ForEach(item =>
            //{
            //    stringBuilder.AppendLine($"update Product set  " +
            //        $"p.Name='{MySqlHelper.EscapeString(item.Name ?? "")}', " +
            //        $"p.Price={item.Price}, " +
            //        $"p.Quantity={item.Quantity}, " +
            //        $"p.QuantitySold={item.QuantitySold}, " +
            //        $"p.CommentCount={item.CommentCount}, " +
            //        $"p.Discount='{MySqlHelper.EscapeString(item.Discount ?? "")}', " +
            //        $"p.VariableJson='{MySqlHelper.EscapeString(item.VariableJson ?? "")}', " +
            //        $"p.Url='{MySqlHelper.EscapeString(item.Url ?? "")}', " +
            //        $"UpdatedDate = utc_timestamp() " +
            //        $"where ProductId = '{MySqlHelper.EscapeString(item.ProductId ?? "")}';");
            //});
            stringBuilder.Append("SET SQL_SAFE_UPDATES = 0; DROP TEMPORARY TABLE IF EXISTS productTemp;" +
            "CREATE TEMPORARY TABLE productTemp(ProductId VARCHAR(50) PRIMARY KEY,Name Text,Price FLOAT,Quantity INT(7),QuantitySold INT(7),CommentCount BIGINT(10),Discount VARCHAR(20),VariableJson TEXT,Url TEXT); ");
            stringBuilder.AppendLine("insert into productTemp(ProductId, Name, Price, Quantity, QuantitySold, CommentCount, Discount, VariableJson, Url) ");
            stringBuilder.AppendLine("VALUES ");
            int count = 0;
            products.ForEach(item =>
            {
                count++;
                if (count < products.Count)
                {
                    stringBuilder.AppendLine($"('{item.ProductId ?? ""}'," +
                        $"'{MySqlHelper.EscapeString(item.Name ?? "")}'," +
                        $"{item.Price}," +
                        $"{item.Quantity}," +
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
                        $"{item.Quantity}," +
                        $"{item.QuantitySold}," +
                        $"{item.CommentCount}," +
                        $"'{MySqlHelper.EscapeString(item.Discount ?? "")}'," +
                        $"'{MySqlHelper.EscapeString(item.VariableJson ?? "")}'," +
                        $"'{MySqlHelper.EscapeString(item.Url ?? "")}');");
                }
            });
            stringBuilder.AppendLine(
            "UPDATE Product as p JOIN productTemp pt ON p.ProductId = pt.ProductId " +
            "SET p.Name = pt.Name,p.Price = pt.Price,p.Quantity = pt.Quantity,p.QuantitySold = pt.QuantitySold, " +
            "    p.CommentCount = p.CommentCount,p.Discount = p.Discount,p.VariableJson = p.VariableJson, " +
            "    p.Url = p.Url,p.UpdatedDate = utc_timestamp(); " +
            "DROP TABLE productTemp; " +
            "SET SQL_SAFE_UPDATES = 1; ");


            stringBuilder.Append("SET SQL_SAFE_UPDATES = 1;");

            using (var db = GetConnection())
            {
                //DynamicParameters param = new DynamicParameters();
                //param.Add("listProduct", JsonConvert.SerializeObject(products));
                //db.Execute("updateProduct", param, commandType: System.Data.CommandType.StoredProcedure);
                return db.Execute(stringBuilder.ToString());
            }
        }
    }
}
