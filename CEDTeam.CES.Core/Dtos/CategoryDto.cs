using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Id { get; set; }
        public string Parent { get; set; }
        public int SiteId { get; set; }
    }
}
