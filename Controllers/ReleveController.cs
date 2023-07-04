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
    public class ReleveController : ControllerBase
    {
        private readonly ILogger<ReleveController> _logger;

        private IRepository<Releve> _repo;

        public ReleveController(ILogger<ReleveController> logger, IRepository<Releve> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet(Name = "GetReleve")]

        public List<Releve> Get()
        {
            List<Releve> list;

            list = _repo.Get();

            return list;

            //return StatusCode(StatusCodes.Status200OK, list);
        }
    }
}