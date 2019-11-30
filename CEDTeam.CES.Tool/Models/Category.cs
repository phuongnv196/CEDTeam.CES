using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Tool.Models
{
    public class Category
    {
        public int? CategoryId { get; set; }
        [JsonProperty("Id")]
        public string CategorySiteId { get; set; }
        [JsonProperty("Name")]
        public string CategoryName { get; set; }
        [JsonProperty("SiteId")]
        public int? SiteId { get; set; }
        [JsonProperty("Url")]
        public string CategoryUrl { get; set; }
        [JsonProperty("Parent")]
        public string Parent { get; set; }
    }
}
