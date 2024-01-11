using Newtonsoft.Json;
using POS_CW.Data.models;
using POS_CW.Data.Models;
using POS_CW.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace POS_CW.Data.Services
{
    public class CustomerServices
    {
        private static List<Customer> _customers = new List<Customer>
    {
        new Customer { Username = "mayung", PhoneNumber = "9862884245", MemberType = MemberType.Regular },
        new Customer { Username = "bishal", PhoneNumber = "9862884245", MemberType = MemberType.Member},
    };

        public Customer getCustomerInstance(string Username, string Phonenumber)
        {
            return _customers.FirstOrDefault(u => u.Username == Username && u.PhoneNumber == Phonenumber);
        }
        public Customer createNewCustomer(string Username, string Phonenumber)
        {
           Customer newCustomer=new Customer { Username = Username, PhoneNumber = Phonenumber, MemberType = MemberType.New };
            _customers.Add(newCustomer);
            return newCustomer;
        }


        public void IncrementPurchaseCount(string Username, string Phonenumber)
        {
            var user = _customers.FirstOrDefault(u => u.Username == Username && u.PhoneNumber == Phonenumber);
            if (user != null)
            {
                
                    user.PurchaseCount++;
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
              if (user.MemberType == MemberType.Member || user.MemberType == MemberType.Regular)
                {
                    if (DateTime.Now != user.MembershipRenewalMonth)
                    {
                        user.Discount = 0.10;
                    }
                    else
                    {
                        user.Discount = 0.00;
                        App.Current.MainPage.DisplayAlert("Note", $" please nenew to get your discount", "Ok");
                    }
                }
                else
                {
                    user.Discount = 0.00;
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

       
           public static void saveCustomerInJson(List<Customer> customer)
            {
                // Gets the file path where form data will be stored from ApplicationFilePath method
                // in Utility class in Utils Folder and stores it in the variable filePath.
                string filePath = Utility.CustomerFilePath();

                // Serialize the list of hobbies to JSON format with formatting Indented and store it in Variable jsonData
                string jsonData = JsonConvert.SerializeObject(customer, Newtonsoft.Json.Formatting.Indented);

                // Write the JSON data to the file given from filePath variable and data from jsonData variable.
                File.WriteAllText(filePath, jsonData);
            }




            // Add a method for membership renewal if needed

            // Add other methods as required
        }

    }