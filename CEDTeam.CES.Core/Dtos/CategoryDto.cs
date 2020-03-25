using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{
    public class CategoryDto
    {
        public string Id { set; get; }
        public string CategoryId { set; get; }
        public string CategoryName { set; get; }
        public string CategoryUrl { set; get; }
        public string ImageUrl { set; get; }
        public string ParentId { set; get; }
        public string SiteId { set; get; }
        public string Level { set; get; }
        public string IdWeb { set; get; }
        public string IsParent { get; set; }
    }
}
