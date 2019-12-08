using CEDTeam.CES.Tool.Enums;
using CEDTeam.CES.Tool.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CEDTeam.CES.Tool.Repositories;

namespace CEDTeam.CES.Tool.Business
{
    public class ReadCategory
    {
        private readonly CategoryRepository categoryRepository = new CategoryRepository();
        public Dictionary<string, List<Category>> GetAllCategory(SiteType siteType)
        {
            var path = "Datas/";
            var siteId = 0;
            switch(siteType)
            {
                case SiteType.Shopee: path += "shopeeCategory.json"; siteId = 1; break;
                case SiteType.Lazada: path += "lazadaCategory.json"; siteId = 2; break;
                case SiteType.Tiki: path += "tikiCategory.json"; siteId = 3; break;
                case SiteType.Sendo: path += "sendoCategory.json"; siteId = 4; break;
            }
            var categorys = new Dictionary<string, List<Category>>();
            using (var reader = new StreamReader(path))
            {
                categorys = JsonConvert.DeserializeObject<Dictionary<string, List<Category>>>(reader.ReadToEnd());
            }
            categorys["category"].ForEach(item => {
                item.SiteId = siteId;
            });
            categorys["subcategory"].ForEach(item => {
                item.SiteId = siteId;
            });

            //if (!categoryRepository.CheckCategory(siteId.ToString()))
            //{
            //    categoryRepository.AddCategorySub(categorys["category"]);
            //    categoryRepository.AddCategorySub(categorys["subcategory"]);
            //}
            return categorys;
        }
    }
}
