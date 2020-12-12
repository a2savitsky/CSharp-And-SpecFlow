using RestSharp;

namespace extension.ApiUtils
{
    public static class ApiUtils
    {
        public static IRestResponse Get(string resource, RestClient restClient)
        {
            var request = new RestRequest(resource, Method.GET);
            IRestResponse restResponse = restClient.Execute(request);
            return restResponse;
        }

        public static IRestResponse Post(string resource, string jsonBody, RestClient restClient)
        {
            var request = new RestRequest(resource, Method.POST);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
            var restResponse = restClient.Execute(request);
            return restResponse;
        }
    }
}