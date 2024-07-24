using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Product
{
    public int ProductId { get; set; }
    [Required(ErrorMessage = "Product must have a name.")]
    public string ProductName { get; set; } = String.Empty;
    [Required(ErrorMessage = "Product must have a price.")]
    public decimal ProductPrice { get; set; }
    public int? CategoryId { get; set; } // Foreign key
    public Category? Category { get; set; } // Navigation property
}
