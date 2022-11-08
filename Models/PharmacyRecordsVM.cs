using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_prescription.Models
{
    public class PharmacyRecordsVM
    {

        public int PharmacyId { get; set; }
        [Required(ErrorMessage ="Please enter pharmacy name.")]
        public string PharmacyName { get; set; }

        [Required(ErrorMessage ="Please enter pharmacy contact number.")]
        public string PharmacyContactNo { get; set; }

        [Required(ErrorMessage ="Please enter pharmacy email.")]
        [EmailAddress(ErrorMessage ="Invalid email.")]
        [Compare("ConfirmEmail")]
        public string PharmacyEmail { get; set; }

        [Required(ErrorMessage ="Please confirm email address.")]
        [EmailAddress(ErrorMessage ="Invalid email.")]
        [Display(Name ="Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage ="Please enter license number.")]
        public string LicenseNo { get; set; }
        
        [Required(ErrorMessage ="Please enter address line 1.")]
        public string AddressLine1 { get; set; }

        [Required(ErrorMessage ="Please enter address line 2.")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage ="Please select suburb.")]
        public int? SuburbID { get; set; }

        [Required(ErrorMessage ="Please select city.")]
        public int CityId { get; set; }

        [Required(ErrorMessage ="Please select province.")]
        public int ProvinceId { get; set; }

        public string Status { get; set; }
        [Required(ErrorMessage ="Please enter postal code")]
        public string PostalCode { get; set; }

        public string PharmacistID { get; set; }
    }
}
