using CEDTeam.CES.Tool.Models.Common;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Tool.Repositories
{
    public class KeywordRepository : BaseRepository
    {
        public long InsertKeywords(List<KeywordByCategory> keywords)
        {
            StringBuilder stringBuilder = new StringBuilder("INSERT IGNORE INTO category_keyword(CategoryId, CategoryUrl, Keyword) VALUES ");
            keywords.ForEach(item =>
            {
                item.Keywords.ForEach(keyword =>
                {
                    stringBuilder.AppendLine($" ({item.CategoryId??"null"}, '{item.CategoryUrl}', '{MySqlHelper.EscapeString(keyword)}'),");
                });
            });
            using (var db = GetConnection())
            {
                string a = stringBuilder.ToString();
                a = a.Remove(a.LastIndexOf(","));
                return db.Execute(a);
            }
        }
    }
}
