using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{
    public class StatusCI
{
    public int code { get; set; }
    public string message { get; set; }
}

public class SubCategory
{
    public int id { get; set; }
    public string name { get; set; }
    public string url_path { get; set; }
    public string url_key { get; set; }
    public string cat_image { get; set; }
}

public class Search
{
    public string sortType { get; set; }
}

public class SortList
{
    public Search search { get; set; }
    public bool vasup_listing { get; set; }
    public string name { get; set; }
    public string listing_algo { get; set; }
}

public class Html
{
    public string footer { get; set; }
    public string header { get; set; }
}

public class CmsContent
{
    public Html html { get; set; }
    public string css { get; set; }
    public string js { get; set; }
}

public class SeoFooter
{
    public string title { get; set; }
    public string description { get; set; }
}

public class AllowNominated
{
    public string field { get; set; }
    public string condition { get; set; }
    public string value { get; set; }
    public string map_field { get; set; }
}

public class DataCI
{
    public List<SubCategory> sub_category { get; set; }
    public List<SortList> sort_list { get; set; }
    public CmsContent cms_content { get; set; }
    public SeoFooter seo_footer { get; set; }
    public List<AllowNominated> allow_nominated { get; set; }
}

public class CategoryInfoCI
{
    public int id { get; set; }
    public string title { get; set; }
    public string path { get; set; }
    public string url_key { get; set; }
    public List<string> images { get; set; }
}

public class BreadcrumbCI
{
    public string title { get; set; }
    public string url { get; set; }
    public bool clickable { get; set; }
    public bool isExternalUrl { get; set; }
}

public class MetaDataCI
{
    public string page_title { get; set; }
    public string description { get; set; }
    public string heading_search { get; set; }
    public string redirect { get; set; }
    public int category_id { get; set; }
    public string category_name { get; set; }
    public int category_level { get; set; }
    public List<CategoryInfoCI> category_info { get; set; }
    public List<BreadcrumbCI> breadcrumb { get; set; }
    public string keywords { get; set; }
    public string keyword_tokenize { get; set; }
    public bool index { get; set; }
    public bool follow { get; set; }
    public string belong_tab { get; set; }
    public int special_res { get; set; }
    public int experiment_id { get; set; }
    public bool in_default_listing { get; set; }
    public string listing_algo { get; set; }
}

public class ResultCI
{
    public DataCI data { get; set; }
    public MetaDataCI meta_data { get; set; }
    public List<object> error { get; set; }
}

public class SendoCategoryInfoDto
{
    public StatusCI status { get; set; }
    public ResultCI result { get; set; }
}
}
