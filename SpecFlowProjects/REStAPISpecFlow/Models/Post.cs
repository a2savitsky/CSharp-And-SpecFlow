using Newtonsoft.Json;

namespace REStAPISpecFlow.Models
{
    public class Post
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        public bool Equals(Post post)
        {
            return this.UserId == post.UserId && this.Id == post.Id && this.Body != "" && post.Body != "" && this.Title != "" && post.Title != "";
        }
    }
}