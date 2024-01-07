using POS_CW.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_CW.Data.Services
{
    public class LoginService
    {
        private static List<Users> _users = new List<Users>
    {
        new Users { Email = "user@example.com", Password = "password123", Role = Role.User },
        new Users { Email = "admin@example.com", Password = "adminPassword", Role = Role.Admin }
    };

        public Users AuthenticateUser(string email, string password)
        {
            var user = _users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return user;
        }
    }


}
