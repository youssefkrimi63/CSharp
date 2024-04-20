#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace ProductsAndCategories.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Name")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [MaxLength(45, ErrorMessage = "must be no more than 45 characters")]
    public string ProductName { get; set; }

    [Required(ErrorMessage = "is required")]
    [MinLength(10, ErrorMessage = "must be at least 10 characters")]
    public string Description { get; set; }

    [Required(ErrorMessage = "is required")]
    [Range(0, Int32.MaxValue, ErrorMessage = "cannot be negative")]
    [DataType(DataType.Currency)]
    public double? Price { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Association> ProductCategories { get; set; } = new List<Association>();
}