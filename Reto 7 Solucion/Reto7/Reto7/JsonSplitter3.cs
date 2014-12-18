using fastJSON;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reto7
{
    public class JsonSplitter
    {
        public static Tuple<string, string> SplitShowsByGenre(string json, string genre)
        {
            var split =
                ((object[])JSON.ToObject(json))
                    .GroupBy(s => ((List<object>)((Dictionary<string, object>)s)["genres"]).Contains(genre))
                    .OrderBy(g => g.Key)
                    .Select(g => JSON.ToJSON(g, new JSONParameters() { UseEscapedUnicode = false }))
                    .ToList();
            return new Tuple<string, string>(split[1], split[0]);
        }
    }
}
