#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;

namespace Chefs.Models;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options){}

    // Our Database Tables 
    public DbSet<Chef> Chefs { get; set; }
    public DbSet<Dish> Dishes { get; set; }
}