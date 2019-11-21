using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEDTeam.CES.Web.Models
{
    public class Datum1
    {
        public string from
        {
            get; set;
        }
        public string info
        {
            get; set;
        }
        public object itemid
        {
            get; set;
        }
        public int score
        {
            get; set;
        }
        public int shopid
        {
            get; set;
        }
    }

    public class Category
    {
        public List<Datum1> data
        {
            get; set;
        }
        public string from
        {
            get; set;
        }
        public List<string> images
        {
            get; set;
        }
        public string info
        {
            get; set;
        }
        public string key
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public int sold
        {
            get; set;
        }
    }

    public class DataTopProduct
    {
        public List<Category> categories
        {
            get; set;
        }
        public int update_time
        {
            get; set;
        }
    }

    public class ShopeeTopProductModel
    {
        public DataTopProduct data
        {
            get; set;
        }
        public object error
        {
            get; set;
        }
        public object error_msg
        {
            get; set;
        }
    }
}