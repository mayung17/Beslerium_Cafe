﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_CW.Data.models
{
    public class Coffee
    {
        // Unique identifier for each AddIn, automatically generated.
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "The Name is Required")]  // Required attribute ensures that this Name field is mandatory.
        public string Coffee_Name { get; set; }
        public float Coffee_Price {  get; set; }
    }
}
