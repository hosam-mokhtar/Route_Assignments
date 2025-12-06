using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.OrderModels
{
    public enum OrderStatus
    {
        pending = 0,
        paymentReceived = 1,
        paymentFailed = 2,
    }
}
