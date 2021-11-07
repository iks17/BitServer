using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitServerBL.ModelsBL
{
    class UserBL:BitDBContextBL
    {
        public User Login(string email, string pswd)
        {
            Users user = this.Users
                .Include(us => us.)
                .Include(uc => uc.)
                .Where(u => u.Email == email && u.Pass == pswd).FirstOrDefault();

            return user;
        }
    }
}
}
