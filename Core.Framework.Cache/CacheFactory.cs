using Core.Framework.Cache.Redis;

namespace Core.Framework.Cache
{
    public class CacheFactory
    {
        static CacheFactory _instance;

        public static CacheFactory Instance
        { get { return _instance ?? (_instance = new CacheFactory()); } }

        public RedisCacheService Redis(string endpoint, int database = 15)
        {
            return new RedisCacheService(endpoint, database);
        }
    }
}
