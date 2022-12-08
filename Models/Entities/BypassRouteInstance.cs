using System.Text.Json.Serialization;

namespace RoutesREST.Models.Entities
{
    public class BypassRouteInstance
    {
        public Guid Id { get; set; }
        public virtual AppUser? Performer { get; set; }
        public Guid? PerformerId { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        [JsonIgnore]
        public virtual BypassRoute? BypassRoute { get; set; }
        public Guid? BypassRouteId { get; set; }
    }
}
