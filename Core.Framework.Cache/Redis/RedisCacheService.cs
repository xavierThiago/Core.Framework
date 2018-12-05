using System;
using StackExchange.Redis;

namespace Core.Framework.Cache.Redis
{
    public sealed class RedisCacheService : ICacheService
    {
        readonly ConnectionMultiplexer _redis;
        readonly IServer _server;
        readonly IDatabase _cache;

        public TimeSpan Expires
        { get; set; }

        public RedisCacheService(string endpoint, int database)
        {
            var options = new ConfigurationOptions
            {
                AbortOnConnectFail = false,
                AllowAdmin = true
            };
            options.EndPoints.Add(endpoint);
            _redis = ConnectionMultiplexer.Connect(options);
            _server = _redis.GetServer(endpoint);
            _cache = _redis.GetDatabase(database);
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

        public void Set(string key, string value, int? secondsToExpire = null)
        {
            try
            {
                if (Expires == default(TimeSpan))
                    Expires = secondsToExpire == null
                        ? TimeSpan.FromSeconds(1800)
                        : TimeSpan.FromSeconds(secondsToExpire.Value);
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

        public void Dispose()
        {
            if (_redis != null)
                _redis.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
