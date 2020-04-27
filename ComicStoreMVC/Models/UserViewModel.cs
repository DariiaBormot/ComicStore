using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicStoreMVC.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public DateTime Birthday { get; set; }
    }
}