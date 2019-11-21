using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{
    public class DataCategoryTiki
    {
        public TikiTopProductDto tikiTopProduct { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string thumbnail_url { get; set; }
        public string url_key { get; set; }
        public string status { get; set; }
    }

    public class Paging
    {
        public int current_page { get; set; }
        public int from { get; set; }
        public int last_page { get; set; }
        public int per_page { get; set; }
        public int to { get; set; }
        public int total { get; set; }
    }

    public class TikiCategoryDto
    {
        public List<DataCategoryTiki> data { get; set; }
        public int is_personalized { get; set; }
        public Paging paging { get; set; }
    }
}
