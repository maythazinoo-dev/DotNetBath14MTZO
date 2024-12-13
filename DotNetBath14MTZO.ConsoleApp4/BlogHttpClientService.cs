using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetBath14MTZO.ConsoleApp4
{
    internal class BlogHttpClientService
    {
        private readonly string endpoint = "https://localhost:7263/api/blog";
        private readonly HttpClient _client;
        public BlogHttpClientService()
        {
            _client = new HttpClient();
        }
        public async Task<List<BlogListResponseModel>> GetBlogs()
        {
           
            //HttpClient client = new HttpClient();
            HttpResponseMessage response = await _client.GetAsync(endpoint);
          
             string json = await response.Content.ReadAsStringAsync();
             Console.WriteLine(json);
             return JsonConvert.DeserializeObject<List<BlogListResponseModel>>(json)!;

            
        }

        public async Task<BlogResponseModel> GetBlog(string id)
        {
            //HttpClient client = new HttpClient();
            HttpResponseMessage response = await _client.GetAsync($"{endpoint}/{id}");
            
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
                return JsonConvert.DeserializeObject<BlogResponseModel>(json)!;
           
        }

        public async Task<BlogResponseModel> CreateBlog(BlogModel requestModel)
        {
            string jsonStr = JsonConvert.SerializeObject(requestModel);
            //var content = new StringContent(jsonStr,Encoding.UTF8, "application/json");
            var stringContent = new StringContent(jsonStr, Encoding.UTF8, Application.Json);
            HttpResponseMessage response = await _client.PostAsync(endpoint,stringContent);
            
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
        }

        public async Task<BlogResponseModel> UpdateBlog(BlogModel requestModel)
        {
            string jsonStr = JsonConvert.SerializeObject(requestModel);
            var stringContent = new StringContent(jsonStr,Encoding.UTF8, Application.Json);
            HttpResponseMessage response = await _client.PatchAsync($"{endpoint}/{requestModel.BlogId}",stringContent);
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;

        }

        public async Task<BlogResponseModel> DeleteBlog(string id)
        {
            //HttpClient client = new HttpClient();
            HttpResponseMessage response = await _client.GetAsync($"{endpoint}/{id}");
            
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
                return JsonConvert.DeserializeObject<BlogResponseModel>(json)!;
            
        }
    }
}
