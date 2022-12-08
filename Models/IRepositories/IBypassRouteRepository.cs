using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;

namespace RoutesREST.Models.IRepositories
{
    public interface IBypassRouteRepository
    {
        IQueryable<BypassRoute> BypassRoutes { get; }
        BypassRoute? GetBypassRouteById(Guid routeId);
        BypassRoute GetBypassRouteByPerformerName(string performerName);
        BypassRoute GetBypassRouteByLocation(BypassRouteLocation location);
        BypassRoute AddBypassRoute(BypassRouteCreate bypassRouteCreate);
        BypassRoute EditBypassRoute(BypassRoute bypassRoute);
        void DeleteBypassRoute(Guid routeId);
        Task<BypassRoute?> AssignPerformer(Guid routeId, string performerId);
        BypassRoute? CheckBypassRoute(Guid routeId);
    }
}
