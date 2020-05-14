using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComicStoreMVC.Models
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            OrderDetails = new List<OrderDetailsViewModel>();
        }
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string UserId { get; set; }

        public IEnumerable<OrderDetailsViewModel> OrderDetails { get; set; }
    }
}