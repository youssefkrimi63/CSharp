#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace WeddingPlanner.Models;

public class WeddingPlannerContext : DbContext 
{ 
    public WeddingPlannerContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; } 
    public DbSet<Wedding> Weddings { get; set; }
    public DbSet<RSVP> RSVPs { get; set; }
}