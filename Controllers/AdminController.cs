using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoutesREST.Models;
using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;
using RoutesREST.Models.IRepositories;

namespace RoutesREST.Controllers
{
    //[Authorize]
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
        public IActionResult AddBypassRoutePoint([FromRoute] string routeId, [FromBody] LatLongPoint latLongPoint)
        {
            if (!_bypassRouteRepository.BypassRoutes.Any(r => r.Id == Guid.Parse(routeId)))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "BypassRoute with specified Id was not found");
            } else
            {
                return Ok(_bypassRoutePointRepository.AddBypassRoutePoint(routeId, latLongPoint));
            }
        }

        [Route("editbypassroute")]
        [HttpPatch]
        public IActionResult EditBypassRoute([FromBody] BypassRoute bypassRoute)
        {
            if (!_bypassRouteRepository.BypassRoutes.Any(r => r.Id == bypassRoute.Id))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "BypassRoute with specified Id was not found");
            } else
            {
                return Ok(_bypassRouteRepository.EditBypassRoute(bypassRoute));
            }
        }

        [Route("deletebypassroute")]
        [HttpDelete]
        public IActionResult DeleteBypassRoute([FromQuery] string routeId)
        {
            if (!_bypassRouteRepository.BypassRoutes.Any(r => r.Id == Guid.Parse(routeId)))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "BypassRoute with specified Id was not found");
            }
            else
            {
                _bypassRouteRepository.DeleteBypassRoute(Guid.Parse(routeId));

                return new StatusCodeResult(StatusCodes.Status200OK);
            }
        }

        [Route("assignnfctag")]
        [HttpPatch]
        public IActionResult AssignNfcTag([FromQuery] string routePointId, [FromQuery] string nfcTagUid)
        {
            if (!_bypassRoutePointRepository.BypassRoutePoints.Any(rp => rp.Id == Guid.Parse(routePointId)))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "BypassRoutePoint with specified Id was not found");
            } else
            {
                return StatusCode(StatusCodes.Status200OK);
            }
        }
    }
}
