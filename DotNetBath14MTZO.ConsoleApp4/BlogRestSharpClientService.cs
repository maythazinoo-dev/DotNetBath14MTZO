using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetBath14MTZO.ConsoleApp4
{
    internal class BlogRestSharpClientService
    {
        private readonly string endpoint = "https://localhost:7263/api/blog";
        private readonly RestClient _client;
        public BlogRestSharpClientService()
        {
            _client = new RestClient();
        }
        public async Task<List<BlogListResponseModel>> GetBlogs()
        {
           
            
            RestRequest request = new RestRequest(endpoint,Method.Get);
            //var response = await _client.GetAsync(request);
            var response = await _client.ExecuteAsync(request);

            string json = response.Content!;
             return JsonConvert.DeserializeObject<List<BlogListResponseModel>>(json)!;

            
        }

        public async Task<BlogResponseModel> GetBlog(string id)
        {
            RestRequest restRequest = new RestRequest($"{endpoint}/{id}", Method.Get);
            //var response = await _client.GetAsync(restRequest);
            var response = await _client.ExecuteAsync(restRequest);

            string json = response.Content!;
                Console.WriteLine(json);
                return JsonConvert.DeserializeObject<BlogResponseModel>(json)!;
           
        }

        public async Task<BlogResponseModel> CreateBlog(BlogModel requestModel)
        {
           RestRequest restRequest = new RestRequest(endpoint,Method.Post);
            restRequest.AddJsonBody(requestModel);
            //var response = await _client.PostAsync(restRequest);
            var response = await _client.ExecuteAsync(restRequest);
            
                string content = response.Content!;
                Console.WriteLine(content);
                return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
        }

        public async Task<BlogResponseModel> UpdateBlog(BlogModel requestModel)
        {
            RestRequest restRequest = new RestRequest($"{endpoint}/{requestModel.BlogId}", Method.Patch);
            restRequest.AddJsonBody(requestModel);
            //var response = await _client.PostAsync(restRequest);
            var response = await _client.ExecuteAsync(restRequest);
          
            string content =response.Content!;
            Console.WriteLine(content);
            return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;

        }

        public async Task<BlogResponseModel> DeleteBlog(string id)
        {
           
            RestRequest restRequest = new RestRequest($"{endpoint}/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(restRequest);
            //var response = await _client.DeleteAsync(restRequest);

            var json = response.Content!;
                Console.WriteLine(json);
                return JsonConvert.DeserializeObject<BlogResponseModel>(json)!;
            
        }
    }
}
