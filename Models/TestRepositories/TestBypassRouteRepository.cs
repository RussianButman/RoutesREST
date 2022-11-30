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
                        Id = new Guid(),
                        Latitude = 82.000001,
                        Longitude = 125.000001
                    },
                BypassDatetimes = new()
                {
                    new BypassDateTime()
                    {
                        Id = new Guid(),
                        DateTime = new(2022, 11, 25, 10, 45, 30),
                    },
                    new BypassDateTime()
                    {
                        Id = new Guid(),
                        DateTime = new(2022, 11, 25, 10, 45, 31),
                    },
                    new BypassDateTime()
                    {
                        Id = new Guid(),
                        DateTime = new(2022, 11, 25, 10, 45, 32),
                    },
                    new BypassDateTime()
                    {
                        Id = new Guid(),
                        DateTime = new(2022, 11, 25, 10, 45, 33),
                    },
                    new BypassDateTime()
                    {
                        Id = new Guid(),
                        DateTime = new(2022, 11, 25, 10, 45, 34),
                    },
                    new BypassDateTime()
                    {
                        Id = new Guid(),
                        DateTime = new(2022, 11, 25, 10, 45, 35),
                    }
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

        public void EditBypassRoute(BypassRoute bypassRoute)
        {
            var toEdit = _bypassRoutes.First(p => p.Id == bypassRoute.Id);
            toEdit = bypassRoute;
        }

        public void DeleteBypassRoute(BypassRoute bypassRoute)
        {
            _bypassRoutes.Remove(bypassRoute);
        }
    }
}
