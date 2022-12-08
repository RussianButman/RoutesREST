using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;

namespace RoutesREST.Models.IRepositories
{
    public interface IBypassRouteInstanceRepository
    {
        IQueryable<BypassRouteInstance> BypassRouteInstances { get; }
        BypassRouteInstance AddBypassRouteInstance(string userId, string routeId, BypassRouteInstanceCreate instance);
        Task<List<BypassRouteInstance>?> GetRouteInstancesByPerformerIdAsync(string performerId);
    }
}
