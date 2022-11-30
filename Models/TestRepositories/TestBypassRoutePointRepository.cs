using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;
using RoutesREST.Models.IRepositories;

namespace RoutesREST.Models.TestRepositories
{
    public class TestBypassRoutePointRepository : IBypassRoutePointRepository
    {
        private List<BypassRoutePoint> _bypassRoutePoints = new()
        {
            new()
            {
                Id = new Guid(),
                BypassRouteIndex = 1,
                Location = new()
                {
                    Id = new Guid(),
                    Latitude = 10.000001,
                    Longitude = 101.000001
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
                NfcTagId = "04 9C 64 D2 45 2B 80"
            }
        };

        public void AddBypassRoutePoint(BypassRoutePoint bypassRoutePoint) => _bypassRoutePoints.Add(bypassRoutePoint);

        public List<BypassRoutePoint> GetBypassRoutePoints() => _bypassRoutePoints;
        public BypassRoutePoint GetWalkRoutePointById(Guid id) => _bypassRoutePoints.First(b => b.Id == id);
        public List<BypassRoutePoint> GetWalkRoutePointsByRegion(LatLongPoint[] latLongPoints)
        {
            throw new NotImplementedException();
        }
    }
}
