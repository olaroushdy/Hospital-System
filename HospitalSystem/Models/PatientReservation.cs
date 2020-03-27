using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSystem.Models
{
    public class PatientReservation
    {
        public int Id { get; set; }
        public string FildeId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Arabic Name is required.")]
        public string ArabicName { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Nationality is required.")]
        public string Nationality { get; set; }
        public string NationalId { get; set; }
        public int PatientTypeId { get; set; }
        public string HomeNumber { get; set; }

        [Display(Name = "Mobile")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^01[0-2][0-9]{8}$", ErrorMessage = "Invalid Mobile Number.")]
        public string MobileNumber { get; set; }
        public int? PatientHistoryId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsSickHistory { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public PatientHistory PatientHistory { get; set; }
        public PatientType PatientType { get; set; }
        public Employee Employee { get; set; }
    }
}
