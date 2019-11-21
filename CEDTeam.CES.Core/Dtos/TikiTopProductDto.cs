using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{
    public class Inventory
    {
        public string product_virtual_type
        {
            get; set;
        }
        public string fulfillment_type
        {
            get; set;
        }
    }

    public class DataProduct
    {
        public int id
        {
            get; set;
        }
        public string sku
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public string url_key
        {
            get; set;
        }
        public string url_path
        {
            get; set;
        }
        public string type
        {
            get; set;
        }
        public object book_cover
        {
            get; set;
        }
        public string short_description
        {
            get; set;
        }
        public int price
        {
            get; set;
        }
        public int list_price
        {
            get; set;
        }
        public double price_usd
        {
            get; set;
        }
        public List<object> badges
        {
            get; set;
        }
        public int discount
        {
            get; set;
        }
        public int discount_rate
        {
            get; set;
        }
        public double rating_average
        {
            get; set;
        }
        public int review_count
        {
            get; set;
        }
        public int order_count
        {
            get; set;
        }
        public int favourite_count
        {
            get; set;
        }
        public string thumbnail_url
        {
            get; set;
        }
        public bool has_ebook
        {
            get; set;
        }
        public string inventory_status
        {
            get; set;
        }
        public bool is_visible
        {
            get; set;
        }
        public string productset_group_name
        {
            get; set;
        }
        public object seller
        {
            get; set;
        }
        public bool is_flower
        {
            get; set;
        }
        public bool is_gift_card
        {
            get; set;
        }
        public Inventory inventory
        {
            get; set;
        }
        public string url_attendant_input_form
        {
            get; set;
        }
        public object master_id
        {
            get; set;
        }
        public string salable_type
        {
            get; set;
        }
        public int seller_product_id
        {
            get; set;
        }
        public object installment_info
        {
            get; set;
        }
    }

    public class PagingProduct
    {
        public int total
        {
            get; set;
        }
        public int per_page
        {
            get; set;
        }
        public int current_page
        {
            get; set;
        }
        public int last_page
        {
            get; set;
        }
        public int from
        {
            get; set;
        }
        public int to
        {
            get; set;
        }
    }

    public class Value
    {
        public int id
        {
            get; set;
        }
        public string display_value
        {
            get; set;
        }
        public int count
        {
            get; set;
        }
        public string term
        {
            get; set;
        }
        public string url_key
        {
            get; set;
        }
        public int query_value
        {
            get; set;
        }
        public int parent_id
        {
            get; set;
        }
    }

    public class CategoryTiki
    {
        public List<Value> values
        {
            get; set;
        }
        public string display_name
        {
            get; set;
        }
        public string query_name
        {
            get; set;
        }
        public bool selected
        {
            get; set;
        }
        public bool is_visible
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
    }

    public class Aggregations
    {
        public CategoryTiki category
        {
            get; set;
        }
    }

    public class SortOption
    {
        public string display_value
        {
            get; set;
        }
        public string query_value
        {
            get; set;
        }
        public bool selected
        {
            get; set;
        }
    }

    public class TikiTopProductDto
    {
        public List<DataProduct> data
        {
            get; set;
        }
        public PagingProduct paging
        {
            get; set;
        }
        public List<object> sellers
        {
            get; set;
        }
        public Aggregations aggregations
        {
            get; set;
        }
        public List<SortOption> sort_options
        {
            get; set;
        }
    }
}
