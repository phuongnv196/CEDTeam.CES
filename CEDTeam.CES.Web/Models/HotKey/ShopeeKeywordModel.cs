using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEDTeam.CES.Web.Models
{
    public class ShopeeKeywordModel
    {
        public string CategoryName { get; set; }
        public string Keyword { get; set; }
        public string CategoryUrl { get; set; }
        public string CategoryId => CategoryUrl.Split('.').LastOrDefault();
    }
}