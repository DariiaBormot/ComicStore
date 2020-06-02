using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComicStoreMVC.Models
{
    public class ShippingDetailsViewModel
    {

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter your street")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Please enter your appartment")]
        public string Appartment { get; set; }
        [Required(ErrorMessage = "Please enter your zip code")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Please enter your email address")]
        public string Email { get; set; } 

    }
}