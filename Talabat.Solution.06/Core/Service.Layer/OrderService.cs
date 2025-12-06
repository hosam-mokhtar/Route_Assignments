using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Layer.Contracts;
using Domain.Layer.Exceptions;
using Domain.Layer.Models.ProductModels;
using DomainLayer.Models.OrderModels;
using Service.Layer.Specifications.OrderModuleSpecification;
using ServiceAbstraction.Layer;
using Shared.DTOs.OrderDtos;

namespace Service.Layer
{
    public class OrderService(IMapper _mapper, 
                              IBasketRepository _basketRepository, 
                              IUnitOfWork _unitOfWork) 
                : IOrderService
    {
        public async Task<OrderToReturnDto> CreateOrderAsync(OrderDto orderDto, string email)
        {
            //Map AddressDto to OrderAddress
            var orderAddress = _mapper.Map<OrderAddress>(orderDto.Address);

            //Get Basket
            var basket = await _basketRepository.GetBasketAsync(orderDto.BasketId);

            if (basket is null)
                throw new BasketNotFoundException(orderDto.BasketId);

            //Create Order Items
            List<OrderItem> orderItems = [];
            var _productRepo = _unitOfWork.GetRepository<Product, int>();

            foreach (var basketItem in basket.Items)
            {
                var OriginalProduct = await _productRepo.GetByIdAsync(basketItem.Id)
                                      ??    throw new ProductNotFoundException(basketItem.Id);
                var OrderItem = new OrderItem()
                {
                    Product = new ProductItemOrdered()
                    {
                        ProductId = basketItem.Id,
                        PictureUrl = OriginalProduct.PictureUrl,
                        ProductName = OriginalProduct.Name,
                    },

                    Price = OriginalProduct.Price,
                    Quantity = basketItem.Quantity,
                };

                orderItems.Add(OrderItem);
            }

            //Get Delivery Method
            var deliveryMethod = await _unitOfWork
                                  .GetRepository<DeliveryMethod, int>()
                                  .GetByIdAsync(orderDto.DeliveryMethodId)
                                  ?? throw new DeliveryMethodNotFoundException(orderDto.DeliveryMethodId);
            //SubTotal
            var subTotal = orderItems.Sum(i => i.Price * i.Quantity);

            // Create Order Object
            var order = new Order(email, orderAddress, deliveryMethod, orderItems, subTotal);
            await _unitOfWork.GetRepository<Order, Guid>().AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            //Return the Order
            return _mapper.Map<OrderToReturnDto>(order);
        }

        public async Task<IEnumerable<DeliveryMethodDto>> GetDeliveryMethodAsync()
        {
            var deliveryMethods = await _unitOfWork.GetRepository<DeliveryMethod, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<DeliveryMethodDto>>(deliveryMethods);
        }

        public async Task<IEnumerable<OrderToReturnDto>> GetAllOrderAsync(string email)
        {
            var specs = new OrderSpecification(email);
            var orders = await _unitOfWork.GetRepository<Order, Guid>().GetAllAsync(specs);
            return _mapper.Map<IEnumerable<OrderToReturnDto>>(orders);
        }

        public async Task<OrderToReturnDto> GetOrderByIdAsync(Guid id)
        {
            var specs = new OrderSpecification(id);
            var order = await _unitOfWork.GetRepository<Order, Guid>().GetByIdAsync(specs);
            return _mapper.Map<OrderToReturnDto>(order);

        }

    }
}
