using Microsoft.AspNetCore.Identity;
using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;
using RoutesREST.Models.IRepositories;

namespace RoutesREST.Models.Repositories
{
    public class BypassRouteRepository : IBypassRouteRepository
    {
        private ApplicationDbContext _context;

        public IQueryable<BypassRoute> BypassRoutes => _context.BypassRoutes;

        public BypassRouteRepository(ApplicationDbContext context) => _context = context;

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
    }
}
