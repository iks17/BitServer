using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitServerBL.Models
{
    partial class BitDBContext
    { 
        public User Login(string email, string pswd)
        {
            User user = this.Users
                .Include(us => us.Admins)
                .Include(uc => uc.Customers)
                .Where(u => u.Email == email && u.Password == pswd).FirstOrDefault();

            return user;
        }
    }
}
