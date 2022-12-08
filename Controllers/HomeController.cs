using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoutesREST.Models;
using RoutesREST.Models.Entities;
using RoutesREST.Models.HelperEntities;
using RoutesREST.Models.IRepositories;
using System.Reflection.Metadata;

namespace RoutesREST.Controllers
{
    //[Authorize]
    [Route("api")]
    public class HomeController : ControllerBase
    {
        private IBypassRouteRepository _bypassRouteRepository;
        private IBypassRoutePointRepository _bypassRoutePointRepository;
        private IBypassRouteInstanceRepository _bypassRouteInstanceRepository;
        private UserManager<AppUser> _userManager;
        private IConfiguration _configuration;

        public HomeController(IBypassRouteRepository bypassRouteRepository, IBypassRoutePointRepository bypassRoutePointRepository, IConfiguration configuration, IBypassRouteInstanceRepository bypassRouteInstanceRepository, UserManager<AppUser> userManager)
        {
            _bypassRouteRepository = bypassRouteRepository;
            _bypassRoutePointRepository = bypassRoutePointRepository;
            _configuration = configuration;
            _bypassRouteInstanceRepository = bypassRouteInstanceRepository;
            _userManager = userManager;
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
        public async Task<ActionResult> CheckBypassRoute([FromBody] BypassRouteInstanceCreate bypassRouteInstance)
        {
            if (!_bypassRouteRepository.BypassRoutes.Any(r => r.Id == Guid.Parse(bypassRouteInstance.BypassRouteId)))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "BypassRoute with specified Id was not found");
            }
            else if (_userManager.FindByIdAsync(bypassRouteInstance.PerformerId.ToString()).Result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "User with specified Id was not found");
            }
            else
            {
                return Ok(_bypassRouteInstanceRepository.AddBypassRouteInstance(bypassRouteInstance));
            }
        }
    }
}
