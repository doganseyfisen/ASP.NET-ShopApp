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
    }
}