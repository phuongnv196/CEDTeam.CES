using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEDTeam.CES.Web.Models
{
    public class DataTiki
    {
        public int updated_at { get; set; }
        public string image_url { get; set; }
        public string keyword { get; set; }
        public int points { get; set; }
    }

    public class TikiHotSearchModel
    {
        public List<DataTiki> data { get; set; }
        public int is_personalized { get; set; }
    }
}
