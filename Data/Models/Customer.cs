using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_CW.Data.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public  MemberType Membertype{ get; set; }



    }
}
