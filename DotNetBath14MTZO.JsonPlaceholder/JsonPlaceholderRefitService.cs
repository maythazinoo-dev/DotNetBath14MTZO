using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZO.JsonPlaceholder
{
    public class JsonPlaceholderRefitService
    {
        private readonly IJsonPlaceHolderApi _Placeholder;
      
        public JsonPlaceholderRefitService() 
        {
            _Placeholder = RestService.For<IJsonPlaceHolderApi>("https://jsonplaceholder.typicode.com")!;
           
        }

        public async Task<List<JsonModel>> GetPosts()
        {

            var model = await _Placeholder.GetPosts();
            return model;

        }


        public async Task<JsonModel> GetPost(int id)
        {
            var model = await _Placeholder.GetPost(id);
            return model;
        }

        public async Task<JsonModel> CreatePost(JsonModel requestModel)
        {
            var model = await _Placeholder.CreatePost(requestModel);
            return model;
        }

        public async Task<JsonModel> UpdatePost(int id, JsonModel requestModel)
        {
            var modle = await _Placeholder.UpdatePost(id, requestModel);
            return modle;
        }

        public async Task<JsonModel> DeletePost(int id)
        {
            var model = await _Placeholder.DeletePost(id);
            return model;
        }
    }



    public interface IJsonPlaceHolderApi
    {
        [Get("/Post")]
        Task<List<JsonModel>> GetPosts();

        [Get("/posts/{id}")]
        public Task<JsonModel> GetPost(int id);

        [Post("/posts")]
        public Task<JsonModel> CreatePost(JsonModel requestModel);

        [Patch("/posts/{id}")]
        public Task<JsonModel> UpdatePost(int id, JsonModel requestModel);

        [Delete("/posts/{id}")]
        public Task<JsonModel> DeletePost(int id);
    }
}
