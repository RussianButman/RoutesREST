namespace RoutesREST.Models.Entities
{
    public class BypassRouteLocation
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public virtual BypassRoute? BypassRoute { get; set; }
        public Guid? BypassRouteId { get; set; }
    }
}
