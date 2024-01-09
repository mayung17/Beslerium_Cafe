using POS_CW.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_CW.Data.Models
{
    public class Payments
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Order order { get; set; }
        public String Username { get; set; }
        public String PhoneNumber { get; set; }

        public double Discount { get; set; }



    }
}
