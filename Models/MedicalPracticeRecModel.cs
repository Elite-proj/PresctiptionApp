using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace E_prescription.Models
{
    public class MedicalPracticeRecModel
    {
        public int MedicalPracticeId { get; set; }
        [Required(ErrorMessage = "Please enter medical practice name.")]
        public string PracticeName { get; set; }
        [Required(ErrorMessage = "Please enter Address Line 1.")]
        public string AddressLine1 { get; set; }
        [Required(ErrorMessage = "Please enter Address Line 2.")]
        public string AddressLine2 { get; set; }
        [Required(ErrorMessage = "Please enter practice email.")]
        public string PracticeEmail { get; set; }
        [Required(ErrorMessage = "Please enter practice contact number.")]
        public string PracticeContactNo { get; set; }
        [Required(ErrorMessage = "Please enter Practice number.")]
        public string PracticeNo { get; set; }

        [Required(ErrorMessage = "Please enter city.")]
        public virtual CityModel City { get; set; }
        [Required(ErrorMessage = "Please enter Suburb.")]
        public virtual SuburbModel Suburb {get; set; }
        [Required(ErrorMessage = "Please enter Province.")]
        public virtual ProvinceModel Province { get; set; }

        //public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
