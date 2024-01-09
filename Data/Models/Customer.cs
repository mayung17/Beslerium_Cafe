using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_CW.Data.Models
{
    public class Customer
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public MemberType MemberType { get; set; }
        public double Discount { get; set; } = 0;
        public int PurchaseCount { get; set; } = 0;
        public int RedemptionCount { get; set; } = 0;
        public bool IsMembershipActive { get; set; } = true;

        public DateTime MembershipStartDate { get; set; } 
        public DateTime MembershipRenewalMonth {  get; set; }
        public Customer()
        {
            // Set the membership start date to the current date
            MembershipStartDate = DateTime.Now;

            // Calculate the renewal date by adding one month to the start date
            MembershipRenewalMonth = MembershipStartDate.AddMonths(1);
        }
    }
}
