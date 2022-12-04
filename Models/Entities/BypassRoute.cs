namespace RoutesREST.Models.Entities
{
    public class BypassRoute
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Performer? Performer { get; set; }
        public virtual BypassRouteLocation? Location { get; set; }
        public virtual List<BypassRoutePoint>? BypassRoutePoints { get; set; }
        public virtual List<BypassRouteDateTime>? BypassDatetimes { get; set; }
    }
}
