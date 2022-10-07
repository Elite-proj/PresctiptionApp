using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class Admin
    {
        public int AdminId { get; set; }

        public virtual TblUser AdminNavigation { get; set; }
    }
}
