using Microsoft.EntityFrameworkCore;
using RoutesREST.Models.Entities;

namespace RoutesREST.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<BypassRoute> BypassRoutes { get; set; }
        DbSet<BypassRoutePoint> BypassRoutePoints { get; set; }
        DbSet<BypassRouteLocation> BypassRouteLocations { get; set; }
        DbSet<BypassDateTime> BypassDateTimes { get; set; }
        DbSet<Performer> Performers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
