using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicStoreMVC.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int UserId { get; set; }
    }
}