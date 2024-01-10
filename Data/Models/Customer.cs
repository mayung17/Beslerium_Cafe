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

        public DateTime MembershipStartDate { get; set; } = new DateTime(2024, 1, 10);
        public DateTime MembershipRenewalMonth {  get; set; }
        public Customer()
        {

            // Calculate the renewal date by adding one month to the start date
            MembershipRenewalMonth = MembershipStartDate.AddMonths(1);
        }
    }
}
