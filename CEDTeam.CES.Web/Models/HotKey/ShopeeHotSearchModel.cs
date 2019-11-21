using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEDTeam.CES.Web.Models
{
    public class Item
    {
        public string info { get; set; }
        public string from { get; set; }
        public string keyword { get; set; }
        public string data_type { get; set; }
        public string intentionid { get; set; }
        public List<string> images { get; set; }
    }

    public class Data
    {
        public List<Item> items { get; set; }
        public int update_time { get; set; }
        public int total { get; set; }
    }

    public class ShopeeHotSearchModel
    {
        public string version { get; set; }
        public Data data { get; set; }
        public object error_msg { get; set; }
        public int error { get; set; }
    }
}
