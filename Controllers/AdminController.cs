using Microsoft.AspNetCore.Mvc;
using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;
using RoutesREST.Models.IRepositories;

namespace RoutesREST.Controllers
{
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private IBypassRoutePointRepository _bypassRoutePointRepository;
        private IBypassRouteRepository _bypassRouteRepository;
        private IPerformerRepository _performerRepository;
        public AdminController(IBypassRoutePointRepository bypassRoutePointRepository, IBypassRouteRepository bypassRouteRepository, IPerformerRepository performerRepository)
        {
            _bypassRoutePointRepository = bypassRoutePointRepository;
            _bypassRouteRepository = bypassRouteRepository;
            _performerRepository = performerRepository;
        }
        [Route("addbypassroute")]
        [HttpPut]
        public IActionResult AddBypassRoute([FromBody] BypassRouteCreate bypassRouteCreate) => Ok(_bypassRouteRepository.AddBypassRoute(bypassRouteCreate));

        [Route("addbypassroutepoint/{routeId}")]
        [HttpPut]
        public IActionResult AddBypassRoutePoint([FromRoute] string routeId, [FromBody] LatLongPoint latLongPoint) => Ok(_bypassRoutePointRepository.AddBypassRoutePoint(routeId, latLongPoint));

        [Route("editbypassroute")]
        [HttpPatch]
        public IActionResult EditBypassRoute([FromBody] BypassRoute bypassRoute)
        {
            _bypassRouteRepository.EditBypassRoute(bypassRoute);

            return new StatusCodeResult(StatusCodes.Status200OK);
        }
        [Route("deletebypassroute/{routeId}")]
        [HttpDelete]
        public IActionResult DeleteBypassRoute([FromRoute] string routeId)
        {
            _bypassRouteRepository.DeleteBypassRoute(Guid.Parse(routeId));

            return new StatusCodeResult(StatusCodes.Status200OK);
        }

        [Route("addperformer")]
        [HttpPut]
        // 00000000-0000-0000-0000-000000000000
        public IActionResult AddPerformer([FromBody] Performer performer)
        {
            performer.Id = new Guid();
            
            return Ok(_performerRepository.AddPerformer(performer));
        }
        [Route("getperformers")]
        [HttpGet]
        public IActionResult GetPerformers() => Ok(_performerRepository.GetAllPerformers());
        [Route("assignperformer/{routeId}")]
        [HttpPatch]
        public IActionResult AssignPerformer([FromRoute] string routeId, [FromBody] string performerId) => Ok(_bypassRouteRepository.AssignPerformer(Guid.Parse(routeId), Guid.Parse(performerId)));
    }
}
