using CEDTeam.CES.Tool.Models.Common;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Tool.Repositories
{
    public class KeywordRepository : BaseRepository
    {
        public long InsertKeywords(List<KeywordByCategory> keywords)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("CategoryUrl", typeof(string));
            dataTable.Columns.Add("Keyword", typeof(string));
            keywords.ForEach(item =>
            {
                item.Keywords.ForEach(keyword =>
                {
                    var row = dataTable.NewRow();
                    row["CategoryUrl"] = item.CategoryUrl;
                    row["Keyword"] = keyword;
                    dataTable.Rows.Add(row);
                });
            });

            using (var db = GetConnection())
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@categoryKeywords", dataTable.AsTableValuedParameter("CategoryKeywordType"));
                db.Execute("spInsertCategoryKeyword", dynamicParameters, commandType: CommandType.StoredProcedure);
                return dataTable.Rows.Count;
            }
        }
    }
}
