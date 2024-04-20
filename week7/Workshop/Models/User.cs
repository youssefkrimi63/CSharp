#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogReg.Models;


public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    public string UserName { get; set; }
    [EmailAddress]
    [Required]
    public string Email { get; set; }
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string Password { get; set; }


    // anything under the notMapped will not go in to the database
    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string PassConfirm { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}