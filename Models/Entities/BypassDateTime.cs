namespace RoutesREST.Models.Entities
{
    public class BypassDateTime
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public Guid RouteOrRoutePointId { get; set; }
    }
}
