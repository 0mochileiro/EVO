using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Caching.Distributed;

namespace EVO.Common.Helpers;

public static class CacheExtensions
{
    public static TimeSpan _defaultDuration = new TimeSpan(1, 0, 0);

    public static void SetEntity<T>(this IDistributedCache cache, String key, T entity, TimeSpan? duration = null)
    {
        if (duration.HasValue is false)
        {
            duration = _defaultDuration;
        }

        var cacheEntryOptions = new DistributedCacheEntryOptions();

        cacheEntryOptions.SetAbsoluteExpiration(duration.Value);

        var jsonSettings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };

        var value = JsonConvert.SerializeObject(entity, jsonSettings);

        cache.SetAsync(key, Encoding.UTF8.GetBytes(value), cacheEntryOptions).Wait();
    }

    public static T GetEntity<T>(this IDistributedCache cache, String key)
    {
        var literalValue = cache.GetAsync(key).Result;

        if (literalValue is not null)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(literalValue, 0, literalValue.Length));
        }

        return default(T);
    }

    public static void SetBytes(this IDistributedCache cache, String key, byte[] bytes, TimeSpan? duration = null)
    {
        if (!duration.HasValue)
            duration = _defaultDuration;

        var cacheEntryOptions = new DistributedCacheEntryOptions();

        cacheEntryOptions.SetAbsoluteExpiration(duration.Value); //Cache duration

        cache.SetAsync(key, bytes, cacheEntryOptions).Wait();

    }

    public static byte[] GetBytes(this IDistributedCache cache, String key)
    {
        return cache.GetAsync(key).Result;
    }

    public static void RemoveEntity(this IDistributedCache cache, String key)
    {
        cache.RemoveAsync(key).Wait();
    }
}
