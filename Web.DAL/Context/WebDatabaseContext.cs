using Microsoft.EntityFrameworkCore;
using Web.DAL.Records;

namespace Web.DAL.Context;

public class WebDatabaseContext : DbContext
{
    public WebDatabaseContext(DbContextOptions options) : base(options) { }
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}