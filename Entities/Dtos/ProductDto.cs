using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record ProductDto
    {
        public int ProductId { get; init; }

        [Required(ErrorMessage = "Product must have a name.")]
        public string ProductName { get; init; } = String.Empty;
        
        [Required(ErrorMessage = "Product must have a price.")]
        public decimal ProductPrice { get; init; }
        
        public int? CategoryId { get; init; } // Foreign key
    }
}