﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{
    public class ProductDto
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? Price { get; set; }
        public long? Quantity { get; set; }
        public string CategoryId { get; set; }
        public long? QuantitySold { get; set; }
        public long? CommentCount { get; set; }
        public string Discount { get; set; }
        public string VariableJson { get; set; }
        public string Url { get; set; }
        public string CategoryUrl { get; set; }
    }
}