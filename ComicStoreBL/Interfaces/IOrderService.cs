using ComicStoreBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Interfaces
{
    public interface IOrderService : IGenericService<OrderBL>
    {
        IEnumerable<OrderBL> GetOrdersByFilter(OrderFilterModelBL filter); 
        int CountPageItems(OrderFilterModelBL filter); 
    }
}
