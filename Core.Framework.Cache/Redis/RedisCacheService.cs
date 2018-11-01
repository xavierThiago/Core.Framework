using System;
using StackExchange.Redis;

namespace Core.Framework.Cache.Redis
{
    public sealed class RedisCacheService : ICacheService
    {
        readonly IServer _server;
        readonly IDatabase _cache;

        public TimeSpan Expires
        { get; set; }

        public RedisCacheService(string endpoint, int database)
        {
            var redisOptions = new ConfigurationOptions
            {
                AbortOnConnectFail = false,
                AllowAdmin = true
            };
            redisOptions.EndPoints.Add(endpoint);
            var multiplexer = ConnectionMultiplexer.Connect(redisOptions);
            _server = multiplexer.GetServer(endpoint);
            _cache = multiplexer.GetDatabase(database);
        }

        public bool Exists(string key)
        {
            try
            {
                return _cache.KeyExists(key);
            }
            catch (RedisCommandException rcex)
            { throw rcex; }
            catch (RedisException rex)
            { throw rex; }
            catch (Exception ex)
            { throw ex; }
        }

        public string Get(string key)
        {
            try
            {
                return _cache.StringGet(key);
            }
            catch (RedisCommandException rcex)
            { throw rcex; }
            catch (RedisException rex)
            { throw rex; }
            catch (Exception ex)
            { throw ex; }
        }

        public void Set(string key, string value, int? minutesToExpire = null)
        {
            try
            {
                if (Expires == default(TimeSpan))
                    Expires = minutesToExpire == null ? TimeSpan.FromMinutes(30) : TimeSpan.FromMinutes(minutesToExpire.Value);
                _cache.StringSet(key, value, Expires);
            }
            catch (RedisCommandException rcex)
            { throw rcex; }
            catch (RedisException rex)
            { throw rex; }
            catch (Exception ex)
            { throw ex; }
        }

        public void Remove(string key)
        {
            try
            {
                _cache.KeyDelete(key);
            }
            catch (RedisCommandException rcex)
            { throw rcex; }
            catch (RedisException rex)
            { throw rex; }
            catch (Exception ex)
            { throw ex; }
        }

        public void Clear()
        {
            try
            {
                var database = _cache.Database;
                _server.FlushDatabase(database);
            }
            catch (RedisCommandException rcex)
            { throw rcex; }
            catch (RedisException rex)
            { throw rex; }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
