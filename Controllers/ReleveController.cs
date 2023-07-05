using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TuCarbureAPI.EntityLayer;
using TuCarbureAPI.Interfaces;
using TuCarbureAPI.RepositoryLayer;

namespace TuCarbureAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReleveController : ControllerBase
    {
        private readonly ILogger<ReleveController> _logger;
        private readonly ReleveRepository _releveRepository;

        private IRepository<Releve> _repo;

        public ReleveController(ILogger<ReleveController> logger, IRepository<Releve> repo, IRepository<Releve> releveRepository)
        {
            _logger = logger;
            _repo = repo;
            _releveRepository = (ReleveRepository?)releveRepository;
        }

        [HttpGet(Name = "GetReleve")]

        public List<Releve> Get()
        {
            List<Releve> list;

            list = _repo.Get();

            return list;

            //return StatusCode(StatusCodes.Status200OK, list);
        }

        // PUT: api/Releve/UpdatePrice/{id}
        [HttpPut("UpdatePrice/{id}")]
        public IActionResult UpdatePrice(int id, [FromBody] float newPrice)
        {
            var updatedReleve = _releveRepository.UpdatePriceAndDate(id, newPrice);

            if (updatedReleve == null)
            {
                return NotFound();
            }

            return Ok(updatedReleve);
        }

                // PUT: api/Releve/LastPrice/{id}
        [HttpPut("LastPrice/{id}")]
        public IActionResult LastPrice(int id)
        {
            var updatedReleve = _releveRepository.LastPrice(id);

            if (updatedReleve == null)
            {
                return NotFound();
            }

            return Ok(updatedReleve);
        }
    }
}