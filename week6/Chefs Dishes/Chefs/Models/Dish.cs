#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Chefs.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required]
    public int? ChefId { get; set; } 

    [Required]
    public string Name { get; set; }
    [Required]
    public int Calories { get; set; }
    [Required]
    public int Tostiness { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Chef? Creator { get; set; }



}
