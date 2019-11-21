using System.Collections.Generic;

namespace CEDTeam.CES.Web.Models
{
    public class Status
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    public class Datum
    {
        public string link { get; set; }
        public string name { get; set; }
        public string q { get; set; }
        public string image { get; set; }
        public int total_count { get; set; }
        public string deeplink { get; set; }
    }

    public class Result
    {
        public List<Datum> data { get; set; }
        public List<object> meta_data { get; set; }
        public List<object> error { get; set; }
    }

    public class SendoHotSearchModel
    {
        public Status status { get; set; }
        public Result result { get; set; }
    }
}