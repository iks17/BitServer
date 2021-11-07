using System;
using System.Collections.Generic;

#nullable disable

namespace BitServerBL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            BusinessAccounts = new HashSet<BusinessAccount>();
            PrivateAccounts = new HashSet<PrivateAccount>();
            TransactionLogReceivers = new HashSet<TransactionLog>();
            TransactionLogSenders = new HashSet<TransactionLog>();
        }

        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<BusinessAccount> BusinessAccounts { get; set; }
        public virtual ICollection<PrivateAccount> PrivateAccounts { get; set; }
        public virtual ICollection<TransactionLog> TransactionLogReceivers { get; set; }
        public virtual ICollection<TransactionLog> TransactionLogSenders { get; set; }
    }
}
