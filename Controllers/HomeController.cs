using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoutesREST.Models.Entities;
using RoutesREST.Models.IRepositories;
using System.Reflection.Metadata;

namespace RoutesREST.Controllers
{
    [Authorize]
    [Route("api")]
    public class HomeController : ControllerBase
    {
        private IBypassRouteRepository _bypassRouteRepository;
        private IBypassRoutePointRepository _bypassRoutePointRepository;
        private IConfiguration _configuration;

        public HomeController(IBypassRouteRepository bypassRouteRepository, IBypassRoutePointRepository bypassRoutePointRepository, IConfiguration configuration)
        {
            _bypassRouteRepository = bypassRouteRepository;
            _bypassRoutePointRepository = bypassRoutePointRepository;
            _configuration = configuration;
        }
        [Route("routes")]
        [HttpGet]
        public List<BypassRoute> GetBypassRoutes() => _bypassRouteRepository.GetAllBypassRoutes();
        [Route("getroutebyid")]
        [HttpGet]
        public IActionResult GetRouteById([FromQuery] string routeId) => Ok(_bypassRouteRepository.GetBypassRouteById(Guid.Parse(routeId)));
        [Route("checkroutepoint")]
        [HttpPatch]
        public IActionResult CheckRoutePoint([FromQuery] string routePointId, [FromQuery] string dateTimeString) => Ok(_bypassRoutePointRepository.CheckBypassRoute(routePointId, dateTimeString));
        [Route("checkroute")]
        [HttpPatch]
        public IActionResult CheckBypassRoute([FromQuery] string routeId) => Ok(_bypassRouteRepository.CheckBypassRoute(Guid.Parse(routeId)));
    }
}
