using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;

namespace RoutesREST.Models.IRepositories
{
    public interface IBypassRoutePointRepository
    {
        List<BypassRoutePoint> GetBypassRoutePoints();
        BypassRoutePoint GetWalkRoutePointById(Guid id);
        List<BypassRoutePoint> GetWalkRoutePointsByRegion(LatLongPoint[] latLongPoints);
        BypassRoutePoint AddBypassRoutePoint(string routeId, LatLongPoint latLongPoint);
        BypassRoutePoint? CheckBypassRoute(string routePointId, string dateTimeString);
    }
}
