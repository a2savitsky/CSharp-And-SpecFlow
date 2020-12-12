
using extension.JsonUtils;

namespace extension.StringUtils
{
    public class Url
    {
        private static string url => DataFromJsonFile.GetDataByKey("url");

        private static string protocol => DataFromJsonFile.GetDataByKey("protocol");

        public static string GetUrlForBasicAuthorization(string user, string password)
        {
            return $"{protocol}://{user}:{password}@{url}";
        }
    }
}
