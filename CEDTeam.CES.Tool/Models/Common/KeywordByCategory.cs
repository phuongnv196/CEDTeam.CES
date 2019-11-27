using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Tool.Models.Common
{
    public class KeywordByCategory
    {
        public string CategoryId { get; set; }
        public string CategoryUrl { get; set; }
        public List<string> Keywords { get; set; }
    }
}
