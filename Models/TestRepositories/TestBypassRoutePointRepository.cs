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
                Id = 1,
                BypassRouteIndex = 1,
                Location = new()
                {
                    Id = 2,
                    Latitude = 10.000001,
                    Longitude = 101.000001
                } ,
                BypassDatetimes = new()
                {
                    new(2022, 11, 25, 10, 45, 30),
                    new(2022, 11, 25, 10, 45, 31),
                    new(2022, 11, 25, 10, 45, 32),
                    new(2022, 11, 25, 10, 45, 33),
                    new(2022, 11, 25, 10, 45, 34),
                }
            },
            new()
            {
                Id = 2,
                BypassRouteIndex = 2,
                Location = new()
                {
                    Id = 2,
                    Latitude = 10.000001,
                    Longitude = 101.000001
                } ,
                BypassDatetimes = new()
                {
                    new(2022, 11, 25, 10, 45, 30),
                    new(2022, 11, 25, 10, 45, 31),
                    new(2022, 11, 25, 10, 45, 32),
                    new(2022, 11, 25, 10, 45, 33),
                    new(2022, 11, 25, 10, 45, 34),
                }
            },
            new()
            {
                Id = 3,
                BypassRouteIndex = 3,
                Location = new()
                {
                    Id = 2,
                    Latitude = 10.000001,
                    Longitude = 101.000001
                } ,
                BypassDatetimes = new()
                {
                    new(2022, 11, 25, 10, 45, 30),
                    new(2022, 11, 25, 10, 45, 31),
                    new(2022, 11, 25, 10, 45, 32),
                    new(2022, 11, 25, 10, 45, 33),
                    new(2022, 11, 25, 10, 45, 34),
                }
            }
        };

        public void AddBypassRoutePoint(BypassRoutePoint bypassRoutePoint) => _bypassRoutePoints.Add(bypassRoutePoint);

        public List<BypassRoutePoint> GetBypassRoutePoints() => _bypassRoutePoints;
        public BypassRoutePoint GetWalkRoutePointById(int id) => _bypassRoutePoints.First(b => b.Id == id);
        public List<BypassRoutePoint> GetWalkRoutePointsByRegion(LatLongPoint[] latLongPoints)
        {
            throw new NotImplementedException();
        }
    }
}
