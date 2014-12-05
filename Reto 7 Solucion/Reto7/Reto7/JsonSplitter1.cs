using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Reto7
{
    public class JsonSplitter
    {
        public static Tuple<string, string> SplitShowsByGenre(string json, string genre)
        {
            var split =
                JArray.Parse(json)
                    .GroupBy(s => s["genres"].Values<string>().Contains(genre))
                    .Select(g => (new JArray(g)).ToString(Formatting.None))
                    .ToList();
            return new Tuple<string, string>(split[1], split[0]);
        }

    }
}
