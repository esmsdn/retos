using System.Collections.Generic;
using System.Linq;

namespace Reto5
{
    public class DictionaryPlus<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public IEnumerable<TValue> this[params TKey[] keys]
        {
            get
            {
                return keys.Select(key => base[key]);
            }
        }
    }
}
