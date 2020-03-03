using ServiceStack.Redis;
using System;

namespace CMCLIS.GATEWAY.CORE.Redis
{
    public class RedisCacheProvider : IRedisCacheProvider
    {
        RedisEndpoint _endPoint;
        /// <summary>
        /// RedisCacheProvider
        /// </summary>
        /// <param name="DatabaseID">DatabaseID : db0,db1,db2...db15.</param>
        public RedisCacheProvider(string DatabaseID)
        {
            //_endPoint = new RedisEndpoint(RedisConfigurationManager.Config.Host, RedisConfigurationManager.Config.Port, RedisConfigurationManager.Config.Password, RedisConfigurationManager.Config.DatabaseID);
            _endPoint = new RedisEndpoint(RedisConfigurationManager.Config.Host, RedisConfigurationManager.Config.Port, RedisConfigurationManager.Config.Password, RedisConfigurationSection.DICT_REDIS_DB[DatabaseID.ToLower()]);
        }

        public void Set<T>(string key, T value)
        {
            this.Set(key, value, TimeSpan.Zero);
        }

        public void Set<T>(string key, T value, TimeSpan timeout)
        {
            using (RedisClient client = new RedisClient(_endPoint))
            {
                client.As<T>().SetValue(key, value, timeout);
            }
        }

        public T Get<T>(string key)
        {
            T result = default(T);

            using (RedisClient client = new RedisClient(_endPoint))
            {
                var wrapper = client.As<T>();

                result = wrapper.GetValue(key);
            }

            return result;
        }

        public bool Remove(string key)
        {
            bool removed = false;

            using (RedisClient client = new RedisClient(_endPoint))
            {
                removed = client.Remove(key);
            }

            return removed;
        }

        public bool IsInCache(string key)
        {
            bool isInCache = false;

            using (RedisClient client = new RedisClient(_endPoint))
            {
                isInCache = client.ContainsKey(key);
            }

            return isInCache;
        }
    }
}
