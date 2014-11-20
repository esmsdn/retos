using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Reto_6
{
    [DebuggerDisplay("Count = {Count}, ActiveCount = {ActiveCount}")]
    [DebuggerTypeProxy(typeof(CacheDebugView))]
    public class Cache
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Dictionary<int, WeakReference> cache = new Dictionary<int, WeakReference>();

        public void Add(int key, object value)
        {
            cache.Add(key, new WeakReference(value));
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int Count
        {
            get { return cache.Count; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int ActiveCount
        {
            get { return cache.Count(reference => reference.Value.IsAlive); }
        }

        public object this[int key]
        {
            get
            {
                return cache[key].Target;
            }
        }

        internal class CacheDebugView
        {
            private Cache cache;

            public CacheDebugView(Cache cache)
            {
                this.cache = cache;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public KeyValuePairs[] Keys
            {
                get
                {
                    KeyValuePairs[] keys = new KeyValuePairs[cache.Count];

                    int i = 0;
                    foreach (int key in cache.cache.Keys)
                    {
                        keys[i] = new KeyValuePairs(key, cache[key]);
                        i++;
                    }
                    return keys;
                }
            }
        }
    }

    [DebuggerDisplay("Key = {Key}, Value = {Value}")]
    internal class KeyValuePairs
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int Key { get; set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private object Value { get; set; }

        public KeyValuePairs(int key, object value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
