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
    public class PaymentService
    {
        public static void SavePaymentToJson(Payments payments)
        {
            string filePath = Utility.PaymentFilePath();
            try
            {
                // Use a lock to ensure exclusive access to the file during write operations
                lock (FileLock)
                {
                    List<Payments> paymentLists;

                    string existingJsonData = File.ReadAllText(filePath);

                    if (string.IsNullOrEmpty(existingJsonData))
                    {
                        paymentLists = new List<Payments>();
                    }
                    else
                    {
                        paymentLists = JsonConvert.DeserializeObject<List<Payments>>(existingJsonData);
                    }

                    paymentLists.Add(payments);

                    string jsonData = JsonConvert.SerializeObject(paymentLists, Formatting.Indented);

                    File.WriteAllText(filePath, jsonData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving JSON file: {ex}");
                App.Current.MainPage.DisplayAlert("Error", $"Error saving data: {ex.Message}", "OK");
            }
        }
        // Define a static object for the lock
        private static readonly object FileLock = new object();
        public static Payments CreatePayment(Order orders, string Usernames, string Phonenumber int Discount)
        {

            // Retrieve the list of hobbies.
            Payments payment = new Payments
            {
                Id = Guid.NewGuid(), // Generate a new unique identifier for the payment
                order = orders,   // Assign the provided orderId
                Username = Usernames,
                PhoneNumber = Phonenumber,
                Discount = Discount

                // Other properties or logic related to payment creation
            };
            SavePaymentToJson(payment);
            return payment;  
        }
        public static List<Payments> RetrievePaymentData()
        {
            // Gets the file path where form data is stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = Utility.PaymentFilePath();
            try
            {
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of AddForm objects.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    return new List<Payments>();
                }
                return JsonConvert.DeserializeObject<List<Payments>>(existingJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                App.Current.MainPage.DisplayAlert("Error", "Error Retrieving Data from Json", "OK");
                return new List<Payments>();
            }
        }
    }
}
