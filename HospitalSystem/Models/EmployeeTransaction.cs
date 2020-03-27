using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSystem.Models
{
    public class EmployeeTransaction
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LocalIp { get; set; }
        public int Date { get; set; }
        public int IsSuccess { get; set; }
        public int IsOpen { get; set; }
    }
}
