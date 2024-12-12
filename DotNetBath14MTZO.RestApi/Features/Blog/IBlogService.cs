﻿using Microsoft.AspNetCore.Mvc;

namespace DotNetBath14MTZO.RestApi.Features.Blog
{
    public interface IBlogService
    {
        BlogResponseModel CreateBlog([FromBody] BlogModel requestModel);
        BlogResponseModel DeleteBlog(string id);
        BlogModel GetBlog(string id);
        List<BlogModel> GetBlogs();
        BlogResponseModel UpdateBlog(BlogModel requestModel);
        BlogResponseModel UpsertBlog(BlogModel requestModel);
    }
}