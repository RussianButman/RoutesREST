using Microsoft.AspNetCore.Identity;
using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;
using RoutesREST.Models.IRepositories;

namespace RoutesREST.Models.Repositories
{
    public class BypassRouteInstanceRepository : IBypassRouteInstanceRepository
    {
        private ApplicationDbContext _context;
        private UserManager<AppUser> _userManager;

        public BypassRouteInstanceRepository(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IQueryable<BypassRouteInstance> BypassRouteInstances => _context.BypassRouteInstances;

        public BypassRouteInstance AddBypassRouteInstance(string userId, string routeId, BypassRouteInstanceCreate instance)
        {
            BypassRouteInstance bypassRouteInstance = new()
            {
                Id = Guid.NewGuid(),
                PerformerId = Guid.Parse(userId),
                BeginDateTime = instance.BeginDateTime,
                EndDateTime = instance.EndDateTime,
                BypassRouteId = Guid.Parse(routeId)
            };
            _context.BypassRouteInstances.Add(bypassRouteInstance);
            _context.SaveChanges();

            return bypassRouteInstance;
        }

        public async Task<List<BypassRouteInstance>?> GetRouteInstancesByPerformerIdAsync(string performerId)
        {
            if ((await _userManager.FindByIdAsync(performerId)) == null)
            {
                return null;
            } else
            {
                var user = await _userManager.FindByIdAsync(performerId);

                return _context.BypassRouteInstances.Where(r => r.PerformerId.ToString() == user.Id).ToList();
            }
        }
    }
}
