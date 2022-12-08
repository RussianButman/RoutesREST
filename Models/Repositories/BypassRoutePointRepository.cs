using Microsoft.AspNetCore.Mvc;
using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;
using RoutesREST.Models.IRepositories;

namespace RoutesREST.Models.Repositories
{
    public class BypassRoutePointRepository : IBypassRoutePointRepository
    {
        private ApplicationDbContext _context;

        public IQueryable<BypassRoutePoint> BypassRoutePoints => _context.BypassRoutePoints;

        public BypassRoutePointRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public BypassRoutePoint AddBypassRoutePoint(string routeId, LatLongPoint latLongPoint)
        {
            if (_context.BypassRoutePointLocations.Where(l => l.Latitude == latLongPoint.Latitude && l.Longitude == latLongPoint.Longitude).Count() == 0)
            {
                _context.BypassRoutePointLocations.Add(new()
                {
                    Id = new Guid(),
                    Latitude = latLongPoint.Latitude,
                    Longitude = latLongPoint.Longitude
                });
                _context.SaveChanges();
            }
            BypassRoutePoint bypassRoutePoint = new()
            {
                Id = new Guid(),
                Location = _context.BypassRoutePointLocations.First(l => l.Latitude == latLongPoint.Latitude && l.Longitude == latLongPoint.Longitude),
                BypassRouteIndex = 1,
                NfcTagId = "",
                BypassRoute = _context.BypassRoutes.First(r => r.Id == Guid.Parse(routeId))
            };
            _context.BypassRoutePoints.Add(bypassRoutePoint);
            _context.SaveChanges();

            return bypassRoutePoint;
        }

        public List<BypassRoutePoint> GetBypassRoutePoints()
        {
            throw new NotImplementedException();
        }

        public BypassRoutePoint GetWalkRoutePointById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<BypassRoutePoint> GetWalkRoutePointsByRegion(LatLongPoint[] latLongPoints)
        {
            throw new NotImplementedException();
        }
        public BypassRoutePoint? CheckBypassRoute(string routePointId, string dateTimeString)
        {
            BypassRoutePoint? bypassRoutePoint = _context.BypassRoutePoints.FirstOrDefault(rp => rp.Id == Guid.Parse(routePointId));

            if (bypassRoutePoint != null)
            {
                bypassRoutePoint.BypassDatetimes.Add(new()
                {
                    Id = new Guid(),
                    DateTime = DateTime.Parse(dateTimeString).ToUniversalTime()
                });
                _context.SaveChanges();
                return bypassRoutePoint;
            }
            else
            {
                return null;
            }
        }
    }
}