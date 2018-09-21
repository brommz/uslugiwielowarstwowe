using ServiceStack.Redis;
using System;
using Newtonsoft.Json;

namespace webapp
{
    public class StorageFunctionality
    {
        private readonly RedisManagerPool _redisManagerPool;

        public StorageFunctionality()
        {
            _redisManagerPool = new RedisManagerPool("redis");
        }

        public void Add<T>(Guid id, T @object)
        {
            string serializedObject = JsonConvert.SerializeObject(@object);
            using (var client = _redisManagerPool.GetClient())
            {
                client.Set(id.ToString(), @serializedObject);
            }
        }

        public void Add<T>(string id, T @object)
        {
            string serializedObject = JsonConvert.SerializeObject(@object);
            using (var client = _redisManagerPool.GetClient())
            {
                client.Set(id, @serializedObject);
            }
        }

        public T Get<T>(Guid id)
        {
            string serializedObject = null;
            
            using (var client = _redisManagerPool.GetClient())
            {
                serializedObject = client.Get<string>(id.ToString());
                T @object = JsonConvert.DeserializeObject<T>(serializedObject);
                return @object;
            }
        }

        public T Get<T>(string id)
        {
            string serializedObject = null;

            using (var client = _redisManagerPool.GetClient())
            {
                serializedObject = client.Get<string>(id);
                if (serializedObject == null)
                {
                    return default(T);
                }

                T @object = JsonConvert.DeserializeObject<T>(serializedObject);
                return @object;
            }
        }

    }
}
