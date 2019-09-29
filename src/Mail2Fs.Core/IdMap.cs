using System;
using System.Collections.Generic;

namespace MailSync
{
    public class IdMap<K, V>
    {
        private readonly Dictionary<K, V> idMap = new Dictionary<K, V>();
        private readonly Dictionary<V, K> reverseMap = new Dictionary<V, K>();

        public IdMap()
        {
        }

        public IDictionary<K,V> Map { get => idMap; }

        public IdMap(IDictionary<K, V> dict)
        {
            foreach(var kvp in dict)
            {
                idMap.Add(kvp.Key, kvp.Value);
                reverseMap.Add(kvp.Value, kvp.Key);
            }
        }

        public V this[K key] { get => idMap[key]; }
        public IEnumerable<K> Keys { get => idMap.Keys; }

        public bool ContainsKey(K key) => idMap.ContainsKey(key);
        public void Add(K key, V value)
        {
            if (reverseMap.ContainsKey(value))
            {
                throw new ArgumentException("value already exists");
            }

            idMap.Add(key, value);
            reverseMap.Add(value, key);
        }

        public void Remove(K key)
        {
            if (idMap.TryGetValue(key, out V val))
            {
                idMap.Remove(key);
                reverseMap.Remove(val);
            }
        }

        public IdMap<V, K> Invert()
        {
            return new IdMap<V, K>(reverseMap);
        }
    }
}
