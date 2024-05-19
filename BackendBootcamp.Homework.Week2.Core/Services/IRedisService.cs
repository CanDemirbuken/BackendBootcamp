using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBootcamp.Homework.Week2.Core.Services
{
    public interface IRedisService
    {
        Task<T> GetCacheAsync<T>(string key);
        Task SetCacheAsync<T>(string key, T value, TimeSpan? expiry = null);
    }
}
