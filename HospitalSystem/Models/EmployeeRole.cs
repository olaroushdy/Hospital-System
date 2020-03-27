using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSystem.Models
{
    public class EmployeeRole
    {
        [Key, Column(Order = 1)]
        public int EmployeeId { get; set; }
        [Key, Column(Order = 2)]
        public int PatientTypeId { get; set; }
        public Employee Employee { get; set; }
        public PatientType PatientType { get; set; }
    }
}
