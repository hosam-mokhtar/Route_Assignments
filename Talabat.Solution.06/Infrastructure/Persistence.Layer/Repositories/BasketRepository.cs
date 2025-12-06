using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Layer.Contracts;
using Domain.Layer.Models.BasketModels;
using StackExchange.Redis;

namespace Persistence.Layer.Repositories
{
    public class BasketRepository(IConnectionMultiplexer connection) : IBasketRepository
    {
        private readonly IDatabase _database = connection.GetDatabase();
        public async Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan? TimeToLive = null)
        {
            var jsonBasket = JsonSerializer.Serialize(basket);
            var isCreatedOrUpdated = await _database.StringSetAsync(basket.Id, jsonBasket, TimeToLive ?? TimeSpan.FromDays(30));

            if (isCreatedOrUpdated)
                return basket;
            else
                return null;
        
        
        }

        public async Task<bool> DeleteBasketAsync(string key)
                                 => await _database.KeyDeleteAsync(key);

        public async Task<CustomerBasket?> GetBasketAsync(string key)
        {
            var basket = await _database.StringGetAsync(key);

            if (basket.IsNullOrEmpty)
                return null;
            else
                return JsonSerializer.Deserialize<CustomerBasket>(basket!);

        }
    }
}
