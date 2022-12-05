using Microsoft.AspNetCore.Identity;
using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;
using RoutesREST.Models.IRepositories;

namespace RoutesREST.Models.Repositories
{
    public class BypassRouteRepository : IBypassRouteRepository
    {
        private ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BypassRouteRepository(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public BypassRoute AddBypassRoute(BypassRouteCreate bypassRouteCreate)
        {
            if (_context.BypassRoutePointLocations.Where(l => l.Latitude == bypassRouteCreate.Location.Latitude && l.Longitude == bypassRouteCreate.Location.Longitude).Count() == 0)
            {
                _context.BypassRouteLocations.Add(new()
                {
                    Id = new Guid(),
                    Latitude = bypassRouteCreate.Location.Latitude,
                    Longitude = bypassRouteCreate.Location.Longitude
                });
                _context.SaveChanges();
            }
            BypassRoute bypassRoute = new()
            {
                Id = new Guid(),
                Name = bypassRouteCreate.Name,
                Location = _context.BypassRouteLocations.First(l => l.Latitude == bypassRouteCreate.Location.Latitude && l.Longitude == bypassRouteCreate.Location.Longitude)
            };
            _context.BypassRoutes.Add(bypassRoute);
            _context.SaveChanges();

            return bypassRoute;
        }

        public void DeleteBypassRoute(Guid routeId)
        {
            _context.BypassRoutes.Remove(_context.BypassRoutes.First(r => r.Id == routeId));
        }

        public BypassRoute EditBypassRoute(BypassRoute bypassRoute)
        {
            throw new NotImplementedException();
        }

        public List<BypassRoute> GetAllBypassRoutes() => _context.BypassRoutes.ToList();

        public BypassRoute? GetBypassRouteById(Guid routeId) => _context.BypassRoutes.FirstOrDefault(r => r.Id == routeId);

        public BypassRoute GetBypassRouteByLocation(BypassRouteLocation location)
        {
            throw new NotImplementedException();
        }

        public BypassRoute GetBypassRouteByPerformerName(string performerName)
        {
            throw new NotImplementedException();
        }
        public async Task<BypassRoute?> AssignPerformer(Guid routeId, string performerId)
        {
            var bypassRoute = _context.BypassRoutes.FirstOrDefault(r => r.Id == routeId);
            // var performer = _context.Performers.FirstOrDefault(p => p.Id == performerId);
            var performer = await _userManager.FindByIdAsync(performerId);
            if ((bypassRoute != null) && (performer != null))
            {
                bypassRoute.Performer = performer;
                _context.SaveChanges();

                return bypassRoute;
            } else
            {
                return null;
            }
        }
        public BypassRoute? CheckBypassRoute(Guid routeId)
        {
            BypassRoute? bypassRoute = _context.BypassRoutes.FirstOrDefault(r => r.Id == routeId);

            if (bypassRoute != null)
            {
                bypassRoute.BypassDatetimes.Add(new()
                {
                    Id = new Guid(),
                    DateTime = DateTime.Now.ToUniversalTime()
                });
                _context.SaveChanges();
                return bypassRoute;
            }
            else
            {
                return null;
            }
        }
    }
}
