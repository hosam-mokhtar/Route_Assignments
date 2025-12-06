using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Layer.Contracts;
<<<<<<< Updated upstream
=======
using Domain.Layer.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
>>>>>>> Stashed changes
using ServiceAbstraction.Layer;

namespace Service.Layer
{
<<<<<<< Updated upstream
    public class ServiceManager(IUnitOfWork _unitOfWork, IMapper _mapper) : IServiceManager
    {
       private readonly Lazy<IProductService> _lazyProductService = new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper));
        public IProductService ProductService => _lazyProductService.Value;
=======
    public class ServiceManager(IUnitOfWork _unitOfWork, 
                                IMapper _mapper, 
                                IBasketRepository _basketRepository,
                                UserManager<ApplicationUser> _userManager,
                                IConfiguration _configuration)

               : IServiceManager
    {

        private readonly Lazy<IProductService> _lazyProductService 
            = new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper));
        public IProductService ProductService => _lazyProductService.Value;




        private readonly Lazy<IBasketService> _lazyBasketService 
            = new Lazy<IBasketService>(() => new BasketService(_basketRepository, _mapper));
        public IBasketService BasketService => _lazyBasketService.Value;




        private readonly Lazy<IAuthenticationService> _lazyAuthenticationService
            = new Lazy<IAuthenticationService>(() => new AuthenticationService(_userManager, _configuration, _mapper));
        public IAuthenticationService AuthenticationService => _lazyAuthenticationService.Value;




        private readonly Lazy<IOrderService> _LazyOrderService
            = new Lazy<IOrderService>(() => new OrderService(_mapper, _basketRepository, _unitOfWork));
        public IOrderService OrderService => _LazyOrderService.Value;
>>>>>>> Stashed changes
    }
}
