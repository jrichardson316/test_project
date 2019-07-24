using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;

namespace challenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly ICompensationRepository _compensationRepository;
        private readonly ILogger<EmployeeService> _logger;


        public CompensationService(ICompensationRepository compensationRepository, ILogger<EmployeeService> logger)
        {
            _compensationRepository = compensationRepository;
            _logger = logger;
        }

        public Compensation Create(string id, double salary, DateTime date)
        {

            if (id != null && date != null)
            {
                var comp = _compensationRepository.Add(id, salary, date);
                _compensationRepository.SaveAsync().Wait();
                return comp;
            }
            return null;
        }

        public Compensation GetById(String id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                return _compensationRepository.GetById(id);
            }
            return null;
        }
    }
}
