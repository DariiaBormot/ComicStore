﻿using ComicStoreBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Interfaces
{
    public interface IOrderService : IGenericService<OrderBL>
    {
        IEnumerable<OrderBL> GetListByFilter(OrderFilterModelBL filter);
        int CountFilteredItems(OrderFilterModelBL filter);
    }
}
