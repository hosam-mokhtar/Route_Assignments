using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Layer;
using Shared.DTOs.BasketDtos;

namespace Presentation.Layer.Controllers
{
    public class BasketController(IServiceManager _serviceManager) : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult<BasketDto>> GetBasket(string key)
        {
            var res = await _serviceManager.BasketService.GetBasketAsync(key);
            return Ok(res);
        }


        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateOrUpdateBasket(BasketDto dto)
        {
            var res = await _serviceManager.BasketService.CreateOrUpdateBasketAsync(dto);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasket(string key)
        {
            var res = await _serviceManager.BasketService.DeleteBasketAsync(key);
            return Ok(res);
        }
    }
}
