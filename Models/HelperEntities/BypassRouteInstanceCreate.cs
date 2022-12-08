using RoutesREST.Models.Entities;

namespace RoutesREST.Models.HelperEntities
{
    public class BypassRouteInstanceCreate
    {
        public string PerformerId { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string BypassRouteId { get; set; }
    }
}
