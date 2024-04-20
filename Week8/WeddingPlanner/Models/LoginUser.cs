#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models;

[NotMapped]
public class LoginUser
{
    [Key]
    public int LoginUserId { get; set; }

    [Required(ErrorMessage = "is required")]
    [EmailAddress(ErrorMessage = "is not valid")]
    [Display(Name = "Email")]
    public string LoginEmail { get; set; }

    [Required(ErrorMessage = "is required")]
    [MinLength(8, ErrorMessage = "must be at least 8 characters")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string LoginPassword { get; set; }
}