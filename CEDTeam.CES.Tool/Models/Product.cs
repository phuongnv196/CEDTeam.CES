using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Tool.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedProductDate { get; set; }
        public long? Price { get; set; }
        public long? Quantity { get; set; }
        public string CategoryId { get; set; }
        public long? QuantitySold { get; set; }
        public long? CommentCount { get; set; }
        public string Discount { get; set; }
        public string VariableJson { get; set; }
        public string Url { get; set; }
        public string CategoryUrl { get; set; }

        public override bool Equals(object obj)
        {
            Product product = (Product)obj;
            return ProductId.Equals(product.ProductId);
        }
    }
}
