using CEDTeam.CES.Tool.Enums;
using CEDTeam.CES.Tool.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CEDTeam.CES.Tool.Business
{
    public class ReadCategory
    {
        public Dictionary<string, List<Category>> GetAllCategory(SiteType siteType)
        {
            var path = "Datas/";
            switch(siteType)
            {
                case SiteType.Shopee: path += "shopeeCategory.json"; break;
                case SiteType.Lazada: path += "lazadaCategory.json"; break;
                case SiteType.Tiki: path += "tikiCategory.json"; break;
                case SiteType.Sendo: path += "sendoCategory.json"; break;
            }
            var categorys = new Dictionary<string, List<Category>>();
            using (var reader = new StreamReader(path))
            {
                categorys = JsonConvert.DeserializeObject<Dictionary<string, List<Category>>>(reader.ReadToEnd());
            }
            return categorys;
        }
    }
}
