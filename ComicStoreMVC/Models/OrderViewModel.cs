﻿using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Appartment { get; set; }
        public string ZipCode { get; set; }
        public int PhoneNumber { get; set; }
        public string UserId { get; set; }
    }
}