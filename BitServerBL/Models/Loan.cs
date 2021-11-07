using System;
using System.Collections.Generic;

#nullable disable

namespace BitServerBL.Models
{
    public partial class Loan
    {
        public int LoanId { get; set; }
        public double UserBalance { get; set; }
        public double Balance { get; set; }
        public int ApprovedBy { get; set; }
        public string BusinessId { get; set; }
        public string PrivateId { get; set; }

        public virtual Admin ApprovedByNavigation { get; set; }
        public virtual BusinessAccount Business { get; set; }
        public virtual PrivateAccount Private { get; set; }
    }
}
