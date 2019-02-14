using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Contracts.Data
{
    public class Product : TreeLeaf
    {
        public Guid ProductId { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public bool IsNew { get; set; }

        public DateTimeOffset ReleaseDate { get; set; }
    }
}
