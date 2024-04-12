#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class Survey
{
    [Required(ErrorMessage = "Please enter a valid Name.")]
    [MinLength(2)]
    public string Name { get; set; }
    [Required]
    public string Location { get; set; }
    [Required]
    public string Language { get; set; }
    [Required]
    [MinLength(10)]
    public string Comment { get; set; }
}