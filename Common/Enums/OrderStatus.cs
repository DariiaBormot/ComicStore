using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum OrderStatus
    {
        Processing = 0,
        AwaitingPayment = 1,
        PaymentConfirmed = 2,
        Failed = 3,
        Canceled = 4,
        Refunded = 5,
        Completed = 6
    }
}
