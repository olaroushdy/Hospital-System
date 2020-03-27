using HospitalSystem.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSystem.ViewModel
{
    public class PatientReservationVM
    {
        public string FildeId { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public byte[] NationalId { get; set; }
        public string PatientType { get; set; }
        public string HomeNumber { get; set; }
        public string MobileNumber { get; set; }
        public string PatientHistoryId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
