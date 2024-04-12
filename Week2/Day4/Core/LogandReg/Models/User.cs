#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogandReg.Models;

public class User
{
    // User Id
    [Key]
    public int UserId { get; set; }

    // Username
    [Required(ErrorMessage = "Please enter your username.")]
    [MinLength(3, ErrorMessage = "Please enter a valid username.")]
    public string Username { get; set; }

    // Email
    [Required(ErrorMessage = "Please enter your email.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")] //! Regex pattern email validation
    public string Email { get; set; }

    // Password
    [Required(ErrorMessage = "Please enter your password.")]
    [MinLength(6, ErrorMessage = "Please enter a valid password.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    //Confirm Password
    [NotMapped] //! Virtual property - cannot be saved to database
    [Required(ErrorMessage = "Please enter your password.")]
    [MinLength(6, ErrorMessage = "Please enter a valid password.")]
    [Compare("Password", ErrorMessage = "Passwords must match .")] //! compare Password and confirm password
    [DataType(DataType.Password)]
    [Display(Name = "Confirm PW")]
    public string ConfirmPW { get; set; }

    // Is Subscribed
    [Required]
    [Display(Name = "Do You want to subscribe to our newsletter ?")]
    public bool IsSubscribed { get; set; } = false;

    // Created At
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Updated At
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}