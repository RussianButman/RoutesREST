using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoutesREST.Models.Entities;
using RoutesREST.Models.IRepositories;
using System.Reflection.Metadata;

namespace RoutesREST.Controllers
{
    [Route("api")]
    public class HomeController : ControllerBase
    {
        private IBypassRouteRepository _bypassRouteRepository;
        private IBypassRoutePointRepository _bypassRoutePointRepository;

        public HomeController(IBypassRouteRepository bypassRouteRepository, IBypassRoutePointRepository bypassRoutePointRepository)
        {
            _bypassRouteRepository = bypassRouteRepository;
            _bypassRoutePointRepository = bypassRoutePointRepository;
        }
        [Route("routes")]
        [HttpGet]
        public List<BypassRoute> GetBypassRoutes() => _bypassRouteRepository.GetAllBypassRoutes();
        [Route("getroutebyid/{routeId}")]
        [HttpGet]
        public IActionResult GetRouteById([FromRoute] string routeId) => Ok(_bypassRouteRepository.GetBypassRouteById(Guid.Parse(routeId)));
        [Route("checkroutepoint/{routePointId}")]
        [HttpPatch]
        public IActionResult CheckRoutePoint([FromRoute] string routePointId, [FromBody] string dateTimeString) => Ok(_bypassRoutePointRepository.CheckBypassRoute(routePointId, dateTimeString));
        public IActionResult CheckBypassRoute([FromRoute] string routeId)
        {
            _context.
        }
    }
}
