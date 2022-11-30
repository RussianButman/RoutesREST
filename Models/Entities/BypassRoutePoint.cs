using System.Diagnostics.CodeAnalysis;

namespace RoutesREST.Models.Entities
{
    public class BypassRoutePoint
    {
        public Guid Id { get; set; }
        public int BypassRouteIndex { get; set; }
        public BypassRouteLocation Location { get; set; }
        public List<BypassDateTime> BypassDatetimes { get; set; }
        public string NfcTagId { get; set; }
    }
}
