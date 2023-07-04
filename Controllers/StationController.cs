using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TuCarbureAPI.EntityLayer;
using TuCarbureAPI.Interfaces;

namespace TuCarbureAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly ILogger<StationController> _logger;

        private IRepository<Station> _repo;

        public StationController(ILogger<StationController> logger, IRepository<Station> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet(Name = "GetStation")]

        public List<Station> Get()
        {
            List<Station> list;

            list = _repo.Get();

            return list;

            //return StatusCode(StatusCodes.Status200OK, list);
        }
    }
}