namespace RoutesREST.Models.Entities
{
    public class BypassRoute
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual BypassRouteLocation? Location { get; set; }
        public virtual List<BypassRoutePoint>? BypassRoutePoints { get; set; }
        public virtual List<BypassRouteInstance> BypassRouteInstances { get; set; }
    }
}
