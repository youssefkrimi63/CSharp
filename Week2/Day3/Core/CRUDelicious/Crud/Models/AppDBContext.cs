#pragma  warning disable CS8618
using Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options){}

      public DbSet<Dish> Dishes { get; set; } 

}