using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{

     public class StatusSC
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    public class FirstSection
    {
        public string name { get; set; }
        public string url_path { get; set; }
        public string algo { get; set; }
        public int square_type { get; set; }
        public string image { get; set; }
        public int square_position { get; set; }
    }

    public class OtherSection
    {
        public string name { get; set; }
        public string url_path { get; set; }
        public string algo { get; set; }
        public int square_type { get; set; }
        public int square_position { get; set; }
    }

    public class ListSC
    {
        public List<FirstSection> firstSection { get; set; }
        public List<OtherSection> otherSection { get; set; }
    }

    public class DataSC2
    {
        public string title { get; set; }
        public string link { get; set; }
        public ListSC list { get; set; }
    }

    public class SourceInfo
    {
        public string source_block_id { get; set; }
        public string source_page_id { get; set; }
    }

    public class MetaData
    {
        public string page_title { get; set; }
        public string heading_search { get; set; }
        public SourceInfo source_info { get; set; }
    }

    public class DataSC1
    {
        public string type { get; set; }
        public DataSC2 data { get; set; }
        public MetaData meta_data { get; set; }
    }

    public class SourceInfo2
    {
        public string source_block_id { get; set; }
        public string source_page_id { get; set; }
    }

    public class MetaData2
    {
        public string page_title { get; set; }
        public string heading_search { get; set; }
        public SourceInfo2 source_info { get; set; }
    }

    public class ResultSC
    {
        public DataSC1 data { get; set; }
        public MetaData2 meta_data { get; set; }
        public List<object> error { get; set; }
    }

    public class SendoCategoryDto
    {
        public StatusSC status { get; set; }
        public ResultSC result { get; set; }
    }
}
