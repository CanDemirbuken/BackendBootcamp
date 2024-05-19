using StackExchange.Redis;
using System.Text.Json;

namespace BackendBootcamp.Homework.Week2.Service.Services
{
    public class RedisService
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(string url)
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect(url);
        }

        public IDatabase GetDb(int dbIndex)
        {
            return _connectionMultiplexer.GetDatabase(dbIndex);
        }

        public async Task<T> GetCacheAsync<T>(string key)
        {
            var db = GetDb(0);
            var value = await db.StringGetAsync(key);
            if (!value.IsNullOrEmpty)
            {
                return JsonSerializer.Deserialize<T>(value)!;
            }
            return default;
        }

        public async Task SetCacheAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            var db = GetDb(0);
            var serializedValue = JsonSerializer.Serialize(value);
            await db.StringSetAsync(key, serializedValue, expiry);
        }
    }
}
