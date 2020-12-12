using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace extension.JsonUtils
{
    public static class JsonUtils
    {
        public static bool IsStringInJsonFormat(string json)
        {
            try
            {
                JToken.Parse(json);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool IsSortedByKey(JToken json, string key)
        {
            for (int i = 0; i < json.Count()-1; i++)
            {
                if ((int)json[i][key] > (int)json[i + 1][key]) return false;
            }
            return true;
        }

        public static JToken GetJTokenById(JToken json, int id)
        {
            foreach (var i in json)
            {
                if ((int)i["id"] == id) return i;
            }
            return null;
        }
    }
}