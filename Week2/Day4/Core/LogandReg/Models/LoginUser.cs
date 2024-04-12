#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace LogandReg.Models;

public class LoginUser
{

    // Email
    [Required(ErrorMessage = "Please enter your email.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")] //! Regex pattern email validation
    [Display(Name ="Email")]
    public string LoginEmail { get; set; }

    // Password
    [Required(ErrorMessage = "Please enter your password.")]
    [MinLength(6, ErrorMessage = "Please enter a valid password.")]
    [DataType(DataType.Password)]
    [Display(Name ="Password")]
    public string LoginPassword { get; set; }
}