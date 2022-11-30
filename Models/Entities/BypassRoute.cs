namespace RoutesREST.Models.Entities
{
    public class BypassRoute
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Performer Performer { get; set; }
        public BypassRouteLocation Location { get; set; }
        public List<BypassRoutePoint> BypassRoutePoints { get; set; }
        public List<BypassDateTime> BypassDatetimes { get; set; }
    }
}
