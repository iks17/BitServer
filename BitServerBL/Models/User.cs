using System;
using System.Collections.Generic;

#nullable disable

namespace BitServerBL.Models
{
    public partial class User
    {
        public User()
        {
            Customers = new HashSet<Customer>();
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
