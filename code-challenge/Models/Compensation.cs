using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace challenge.Models
{
    public class Compensation
    {
        [Key]
        public String employeeId { get; set; }
        public Employee employee { get; set; }
        public double salary { get; set; }
        public DateTime date { get; set; }
    }
}
