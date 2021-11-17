using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitServerBL.Models;
using Microsoft.EntityFrameworkCore;

namespace BitServerBL.Models
{
    class UserBL:BitDBContext
    {
        public User Login(string email, string pswd)
        {
            User user = this.Users
                .Include(us => us.Admins)
                .Include(uc => uc.Customers)
                .Where(u => u.Email == email && u.Pass == pswd).FirstOrDefault();

            return user;
        }
    }
}

