using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoutesREST.Models.Entities;
using System.Diagnostics;

namespace RoutesREST.Models
{
    public partial class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<BypassRoute> BypassRoutes { get; set; }
        public DbSet<BypassRoutePoint> BypassRoutePoints { get; set; }
        public DbSet<BypassRouteLocation> BypassRouteLocations { get; set; }
        public DbSet<BypassRoutePointLocation> BypassRoutePointLocations { get; set; }
        public DbSet<BypassRouteDateTime> BypassDateTimes { get; set; }
        // public DbSet<Performer> Performers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BypassRoute>()
                .HasMany<BypassRoutePoint>(r => r.BypassRoutePoints)
                .WithOne(p => p.BypassRoute)
                .HasForeignKey(p => p.RouteId);
            modelBuilder.Entity<BypassRouteDateTime>()
                .HasOne<BypassRoute>(s => s.BypassRoute)
                .WithMany(g => g.BypassDatetimes)
                .HasForeignKey(r => r.RouteId);
            modelBuilder.Entity<BypassRoutePointDateTime>()
                .HasOne<BypassRoutePoint>(s => s.BypassRoutePoint)
                .WithMany(g => g.BypassDatetimes)
                .HasForeignKey(r => r.RoutePointId);
            modelBuilder.Entity<BypassRoute>()
                .HasOne<BypassRouteLocation>(s => s.Location)
                .WithOne(g => g.BypassRoute)
                .HasForeignKey<BypassRouteLocation>(l => l.BypassRouteId);
            modelBuilder.Entity<BypassRoutePoint>()
                .HasOne<BypassRoutePointLocation>(s => s.Location)
                .WithOne(g => g.BypassRoutePoint)
                .HasForeignKey<BypassRoutePointLocation>(l => l.BypassRoutePointId);
            modelBuilder.Entity<AppUser>()
                .HasOne<BypassRoute>(s => s.BypassRoute)
                .WithOne(g => g.Performer)
                .HasForeignKey<AppUser>(r => r.RouteId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
