using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Tool.Models.Shopee
{
    public class ShopeeCategory
    {
        public string version { get; set; }
        public Data data { get; set; }
        public object error_msg { get; set; }
        public object error { get; set; }
    }
    public class CategoryList
    {
        public string display_name { get; set; }
        public int catid { get; set; }
        public string image { get; set; }
        public bool no_sub { get; set; }
        public int is_default_subcat { get; set; }
        public object block_buyer_platform { get; set; }
    }

    public class Data
    {
        public List<CategoryList> category_list { get; set; }
    }
}
