#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WeddingPlanner.Models.CustomValidations;

namespace WeddingPlanner.Models;

public class Wedding
{
    [Key]
    public int WeddingId { get; set; }

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Wedder One")]
    public string WedderOne { get; set; }

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Wedder Two")]
    public string WedderTwo { get; set; }

    [Required(ErrorMessage = "is required")]
    [Past]
    [Display(Name = "Wedding Date")]
    [DataType(DataType.Date, ErrorMessage = "is not valid")]
    public DateTime? WeddingDate { get; set;}

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Wedding Address")]
    public string WeddingAddress { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int UserId { get; set; }

    public User? Creator { get; set; }

    public List<RSVP> Guests { get; set; } = new List<RSVP>();
}