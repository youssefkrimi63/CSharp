#pragma warning disable CS8618
using System.Data.Common;
using FirstConnection.Model;
using Microsoft.EntityFrameworkCore;
namespace FirstConnection.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) {}
    
    // The Table For Our DataBase
    public DbSet<Pet> Pets {get; set;}
    
}