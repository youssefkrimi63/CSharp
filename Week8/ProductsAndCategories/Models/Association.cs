#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace ProductsAndCategories.Models;

public class Association
{
    [Key]
    public int AssociationId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}