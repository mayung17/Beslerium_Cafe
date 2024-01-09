
using Newtonsoft.Json;
using POS_CW.Data.models;
using POS_CW.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_CW.Data.Services
{
    public class Order_Services
    {
        public static void SaveOrderToJson(Order Orders)
        {
            string filePath = Utility.OrderFilePath();
            try
            {
                // Use a lock to ensure exclusive access to the file during write operations
                lock (FileLock)
                {
                    List<Order> orderList;

                    string existingJsonData = File.ReadAllText(filePath);

                    if (string.IsNullOrEmpty(existingJsonData))
                    {
                        orderList = new List<Order>();
                    }
                    else
                    {
                        orderList = JsonConvert.DeserializeObject<List<Order>>(existingJsonData);
                    }

                    orderList.Add(Orders);

                    string jsonData = JsonConvert.SerializeObject(orderList, Formatting.Indented);

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


        //This method Injects the data Into the Json File Manually by creating the multiple objects and Passing it to the list only if the data inside the file is empty.

        // Retrieves Add_In data from the JSON file.
        public static List<Order> RetrieveOrderedData()
        {
            // Gets the file path where form data is stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = Utility.OrderFilePath();
            try
            {
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of AddForm objects.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    return new List<Order>();
                }
                return JsonConvert.DeserializeObject<List<Order>>(existingJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                App.Current.MainPage.DisplayAlert("Error", "Error Retrieving Data from Json", "OK");
                return new List<Order>();
            }
        }
        public static Order GetOrderById(Guid id)
        {
            List<Order> order = RetrieveOrderedData(); // Retrieves the list of hobbies and stores it in hobbies object

            // Return the first Add_In with the specified Id.
            return order.FirstOrDefault(x => x.Id == id); //creating arrow function and checking whether the Id of Hobbies is equal to the id of parameter that recieves value later on.
        }

    }
}
