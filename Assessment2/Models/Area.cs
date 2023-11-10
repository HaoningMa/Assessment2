using Antlr.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Assessment2.Models
{
    public class Area
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "The area Name cannot be blank")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter a area Name between 3 and 50 characters in length")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Please enter a area Name beginning with a capital letter and enter only letters and spaces.")]
        [Display( Name= "Area Name")]
        public string Name { get; set; }

        public virtual ICollection<Custom> Customers { get; set; }
    }
}