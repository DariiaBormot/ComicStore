using ComicStoreBL.Models;
using ComicStoreBL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Interfaces
{
    public interface IMailOrderProcessor
    {
        void SendEmail(ShippingDetailsBL shippingDetails, CartService cartService);
    }
}
