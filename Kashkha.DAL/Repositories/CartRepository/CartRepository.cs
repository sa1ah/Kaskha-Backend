using Kashkha.DAL.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
    public class CartRepository : ICartRepository
    {
        private readonly IConnectionMultiplexer _redis;
    private readonly IDatabase _db;

    public CartRepository(IConnectionMultiplexer redis)
    {
        _redis = redis;
        _db = redis.GetDatabase();
    }
        public async Task<Cart?> GetCartAsync(string userId)
    {
        var cartJson = await _db.StringGetAsync(GetCartKey(userId));
        if (cartJson.IsNull)
            return null;
           
            return JsonSerializer.Deserialize<Cart>(cartJson);
           
        }

    public async Task<bool> SetCartAsync(string userId, Cart cart)
    {
        var cartJson = JsonSerializer.Serialize(cart);
        return await _db.StringSetAsync(GetCartKey(userId), cartJson);
    }

    public async Task<bool> DeleteCartAsync(string userId)
    {
        return await _db.KeyDeleteAsync(GetCartKey(userId));
    }

    private static string GetCartKey(string userId) => $"cart:{userId}";
    }
}
