using RoutesREST.Models.Entities;

namespace RoutesREST.Models.IRepositories
{
    public interface IBypassRouteRepository
    {
        List<BypassRoute> GetAllBypassRoutes();
        BypassRoute GetBypassRouteById(int id);
        BypassRoute GetBypassRouteByPerformerName(string performerName);
        BypassRoute GetBypassRouteByLocation(BypassRouteLocation location);
        void AddBypassRoute(BypassRoute bypassRoute);
    }
}
