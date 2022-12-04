namespace RoutesREST.Models.Entities
{
    public class BypassRouteDateTime
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public virtual BypassRoute BypassRoute { get; set; }
        public Guid? RouteId { get; set; }
    }
}
