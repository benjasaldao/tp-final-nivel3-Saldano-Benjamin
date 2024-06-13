using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Dominio
{
    public static class Security
    {
        public static bool activeSession(object currentUser)
        {
            User user = currentUser != null ? (User)currentUser : null;
            if (user != null && user.id != 0)
                return true;
            else
                return false;
        }

        public static bool isAdmin(object currentUser)
        {
            User user = currentUser != null ? (User)currentUser : null;
            return user != null ? user.isAdmin : false;
        }
    }
}
