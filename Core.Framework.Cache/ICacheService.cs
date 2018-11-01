using System;

namespace Core.Framework.Cache
{
    public interface ICacheService
    {
        TimeSpan Expires
        { get; set; }

        bool Exists(string key);
        string Get(string key);
        void Set(string key, string value, int? minutesToExpire = null);
        void Remove(string key);
        void Clear();
    }
}
