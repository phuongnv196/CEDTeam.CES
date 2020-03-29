using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Web.Models
{
    public class Values
    {
        public string display_value { get; set; }
        public int count { get; set; }
        public object query_value { get; set; }
        public string url_key { get; set; }
    }

    public class Filters
    {
        public string query_name { get; set; }
        public string display_name { get; set; }
        public List<Values> values { get; set; }
    }

    public class TikiShopModel
    {
        public List<Filters> filters { get; set; }
    }

}
