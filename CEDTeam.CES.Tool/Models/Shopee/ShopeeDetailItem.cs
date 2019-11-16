using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Tool.Models.Shopee
{
    public class Category
    {
    }

    public class Attribute
    {
        public bool is_pending_qc { get; set; }
        public int idx { get; set; }
        public string value { get; set; }
        public int id { get; set; }
        public bool is_timestamp { get; set; }
        public string name { get; set; }
    }

    public class CoinInfo
    {
        public int spend_cash_unit { get; set; }
        public List<object> coin_earn_items { get; set; }
    }

    public class ShopeeDetailItem
    {
        public Item item { get; set; }
        public string version { get; set; }
        public object data { get; set; }
        public object error_msg { get; set; }
        public object error { get; set; }
    }
}
