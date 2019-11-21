using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEDTeam.CES.Web.Models
{
    public class HotKeyModel
    {
        public ShopeeHotSearchModel Shopee { get; set; }
        public TikiHotSearchModel Tiki { get; set; }
        public SendoHotSearchModel Sendo { get; set; }
    }
}
