﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVCFastTactsoft.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Enter Your Name")]
        
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Your Age")]
       
        public int Age { get; set; }
        [Required(ErrorMessage = "Enter Your Address")]
        
        public string Address { get; set; }
    }
}
