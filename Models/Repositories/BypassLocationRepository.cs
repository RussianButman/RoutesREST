using RoutesREST.Models.HelperEntities;
using RoutesREST.Models.IRepositories;

namespace RoutesREST.Models.Repositories
{
    public class BypassLocationRepository : IBypassRouteLocationRepository
    {
        private ApplicationDbContext _context;

        public BypassLocationRepository(ApplicationDbContext context) => _context = context;

        public void AddLocation(LatLongPoint latLongPoint)
        {
            _context.BypassRouteLocations.Add(new()
            {
                Id = new Guid(),
                Latitude = latLongPoint.Latitude,
                Longitude = latLongPoint.Longitude,

            });
        }
    }
}
