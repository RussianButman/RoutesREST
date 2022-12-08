using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoutesREST.Models;
using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;
using RoutesREST.Models.IRepositories;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace RoutesREST.Controllers
{
    [Authorize]
    [Route("api")]
    public class HomeController : ControllerBase
    {
        private IBypassRouteRepository _bypassRouteRepository;
        private IBypassRoutePointRepository _bypassRoutePointRepository;
        private IBypassRouteInstanceRepository _bypassRouteInstanceRepository;

        public HomeController(IBypassRouteRepository bypassRouteRepository, IBypassRoutePointRepository bypassRoutePointRepository, IBypassRouteInstanceRepository bypassRouteInstanceRepository)
        {
            _bypassRouteRepository = bypassRouteRepository;
            _bypassRoutePointRepository = bypassRoutePointRepository;
            _bypassRouteInstanceRepository = bypassRouteInstanceRepository;
        }
        [Route("routes")]
        [HttpGet]
        public List<BypassRoute> GetBypassRoutes() => _bypassRouteRepository.BypassRoutes.ToList();
        [Route("getroutebyid")]
        [HttpGet]
        public IActionResult GetRouteById([FromQuery] string routeId)
        {
            if (!_bypassRouteRepository.BypassRoutes.Any(r => r.Id == Guid.Parse(routeId)))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "BypassRoute with specified Id was not found");
            } else
            {
                return Ok(_bypassRouteRepository.GetBypassRouteById(Guid.Parse(routeId)));
            }
        }

        [Route("checkroutepoint")]
        [HttpPatch]
        public IActionResult CheckRoutePoint([FromQuery] string routePointId, [FromQuery] string dateTimeString)
        {
            if (!_bypassRoutePointRepository.BypassRoutePoints.Any(r => r.Id == Guid.Parse(routePointId)))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "BypassRoutePoint with specified Id was not found");
            } else
            {
                return Ok(_bypassRoutePointRepository.CheckBypassRoute(routePointId, dateTimeString));
            }
        }

        [Route("checkroute")]
        [HttpPut]
        public ActionResult CheckBypassRoute([FromQuery] string bypassRouteId, [FromBody] BypassRouteInstanceCreate bypassRouteInstance)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!_bypassRouteRepository.BypassRoutes.Any(r => r.Id == Guid.Parse(bypassRouteId)))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "BypassRoute with specified Id was not found");
            }
            else if (userId == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "User with specified Id was not found");
            }
            else
            {
                return Ok(_bypassRouteInstanceRepository.AddBypassRouteInstance(userId, bypassRouteId, bypassRouteInstance));
            }
        }
        [Route("getmyroutes")]
        [HttpGet]
        public async Task<IActionResult> GetMyRoutesAsync()
        {
            var myRoutes = await _bypassRouteInstanceRepository.GetRouteInstancesByPerformerIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (myRoutes == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There's no route instances attached to you");
            } else
            {
                return Ok(myRoutes);
            }
        }
    }
}
