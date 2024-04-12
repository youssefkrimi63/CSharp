#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
using Products.Models;

namespace Products.Models;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options){}

    // Our Database Tables 
    public DbSet<Association> Associations { get; set; }
    public DbSet<Category> Categories { get; set; }
      public DbSet<Product> Products { get; set; }
}