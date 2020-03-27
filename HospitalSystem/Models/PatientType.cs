using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSystem.Models
{
    public class PatientType
    {
        public int PatientTypeId { get; set; }
        public string Name { get; set; }

        public IList<EmployeeRole> EmployeeRoles { get; set; }
    }
}
