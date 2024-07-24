using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = String.Empty;
    public decimal ProductPrice { get; set; }
    public int? CategoryId { get; set; } // Foreign key
    public Category? Category { get; set; } // Navigation property
}
