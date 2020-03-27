using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSystem.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }

        public IList<EmployeeRole> EmployeeRoles { get; set; }

    }
}
