#pragma  warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Models;

public class Dish
{
    [Key]
    public int DishId { get; set; }


    [Required]
    [Display(Name = "Chef's name")]
    public string ChefName { get; set; }


    [Required]
    [Display(Name = " name of Dish")]
    public string DishName { get; set; }

    [Required]
    [Display(Name = " # of Calories")]
    public int Calories { get; set; }


    [Required]
    [Display(Name = " Tostiness")]
    public int Tostiness { get; set; }

    [Required]
    [Display(Name = " Description")]
    public String Description { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
