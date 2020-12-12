using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using REStAPISpecFlow.JPHApiUtils;
using RestSharp;
using extension.JsonUtils;
using extension.RandomUtils;
using REStAPISpecFlow.Models;
using TechTalk.SpecFlow.Assist;

namespace REStAPISpecFlow.Steps
{
    [Binding]
    public class RESTAPISteps
    {
        private ScenarioContext context;

        public RESTAPISteps(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"I get test model of Post and save it to context as '(.*)'")]
        public void GivenIGetModelOfPostAndSaveItToContextAs(string post)
        {
            var newPost = new Post
            {
                UserId = 1,
                Id = 101,
                Body = DataGenerator.GetRandomString(),
                Title = DataGenerator.GetRandomString()
            };
            context[post] = newPost;
        }

        [Given(@"I get json object of User from file '(.*)' and save it to context as '(.*)'")]
        public void GivenIGetJObjectOfUserFromFileAndSaveItToContextAs(string file, string user)
        {
            context[user] = DataFromJsonFile.GetJTokenFromFile("TestData/" + file);
        }

        [When(@"I do GET request to get all posts and save response to context with name '(.*)'")]
        public void WhenIDoGETRequestToGetAllPosts(string response)
        {
            context[response] = JsonPlaceHolderApiUtils.GetAllPosts();
        }
        
        [Then(@"I get status code '(.*)' from response '(.*)'")]
        public void ThenIGetStatusCodeAndListPostsInJSONFormat(int expStatusCode, string response)
        {
            Assert.AreEqual(expStatusCode, (int)context.Get<IRestResponse>(response).StatusCode, $"Status code in {response} is not {expStatusCode}");
        }

        [Then(@"List posts in JSON format from response '(.*)'")]
        public void ThenListPostsInJSONFormat(string response)
        {
            Assert.True(JsonUtils.IsStringInJsonFormat(context.Get<IRestResponse>(response).Content), $"Response {response} has gotten not in JSON format");
        }

        [Then(@"Sorted by '(.*)' from response '(.*)'")]
        public void ThenSortedBy(string key, string response)
        {
            Assert.True(JsonUtils.IsSortedByKey(JToken.Parse(context.Get<IRestResponse>(response).Content), key), $"Response {response} is not sorted by {key}");
        }

        [When(@"I do GET request to get post with id '(.*)' and save response to context with name '(.*)'")]
        public void WhenIDoGETRequestToGetPostWithIdAndSaveResponseToContextWithName(int id, string response)
        {
            context[response] = JsonPlaceHolderApiUtils.GetPostById(id);
        }

        [Then(@"Values from '(.*)' are equals:")]
        public void ThenValuesFromAreEquals(string response, Table table)
        {
            var actualPost = JToken.Parse(context.Get<IRestResponse>(response).Content).ToObject<Post>();
            var expectedPost = table.CreateInstance<Post>();
            Assert.IsTrue(actualPost.Equals(expectedPost));
        }

        [Then(@"Body of response '(.*)' is '(.*)'")]
        public void ThenBodyOfResponseShouldBe(string response, string expBody)
        {
            Assert.AreEqual(expBody, JToken.Parse(context.Get<IRestResponse>(response).Content).ToString(),
                $"Body of {response} is not {expBody}");
        }

        [When(@"I do POST request to make new post with model '(.*)' and save response to context with name '(.*)'")]
        public void WhenIDoPOSTRequestToMakeNewPostAndSaveResponseToContextWithName(string post, string response)
        {
            context[response] = JsonPlaceHolderApiUtils.AddPost(JToken.FromObject(context.Get<Post>(post)).ToString());
        }

        [Then(@"Values from '(.*)' are equal to values of model '(.*)'")]
        public void ThenValuesFromShouldBeEqualValuesOfModel(string response, string model)
        {
            var postFromResponse = JToken.Parse(context.Get<IRestResponse>(response).Content);
            Assert.True(JToken.DeepEquals(postFromResponse, JToken.FromObject(context.Get<Post>(model))), $"Values from {response} are not equal of model {model}");
        }

        [When(@"I do GET request to get all users and save response to context with name '(.*)'")]
        public void WhenIDoGETRequestToGetAllUsersAndSaveResponseToContextWithName(string response)
        {
            context[response] = JsonPlaceHolderApiUtils.GetAllUsers();
        }

        [Then(@"User with id '(.*)' from response '(.*)' has data as the json object '(.*)' has")]
        public void ThenUserWithIdShouldHaveDataAsTheModelHas(int id, string response, string user)
        {
            var userFromResponse = JsonUtils.GetJTokenById(JToken.Parse(context.Get<IRestResponse>(response).Content), id);
            var expUserFromFile = context.Get<JToken>(user);
            Assert.True(JToken.DeepEquals(userFromResponse, expUserFromFile), $"Data of user with {id} and data of model does not match");
        }

        [When(@"I do GET request to get user with id '(.*)' and save response to context with name '(.*)'")]
        public void WhenIDoGETRequestToGetUserWithIdAndSaveResponseToContextWithName(int id, string response)
        {
            context[response] = JsonPlaceHolderApiUtils.GetUserById(id);
        }

        [Then(@"User from response '(.*)' is equal to user with id '(.*)' from response '(.*)'")]
        public void ThenUserFromResponseShouldBeEqualToUserWithIdFromResponse(string user5Resp, int id, string allUsersResp)
        {
            var userAllUserResponse = JsonUtils.GetJTokenById(JToken.Parse(context.Get<IRestResponse>(allUsersResp).Content), id);
            var user5Response = JToken.Parse(context.Get<IRestResponse>(user5Resp).Content);
            Assert.True(JToken.DeepEquals(userAllUserResponse, user5Response), $"Data of user from {user5Resp} and data of user from {allUsersResp} does not match");
        }
    }
}