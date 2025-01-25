using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetBath14MTZO.ConsoleApp4
{
    internal class BlogRefitService
    {
        private readonly string domain = "https://localhost:7263";
        private readonly IBlogApi _api;
        public BlogRefitService()
        {
           _api= RestService.For<IBlogApi>(domain);
        }
        public async Task<BlogListResponseModel> GetBlogs()
        {

            var model =await _api.GetBlogs();
            return model;

        }

        public async Task<BlogResponseModel> GetBlog(string id)
        {
            
            var model = await _api.GetBlog(id);
            return model;

        }

        public async Task<BlogResponseModel> CreateBlog(BlogModel requestModel)
        {
            var model =await _api.CreateBlog(requestModel);
            return model;
        }

        public async Task<BlogResponseModel> PatchBlog(string id,BlogModel requestModel)
        {
            var model =await _api.PatchBlog(id, requestModel);
            return model;

        }
        public async Task<BlogResponseModel> UpdateBlog(String id,BlogModel requestModel)
        {
            var model =await _api.PutBlog(id, requestModel);
            return model;

        }

        public async Task<BlogResponseModel> DeleteBlog(string id)
        {
          var model = await _api.DeleteBlog(id);
            return model;
        }
    }


    public interface IBlogApi
    {
        //interface =I
        //Feature=Blog
        //API=Api
        [Get("/api/blog")]
        Task<BlogListResponseModel> GetBlogs();

        [Get("/api/blog/{id}")]
        Task<BlogResponseModel> GetBlog(String Id);

        [Post("/api/blog")]
        Task<BlogResponseModel>CreateBlog(BlogModel requestModel);

        [Patch("/api/blog/{id}")]
        Task<BlogResponseModel> PatchBlog(string id,BlogModel requestModel);

        [Put("/api/blog/{id}")]
        Task<BlogResponseModel> PutBlog(string id,BlogModel requestModel);

        [Delete("/api/blog/{id}")]
        Task<BlogResponseModel> DeleteBlog(string id);
    }
}
