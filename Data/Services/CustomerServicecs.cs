using POS_CW.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;


namespace POS_CW.Data.Services
{
    public class CustomerServices
    {
        private static List<Customer> _customers = new List<Customer>
    {
        new Customer { Username = "mayung", PhoneNumber = "9862884245", Membertype =MemberType.Member },
        new Customer { Username = "bishal", PhoneNumber = "9862884245", Membertype =MemberType.Regular },
    };

        public Customer IsApplicableForSchemes(string Username, string Phonenumber)
        {
            var user = _customers.FirstOrDefault(u => u.Username == Username && u.PhoneNumber == Phonenumber);
            return user;
        }
    }
}