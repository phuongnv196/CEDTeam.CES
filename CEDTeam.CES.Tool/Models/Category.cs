﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Tool.Models
{
    public class Category
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Id { get; set; }
        public string Parent { get; set; }
        public int SiteId { get; set; }
    }
}
