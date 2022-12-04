using RoutesREST.Models.HelperEntities;

namespace RoutesREST.Models.IRepositories
{
    public interface IBypassRouteLocationRepository
    {
        void AddLocation(LatLongPoint latLongPoint);
    }
}
