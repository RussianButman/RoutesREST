namespace RoutesREST.Models.Entities
{
    public class BypassRoutePointLocation
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public virtual BypassRoutePoint? BypassRoutePoint { get; set; }
        public Guid? BypassRoutePointId { get; set; }
    }
}
