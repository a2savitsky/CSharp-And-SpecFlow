using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace extension.JsonUtils
{
    public static class DataFromJsonFile
    {
        private const string PathToConfigFile = "config.json";
        
        public static string GetDataByKey(string key, string pathToFile = PathToConfigFile)
        {
            dynamic array;
            using (StreamReader json = new StreamReader(GetPath(pathToFile)))
            {
                array = JsonConvert.DeserializeObject(json.ReadToEnd());
            }
            return array[key];
        }
        
        public static string GetPath(string filePath)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(baseDirectory, filePath);
        }

        public static JToken GetJTokenFromFile(string pathToFile)
        {
            JToken jtoken;
            using (StreamReader json = new StreamReader(GetPath(pathToFile)))
            {
                jtoken = JToken.Parse(json.ReadToEnd());
            }
            return jtoken;
        }
    }
}