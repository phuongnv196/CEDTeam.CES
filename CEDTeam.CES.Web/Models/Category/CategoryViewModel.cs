using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEDTeam.CES.Web.Models
{
    public class CategoryViewModel
    {
        public string CategoryId { set; get; }
        public string CategorySiteId { set; get; }
        public string CategoryName { set; get; }
        public string SiteId { set; get; }
        public string CategoryUrl { set; get; }
        public string Parent { set; get; }
        public string ParentId { set; get; }
        public string Level { set; get; }
        public string IdWeb { set; get; }
    }
}
