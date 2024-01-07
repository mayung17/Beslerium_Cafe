using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_CW.Data.models
{
    public class Order
    {
        [Required(ErrorMessage = "First Name is Required")] // Required attribute ensures that this field is mandatory.
        [Display(Name = "First Name")] // Display attribute changes the label that will be shown in the UI.
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")] // Similar annotations for Last Name.
        [Display(Name = "Last Name")]  // Similar annotations for Last Name.
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]  // Similar annotations for Last Name.
        [EmailAddress(ErrorMessage = "Invalid email address")]  // Annotation to ensure a valid email address is provided.
        [Display(Name = "Email")]   // Similar annotations for Last Name.
        public string Email { get; set; }

        // This property represents a list of hobbies associated with the form.
        public List<Add_In> Addin { get; set; }
        public decimal TotalPrice { get; set;}

    }
}
