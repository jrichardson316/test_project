using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using challenge.Services;
using challenge.Models;

namespace challenge.Controllers
{
    [Route("api/compensation")]
    public class CompensationController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        public CompensationController(ICompensationService compensationService, ILogger<CompensationController> logger)
        {
            _compensationService = compensationService;
            _logger = logger;
        }

        [HttpGet("{id}", Name = "getCompensationById")]
        public IActionResult GetCompensationById(String id)
        {
               _logger.LogDebug($"Received compensation get request for '{id}'");

               var compensation = _compensationService.GetById(id);

               if (compensation == null)
                   return NotFound();

               return Ok(compensation);
        }

        [HttpPost]
        public IActionResult CreateCompensation(string id, double salary)
        {
            _logger.LogDebug($"Received compensation create request for employee {id}");
            DateTime date = DateTime.Now;
            var comp = _compensationService.Create(id, salary, date);

            return Ok(comp);
        }

    }
}
