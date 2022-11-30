namespace RoutesREST.Models.Entities
{
    public class Performer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BypassRouteId { get; set; }
    }
}
