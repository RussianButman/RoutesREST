using System.Diagnostics.CodeAnalysis;

namespace RoutesREST.Models.Entities
{
    public class BypassRoutePoint
    {
        public Guid Id { get; set; }
        public int BypassRouteIndex { get; set; }
        public virtual BypassRoutePointLocation? Location { get; set; }
        public virtual List<BypassRoutePointDateTime> BypassDatetimes { get; set; }
        public string NfcTagId { get; set; }
        public virtual BypassRoute BypassRoute { get; set; }
        public Guid? RouteId { get; set; }
    }
}
