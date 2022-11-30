﻿using Microsoft.AspNetCore.Mvc;
using RoutesREST.Models.Entities;
using RoutesREST.Models.IRepositories;

namespace RoutesREST.Controllers
{
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private IBypassRoutePointRepository _bypassRoutePointRepository;
        private IBypassRouteRepository _bypassRouteRepository;

        public AdminController(IBypassRoutePointRepository bypassRoutePointRepository, IBypassRouteRepository bypassRouteRepository)
        {
            _bypassRoutePointRepository = bypassRoutePointRepository;
            _bypassRouteRepository = bypassRouteRepository;
        }
        [Route("addbypassroute")]
        [HttpPost]
        public IActionResult AddBypassRoute([FromBody] BypassRoute bypassRoute)
        {
            bypassRoute.BypassRoutePoints.ForEach(p => _bypassRoutePointRepository.AddBypassRoutePoint(p));
            _bypassRouteRepository.AddBypassRoute(bypassRoute);

            return new StatusCodeResult(StatusCodes.Status201Created);
        }
        [Route("editbypassroute")]
        [HttpPatch]
        public IActionResult EditBypassRoute([FromBody] BypassRoute bypassRoute)
        {
            _bypassRouteRepository.EditBypassRoute(bypassRoute);

            return new StatusCodeResult(StatusCodes.Status200OK);
        }
        [Route("deletebypassroute")]
        [HttpDelete]
        public IActionResult DeleteBypassRoute([FromBody] BypassRoute bypassRoute)
        {
            _bypassRouteRepository.DeleteBypassRoute(bypassRoute);

            return new StatusCodeResult(StatusCodes.Status200OK);
        }
    }
}
