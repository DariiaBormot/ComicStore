using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Appartment { get; set; }
        public string ZipCode { get; set; }
        public int PhoneNumber { get; set; }

        public virtual Order Order { get; set; }
        public int OrderId { get; set; }

    }
}
