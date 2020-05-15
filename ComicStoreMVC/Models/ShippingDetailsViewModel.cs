using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComicStoreMVC.Models
{
    public class ShippingDetailsViewModel
    {

        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your last name")]

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter your Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Enter your city")]
        public string City { get; set; }
        public string Street { get; set; }
        public string Appartment { get; set; }
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Enter your phone number")]
        public int PhoneNumber { get; set; }

    }
}