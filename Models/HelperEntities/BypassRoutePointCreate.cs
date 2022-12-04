namespace RoutesREST.Models.HelperEntities
{
    public class BypassRoutePointCreate
    {
        public LatLongPoint Location { get; set; }
        public Guid RouteId { get; set; }
    }
}
