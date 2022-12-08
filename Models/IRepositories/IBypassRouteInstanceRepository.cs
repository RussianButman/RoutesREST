using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;

namespace RoutesREST.Models.IRepositories
{
    public interface IBypassRouteInstanceRepository
    {
        IQueryable<BypassRouteInstance> BypassRouteInstances { get; }
        BypassRouteInstance AddBypassRouteInstance(BypassRouteInstanceCreate instance);
    }
}
