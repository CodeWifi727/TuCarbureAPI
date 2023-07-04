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
    public class CarburantController : ControllerBase
    {
        private readonly ILogger<CarburantController> _logger;

        private IRepository<Carburant> _repo;

        public CarburantController(ILogger<CarburantController> logger, IRepository<Carburant> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet(Name = "GetCarburant")]

        public List<Carburant> Get()
        {
            List<Carburant> list;

            list = _repo.Get();

            return list;

            //return StatusCode(StatusCodes.Status200OK, list);
        }
    }
}