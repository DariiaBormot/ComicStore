using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Models
{
    public class UserBL
    {
        public UserBL()
        {
            Orders = new List<OrderBL>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public DateTime Birthday { get; set; }

        public ICollection<OrderBL> Orders { get; set; }
    }
}
