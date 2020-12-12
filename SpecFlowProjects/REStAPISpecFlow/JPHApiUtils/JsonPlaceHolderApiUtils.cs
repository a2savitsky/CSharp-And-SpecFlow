using RestSharp;
using extension.ApiUtils;
using extension.JsonUtils;

namespace REStAPISpecFlow.JPHApiUtils
{
    public class JsonPlaceHolderApiUtils
    {
        private static RestClient RestClient => new RestClient(DataFromJsonFile.GetDataByKey("url"));

        public static IRestResponse GetPostById(int id)
        {
            return ApiUtils.Get($"/posts/{id}", RestClient);
        }

        public static IRestResponse GetAllPosts()
        {
            return ApiUtils.Get($"/posts", RestClient);
        }

        public static IRestResponse GetUserById(int id)
        {
            return ApiUtils.Get($"/users/{id}", RestClient);
        }

        public static IRestResponse GetAllUsers()
        {
            return ApiUtils.Get($"/users", RestClient);
        }

        public static IRestResponse AddPost(string jsonBody)
        {
            return ApiUtils.Post("/posts", jsonBody, RestClient);
        }
    }
}