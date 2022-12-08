using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;
using RoutesREST.Models.IRepositories;

namespace RoutesREST.Models.Repositories
{
    public class BypassRouteInstanceRepository : IBypassRouteInstanceRepository
    {
        private ApplicationDbContext _context;

        public BypassRouteInstanceRepository(ApplicationDbContext context) => _context = context;

        public IQueryable<BypassRouteInstance> BypassRouteInstances => _context.BypassRouteInstances;

        public BypassRouteInstance AddBypassRouteInstance(BypassRouteInstanceCreate instance)
        {
            BypassRouteInstance bypassRouteInstance = new()
            {
                Id = Guid.NewGuid(),
                PerformerId = Guid.Parse(instance.PerformerId),
                BeginDateTime = instance.BeginDateTime,
                EndDateTime = instance.EndDateTime,
                BypassRouteId = Guid.Parse(instance.BypassRouteId)
            };
            _context.BypassRouteInstances.Add(bypassRouteInstance);
            _context.SaveChanges();

            return bypassRouteInstance;
        }
    }
}
