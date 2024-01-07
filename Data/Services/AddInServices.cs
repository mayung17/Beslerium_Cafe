﻿using System.Xml;
using POS_CW.Data.models;
using POS_CW.Data.Utils;
using Newtonsoft.Json;
namespace POS_CW.Data.services

{
    public class Add_InServices
    {
        public static void SaveAdd_InToJson(List<Add_In> AddIn)
        {
            // Gets the file path where form data will be stored from ApplicationFilePath method
            // in Utility class in Utils Folder and stores it in the variable filePath.
            string filePath = Utility.AddinFilePath();

            // Serialize the list of hobbies to JSON format with formatting Indented and store it in Variable jsonData
            string jsonData = JsonConvert.SerializeObject(AddIn, Newtonsoft.Json.Formatting.Indented);

            // Write the JSON data to the file given from filePath variable and data from jsonData variable.
            File.WriteAllText(filePath, jsonData);
        }

        //This method Injects the data Into the Json File Manually by creating the multiple objects and Passing it to the list only if the data inside the file is empty.
        public static void InjectSampleAddInData()
        {
            // Gets the file path where Add_In data will be stored from HobbiesFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = Utility.AddinFilePath();

            // Read existing data from the file and store it in variable existingData
            var existingData = File.ReadAllText(filePath);

            // If the file is empty, injects a list of sample Add_In data in a object of List<Add_In> called sampleHobbies first and saves it in a Json File by calling method SaveHobbiesToJson.
            if (string.IsNullOrEmpty(existingData))
            {
                List<Add_In> sampleAddIn = new List<Add_In>
            {
                new Add_In { AddIn_Name = "Honey", AddIn_Price=50 },
                new Add_In { AddIn_Name = "Ice Cream",AddIn_Price=50  },
                new Add_In { AddIn_Name = "Whipped Cream",AddIn_Price=50  },
                new Add_In { AddIn_Name = "Double Shots",AddIn_Price=50  },
                new Add_In { AddIn_Name = "Caremel", AddIn_Price=50 },
                new Add_In { AddIn_Name= "Chocoloate", AddIn_Price = 50},
                new Add_In { AddIn_Name= "Choco Chipa", AddIn_Price = 50},
            };
                SaveAdd_InToJson(sampleAddIn); // Save the sample Add_In data to the JSON file by calling SaveHobbiesToJson Method and passing sampleHobbies as it Argument.
            }
        }

        // Retrieves Add_In data from the JSON file.
        public static List<Add_In> RetrieveAddInData()
        {
            // Gets the file path where Add_In data is stored from HobbiesFilePath method
            // in Utility class in Utils Folder and stores it in the variable filePath.
            string filePath = Utility.AddinFilePath();
            try
            {
                string existingJsonData = File.ReadAllText(filePath); // Read existing JSON data from the file.

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of Add_In objects.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    return new List<Add_In>();
                }
                return JsonConvert.DeserializeObject<List<Add_In>>(existingJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                return new List<Add_In>();
            }
        }

        // Retrieves a specific Add_In by its Id.
        public static Add_In GetAdd_InById(Guid id)
        {
            List<Add_In> addin = RetrieveAddInData(); // Retrieves the list of hobbies and stores it in hobbies object

            // Return the first Add_In with the specified Id.
            return addin.FirstOrDefault(x => x.Id == id); //creating arrow function and checking whether the Id of Hobbies is equal to the id of parameter that recieves value later on.
        }

        // Edits the name of a specific Add_In.
        public static List<Add_In> EditAdd_In(Guid id, string newName, float newPrice)
        {
            // Retrieve the list of hobbies.
            List<Add_In> addin = RetrieveAddInData();
            // Find the Add_In with the specified Id.
            Add_In editAdd_In = addin.FirstOrDefault(x => x.Id == id);
            // If the Add_In is not found, throw an exception.
            if (editAdd_In == null)
            {
                throw new Exception("Add_In not found");
            }
            // Update the name of the Add_In.
            editAdd_In.AddIn_Name = newName;
            editAdd_In.AddIn_Price = newPrice;
            SaveAdd_InToJson(addin); // Save the updated list of hobbies to the JSON file by calling method SaveHobbiesToJson
            return addin;  // Return the updated list of hobbies.
        }
    }
}
