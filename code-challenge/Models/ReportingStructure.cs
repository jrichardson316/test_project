using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class ReportingStructure
    {
        public int numberOfReports;
        public Employee employee;

        public ReportingStructure(int _numberOfReports, Employee _employee)
        {
            numberOfReports = _numberOfReports;
            employee = _employee;
        }

        public int getNumberOfReports()
        {
            return numberOfReports;
        }

        public Employee getEmployee()
        {
            return employee;
        }

    }
}
