using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.RequestParameters
{
    public class ProductRequestParameters : RequestParameters
    {
        public ProductRequestParameters()
        {
        }

        public int? CategoryId { get; set; }

        public int? MinPrice { get; set; } = 0;
        
        public int? MaxPrice { get; set; } = int.MaxValue;

        public bool IsValidPrice => MaxPrice > MinPrice;
    }
}