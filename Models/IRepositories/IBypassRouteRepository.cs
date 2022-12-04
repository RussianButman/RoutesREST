using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;

namespace RoutesREST.Models.IRepositories
{
    public interface IBypassRouteRepository
    {
        List<BypassRoute> GetAllBypassRoutes();
        BypassRoute? GetBypassRouteById(Guid routeId);
        BypassRoute GetBypassRouteByPerformerName(string performerName);
        BypassRoute GetBypassRouteByLocation(BypassRouteLocation location);
        BypassRoute AddBypassRoute(BypassRouteCreate bypassRouteCreate);
        BypassRoute EditBypassRoute(BypassRoute bypassRoute);
        void DeleteBypassRoute(Guid routeId);
        BypassRoute? AssignPerformer(Guid routeId, Guid performerId);
        BypassRoute? CheckBypassRoute(Guid routeId);
    }
}
