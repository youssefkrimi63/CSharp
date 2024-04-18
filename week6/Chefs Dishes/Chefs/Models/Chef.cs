#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Chefs.Models;
public class Chef
{
    [Key]
    public int ChefId { get; set; }

    [Required]
    public string Firstname { get; set; }
    [Required]
    public string Lastname { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish> AllDishes { get; set; } = new List<Dish>();
}
