using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs.IdentityDtos;

namespace Shared.DTOs.OrderDtos
{
    public class OrderDto
    {
        public string BasketId { get; set; } = null!;
        public int DeliveryMethodId { get; set; }
        public AddressDto Address { get; set; } = null!;
    }
}
