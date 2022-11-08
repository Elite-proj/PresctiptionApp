using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_prescription.Models.Account
{
    public class DoctorAccount
    {
        public int DoctorID { get; set; }
        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your surname.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Incorrect email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Confirm email address.")]
        [EmailAddress(ErrorMessage = "Incorrect email address.")]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "Please enter contact number.")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Please select suburb.")]
        public int SuburbID { get; set; }

        [Required(ErrorMessage = "Please select city.")]
        public int CityID { get; set; }

        [Required(ErrorMessage = "Please select province.")]
        public int ProvinceID { get; set; }

        [Required(ErrorMessage = "Please enter address.")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string UserType { get; set; }
        public string UserStatus { get; set; }

        [Required(ErrorMessage ="Please enter HCRN.")]
        public string HCRN { get; set; }

        [Required(ErrorMessage ="Please select qualification.")]
        public int QualificationID { get; set; }

        [Required(ErrorMessage ="Please select medical practice")]
        public int MedicalPracticeID { get; set; }

        [Required(ErrorMessage = "Please enter postal code.")]
        public string PostalCode { get; set; }
    }
}
