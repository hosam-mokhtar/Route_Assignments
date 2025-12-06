using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.OrderModels;

namespace Service.Layer.Specifications.OrderModuleSpecification
{
    public class OrderSpecification : BaseSpecifications<Order, Guid>
    {
        // Get All By Email o => o.Email == ClaimsEmail
        public OrderSpecification(string email) : base(o => o.UserEmail == email)
        {
            AddInclude(o => o.DeliveryMethod);
            AddInclude(o => o.Items);
            AddOrderByDescending(o => o.OrderDate);
        }

        // Get By ID
        public OrderSpecification(Guid id) : base(o => o.Id == id)
        {
            AddInclude(o => o.DeliveryMethod);
            AddInclude(o => o.Items);
            AddOrderByDescending(o => o.OrderDate);
        }
    }
}
