using RoutesREST.Models.Entities;
using RoutesREST.Models.IRepositories;

namespace RoutesREST.Models.Repositories
{
    public class PerformerRepository : IPerformerRepository
    {
        private ApplicationDbContext _context;

        public PerformerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Performer> Performers => _context.Performers;

        public Performer AddPerformer(Performer performer)
        {
            _context.Performers.Add(performer);
            _context.SaveChanges();

            return performer;
        }

        public List<Performer> GetAllPerformers() => _context.Performers.ToList();

        public void RemovePerformer(Performer performer)
        {
            _context.Performers.Remove(performer);
            _context.SaveChanges();
        }
    }
}
