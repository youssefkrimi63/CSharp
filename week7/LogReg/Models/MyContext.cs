#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace LogReg.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users { get; set; }
}
