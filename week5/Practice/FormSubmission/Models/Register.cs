#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models;

public class User
{
    [Required]
    [MinLength(2)]
    [DisplayName("Name")]
    public string name { get; set; }
    [Required]
    [EmailAddress()]
    [DisplayName("Email")]
    public string email { get; set; }
    [Required]
    [CustomDateValidation]
    [DisplayName("Date")]
    public string date { get; set; }
    [Required]
    [MinLength(8)]
    [DisplayName("Password")]
    public string password { get; set; }
    [Required]
  [oddNumber(ErrorMessage = "It must be an odd number.")]
  [DisplayName("Favorite Odd Number")]
    public int oddNumber {get ;set;}

}