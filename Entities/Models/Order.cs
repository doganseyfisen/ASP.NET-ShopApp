using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
        
        [Required(ErrorMessage = "Name field is required.")]
        public string? Name { get; set; }
        
        [Required(ErrorMessage = "Line1 field is required.")]
        public string? Line1 { get; set; }
        
        [Required(ErrorMessage = "Line2 field is required.")]
        public string? Line2 { get; set; }

        [Required(ErrorMessage = "City field is required.")] 
        public string? City { get; set; }
        
        public bool OrderShipped { get; set; }

        public DateTime OrderedAt { get; set; } = DateTime.Now;
    }
}