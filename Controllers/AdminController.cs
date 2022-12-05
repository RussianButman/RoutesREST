using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoutesREST.Models;
using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;
using RoutesREST.Models.IRepositories;

namespace RoutesREST.Controllers
{
    [Authorize]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private IBypassRoutePointRepository _bypassRoutePointRepository;
        private IBypassRouteRepository _bypassRouteRepository;
        // private IPerformerRepository _performerRepository;
        public AdminController(IBypassRoutePointRepository bypassRoutePointRepository, IBypassRouteRepository bypassRouteRepository /*IPerformerRepository performerRepository*/)
        {
            _bypassRoutePointRepository = bypassRoutePointRepository;
            _bypassRouteRepository = bypassRouteRepository;
            // _performerRepository = performerRepository;
        }
        [Route("addbypassroute")]
        [HttpPut]
        public IActionResult AddBypassRoute([FromBody] BypassRouteCreate bypassRouteCreate) => Ok(_bypassRouteRepository.AddBypassRoute(bypassRouteCreate));

        [Route("addbypassroutepoint/{routeId}")]
        [HttpPut]
        public IActionResult AddBypassRoutePoint([FromRoute] string routeId, [FromBody] LatLongPoint latLongPoint) => Ok(_bypassRoutePointRepository.AddBypassRoutePoint(routeId, latLongPoint));

        [Route("editbypassroute")]
        [HttpPatch]
        public IActionResult EditBypassRoute([FromBody] BypassRoute bypassRoute) => Ok(_bypassRouteRepository.EditBypassRoute(bypassRoute));

        [Route("deletebypassroute")]
        [HttpDelete]
        public IActionResult DeleteBypassRoute([FromQuery] string routeId)
        {
            _bypassRouteRepository.DeleteBypassRoute(Guid.Parse(routeId));

            return new StatusCodeResult(StatusCodes.Status200OK);
        }

        /*[Route("addperformer")]
        [HttpPut]
        // 00000000-0000-0000-0000-000000000000
        public IActionResult AddPerformer([FromBody] AppUser performer)
        {            
            return Ok(_performerRepository.AddPerformer(performer));
        }*/
        /*[Route("getperformers")]
        [HttpGet]
        public IActionResult GetPerformers() => Ok(_performerRepository.GetAllPerformers());*/
        [Route("assignperformer")]
        [HttpPatch]
        public IActionResult AssignPerformer([FromQuery] string routeId, [FromQuery] string performerId) => Ok(_bypassRouteRepository.AssignPerformer(Guid.Parse(routeId), performerId).Result);
        [Route("assigntag")]
        [HttpPatch]
        public IActionResult AssignTag([FromQuery] string routePointId, [FromQuery] string nfcTagUid)
        {
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
