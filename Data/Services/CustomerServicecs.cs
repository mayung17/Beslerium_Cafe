using POS_CW.Data.models;
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
        new Customer { Username = "mayung", PhoneNumber = "9862884245", MemberType = MemberType.Regular },
        new Customer { Username = "bishal", PhoneNumber = "9862884245", MemberType = MemberType.Member},
    };

        public Customer IsApplicableForSchemes(string Username, string Phonenumber)
        {
            return _customers.FirstOrDefault(u => u.Username == Username && u.PhoneNumber == Phonenumber);
        }

        public void IncrementPurchaseCount(string Username, string Phonenumber)
        {
            var user = _customers.FirstOrDefault(u => u.Username == Username && u.PhoneNumber == Phonenumber);
            if (user != null)
            {
                if (user.MemberType == MemberType.Member)
                {
                    user.PurchaseCount++;
                }
            }
        }

        public void IncrementRedemptionCount(string Username, string Phonenumber)
        {
            var user = _customers.FirstOrDefault(u => u.Username == Username && u.PhoneNumber == Phonenumber);
            if (user != null)
            {
                if (user.MemberType == MemberType.Member)
                {
                    if (user.PurchaseCount % 10 == 0)
                    {
                        user.RedemptionCount++;
                    }
                }
            }
        }

        public void ApplyFlatDiscount(string Username, string Phonenumber)
        {
            var user = _customers.FirstOrDefault(u => u.Username == Username && u.PhoneNumber == Phonenumber);
            if (user != null)
            {
                if (DateTime.Now != user.MembershipRenewalMonth)
                {
                    user.Discount = 0.10;
                }
                
            }
        }
        public void Valid(string Username, string Phonenumber)
        {
            var user = _customers.FirstOrDefault(u => u.Username == Username && u.PhoneNumber == Phonenumber);
            if (user != null)
            {
                if (user.MemberType == MemberType.Member)
                {
                    user.PurchaseCount++;
                }
            }
        }
        public void RenewMembership(string Username, string Phonenumber)
        {
            var user = _customers.FirstOrDefault(u => u.Username == Username && u.PhoneNumber == Phonenumber);
            if (user != null)
            {
                if (user.MembershipRenewalMonth==DateTime.Now)
                {
                    if (user.IsMembershipActive == false)
                    {
                        user.IsMembershipActive = true;
                    }
                }
            }
        }
   


        // Add a method for membership renewal if needed

        // Add other methods as required
    }

}