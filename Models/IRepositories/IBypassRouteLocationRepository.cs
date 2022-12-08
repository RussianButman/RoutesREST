using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;

namespace RoutesREST.Models.IRepositories
{
    public interface IBypassRouteLocationRepository
    {
        IQueryable<BypassRouteLocation> BypassRouteLocations { get; }
        void AddLocation(LatLongPoint latLongPoint);
    }
}
