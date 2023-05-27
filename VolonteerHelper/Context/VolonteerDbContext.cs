using Microsoft.EntityFrameworkCore;
using VolonteerHelper.Api.Extensions;

namespace VolonteerHelper.Api.Context
{
    public class VolonteerDbContext : DbContext
    {
        public VolonteerDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Configure();
            modelBuilder.Seed();
        }
    }
}