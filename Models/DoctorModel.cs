using System.ComponentModel.DataAnnotations;

namespace E_prescription.Models
{
    public class DoctorModel
    {
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Please enter your HRCN.")]
        public string Hcrn { get; set; }
        [Required(ErrorMessage = "Please enter your Highest Qualification.")]
        public virtual HighestQualification Qualification { get; set; }
        [Required(ErrorMessage = "Please select your Medical practice.")]
        public virtual MedicalPractice MedicalPractice { get; set; }
       
        public virtual User User { get; set; }
    }
}
