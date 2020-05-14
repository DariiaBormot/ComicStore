using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Models
{
    public class OrderDetailsBL
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Appartment { get; set; }
        public int ZipCode { get; set; }
        public int PhoneNumber { get; set; }

    }
}
