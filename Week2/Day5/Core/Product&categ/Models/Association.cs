#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Products.Models;
public class Association
{
    [Key]    
    public int AssociationId { get; set; } 
    // The IDs linking to the adjoining tables   
    public int CategoryId { get; set; }    
    public int ProductId { get; set; }
    // Our navigation properties - don't forget the ?    
    public Category? Category { get; set; }    
    public Product? Product { get; set; }
}
