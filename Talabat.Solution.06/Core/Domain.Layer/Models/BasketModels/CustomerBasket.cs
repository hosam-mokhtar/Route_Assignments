using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.Models.BasketModels
{
    public class CustomerBasket
    {
        public string Id { get; set; } //GUID : created from client [front-end]
        public ICollection<BasketItem> Items { get; set; }
    }
}
