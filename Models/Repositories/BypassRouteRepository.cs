using RoutesREST.Models.Entities;
using RoutesREST.Models.IRepositories;

namespace RoutesREST.Models.Repositories
{
    public class BypassRouteRepository : IBypassRouteRepository
    {
        private ApplicationDbContext _context;

        public BypassRouteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBypassRoute(BypassRoute bypassRoute)
        {
            throw new NotImplementedException();
        }

        public void DeleteBypassRoute(BypassRoute bypassRoute)
        {
            throw new NotImplementedException();
        }

        public void EditBypassRoute(BypassRoute bypassRoute)
        {
            throw new NotImplementedException();
        }

        public List<BypassRoute> GetAllBypassRoutes()
        {
            throw new NotImplementedException();
        }

        public BypassRoute GetBypassRouteById(int id)
        {
            throw new NotImplementedException();
        }

        public BypassRoute GetBypassRouteByLocation(BypassRouteLocation location)
        {
            throw new NotImplementedException();
        }

        public BypassRoute GetBypassRouteByPerformerName(string performerName)
        {
            throw new NotImplementedException();
        }
    }
}
