using Application.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Infrastructure.Repositories;

public class RedisCacheService : ICacheService
{
    private readonly IDistributedCache _cach;

    public RedisCacheService(IDistributedCache cach)
    {
        _cach = cach;
    }

    public async Task<T?> GetAsync<T>(string cachKey)
    {
        var cachedData = await _cach.GetAsync(cachKey);

        if(cachedData == null)
        {
            return default(T);
        }

        return JsonSerializer.Deserialize<T>(cachedData);
    }

    public async Task SetAsync<T>(string cachKey, T value, TimeSpan? expiration = null)
    {
        var options = new DistributedCacheEntryOptions
        {
            SlidingExpiration = expiration ?? TimeSpan.FromMinutes(1),
        };

        var json = JsonSerializer.Serialize(value);

        await _cach.SetStringAsync(cachKey, json, options);
    }
}
