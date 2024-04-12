#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurveyWithModel.Model;
public class User
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Location { get; set; }
    [Required]
    public string Language { get; set; }
    [Required]
    public string? Comment { get; set; } 
}



