using RestServicesTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestServicesTest.Helpers
{
    class RestService : IRestService
    {
        HttpClient Client;
        List<Post> PostList;
        string Url = "http://jsonplaceholder.typicode.com/posts";

        public RestService()
        {
            Client = new HttpClient();
            Client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Post>> GetPostList()
        {
            var uri = new Uri(string.Format(Url, string.Empty));
            var response = await Client.GetAsync(uri);0.
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                PostList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Post>>(content);
            }
            return PostList;
        }
    }
}
