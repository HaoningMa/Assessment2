using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Assessment2.Models
{
    public class Custom
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "The customer Name cannot be blank")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter a customer Name between 3 and 50 characters in length")] 
        [RegularExpression(@"^[a-zA-Z0-9,\s]*$", ErrorMessage = "Please enter a customer Name made up of only letters, numbers and spaces")]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public int? PlaceID { get; set; }

        public virtual Area Place { get; set; }
    }
}