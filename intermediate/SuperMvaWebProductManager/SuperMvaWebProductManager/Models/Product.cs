using System;
using System.Collections.Generic;

namespace SuperMvaWebProductManager.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public decimal? Price { get; set; }

        public virtual Category Category { get; set; }
    }
}
