using System;
using System.Collections.Generic;

#nullable disable

namespace BitServerBL.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Loans = new HashSet<Loan>();
        }

        public int AdminId { get; set; }
        public int EnrolledCustomers { get; set; }
        public DateTime LastOnline { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
