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
    [Route("api/reporting")]
    public class ReportingStructureController : Controller
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;
        private int _directReports = 0;

        public ReportingStructureController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet("{id}", Name = "getReportingStructureByEmployeeId")]
        public IActionResult GetEmployeeById(String id)
        {
            _logger.LogDebug($"Received Reporting Structure get request for '{id}'");

            var employee = _employeeService.GetById(id);
            _directReports = 0;
            recursiveCount(employee.DirectReports);

            var reportingStructure = new ReportingStructure(_directReports, employee);


            if (employee == null)
                return NotFound();

            return Ok(reportingStructure);
        }

        public void recursiveCount(List<Employee> employees)
        {
            foreach (Employee e in employees) {
                _directReports++;
                if (e.DirectReports != null)
                {
                    recursiveCount(e.DirectReports);
                }
            }
        }
    }
}
