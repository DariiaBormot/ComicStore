﻿using ComicStoreBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Interfaces
{
    public interface IOrderDetailsService : IGenericService<OrderDetailsBL>
    {
        IEnumerable<OrderDetailsBL> GetOrderDetailsByOrderId(int? id);
    }
}
