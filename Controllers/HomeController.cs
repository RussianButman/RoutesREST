using Microsoft.AspNetCore.Mvc;
using RoutesREST.Models.Entities;
using RoutesREST.Models.IRepositories;

namespace RoutesREST.Controllers
{
    [Route("api")]
    public class HomeController : ControllerBase
    {
        private IBypassRouteRepository _bypassRouteRepository;

        public HomeController(IBypassRouteRepository bypassRouteRepository)
        {
            _bypassRouteRepository = bypassRouteRepository;
        }
        [Route("routes")]
        [HttpGet]
        public List<BypassRoute> GetBypassRoutes() => _bypassRouteRepository.GetAllBypassRoutes();
        [HttpGet]
        public IActionResult GetRouteById([FromRoute] int id)
        {
            return new StatusCodeResult(StatusCodes.Status200OK);
        }
    }
}
