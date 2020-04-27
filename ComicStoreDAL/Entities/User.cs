using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Entities
{
    public class User
    {
        public User()
        {
            Orders = new List<Order>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public DateTime Birthday { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
