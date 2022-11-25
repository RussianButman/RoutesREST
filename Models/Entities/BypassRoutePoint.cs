namespace RoutesREST.Models.Entities
{
    public class BypassRoutePoint
    {
        public int Id { get; set; }
        public int BypassRouteIndex { get; set; }
        public BypassRouteLocation Location { get; set; }
        public List<DateTime> BypassDatetimes { get; set; }
    }
}
