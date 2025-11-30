using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs.BasketDtos;

namespace ServiceAbstraction.Layer
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasketAsync(string key);
        Task<BasketDto> CreateOrUpdateBasketAsync(BasketDto basket);
        Task<bool> DeleteBasketAsync(string key);
    }
}
