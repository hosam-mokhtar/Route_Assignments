using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Layer
{
    public interface IServiceManager
    {
                                             //Read Only
        public IProductService ProductService { get; }
<<<<<<< Updated upstream
=======
        public IBasketService BasketService { get; }
        public IAuthenticationService AuthenticationService { get; }
        public IOrderService OrderService { get; }
>>>>>>> Stashed changes
    }
}
