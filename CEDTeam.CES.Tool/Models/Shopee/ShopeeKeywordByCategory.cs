using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Tool.Models.Shopee
{
    public class ShopeeKeywordByCategoryItem
    {
        public int status { get; set; }
        public int count { get; set; }
        public List<int> return_reason_bl_before_frd { get; set; }
        public int sort_weight { get; set; }
        public string name { get; set; }
        public int catid { get; set; }
        public List<int> parentids { get; set; }
        public string country { get; set; }
        public string image { get; set; }
        public int max_estimated_days { get; set; }
        public int parent_category { get; set; }
        public int is_adult { get; set; }
        public bool no_sub { get; set; }
        public int is_default_subcat { get; set; }
        public int has_active_childs { get; set; }
        public int usage_sort_weight { get; set; }
        public string display_name { get; set; }
        public bool placeholder { get; set; }
        public bool? block_cb { get; set; }
        public bool? is_3c { get; set; }
    }

    public class ShopeeKeywordByCategory
    {
        public List<ShopeeKeywordByCategoryItem> items { get; set; }
    }
}
