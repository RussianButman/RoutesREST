using RoutesREST.Models.Entities;
using RoutesREST.Models.IRepositories;

namespace RoutesREST.Models.TestRepositories
{
    public class TestBypassRouteRepository : IBypassRouteRepository
    {
        private IBypassRoutePointRepository _bypassRoutePointRepository;

        public TestBypassRouteRepository(IBypassRoutePointRepository bypassRoutePointRepository)
        {
            _bypassRoutePointRepository = bypassRoutePointRepository;
            _bypassRoutes = new()
            {
                new()
                {
                    Id = 1,
                    Name = "Маршрут 1",
                    Performer = new()
                    {
                        Id = 1,
                        Name = "Бондарь Антон Алексеевич"
                    },
                    Location = new()
                    {
                        Id = 1,
                        Latitude = 82.000001,
                        Longitude = 125.000001
                    },
                    BypassDatetimes = new()
                    {
                        new(2022, 11, 25, 10, 43, 30),
                        new(2022, 11, 25, 10, 43, 31),
                        new(2022, 11, 25, 10, 43, 32),
                        new(2022, 11, 25, 10, 43, 33),
                        new(2022, 11, 25, 10, 43, 34)
                    },
                    BypassRoutePoints = _bypassRoutePointRepository.GetBypassRoutePoints()
                }
            };
        }

        private List<BypassRoute> _bypassRoutes;
        public void AddBypassRoute(BypassRoute bypassRoute) => _bypassRoutes.Add(bypassRoute);

        public List<BypassRoute> GetAllBypassRoutes() => _bypassRoutes;

        public BypassRoute GetBypassRouteById(int id)
        {
            throw new NotImplementedException();
        }

        public BypassRoute GetBypassRouteByLocation(BypassRouteLocation location)
        {
            throw new NotImplementedException();
        }

        public BypassRoute GetBypassRouteByPerformerName(string performerName)
        {
            throw new NotImplementedException();
        }
    }
}
