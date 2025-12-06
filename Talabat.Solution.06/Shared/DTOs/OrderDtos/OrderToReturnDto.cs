using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs.IdentityDtos;

namespace Shared.DTOs.OrderDtos
{
    public class OrderToReturnDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public string DeliveryMethod { get; set; } = null!;     //Name
        public string OrderStatus { get; set; } = null!;
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset Date { get; set; }
        public ICollection<OrderItemDto> Items { get; set; } = [];
        public AddressDto Address { get; set; } = null!;
    }
}
