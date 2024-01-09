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
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Select a coffee")] // Required attribute ensures that this field is mandatory.
        [Display(Name = "Coffee")] // Display attribute changes the label that will be shown in the UI.
        public Coffee Coffee { get; set; }

        // This property represents a list of hobbies associated with the form.
        public List<Add_In> Addin { get; set; }
        public float TotalPrice { get; set;}
  
    }
}
