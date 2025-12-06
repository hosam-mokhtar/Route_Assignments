using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs.OrderDtos;

namespace ServiceAbstraction.Layer
{
    public interface IOrderService
    {
        Task<OrderToReturnDto> CreateOrderAsync(OrderDto orderDto, string email);
        Task<IEnumerable<DeliveryMethodDto>> GetDeliveryMethodAsync();

        //Get All Orders of Specific Customer
        Task<IEnumerable<OrderToReturnDto>> GetAllOrderAsync(string email);
        Task<OrderToReturnDto> GetOrderByIdAsync(Guid id);
    }
}
