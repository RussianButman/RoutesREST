namespace RoutesREST.Models.Entities
{
    public class BypassRoutePointDateTime
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public virtual BypassRoutePoint BypassRoutePoint { get; set; }
        public Guid? RoutePointId { get; set; }
    }
}
