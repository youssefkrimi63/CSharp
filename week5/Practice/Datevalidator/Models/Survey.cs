#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DojoWithModel.Models;

public class Survey
{
    [Required(ErrorMessage = "Please enter a valid title.")]
    [MinLength(2)]
    [DisplayName("Name")]
    public string name { get; set; }
    [Required]
    [DisplayName("Location")]
    public string location { get; set; }
    [Required]
    [DisplayName("Language")]
    public string language { get; set; }
    [CustomDateValidation]
    [DisplayName("Date")]
    public string date { get; set; } 
}