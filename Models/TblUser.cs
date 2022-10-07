using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class TblUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string UserType { get; set; }
        public int? SuburbId { get; set; }
        public string UserStatus { get; set; }

        public virtual Suburb Suburb { get; set; }
        public virtual Admin Admin { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Pharmacist Pharmacist { get; set; }
    }
}
