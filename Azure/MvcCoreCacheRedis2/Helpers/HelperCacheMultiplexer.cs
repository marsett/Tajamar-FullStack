using StackExchange.Redis;

namespace MvcCoreCacheRedis2.Helpers
{
    public class HelperCacheMultiplexer
    {
        private static string cacheRedisKeys;

        public static void Initialize(string connectionString)
        {
            cacheRedisKeys = connectionString;
        }
        public static Lazy<ConnectionMultiplexer>
            CreateConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                //string cacheRedisKeys = "cacheredismario.redis.cache.windows.net:6380,password=pmcD7ZndX80BHaUUykOtWP3B63QAOrFfgAzCaLSiYfs=,ssl=True,abortConnect=False";
                //return ConnectionMultiplexer.Connect(cacheRedisKeys);
                return ConnectionMultiplexer.Connect(cacheRedisKeys);
            });

        public static ConnectionMultiplexer Connection
        {
            get { return CreateConnection.Value; }
        }
    }
}
