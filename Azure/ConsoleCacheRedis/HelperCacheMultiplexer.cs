using StackExchange.Redis;

namespace ConsoleCacheRedis
{
    public class HelperCacheMultiplexer
    {
        public static Lazy<ConnectionMultiplexer>
            CreateConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                string cacheRedisKeys = "cacheredismario.redis.cache.windows.net:6380,password=pmcD7ZndX80BHaUUykOtWP3B63QAOrFfgAzCaLSiYfs=,ssl=True,abortConnect=False";
                return ConnectionMultiplexer.Connect(cacheRedisKeys);
            });

        public static ConnectionMultiplexer Connection
        {
            get { return CreateConnection.Value; }
        }
    }
}
