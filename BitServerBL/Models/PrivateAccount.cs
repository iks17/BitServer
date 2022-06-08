using System;
using System.Collections.Generic;

#nullable disable

namespace BitServerBL.Models
{
    public partial class PrivateAccount
    {
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public double TotalBalance { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
