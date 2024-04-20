#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace ProductsAndCategories.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    
    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [Display(Name = "Name")]
    public string CategoryName { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Association> CategoryProducts { get; set; } = new List<Association>();
}