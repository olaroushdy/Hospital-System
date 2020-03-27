using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSystem.Models
{
    public class PatientHistory
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string DiseaseType { get; set; }
        public bool IsChronic { get; set; }
        public bool IsHereditany { get; set; }
        public bool IsInfection { get; set; }
        public DateTime EnteranceDate { get; set; }
        public DateTime LeaveDate { get; set; }
        public string Doctor { get; set; }
        public string Diagnose { get; set; }
        public string Department { get; set; }
    }
}
