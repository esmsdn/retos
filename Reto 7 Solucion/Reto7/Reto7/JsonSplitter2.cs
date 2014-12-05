using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Reto7
{
    public class JsonSplitter
    {
        public static Tuple<string, string> SplitShowsByGenre(string json, string genre)
        {
            JArray selectedShowsJson = new JArray();
            JArray otherShowsJson = new JArray();

            foreach (JObject showJson in JArray.Parse(json))
            {
                bool genreFound = false;
                foreach (JValue genreJson in showJson.Value<JArray>("genres"))
                {
                    if (genreJson.ToString() == genre)
                    {
                        selectedShowsJson.Add(showJson);
                        genreFound = true;
                        break;
                    }
                }
                if (!genreFound)
                {
                    otherShowsJson.Add(showJson);
                }
            }

            return new Tuple<string, string>(selectedShowsJson.ToString(Formatting.None), otherShowsJson.ToString(Formatting.None));
        }
    }
}
