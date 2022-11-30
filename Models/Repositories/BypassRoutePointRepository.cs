using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;
using RoutesREST.Models.IRepositories;

namespace RoutesREST.Models.Repositories
{
    public class BypassRoutePointRepository : IBypassRoutePointRepository
    {
        private ApplicationDbContext _context;

        public BypassRoutePointRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBypassRoutePoint(BypassRoutePoint bypassRoutePoint)
        {
            throw new NotImplementedException();
        }

        public List<BypassRoutePoint> GetBypassRoutePoints()
        {
            throw new NotImplementedException();
        }

        public BypassRoutePoint GetWalkRoutePointById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<BypassRoutePoint> GetWalkRoutePointsByRegion(LatLongPoint[] latLongPoints)
        {
            throw new NotImplementedException();
        }
    }
}
