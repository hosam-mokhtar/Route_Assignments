using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Layer.Models;

namespace DomainLayer.Models.OrderModels
{
    public class Order:BaseEntity<Guid>
    {
        public Order()
        {        
        }

        public Order(string userEmail, OrderAddress address, DeliveryMethod deliveryMethod, ICollection<OrderItem> items, decimal subTotal)
        {
            UserEmail = userEmail;
            Address = address;
            DeliveryMethod = deliveryMethod;
            Items = items;
            SubTotal = subTotal;
        }

        public string UserEmail { get; set; } = null!;
        public OrderAddress Address { get; set; } = null!;
        public DeliveryMethod DeliveryMethod { get; set; } = null!;
        public ICollection<OrderItem> Items { get; set; } = [];
        public decimal SubTotal { get; set; }

        public int DeliveryMethodId { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public OrderStatus OrderStatus { get; set; }

        [NotMapped]
        public decimal Total { get => SubTotal + DeliveryMethod.Price; }
        //public decimal GetTotal() => SubTotal + DeliveryMethod.Price;
    }
}
