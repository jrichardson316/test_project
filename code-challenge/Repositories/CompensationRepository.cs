using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using challenge.Services;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using challenge.Data;

namespace challenge.Repositories
{
    public class CompensationRepository : ICompensationRepository 
    {
        private readonly CompensationContext _compensationContext;
        private readonly ILogger<IEmployeeRepository> _logger;
        private readonly IEmployeeService _employeeService;

        public CompensationRepository(CompensationContext compensationContext, ILogger<IEmployeeRepository> logger, IEmployeeService employeeService)
        {
            _compensationContext = compensationContext;
            _logger = logger;
            _employeeService = employeeService;
        }

        public Compensation Add(string id, double salary, DateTime date)
        {
            Employee e = _employeeService.GetById(id);

            Compensation _comp = new Compensation();
            _comp.employee = e;
            _comp.salary = salary;
            _comp.date = date;
            _comp.employeeId = e.EmployeeId;

            _compensationContext.compensation.Add(_comp);

            return _comp;
        }

        public Compensation GetById(string id)
        {
            var all_employees = _compensationContext.compensation.Include(c => c.employee).ToList();
            var compensation = all_employees.Where(c => c.employeeId == id).FirstOrDefault();

            return compensation;
        }

        public Task SaveAsync()
        {
            return _compensationContext.SaveChangesAsync();
        }

        public Compensation Remove(Compensation compensation)
        {
            return _compensationContext.Remove(compensation).Entity;
        }
    }
}
